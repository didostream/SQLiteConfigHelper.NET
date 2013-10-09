using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;           // for Process
using System.Windows.Forms;

namespace SIMPLISM.Common.Config
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateObject_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(SQLiteConfigHelper.Instance.GetType().ToString(), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnGetDBPath_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(SQLiteConfigHelper.Instance.getDefaultConfigValue("APPDB_FILEPATH"), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnGetNoneDefaultValue_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(SQLiteConfigHelper.Instance.getDefaultConfigValue("AAA"), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnGetDefaultKeyList_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsvDefaultKeyList.Items.Clear();

                List<string> list = SQLiteConfigHelper.Instance.getDefaultConfigKeyList();

                foreach (string entry in list)
                {
                    this.lsvDefaultKeyList.Items.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void lsvDefaultKeyList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string key = this.lsvDefaultKeyList.SelectedItems[0].Text;

                MessageBox.Show(SQLiteConfigHelper.Instance.getDefaultConfigValue(key), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnGetDBFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(SQLiteConfigHelper.Instance.getAppConfigDBFilePath(), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void lsvDefaultKeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvDefaultKeyList.SelectedItems.Count > 0)
                {
                    string key = this.lsvDefaultKeyList.SelectedItems[0].Text;
                    this.txbDefaultConfigValue.Text = SQLiteConfigHelper.Instance.getDefaultConfigValue(key);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnModifyDefaultConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvDefaultKeyList.SelectedItems.Count > 0)
                {
                    string key = this.lsvDefaultKeyList.SelectedItems[0].Text;
                    if (SQLiteConfigHelper.Instance.setDefaultConfigValue(key, this.txbDefaultConfigValue.Text))
                    {
                        MessageBox.Show("기본설정 저장완료!");
                    }
                    else
                    {
                        MessageBox.Show("저장실패!!");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnCreateAppDB_Click(object sender, EventArgs e)
        {
            try
            {
                // 암호화를 시키지 않기 위해서 암호여부 변경
                SQLiteConfigHelper.Instance.setDefaultConfigValue("APPDB_ISENCRYPTED", "no");
                if (SQLiteConfigHelper.Instance.createAppDBFile())
                {
                    MessageBox.Show("설정용 DB파일생성완료!");
                }
                else
                {
                    MessageBox.Show("DB파일생성실패!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnOpenExeDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process explorer = new Process();
                explorer.StartInfo.FileName = "explorer.exe";
                explorer.StartInfo.Arguments = Application.StartupPath;
                explorer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnCreateAppDbfileWithPasswd_Click(object sender, EventArgs e)
        {
            try
            {
                // 암호화를 시키기 위해서 암호여부 변경
                SQLiteConfigHelper.Instance.setDefaultConfigValue("APPDB_ISENCRYPTED", "yes");
                if (SQLiteConfigHelper.Instance.createAppDBFile(this.txbPassword.Text))
                {
                    MessageBox.Show("설정용 DB파일생성완료!");
                }
                else
                {
                    MessageBox.Show("DB파일생성실패!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnOpenAppDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLiteConfigHelper.Instance.openAppDBFile())
                {
                    MessageBox.Show("Open 성공");
                }
                else
                {
                    MessageBox.Show("Open 실패...ㅠ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnOpenAppDbWithPasswd_Click(object sender, EventArgs e)
        {
            try
            {
                string password = this.txbPassword2.Text;
                if (SQLiteConfigHelper.Instance.openAppDBFile(password))
                {
                    MessageBox.Show("Open 성공");
                }
                else
                {
                    MessageBox.Show("Open 실패...ㅠ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnCloseAppDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLiteConfigHelper.Instance.closeAppDBFile())
                {
                    MessageBox.Show("Close 성공");
                }
                else
                {
                    MessageBox.Show("Close 실패...ㅠ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnConnectionTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (SQLiteConfigHelper.Instance.testAppDBConnection())
                {
                    MessageBox.Show("테스트 성공!");
                }
                else
                {
                    MessageBox.Show("테스트 실패..ㅠ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnAddNewConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string key = this.txbKey.Text;
                string value = this.txbValue.Text;
                string remark = this.txbRemark.Text;

                if (SQLiteConfigHelper.Instance.addNewAppConfig(key, value, remark))
                {
                    MessageBox.Show("추가 성공!");
                }
                else
                {
                    MessageBox.Show("추가 실패...ㅠ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnAppConfigList_Click(object sender, EventArgs e)
        {
            try
            {
                this.lsvAppConfigList.Items.Clear();
                List<string> configList = SQLiteConfigHelper.Instance.getAppConfigList();

                foreach (string entry in configList)
                {
                    this.lsvAppConfigList.Items.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void lsvAppConfigList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string key = this.lsvAppConfigList.SelectedItems[0].Text;
                string value = SQLiteConfigHelper.Instance.getAppConfigValue(key);
                MessageBox.Show(value, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnModifyConfigValue_Click(object sender, EventArgs e)
        {
            try
            {
                string key = this.txbAppConfigKey.Text;
                string value = this.txbAppConfigValue.Text;
                string remark = this.txbAppConfigRemark.Text;

                if (SQLiteConfigHelper.Instance.setAppConfigValue(key, value, remark))
                {
                    MessageBox.Show("설정변경 성공!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void lsvAppConfigList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lsvAppConfigList.SelectedItems.Count > 0)
                {
                    string key = this.lsvAppConfigList.SelectedItems[0].Text;
                    string value = SQLiteConfigHelper.Instance.getAppConfigValue(key);
                    string remark = SQLiteConfigHelper.Instance.getAppConfigRemark(key);

                    this.txbAppConfigKey.Text = key;
                    this.txbAppConfigValue.Text = value;
                    this.txbAppConfigRemark.Text = remark;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnAppConfigExists_Click(object sender, EventArgs e)
        {
            try
            {
                string key = this.txbAppConfigKeyExists.Text;

                if (SQLiteConfigHelper.Instance.isExistAppConfig(key))
                {
                    MessageBox.Show("설정 있음!");
                }
                else
                {
                    MessageBox.Show("설정 없음...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
    }
}
