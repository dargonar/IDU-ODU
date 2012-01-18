namespace ImagePosition
{
  partial class frmMain
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
      this.nudTOP = new System.Windows.Forms.NumericUpDown();
      this.nudLEFT = new System.Windows.Forms.NumericUpDown();
      this.lblTop = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSelectFile = new System.Windows.Forms.Button();
      this.btnPrint = new System.Windows.Forms.Button();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudTOP)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLEFT)).BeginInit();
      this.SuspendLayout();
      // 
      // nudTOP
      // 
      this.nudTOP.Location = new System.Drawing.Point(112, 42);
      this.nudTOP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudTOP.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.nudTOP.Name = "nudTOP";
      this.nudTOP.Size = new System.Drawing.Size(120, 20);
      this.nudTOP.TabIndex = 0;
      // 
      // nudLEFT
      // 
      this.nudLEFT.Location = new System.Drawing.Point(112, 85);
      this.nudLEFT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudLEFT.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.nudLEFT.Name = "nudLEFT";
      this.nudLEFT.Size = new System.Drawing.Size(120, 20);
      this.nudLEFT.TabIndex = 1;
      // 
      // lblTop
      // 
      this.lblTop.AutoSize = true;
      this.lblTop.Location = new System.Drawing.Point(25, 42);
      this.lblTop.Name = "lblTop";
      this.lblTop.Size = new System.Drawing.Size(29, 13);
      this.lblTop.TabIndex = 2;
      this.lblTop.Text = "TOP";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 85);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "LEFT";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(111, 178);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(413, 20);
      this.textBox1.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 181);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Etiqueta Imagen";
      // 
      // btnSelectFile
      // 
      this.btnSelectFile.Location = new System.Drawing.Point(565, 174);
      this.btnSelectFile.Name = "btnSelectFile";
      this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
      this.btnSelectFile.TabIndex = 6;
      this.btnSelectFile.Text = "Seleccionar";
      this.btnSelectFile.UseVisualStyleBackColor = true;
      this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
      // 
      // btnPrint
      // 
      this.btnPrint.Location = new System.Drawing.Point(548, 269);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new System.Drawing.Size(75, 23);
      this.btnPrint.TabIndex = 7;
      this.btnPrint.Text = "Print";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(111, 126);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 8;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 413);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.btnPrint);
      this.Controls.Add(this.btnSelectFile);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblTop);
      this.Controls.Add(this.nudLEFT);
      this.Controls.Add(this.nudTOP);
      this.Name = "frmMain";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.nudTOP)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLEFT)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown nudTOP;
    private System.Windows.Forms.NumericUpDown nudLEFT;
    private System.Windows.Forms.Label lblTop;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectFile;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}

