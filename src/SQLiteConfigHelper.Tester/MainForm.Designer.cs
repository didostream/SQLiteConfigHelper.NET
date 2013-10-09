namespace SIMPLISM.Common.Config
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateObject = new System.Windows.Forms.Button();
            this.btnGetDBPath = new System.Windows.Forms.Button();
            this.btnGetNoneDefaultValue = new System.Windows.Forms.Button();
            this.btnGetDefaultKeyList = new System.Windows.Forms.Button();
            this.lsvDefaultKeyList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblKeyList = new System.Windows.Forms.Label();
            this.btnGetDBFilePath = new System.Windows.Forms.Button();
            this.txbDefaultConfigValue = new System.Windows.Forms.TextBox();
            this.btnModifyDefaultConfig = new System.Windows.Forms.Button();
            this.btnCreateAppDB = new System.Windows.Forms.Button();
            this.btnOpenExeDir = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.btnCreateAppDbfileWithPasswd = new System.Windows.Forms.Button();
            this.lblConfig = new System.Windows.Forms.Label();
            this.btnOpenAppDb = new System.Windows.Forms.Button();
            this.btnOpenAppDbWithPasswd = new System.Windows.Forms.Button();
            this.txbPassword2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseAppDb = new System.Windows.Forms.Button();
            this.btnConnectionTest = new System.Windows.Forms.Button();
            this.btnAddNewConfig = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txbRemark = new System.Windows.Forms.TextBox();
            this.btnAppConfigList = new System.Windows.Forms.Button();
            this.lsvAppConfigList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAppConfigKey = new System.Windows.Forms.Label();
            this.txbAppConfigRemark = new System.Windows.Forms.TextBox();
            this.btnModifyConfigValue = new System.Windows.Forms.Button();
            this.lblAppConfigValue = new System.Windows.Forms.Label();
            this.txbAppConfigKey = new System.Windows.Forms.TextBox();
            this.lblAppConfigRemark = new System.Windows.Forms.Label();
            this.txbAppConfigValue = new System.Windows.Forms.TextBox();
            this.txbAppConfigKeyExists = new System.Windows.Forms.TextBox();
            this.lblAppConfigKeyExists = new System.Windows.Forms.Label();
            this.btnAppConfigExists = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateObject
            // 
            this.btnCreateObject.Location = new System.Drawing.Point(12, 12);
            this.btnCreateObject.Name = "btnCreateObject";
            this.btnCreateObject.Size = new System.Drawing.Size(240, 23);
            this.btnCreateObject.TabIndex = 0;
            this.btnCreateObject.Text = "01. SQLiteConfigHelper 객체생성";
            this.btnCreateObject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateObject.UseVisualStyleBackColor = true;
            this.btnCreateObject.Click += new System.EventHandler(this.btnCreateObject_Click);
            // 
            // btnGetDBPath
            // 
            this.btnGetDBPath.Location = new System.Drawing.Point(12, 41);
            this.btnGetDBPath.Name = "btnGetDBPath";
            this.btnGetDBPath.Size = new System.Drawing.Size(240, 23);
            this.btnGetDBPath.TabIndex = 1;
            this.btnGetDBPath.Text = "02. DB경로조회 (기본설정값)";
            this.btnGetDBPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetDBPath.UseVisualStyleBackColor = true;
            this.btnGetDBPath.Click += new System.EventHandler(this.btnGetDBPath_Click);
            // 
            // btnGetNoneDefaultValue
            // 
            this.btnGetNoneDefaultValue.Location = new System.Drawing.Point(12, 70);
            this.btnGetNoneDefaultValue.Name = "btnGetNoneDefaultValue";
            this.btnGetNoneDefaultValue.Size = new System.Drawing.Size(240, 23);
            this.btnGetNoneDefaultValue.TabIndex = 2;
            this.btnGetNoneDefaultValue.Text = "03. 없는 기본설정값 조회";
            this.btnGetNoneDefaultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetNoneDefaultValue.UseVisualStyleBackColor = true;
            this.btnGetNoneDefaultValue.Click += new System.EventHandler(this.btnGetNoneDefaultValue_Click);
            // 
            // btnGetDefaultKeyList
            // 
            this.btnGetDefaultKeyList.Location = new System.Drawing.Point(12, 99);
            this.btnGetDefaultKeyList.Name = "btnGetDefaultKeyList";
            this.btnGetDefaultKeyList.Size = new System.Drawing.Size(240, 23);
            this.btnGetDefaultKeyList.TabIndex = 3;
            this.btnGetDefaultKeyList.Text = "04. 기본설정 키목록조회";
            this.btnGetDefaultKeyList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetDefaultKeyList.UseVisualStyleBackColor = true;
            this.btnGetDefaultKeyList.Click += new System.EventHandler(this.btnGetDefaultKeyList_Click);
            // 
            // lsvDefaultKeyList
            // 
            this.lsvDefaultKeyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvDefaultKeyList.FullRowSelect = true;
            this.lsvDefaultKeyList.GridLines = true;
            this.lsvDefaultKeyList.Location = new System.Drawing.Point(12, 128);
            this.lsvDefaultKeyList.Name = "lsvDefaultKeyList";
            this.lsvDefaultKeyList.Size = new System.Drawing.Size(240, 98);
            this.lsvDefaultKeyList.TabIndex = 4;
            this.lsvDefaultKeyList.UseCompatibleStateImageBehavior = false;
            this.lsvDefaultKeyList.View = System.Windows.Forms.View.Details;
            this.lsvDefaultKeyList.SelectedIndexChanged += new System.EventHandler(this.lsvDefaultKeyList_SelectedIndexChanged);
            this.lsvDefaultKeyList.DoubleClick += new System.EventHandler(this.lsvDefaultKeyList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "KEY";
            this.columnHeader1.Width = 195;
            // 
            // lblKeyList
            // 
            this.lblKeyList.AutoSize = true;
            this.lblKeyList.Location = new System.Drawing.Point(12, 229);
            this.lblKeyList.Name = "lblKeyList";
            this.lblKeyList.Size = new System.Drawing.Size(197, 12);
            this.lblKeyList.TabIndex = 5;
            this.lblKeyList.Text = "키값을 더블클릭하면 설정값을 조회";
            // 
            // btnGetDBFilePath
            // 
            this.btnGetDBFilePath.Location = new System.Drawing.Point(12, 244);
            this.btnGetDBFilePath.Name = "btnGetDBFilePath";
            this.btnGetDBFilePath.Size = new System.Drawing.Size(240, 23);
            this.btnGetDBFilePath.TabIndex = 6;
            this.btnGetDBFilePath.Text = "05. DB경로조회 (절대경로변환)";
            this.btnGetDBFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetDBFilePath.UseVisualStyleBackColor = true;
            this.btnGetDBFilePath.Click += new System.EventHandler(this.btnGetDBFilePath_Click);
            // 
            // txbDefaultConfigValue
            // 
            this.txbDefaultConfigValue.Location = new System.Drawing.Point(65, 273);
            this.txbDefaultConfigValue.Name = "txbDefaultConfigValue";
            this.txbDefaultConfigValue.Size = new System.Drawing.Size(187, 21);
            this.txbDefaultConfigValue.TabIndex = 7;
            // 
            // btnModifyDefaultConfig
            // 
            this.btnModifyDefaultConfig.Location = new System.Drawing.Point(12, 300);
            this.btnModifyDefaultConfig.Name = "btnModifyDefaultConfig";
            this.btnModifyDefaultConfig.Size = new System.Drawing.Size(240, 23);
            this.btnModifyDefaultConfig.TabIndex = 8;
            this.btnModifyDefaultConfig.Text = "06. 기본설정 수정";
            this.btnModifyDefaultConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyDefaultConfig.UseVisualStyleBackColor = true;
            this.btnModifyDefaultConfig.Click += new System.EventHandler(this.btnModifyDefaultConfig_Click);
            // 
            // btnCreateAppDB
            // 
            this.btnCreateAppDB.Location = new System.Drawing.Point(12, 329);
            this.btnCreateAppDB.Name = "btnCreateAppDB";
            this.btnCreateAppDB.Size = new System.Drawing.Size(240, 23);
            this.btnCreateAppDB.TabIndex = 9;
            this.btnCreateAppDB.Text = "07. 애플리케이션 설정DB생성";
            this.btnCreateAppDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAppDB.UseVisualStyleBackColor = true;
            this.btnCreateAppDB.Click += new System.EventHandler(this.btnCreateAppDB_Click);
            // 
            // btnOpenExeDir
            // 
            this.btnOpenExeDir.Location = new System.Drawing.Point(12, 695);
            this.btnOpenExeDir.Name = "btnOpenExeDir";
            this.btnOpenExeDir.Size = new System.Drawing.Size(240, 23);
            this.btnOpenExeDir.TabIndex = 10;
            this.btnOpenExeDir.Text = "애플리케이션 실행폴더 열기";
            this.btnOpenExeDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenExeDir.UseVisualStyleBackColor = true;
            this.btnOpenExeDir.Click += new System.EventHandler(this.btnOpenExeDir_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 361);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(37, 12);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "암호 :";
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(53, 358);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(199, 21);
            this.txbPassword.TabIndex = 12;
            // 
            // btnCreateAppDbfileWithPasswd
            // 
            this.btnCreateAppDbfileWithPasswd.Location = new System.Drawing.Point(12, 385);
            this.btnCreateAppDbfileWithPasswd.Name = "btnCreateAppDbfileWithPasswd";
            this.btnCreateAppDbfileWithPasswd.Size = new System.Drawing.Size(240, 23);
            this.btnCreateAppDbfileWithPasswd.TabIndex = 13;
            this.btnCreateAppDbfileWithPasswd.Text = "08. 애플리케이션 설정DB생성(암호적용)";
            this.btnCreateAppDbfileWithPasswd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAppDbfileWithPasswd.UseVisualStyleBackColor = true;
            this.btnCreateAppDbfileWithPasswd.Click += new System.EventHandler(this.btnCreateAppDbfileWithPasswd_Click);
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(10, 276);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(49, 12);
            this.lblConfig.TabIndex = 14;
            this.lblConfig.Text = "설정값 :";
            // 
            // btnOpenAppDb
            // 
            this.btnOpenAppDb.Location = new System.Drawing.Point(12, 414);
            this.btnOpenAppDb.Name = "btnOpenAppDb";
            this.btnOpenAppDb.Size = new System.Drawing.Size(240, 23);
            this.btnOpenAppDb.TabIndex = 15;
            this.btnOpenAppDb.Text = "09. 애플리케이션 설정DB 열기(암호X)";
            this.btnOpenAppDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenAppDb.UseVisualStyleBackColor = true;
            this.btnOpenAppDb.Click += new System.EventHandler(this.btnOpenAppDb_Click);
            // 
            // btnOpenAppDbWithPasswd
            // 
            this.btnOpenAppDbWithPasswd.Location = new System.Drawing.Point(12, 470);
            this.btnOpenAppDbWithPasswd.Name = "btnOpenAppDbWithPasswd";
            this.btnOpenAppDbWithPasswd.Size = new System.Drawing.Size(240, 23);
            this.btnOpenAppDbWithPasswd.TabIndex = 16;
            this.btnOpenAppDbWithPasswd.Text = "10. 애플리케이션 설정DB 열기(암호)";
            this.btnOpenAppDbWithPasswd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenAppDbWithPasswd.UseVisualStyleBackColor = true;
            this.btnOpenAppDbWithPasswd.Click += new System.EventHandler(this.btnOpenAppDbWithPasswd_Click);
            // 
            // txbPassword2
            // 
            this.txbPassword2.Location = new System.Drawing.Point(53, 443);
            this.txbPassword2.Name = "txbPassword2";
            this.txbPassword2.Size = new System.Drawing.Size(199, 21);
            this.txbPassword2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "암호 :";
            // 
            // btnCloseAppDb
            // 
            this.btnCloseAppDb.Location = new System.Drawing.Point(12, 499);
            this.btnCloseAppDb.Name = "btnCloseAppDb";
            this.btnCloseAppDb.Size = new System.Drawing.Size(240, 23);
            this.btnCloseAppDb.TabIndex = 19;
            this.btnCloseAppDb.Text = "11. 애플리케이션 설정DB 연결해제";
            this.btnCloseAppDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseAppDb.UseVisualStyleBackColor = true;
            this.btnCloseAppDb.Click += new System.EventHandler(this.btnCloseAppDb_Click);
            // 
            // btnConnectionTest
            // 
            this.btnConnectionTest.Location = new System.Drawing.Point(12, 528);
            this.btnConnectionTest.Name = "btnConnectionTest";
            this.btnConnectionTest.Size = new System.Drawing.Size(240, 23);
            this.btnConnectionTest.TabIndex = 20;
            this.btnConnectionTest.Text = "12. 애플리케이션 설정DB 연결테스트";
            this.btnConnectionTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectionTest.UseVisualStyleBackColor = true;
            this.btnConnectionTest.Click += new System.EventHandler(this.btnConnectionTest_Click);
            // 
            // btnAddNewConfig
            // 
            this.btnAddNewConfig.Location = new System.Drawing.Point(290, 93);
            this.btnAddNewConfig.Name = "btnAddNewConfig";
            this.btnAddNewConfig.Size = new System.Drawing.Size(247, 23);
            this.btnAddNewConfig.TabIndex = 21;
            this.btnAddNewConfig.Text = "13. 설정추가";
            this.btnAddNewConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewConfig.UseVisualStyleBackColor = true;
            this.btnAddNewConfig.Click += new System.EventHandler(this.btnAddNewConfig_Click);
            // 
            // lblKey
            // 
            this.lblKey.Location = new System.Drawing.Point(288, 15);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(56, 12);
            this.lblKey.TabIndex = 23;
            this.lblKey.Text = "Key :";
            this.lblKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbKey
            // 
            this.txbKey.Location = new System.Drawing.Point(350, 12);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(187, 21);
            this.txbKey.TabIndex = 22;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(288, 42);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(56, 12);
            this.lblValue.TabIndex = 25;
            this.lblValue.Text = "Value :";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(350, 39);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(187, 21);
            this.txbValue.TabIndex = 24;
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(288, 69);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(56, 12);
            this.lblRemark.TabIndex = 27;
            this.lblRemark.Text = "Remark :";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbRemark
            // 
            this.txbRemark.Location = new System.Drawing.Point(350, 66);
            this.txbRemark.Name = "txbRemark";
            this.txbRemark.Size = new System.Drawing.Size(187, 21);
            this.txbRemark.TabIndex = 26;
            // 
            // btnAppConfigList
            // 
            this.btnAppConfigList.Location = new System.Drawing.Point(290, 122);
            this.btnAppConfigList.Name = "btnAppConfigList";
            this.btnAppConfigList.Size = new System.Drawing.Size(247, 23);
            this.btnAppConfigList.TabIndex = 28;
            this.btnAppConfigList.Text = "14. 설정목록 조회";
            this.btnAppConfigList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppConfigList.UseVisualStyleBackColor = true;
            this.btnAppConfigList.Click += new System.EventHandler(this.btnAppConfigList_Click);
            // 
            // lsvAppConfigList
            // 
            this.lsvAppConfigList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvAppConfigList.FullRowSelect = true;
            this.lsvAppConfigList.GridLines = true;
            this.lsvAppConfigList.Location = new System.Drawing.Point(290, 151);
            this.lsvAppConfigList.Name = "lsvAppConfigList";
            this.lsvAppConfigList.Size = new System.Drawing.Size(247, 172);
            this.lsvAppConfigList.TabIndex = 29;
            this.lsvAppConfigList.UseCompatibleStateImageBehavior = false;
            this.lsvAppConfigList.View = System.Windows.Forms.View.Details;
            this.lsvAppConfigList.SelectedIndexChanged += new System.EventHandler(this.lsvAppConfigList_SelectedIndexChanged);
            this.lsvAppConfigList.DoubleClick += new System.EventHandler(this.lsvAppConfigList_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "KEY";
            this.columnHeader2.Width = 222;
            // 
            // lblAppConfigKey
            // 
            this.lblAppConfigKey.Location = new System.Drawing.Point(288, 332);
            this.lblAppConfigKey.Name = "lblAppConfigKey";
            this.lblAppConfigKey.Size = new System.Drawing.Size(56, 12);
            this.lblAppConfigKey.TabIndex = 31;
            this.lblAppConfigKey.Text = "Key :";
            this.lblAppConfigKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbAppConfigRemark
            // 
            this.txbAppConfigRemark.Location = new System.Drawing.Point(350, 383);
            this.txbAppConfigRemark.Name = "txbAppConfigRemark";
            this.txbAppConfigRemark.Size = new System.Drawing.Size(187, 21);
            this.txbAppConfigRemark.TabIndex = 30;
            // 
            // btnModifyConfigValue
            // 
            this.btnModifyConfigValue.Location = new System.Drawing.Point(290, 410);
            this.btnModifyConfigValue.Name = "btnModifyConfigValue";
            this.btnModifyConfigValue.Size = new System.Drawing.Size(247, 23);
            this.btnModifyConfigValue.TabIndex = 32;
            this.btnModifyConfigValue.Text = "15. 설정변경";
            this.btnModifyConfigValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyConfigValue.UseVisualStyleBackColor = true;
            this.btnModifyConfigValue.Click += new System.EventHandler(this.btnModifyConfigValue_Click);
            // 
            // lblAppConfigValue
            // 
            this.lblAppConfigValue.Location = new System.Drawing.Point(288, 359);
            this.lblAppConfigValue.Name = "lblAppConfigValue";
            this.lblAppConfigValue.Size = new System.Drawing.Size(56, 12);
            this.lblAppConfigValue.TabIndex = 34;
            this.lblAppConfigValue.Text = "Value :";
            this.lblAppConfigValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbAppConfigKey
            // 
            this.txbAppConfigKey.Location = new System.Drawing.Point(350, 329);
            this.txbAppConfigKey.Name = "txbAppConfigKey";
            this.txbAppConfigKey.ReadOnly = true;
            this.txbAppConfigKey.Size = new System.Drawing.Size(187, 21);
            this.txbAppConfigKey.TabIndex = 33;
            // 
            // lblAppConfigRemark
            // 
            this.lblAppConfigRemark.Location = new System.Drawing.Point(288, 386);
            this.lblAppConfigRemark.Name = "lblAppConfigRemark";
            this.lblAppConfigRemark.Size = new System.Drawing.Size(56, 12);
            this.lblAppConfigRemark.TabIndex = 36;
            this.lblAppConfigRemark.Text = "Remark :";
            this.lblAppConfigRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbAppConfigValue
            // 
            this.txbAppConfigValue.Location = new System.Drawing.Point(350, 356);
            this.txbAppConfigValue.Name = "txbAppConfigValue";
            this.txbAppConfigValue.Size = new System.Drawing.Size(187, 21);
            this.txbAppConfigValue.TabIndex = 35;
            // 
            // txbAppConfigKeyExists
            // 
            this.txbAppConfigKeyExists.Location = new System.Drawing.Point(350, 439);
            this.txbAppConfigKeyExists.Name = "txbAppConfigKeyExists";
            this.txbAppConfigKeyExists.Size = new System.Drawing.Size(187, 21);
            this.txbAppConfigKeyExists.TabIndex = 38;
            // 
            // lblAppConfigKeyExists
            // 
            this.lblAppConfigKeyExists.Location = new System.Drawing.Point(288, 442);
            this.lblAppConfigKeyExists.Name = "lblAppConfigKeyExists";
            this.lblAppConfigKeyExists.Size = new System.Drawing.Size(56, 12);
            this.lblAppConfigKeyExists.TabIndex = 37;
            this.lblAppConfigKeyExists.Text = "Key :";
            this.lblAppConfigKeyExists.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAppConfigExists
            // 
            this.btnAppConfigExists.Location = new System.Drawing.Point(290, 466);
            this.btnAppConfigExists.Name = "btnAppConfigExists";
            this.btnAppConfigExists.Size = new System.Drawing.Size(247, 23);
            this.btnAppConfigExists.TabIndex = 39;
            this.btnAppConfigExists.Text = "16. 설정의 존재유무 체크";
            this.btnAppConfigExists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppConfigExists.UseVisualStyleBackColor = true;
            this.btnAppConfigExists.Click += new System.EventHandler(this.btnAppConfigExists_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnAppConfigExists);
            this.Controls.Add(this.txbAppConfigKeyExists);
            this.Controls.Add(this.lblAppConfigKeyExists);
            this.Controls.Add(this.lblAppConfigRemark);
            this.Controls.Add(this.txbAppConfigValue);
            this.Controls.Add(this.lblAppConfigValue);
            this.Controls.Add(this.txbAppConfigKey);
            this.Controls.Add(this.btnModifyConfigValue);
            this.Controls.Add(this.lblAppConfigKey);
            this.Controls.Add(this.txbAppConfigRemark);
            this.Controls.Add(this.lsvAppConfigList);
            this.Controls.Add(this.btnAppConfigList);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txbRemark);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txbValue);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txbKey);
            this.Controls.Add(this.btnAddNewConfig);
            this.Controls.Add(this.btnConnectionTest);
            this.Controls.Add(this.btnCloseAppDb);
            this.Controls.Add(this.txbPassword2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenAppDbWithPasswd);
            this.Controls.Add(this.btnOpenAppDb);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.btnCreateAppDbfileWithPasswd);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnOpenExeDir);
            this.Controls.Add(this.btnCreateAppDB);
            this.Controls.Add(this.btnModifyDefaultConfig);
            this.Controls.Add(this.txbDefaultConfigValue);
            this.Controls.Add(this.btnGetDBFilePath);
            this.Controls.Add(this.lblKeyList);
            this.Controls.Add(this.lsvDefaultKeyList);
            this.Controls.Add(this.btnGetDefaultKeyList);
            this.Controls.Add(this.btnGetNoneDefaultValue);
            this.Controls.Add(this.btnGetDBPath);
            this.Controls.Add(this.btnCreateObject);
            this.Name = "MainForm";
            this.Text = "SQLiteConfigHelper Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateObject;
        private System.Windows.Forms.Button btnGetDBPath;
        private System.Windows.Forms.Button btnGetNoneDefaultValue;
        private System.Windows.Forms.Button btnGetDefaultKeyList;
        private System.Windows.Forms.ListView lsvDefaultKeyList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblKeyList;
        private System.Windows.Forms.Button btnGetDBFilePath;
        private System.Windows.Forms.TextBox txbDefaultConfigValue;
        private System.Windows.Forms.Button btnModifyDefaultConfig;
        private System.Windows.Forms.Button btnCreateAppDB;
        private System.Windows.Forms.Button btnOpenExeDir;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Button btnCreateAppDbfileWithPasswd;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Button btnOpenAppDb;
        private System.Windows.Forms.Button btnOpenAppDbWithPasswd;
        private System.Windows.Forms.TextBox txbPassword2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseAppDb;
        private System.Windows.Forms.Button btnConnectionTest;
        private System.Windows.Forms.Button btnAddNewConfig;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txbRemark;
        private System.Windows.Forms.Button btnAppConfigList;
        private System.Windows.Forms.ListView lsvAppConfigList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblAppConfigKey;
        private System.Windows.Forms.TextBox txbAppConfigRemark;
        private System.Windows.Forms.Button btnModifyConfigValue;
        private System.Windows.Forms.Label lblAppConfigValue;
        private System.Windows.Forms.TextBox txbAppConfigKey;
        private System.Windows.Forms.Label lblAppConfigRemark;
        private System.Windows.Forms.TextBox txbAppConfigValue;
        private System.Windows.Forms.TextBox txbAppConfigKeyExists;
        private System.Windows.Forms.Label lblAppConfigKeyExists;
        private System.Windows.Forms.Button btnAppConfigExists;
    }
}

