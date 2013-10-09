using System;
using System.Collections;           // for Hashtable
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;                    // for File
using System.Data.SQLite;           // System.Data.SQLite 1.0.88.0 (3.7.17)

namespace SIMPLISM.Common.Config
{
    public sealed class SQLiteConfigHelper
    {
        /// <summary>
        /// SQLiteConfigHelper Class Variables.
        /// </summary>
        private static SQLiteConfigHelper instance  = null;         // Singleton object.
        private static readonly object padlock      = new object(); // lock object.
        private Hashtable defaultConfigTable        = null;         // SQLiteConfigHelper configuration object.
        private SQLiteConnection dbConnection       = null;         // SQLite3 connection object.





        /// <summary>
        /// SQLiteConfigHelper Constructor.
        /// </summary>
        SQLiteConfigHelper ()
        {
            try
            {
                //----------
                // SQLiteConfigHelper의 기본 설정파일을 읽어서 해쉬테이블에 저장한다.
                this.loadDefaultConfigFileIntoHash();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }





        /// <summary>
        /// SQLiteConfigHelper Singleton Instance Property.
        /// </summary>
        public static SQLiteConfigHelper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SQLiteConfigHelper();
                    }
                    return instance;
                }
            }
        }





        /// <summary>
        /// SQLiteConfigHelper의 기본 설정파일을 읽어와서 해쉬테이블에 저장한다.
        /// </summary>
        private void loadDefaultConfigFileIntoHash()
        {
            try
            {
                //----------
                // SQLiteConfigHelper의 기본설정을 보관할 해쉬테이블을 초기화한다.
                this.defaultConfigTable = new Hashtable();

                //----------
                // 문자열(string) 배열을 생성하고, 각 라인별로 저장한다.
                string[] rawString = { "" };
                rawString = File.ReadAllLines("SQLiteConfigHelper.config");

                //----------
                // 각 행에서 '=' 문자를 기준으로 키(key)와 값(value) 쌍을 분리하고 해쉬테이블에 설정정보를 저장한다.
                foreach (string lineStr in rawString)
                {
                    //----------
                    // 공백행은 생략하고, 행을 주석처리한 '#' 문자로 시작하는 줄은 무시한다.
                    if (lineStr.Length > 1 && !lineStr.Trim().Substring(0, 1).Equals("#"))
                    {
                        int separatePoint = lineStr.IndexOf("=");
                        string key = lineStr.Substring(0, separatePoint).Trim();
                        string value = lineStr.Substring(separatePoint + 1).Trim();
                        this.defaultConfigTable.Add(key, value);
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }





        /// <summary>
        /// 키에 해당하는 기본 설정값을 반환한다.
        /// </summary>
        /// <param name="key">키</param>
        /// <returns>기본 설정값</returns>
        public string getDefaultConfigValue(string key)
        {
            string value = "";

            try
            {
                //----------
                // 기본 설정값을 보관하는 해쉬테이블에 키가 있는지 확인한다.
                if (!this.defaultConfigTable.ContainsKey(key))
                {
                    throw new Exception("'" + key + "' default configuration does not exists!");
                }

                //----------
                // 키(Key)에 해당하는 기본 설정 값을 반환한다.
                value = this.defaultConfigTable[key].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return value;
        }





        /// <summary>
        /// 기본 설정값이 보관된 해쉬테이블의 키목록을 반환한다.
        /// </summary>
        /// <returns>키 목록</returns>
        public List<string> getDefaultConfigKeyList()
        {
            List<string> value = new List<string>();

            try
            {
                //----------
                // 해쉬테이블의 키만큼 looping하면서 키 목록을 List형으로 생성한다.
                foreach (DictionaryEntry entry in this.defaultConfigTable)
                {
                    value.Add(entry.Key.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return value;
        }





        /// <summary>
        /// 애플리케이션 설정을 보관하는 DB파일의 경로를 반환한다.
        /// </summary>
        /// <returns>애플리케이션 설정DB 경로</returns>
        public string getAppConfigDBFilePath()
        {
            string value = "";

            try
            {
                //----------
                // 절대경로인 경우에는 바로 반환한다.
                string flag = this.defaultConfigTable["APPDB_ISRELATIVEPATH"].ToString().ToLower();
                if (flag.Equals("no"))
                {
                    value = this.defaultConfigTable["APPDB_FILEPATH"].ToString();
                }
                else if (flag.Equals("yes"))
                {
                    //----------
                    // 상대경로인 경우에는 애플리케이션의 실행경로와 결합하여 처리한다.
                    string startupPath = AppDomain.CurrentDomain.BaseDirectory;
                    value = Path.Combine(startupPath, this.defaultConfigTable["APPDB_FILEPATH"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return value;
        }





        /// <summary>
        /// 기본 설정값을 변경한다.
        /// </summary>
        /// <param name="key">변경할 기본 설정의 키</param>
        /// <param name="value">변경할 기본 설정값</param>
        public bool setDefaultConfigValue(string key, string value)
        {
            try
            {
                //----------
                // 기본 설정값을 보관하는 해쉬테이블에 키가 있는지 확인한다.
                if (!this.defaultConfigTable.ContainsKey(key))
                {
                    throw new Exception("'" + key + "' default configuration does not exists!");
                }

                //----------
                // 기본 설정값을 수정한다.
                this.defaultConfigTable[key] = value;

                //----------
                // 변경된 설정적용을 위해서 기본설정파일을 다시 작성한다.
                this.rewriteDefaultConfigFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 해쉬테이블에 저장되어있는 기본설정값을 설정파일로 작성한다.
        /// </summary>
        private void rewriteDefaultConfigFile()
        {
            try
            {
                //----------
                // 기본 설정파일의 백업여부를 확인한다.
                bool isBackup = this.defaultConfigTable["DEFAULTCONFIG_ISBACKUP"].ToString().ToLower().Equals("yes") ? true : false;

                //----------
                // 백업여부가 "yes"인 경우에는 기존의 기본설정파일(SQLiteConfigHelper.config)을 백업한다.
                if (isBackup)
                {
                    //----------
                    // 백업을 위해서 현재일시를 문자열로 만든다.
                    DateTime date = DateTime.Now;
                    string backupFileName  =  "SQLiteConfigHelper";
                    backupFileName         += "_" + date.ToString("yyyyMMddHHmmss");
                    File.Move("SQLiteConfigHelper.config", backupFileName);
                }

                //----------
                // 해쉬테이블을 읽어서 해쉬테이블의 내용을 기준으로 기본설정파일을 생성한다.
                string configText = "# SQLiteConfigHelper Default Configuration File.\r\n";
                foreach (DictionaryEntry entry in this.defaultConfigTable)
                {
                    configText += String.Format("{0} = {1}\r\n", entry.Key, entry.Value);
                }
                File.WriteAllText("SQLiteConfigHelper.config", configText);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }





        /// <summary>
        /// 애플리케이션 설정DB 파일을 생성하고 초기화한다.
        /// </summary>
        public bool createAppDBFile()
        {
            try
            {
                //----------
                // 애플리케이션 설정DB 생성을 위해서 경로를 가져온다.
                string appDBFilePath = this.getAppConfigDBFilePath();

                //----------
                // DB파일이 이미 존재하는지 체크한다.
                if (File.Exists(appDBFilePath))
                {
                    throw new Exception("Application configuration DB file is already exists!");
                }

                //----------
                // DB파일을 생성한다.
                SQLiteConnection.CreateFile(appDBFilePath);

                //----------
                // 애플리케이션 설정 데이터베이스를 초기화한다.
                this.initializeAppDatabase("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 애플리케이션 설정DB 파일을 생성하고 초기화한다.(암호적용)
        /// </summary>
        public bool createAppDBFile(string password)
        {
            try
            {
                //----------
                // 애플리케이션 설정DB 생성을 위해서 경로를 가져온다.
                string appDBFilePath = this.getAppConfigDBFilePath();

                //----------
                // DB파일이 이미 존재하는지 체크한다.
                if (File.Exists(appDBFilePath))
                {
                    throw new Exception("Application configuration DB file is already exists!");
                }

                //----------
                // DB파일을 생성한다.
                SQLiteConnection.CreateFile(appDBFilePath);

                //----------
                // 애플리케이션 설정 데이터베이스를 초기화한다.
                this.initializeAppDatabase(password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 설정 데이터베이스를 초기화한다.(암호적용)
        /// </summary>
        /// <param name="password">암호</param>
        private void initializeAppDatabase(string password)
        {
            try
            {
                //----------
                // 지역변수 초기화
                string dbConnectionString = "";

                //----------
                // 애플리케이션 설정DB파일의 암호화여부를 확인한다.
                bool isEncrypt = this.defaultConfigTable["APPDB_ISENCRYPTED"].ToString().ToLower().Equals("yes") ? true : false;

                //----------
                // 암호화할 경우에 비밀번호의 유무를 확인한다.
                if (isEncrypt)
                {
                    //----------
                    // 앞 뒤의 공백은 제거한다.
                    if (password.Length < 1)
                    {
                        throw new Exception("Application configuration DB password is empty!");
                    }
                    else if (password.Length < 6)
                    {
                        //----------
                        // 비밀번호가 6글자 이하인 경우에는 Exception 처리한다.
                        throw new Exception("Application configuration DB password is too short! (6 characters more need)");
                    }

                    //----------
                    // 애플리케이션 설정DB와의 연결을 위한 연결문자열(Connection string)을 만든다.(암호화된)
                    dbConnectionString = String.Format("Data Source={0}; Version=3; Password={1};", this.getAppConfigDBFilePath(), password);
                }
                else
                {
                    //----------
                    // 애플리케이션 설정DB와의 연결을 위한 연결문자열(Connection string)을 만든다.
                    dbConnectionString = String.Format("Data Source={0}; Version=3;", this.getAppConfigDBFilePath());
                }

                //----------
                // 애플리케이션 설정DB와 연결한다.
                this.dbConnection = new SQLiteConnection(dbConnectionString);

                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);

                //----------
                // 트랜잭션 시작
                cmd.CommandText = "BEGIN TRANSACTION";
                cmd.ExecuteNonQuery();

                //----------
                // 설정을 보관할 테이블 생성(config 테이블)
                cmd.CommandText  = "CREATE TABLE config ("                    + "\n";
                cmd.CommandText += "    key                 TEXT PRIMARY KEY" + "\n";
                cmd.CommandText += "  , value               TEXT"             + "\n";
                cmd.CommandText += "  , remark              TEXT"             + "\n";
                cmd.CommandText += "  , create_datetime     TEXT"             + "\n";
                cmd.CommandText += "  , lastmodify_datetime TEXT"             + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // 설정의 변경이력을 보관할 테이블 생성(config_log 테이블)
                cmd.CommandText  = "CREATE TABLE config_log ("   + "\n";
                cmd.CommandText += "    key              TEXT"   + "\n";
                cmd.CommandText += "  , seq              NUMBER" + "\n";
                cmd.CommandText += "  , value            TEXT"   + "\n";
                cmd.CommandText += "  , remark           TEXT"   + "\n";
                cmd.CommandText += "  , flag             TEXT"   + "\n";
                cmd.CommandText += "  , logging_datetime TEXT"   + "\n";
                cmd.CommandText += "  , PRIMARY KEY (key, seq)"  + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // 더미(dummy)용 dual 테이블생성
                cmd.CommandText  = "CREATE TABLE dual (" + "\n";
                cmd.CommandText += "    dummy    TEXT"   + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // dual 테이블에 1 row insert
                cmd.CommandText  = "INSERT INTO dual (" + "\n";
                cmd.CommandText += "    dummy"          + "\n";
                cmd.CommandText += ") VALUES ("         + "\n";
                cmd.CommandText += "    'X'"            + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // 트랜잭션 종료
                cmd.CommandText = "END TRANSACTION";
                cmd.ExecuteNonQuery();

                //----------
                // 객체해제
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //----------
                // Exception이 발생되었으면, 해당 DB파일은 무의미하므로 파일을 삭제한다.
                if (File.Exists(this.getAppConfigDBFilePath()))
                {
                    File.Delete(this.getAppConfigDBFilePath());
                }

                throw new Exception(ex.Message);
            }
            finally
            {
                if (this.dbConnection != null)
                {
                    //----------
                    // 데이터베이스 연결을 해제한다.
                    this.dbConnection.Close();
                    this.dbConnection = null;
                }
            }
        }





        /// <summary>
        /// 설정 데이터베이스를 연다.
        /// </summary>
        /// <returns></returns>
        public bool openAppDBFile()
        {
            try
            {
                //----------
                // 기존 Connection이 있는지 체크한다.
                if (this.dbConnection != null)
                {
                    throw new Exception("Application DB file is already connected!");
                }

                //----------
                // 애플리케이션 설정DB의 경로를 가져온다.
                string appDBFilePath = this.getAppConfigDBFilePath();

                //----------
                // 애플리케이션 설정DB의 존재유무를 확인한다.
                if (!File.Exists(appDBFilePath))
                {
                    string message = "Application configuration DB file does not exists!\r\n";
                    message += "Config DB file path = " + appDBFilePath;
                    throw new Exception(message);
                }

                //----------
                // 설정 데이터베이스에 연결한다.
                string dbConnectionString = String.Format("Data Source={0}; Version=3;", appDBFilePath);
                this.dbConnection = new SQLiteConnection(dbConnectionString);

                //----------
                // DB 연결상태를 테스트한다.
                this.testAppDBConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 설정 데이터베이스를 연다.(암호적용)
        /// </summary>
        /// <returns></returns>
        public bool openAppDBFile(string password)
        {
            try
            {
                //----------
                // 기존 Connection이 있는지 체크한다.
                if (this.dbConnection != null)
                {
                    throw new Exception("Application DB file is already connected!");
                }

                //----------
                // 애플리케이션 설정DB의 경로를 가져온다.
                string appDBFilePath = this.getAppConfigDBFilePath();

                //----------
                // 애플리케이션 설정DB의 존재유무를 확인한다.
                if (!File.Exists(appDBFilePath))
                {
                    string message = "Application configuration DB file does not exists!\r\n";
                    message += "Config DB file path = " + appDBFilePath;
                    throw new Exception(message);
                }

                //----------
                // 설정 데이터베이스에 연결한다.
                string dbConnectionString = String.Format("Data Source={0}; Version=3; Password={1};", appDBFilePath, password);
                this.dbConnection = new SQLiteConnection(dbConnectionString);

                //----------
                // DB 연결상태를 테스트한다.
                this.testAppDBConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 설정 데이터베이스의 연결상태를 확인한다.
        /// </summary>
        public bool testAppDBConnection()
        {
            try
            {
                //----------
                // 현재 연결되어있다면 Exception 처리
                if (this.dbConnection == null)
                {
                    throw new Exception("Application DB file is not connected!");
                }

                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);

                //----------
                // 더미용 테이블인 dual 테이블을 조회해서 점검한다.
                cmd.CommandText = "SELECT * FROM dual;";
                SQLiteDataReader reader = cmd.ExecuteReader();

                //----------
                // 관련 객체를 해제한다.
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                this.dbConnection = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                if (this.dbConnection != null)
                {
                    //----------
                    // 데이터베이스와 연결을 해제한다.
                    this.dbConnection.Close();
                }
            }

            return true;
        }





        /// <summary>
        /// 설정 데이터베이스를 연결해제한다.
        /// </summary>
        /// <returns></returns>
        public bool closeAppDBFile()
        {
            try
            {
                //----------
                // 현재 연결되어있다면 Exception 처리
                if (this.dbConnection == null)
                {
                    throw new Exception("Application DB file is not connected!");
                }

                //----------
                // 데이터베이스와 연결을 해제한다.
                this.dbConnection.Close();
                this.dbConnection = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 새로운 애플리케이션 설정을 추가한다.
        /// </summary>
        /// <param name="key">설정 키</param>
        /// <param name="value">설정 값</param>
        /// <param name="remark">설정 비고</param>
        /// <returns></returns>
        public bool addNewAppConfig(string key, string value, string remark)
        {
            SQLiteCommand cmd = null;

            try
            {
                //----------
                // 입력 값을 검증한다.
                if (key.Length < 1 || value.Length < 1)
                {
                    throw new Exception("key & value는 1글자 이상이어야 합니다!");
                }

                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();
                cmd = new SQLiteCommand(this.dbConnection);

                //----------
                // 트랜잭션을 시작한다.
                cmd.CommandText = "BEGIN TRANSACTION";
                cmd.ExecuteNonQuery();

                //----------
                // 새로운 설정을 만든다.
                cmd.CommandText  = "INSERT INTO config ("             + "\n";
                cmd.CommandText += "    key"                          + "\n";
                cmd.CommandText += "  , value"                        + "\n";
                cmd.CommandText += "  , remark"                       + "\n";
                cmd.CommandText += "  , create_datetime"              + "\n";
                cmd.CommandText += "  , lastmodify_datetime"          + "\n";
                cmd.CommandText += ") VALUES ("                       + "\n";
                cmd.CommandText += "    '" + key + "'"                + "\n";
                cmd.CommandText += "  , '" + value + "'"              + "\n";
                cmd.CommandText += "  , '" + remark + "'"             + "\n";
                cmd.CommandText += "  , datetime('now', 'localtime')" + "\n";
                cmd.CommandText += "  , datetime('now', 'localtime')" + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // 설정의 로그를 생성한다.
                cmd.CommandText  = "INSERT INTO config_log ("              + "\n";
                cmd.CommandText += "    key"                               + "\n";
                cmd.CommandText += "  , seq"                               + "\n";
                cmd.CommandText += "  , value"                             + "\n";
                cmd.CommandText += "  , remark"                            + "\n";
                cmd.CommandText += "  , flag"                              + "\n";
                cmd.CommandText += "  , logging_datetime"                  + "\n";
                cmd.CommandText += ") VALUES ("                            + "\n";
                cmd.CommandText += "    '" + key + "'"                     + "\n";
                cmd.CommandText += "  , (SELECT ifnull (MAX (seq) + 1, 0)" + "\n";
                cmd.CommandText += "       FROM config_log"                + "\n";
                cmd.CommandText += "      WHERE key = '" + key + "')"      + "\n";
                cmd.CommandText += "  , '" + value + "'"                   + "\n";
                cmd.CommandText += "  , '" + remark + "'"                  + "\n";
                cmd.CommandText += "  , 'N'"                               + "\n";
                cmd.CommandText += "  , datetime('now', 'localtime')"      + "\n";
                cmd.CommandText += ");";
                cmd.ExecuteNonQuery();

                //----------
                // 트랜잭션 종료한다.
                cmd.CommandText = "END TRANSACTION";
                cmd.ExecuteNonQuery();

                // 실행된 쿼리의 객체들을 해제한다.
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                if (cmd != null)
                {
                    //----------
                    // 트랜잭션 종료한다.
                    // 쿼리 오류로 Exception 발생 시 트랜잭션을 종료시켜야 lock이 걸리지 않는다.
                    cmd.CommandText = "END TRANSACTION";
                    cmd.ExecuteNonQuery();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                //----------
                // 데이터베이스 연결을 해제한다.
                this.dbConnection.Close();
            }

            return true;
        }





        /// <summary>
        /// 설정의 목록을 반환한다.
        /// </summary>
        /// <returns>설정 키 목록</returns>
        public List<string> getAppConfigList()
        {
            List<string> value = null;

            try
            {
                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);

                //----------
                // 설정리스트를 조회한다.
                cmd.CommandText  = "SELECT key"     + "\n";
                cmd.CommandText += "  FROM config"  + "\n";
                cmd.CommandText += " ORDER BY key";
                
                //----------
                // 설정 값이 비어있는지 확인
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("Application configuration is empty!");
                }

                //----------
                // 반환을 위해서 List형으로 key의 목록을 만든다.
                value = new List<string>();
                while (reader.Read())
                {
                    value.Add(reader["key"].ToString());
                }

                // 실행된 쿼리의 객체들을 해제한다.
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //----------
                // 데이터베이스 연결을 해제한다.
                this.dbConnection.Close();
            }

            return value;
        }





        /// <summary>
        /// 설정 값을 반환한다.
        /// </summary>
        /// <param name="key">설정 키</param>
        /// <returns>설정 값</returns>
        public string getAppConfigValue(string key)
        {
            string value = "";

            try
            {
                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();

                //----------
                // 설정정보를 조회하기 위한 쿼리문자열을 생성한다.
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);
                cmd.CommandText  = "SELECT value"                 + "\n";
                cmd.CommandText += "  FROM config"                + "\n";
                cmd.CommandText += " WHERE key = '" + key + "'";

                //----------
                // 설정정보를 조회하기 위한 쿼리를 실행한다.
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("'" + key + "' configuration does not exists!");
                }

                //----------
                // 데이터를 읽기 위해서 조회된 데이터를 한 번 읽는다.
                reader.Read();

                //----------
                // 조회된 값을 반환할 변수에 저장한다.
                value = reader["value"].ToString();

                //----------
                // 실행된 쿼리의 객체들을 해제한다.
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //----------
                // 데이터베이스 연결을 해제한다.
                this.dbConnection.Close();
            }

            return value;
        }





        /// <summary>
        /// 설정 설명을 반환한다.
        /// </summary>
        /// <param name="key">설정 키</param>
        /// <returns>설정 설명</returns>
        public string getAppConfigRemark(string key)
        {
            string remark = "";

            try
            {
                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();

                //----------
                // 설정정보를 조회하기 위한 쿼리문자열을 생성한다.
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);
                cmd.CommandText  = "SELECT remark"                + "\n";
                cmd.CommandText += "  FROM config"                + "\n";
                cmd.CommandText += " WHERE key = '" + key + "'";

                //----------
                // 설정정보를 조회하기 위한 쿼리를 실행한다.
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("'" + key + "' configuration does not exists!");
                }

                //----------
                // 데이터를 읽기 위해서 조회된 데이터를 한 번 읽는다.
                reader.Read();

                //----------
                // 조회된 값을 반환할 변수에 저장한다.
                remark = reader["remark"].ToString();

                //----------
                // 실행된 쿼리의 객체들을 해제한다.
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //----------
                // 데이터베이스 연결을 해제한다.
                this.dbConnection.Close();
            }

            return remark;
        }





        /// <summary>
        /// 설정 값을 저장한다.
        /// </summary>
        /// <param name="key">설정 키</param>
        /// <param name="value">설정 값</param>
        /// <param name="remark">설정 설명</param>
        /// <returns>성공여부 (true:성공, Exception:실패)</returns>
        public bool setAppConfigValue(string key, string value, string remark)
        {
            SQLiteCommand cmd = null;

            try
            {
                //----------
                // 입력 값 검증
                if (key.Length < 1 || value.Length < 1)
                {
                    throw new Exception("key & value는 1글자 이상이어야 합니다!");
                }

                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();
                cmd = new SQLiteCommand(this.dbConnection);

                //----------
                // 트랜잭션을 시작한다.
                cmd.CommandText = "BEGIN TRANSACTION";
                cmd.ExecuteNonQuery();

                //----------
                // 설정의 로그를 생성한다.
                cmd.CommandText  = "INSERT INTO config_log"                   + "\n";
                cmd.CommandText += "SELECT key"                               + "\n";
                cmd.CommandText += "     , (SELECT ifnull (MAX (seq) + 1, 0)" + "\n";
                cmd.CommandText += "          FROM config_log"                + "\n";
                cmd.CommandText += "         WHERE key = '" + key + "')"      + "\n";
                cmd.CommandText += "     , value"                             + "\n";
                cmd.CommandText += "     , remark"                            + "\n";
                cmd.CommandText += "     , 'U'"                               + "\n";
                cmd.CommandText += "     , datetime('now', 'localtime')"      + "\n";
                cmd.CommandText += "  FROM config"                            + "\n";
                cmd.CommandText += " WHERE key = '" + key + "'";
                cmd.ExecuteNonQuery();

                //----------
                // 설정값을 수정한다.
                cmd.CommandText  = "UPDATE config"                                             + "\n";
                cmd.CommandText += "   SET value  = '" + value + "'"                           + "\n";
                cmd.CommandText += "     , remark = '" + remark + "'"                          + "\n";
                cmd.CommandText += "     , lastmodify_datetime = datetime('now', 'localtime')" + "\n";
                cmd.CommandText += " WHERE key = '" + key + "'";
                cmd.ExecuteNonQuery();

                //----------
                // 트랜잭션 종료한다.
                cmd.CommandText = "END TRANSACTION";
                cmd.ExecuteNonQuery();

                // 실행된 쿼리의 객체들을 해제한다.
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                if (cmd != null)
                {
                    //----------
                    // 트랜잭션 종료한다.
                    // 쿼리 오류로 Exception 발생 시 트랜잭션을 종료시켜야 lock이 걸리지 않는다.
                    cmd.CommandText = "END TRANSACTION";
                    cmd.ExecuteNonQuery();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return true;
        }





        /// <summary>
        /// 설정의 존재유무를 반환한다.
        /// </summary>
        /// <param name="key">설정 키</param>
        /// <returns>true : 설정있음, false : 설정없음</returns>
        public bool isExistAppConfig(string key)
        {
            bool value = true;

            try
            {
                //----------
                // 데이터베이스 연결객체를 이용해서 데이터베이스 파일을 연다.
                this.dbConnection.Open();

                //----------
                // 설정정보를 조회하기 위한 쿼리문자열을 생성한다.
                SQLiteCommand cmd = new SQLiteCommand(this.dbConnection);
                cmd.CommandText  = "SELECT key"                   + "\n";
                cmd.CommandText += "  FROM config"                + "\n";
                cmd.CommandText += " WHERE key = '" + key + "'";

                //----------
                // 설정정보를 조회하기 위한 쿼리를 실행한다.
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    value = false;
                }

                //----------
                // 실행된 쿼리의 객체들을 해제한다.
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //----------
                // 데이터베이스 연결을 해제한다.
                this.dbConnection.Close();
            }

            return value;
        }
    }
}
