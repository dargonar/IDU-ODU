namespace DCFStarter
{
  partial class frmDBRestorer
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtBkpFile = new System.Windows.Forms.TextBox();
        this.lblTitleBkp = new System.Windows.Forms.Label();
        this.btnSelectBkpFile = new System.Windows.Forms.Button();
        this.txtLog = new System.Windows.Forms.TextBox();
        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnRestore = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.txtConnString = new System.Windows.Forms.TextBox();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.pageDirecto = new System.Windows.Forms.TabPage();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.btnMysqlBinPath = new System.Windows.Forms.Button();
        this.txtMysqlBinPath = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.txtServer = new System.Windows.Forms.TextBox();
        this.label5 = new System.Windows.Forms.Label();
        this.txtDBChoice = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.txtPwd = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txtUser = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.btnRestoreBat = new System.Windows.Forms.Button();
        this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        this.tabControl1.SuspendLayout();
        this.pageDirecto.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.SuspendLayout();
        // 
        // txtBkpFile
        // 
        this.txtBkpFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtBkpFile.Location = new System.Drawing.Point(12, 25);
        this.txtBkpFile.Name = "txtBkpFile";
        this.txtBkpFile.Size = new System.Drawing.Size(556, 20);
        this.txtBkpFile.TabIndex = 0;
        // 
        // lblTitleBkp
        // 
        this.lblTitleBkp.AutoSize = true;
        this.lblTitleBkp.Location = new System.Drawing.Point(12, 9);
        this.lblTitleBkp.Name = "lblTitleBkp";
        this.lblTitleBkp.Size = new System.Drawing.Size(83, 13);
        this.lblTitleBkp.TabIndex = 1;
        this.lblTitleBkp.Text = "Archivo Backup";
        // 
        // btnSelectBkpFile
        // 
        this.btnSelectBkpFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSelectBkpFile.Location = new System.Drawing.Point(574, 23);
        this.btnSelectBkpFile.Name = "btnSelectBkpFile";
        this.btnSelectBkpFile.Size = new System.Drawing.Size(48, 23);
        this.btnSelectBkpFile.TabIndex = 2;
        this.btnSelectBkpFile.Text = "...";
        this.btnSelectBkpFile.UseVisualStyleBackColor = true;
        this.btnSelectBkpFile.Click += new System.EventHandler(this.btnSelectBkpFile_Click);
        // 
        // txtLog
        // 
        this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtLog.Location = new System.Drawing.Point(12, 344);
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.Size = new System.Drawing.Size(556, 169);
        this.txtLog.TabIndex = 3;
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "openFileDialog1";
        this.openFileDialog1.Filter = "Archivos SQL|*.sql";
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.Location = new System.Drawing.Point(574, 516);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(48, 23);
        this.btnClose.TabIndex = 4;
        this.btnClose.Text = "Cerrar";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnRestore
        // 
        this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRestore.Enabled = false;
        this.btnRestore.Location = new System.Drawing.Point(477, 49);
        this.btnRestore.Name = "btnRestore";
        this.btnRestore.Size = new System.Drawing.Size(64, 23);
        this.btnRestore.TabIndex = 5;
        this.btnRestore.Text = "Restaurar";
        this.btnRestore.UseVisualStyleBackColor = true;
        this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(6, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(105, 13);
        this.label1.TabIndex = 7;
        this.label1.Text = "Cadena de conexión";
        // 
        // txtConnString
        // 
        this.txtConnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtConnString.Location = new System.Drawing.Point(6, 23);
        this.txtConnString.Name = "txtConnString";
        this.txtConnString.Size = new System.Drawing.Size(538, 20);
        this.txtConnString.TabIndex = 6;
        this.txtConnString.Text = "server=localhost;uid=root;pwd=248;pooling=false;";
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.pageDirecto);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Location = new System.Drawing.Point(13, 60);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(555, 278);
        this.tabControl1.TabIndex = 8;
        // 
        // pageDirecto
        // 
        this.pageDirecto.Controls.Add(this.txtConnString);
        this.pageDirecto.Controls.Add(this.label1);
        this.pageDirecto.Controls.Add(this.btnRestore);
        this.pageDirecto.Location = new System.Drawing.Point(4, 22);
        this.pageDirecto.Name = "pageDirecto";
        this.pageDirecto.Padding = new System.Windows.Forms.Padding(3);
        this.pageDirecto.Size = new System.Drawing.Size(547, 252);
        this.pageDirecto.TabIndex = 0;
        this.pageDirecto.Text = "Directo";
        this.pageDirecto.UseVisualStyleBackColor = true;
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.btnMysqlBinPath);
        this.tabPage2.Controls.Add(this.txtMysqlBinPath);
        this.tabPage2.Controls.Add(this.label6);
        this.tabPage2.Controls.Add(this.txtServer);
        this.tabPage2.Controls.Add(this.label5);
        this.tabPage2.Controls.Add(this.txtDBChoice);
        this.tabPage2.Controls.Add(this.label4);
        this.tabPage2.Controls.Add(this.txtPwd);
        this.tabPage2.Controls.Add(this.label3);
        this.tabPage2.Controls.Add(this.txtUser);
        this.tabPage2.Controls.Add(this.label2);
        this.tabPage2.Controls.Add(this.btnRestoreBat);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(547, 252);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Bat";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // btnMysqlBinPath
        // 
        this.btnMysqlBinPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnMysqlBinPath.Location = new System.Drawing.Point(493, 117);
        this.btnMysqlBinPath.Name = "btnMysqlBinPath";
        this.btnMysqlBinPath.Size = new System.Drawing.Size(48, 23);
        this.btnMysqlBinPath.TabIndex = 9;
        this.btnMysqlBinPath.Text = "...";
        this.btnMysqlBinPath.UseVisualStyleBackColor = true;
        this.btnMysqlBinPath.Click += new System.EventHandler(this.btnMysqlBinPath_Click);
        // 
        // txtMysqlBinPath
        // 
        this.txtMysqlBinPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtMysqlBinPath.Location = new System.Drawing.Point(118, 118);
        this.txtMysqlBinPath.Name = "txtMysqlBinPath";
        this.txtMysqlBinPath.Size = new System.Drawing.Size(369, 20);
        this.txtMysqlBinPath.TabIndex = 17;
        this.txtMysqlBinPath.Text = "%PROGRAMFILES%\\MySQL\\MySQL Server 5.0\\bin\\";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(17, 121);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(77, 13);
        this.label6.TabIndex = 18;
        this.label6.Text = "Mysql Bin Path";
        // 
        // txtServer
        // 
        this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtServer.Location = new System.Drawing.Point(118, 91);
        this.txtServer.Name = "txtServer";
        this.txtServer.Size = new System.Drawing.Size(369, 20);
        this.txtServer.TabIndex = 15;
        this.txtServer.Text = "localhost";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(56, 94);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(38, 13);
        this.label5.TabIndex = 16;
        this.label5.Text = "Server";
        // 
        // txtDBChoice
        // 
        this.txtDBChoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtDBChoice.Location = new System.Drawing.Point(118, 64);
        this.txtDBChoice.Name = "txtDBChoice";
        this.txtDBChoice.Size = new System.Drawing.Size(369, 20);
        this.txtDBChoice.TabIndex = 13;
        this.txtDBChoice.Text = "idu_odu_min";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(72, 67);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(22, 13);
        this.label4.TabIndex = 14;
        this.label4.Text = "DB";
        // 
        // txtPwd
        // 
        this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtPwd.Location = new System.Drawing.Point(118, 37);
        this.txtPwd.Name = "txtPwd";
        this.txtPwd.Size = new System.Drawing.Size(369, 20);
        this.txtPwd.TabIndex = 11;
        this.txtPwd.Text = "248";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(41, 40);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(53, 13);
        this.label3.TabIndex = 12;
        this.label3.Text = "Password";
        // 
        // txtUser
        // 
        this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtUser.Location = new System.Drawing.Point(118, 10);
        this.txtUser.Name = "txtUser";
        this.txtUser.Size = new System.Drawing.Size(369, 20);
        this.txtUser.TabIndex = 9;
        this.txtUser.Text = "root";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(65, 13);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(29, 13);
        this.label2.TabIndex = 10;
        this.label2.Text = "User";
        // 
        // btnRestoreBat
        // 
        this.btnRestoreBat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRestoreBat.Location = new System.Drawing.Point(477, 223);
        this.btnRestoreBat.Name = "btnRestoreBat";
        this.btnRestoreBat.Size = new System.Drawing.Size(64, 23);
        this.btnRestoreBat.TabIndex = 8;
        this.btnRestoreBat.Text = "Restaurar";
        this.btnRestoreBat.UseVisualStyleBackColor = true;
        this.btnRestoreBat.Click += new System.EventHandler(this.btnRestoreBat_Click);
        // 
        // frmDBRestorer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ClientSize = new System.Drawing.Size(627, 544);
        this.Controls.Add(this.tabControl1);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.txtLog);
        this.Controls.Add(this.btnSelectBkpFile);
        this.Controls.Add(this.lblTitleBkp);
        this.Controls.Add(this.txtBkpFile);
        this.Name = "frmDBRestorer";
        this.ShowIcon = false;
        this.Text = "Restaurador de BBDD";
        this.Load += new System.EventHandler(this.frmDBRestorer_Load);
        this.tabControl1.ResumeLayout(false);
        this.pageDirecto.ResumeLayout(false);
        this.pageDirecto.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtBkpFile;
    private System.Windows.Forms.Label lblTitleBkp;
    private System.Windows.Forms.Button btnSelectBkpFile;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnRestore;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtConnString;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage pageDirecto;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtMysqlBinPath;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtServer;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtDBChoice;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtPwd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnRestoreBat;
    private System.Windows.Forms.Button btnMysqlBinPath;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
  }
}