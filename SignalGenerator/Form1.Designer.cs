namespace SignalGenerator
{
  partial class Form1
  {
    /// <summary>
    /// Variable del diseñador requerida.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén utilizando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido del método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.btnStartIdu = new System.Windows.Forms.Button();
      this.btnStopIdu = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblLogIdu = new System.Windows.Forms.Label();
      this.btnStopIduFallado = new System.Windows.Forms.Button();
      this.tbctrlIduOdu = new System.Windows.Forms.TabControl();
      this.tbpgIdu = new System.Windows.Forms.TabPage();
      this.tbpgOdu = new System.Windows.Forms.TabPage();
      this.btnStopOduOk = new System.Windows.Forms.Button();
      this.btnStopOduFallado = new System.Windows.Forms.Button();
      this.btnStartOdu = new System.Windows.Forms.Button();
      this.lblLogOdu = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.tbctrlIduOdu.SuspendLayout();
      this.tbpgIdu.SuspendLayout();
      this.tbpgOdu.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnStartIdu
      // 
      this.btnStartIdu.Location = new System.Drawing.Point(36, 51);
      this.btnStartIdu.Name = "btnStartIdu";
      this.btnStartIdu.Size = new System.Drawing.Size(75, 23);
      this.btnStartIdu.TabIndex = 0;
      this.btnStartIdu.Text = "Start IDU";
      this.btnStartIdu.UseVisualStyleBackColor = true;
      this.btnStartIdu.Click += new System.EventHandler(this.btnStartIdu_Click);
      // 
      // btnStopIdu
      // 
      this.btnStopIdu.Location = new System.Drawing.Point(132, 28);
      this.btnStopIdu.Name = "btnStopIdu";
      this.btnStopIdu.Size = new System.Drawing.Size(117, 34);
      this.btnStopIdu.TabIndex = 1;
      this.btnStopIdu.Text = "STOP IDU";
      this.btnStopIdu.UseVisualStyleBackColor = true;
      this.btnStopIdu.Click += new System.EventHandler(this.btnEndIdu_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(26, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "IDU";
      // 
      // lblLogIdu
      // 
      this.lblLogIdu.AutoSize = true;
      this.lblLogIdu.Location = new System.Drawing.Point(130, 175);
      this.lblLogIdu.Name = "lblLogIdu";
      this.lblLogIdu.Size = new System.Drawing.Size(26, 13);
      this.lblLogIdu.TabIndex = 6;
      this.lblLogIdu.Text = "IDU";
      // 
      // btnStopIduFallado
      // 
      this.btnStopIduFallado.Location = new System.Drawing.Point(132, 64);
      this.btnStopIduFallado.Name = "btnStopIduFallado";
      this.btnStopIduFallado.Size = new System.Drawing.Size(117, 34);
      this.btnStopIduFallado.TabIndex = 7;
      this.btnStopIduFallado.Text = "STOP IDU FALLADO";
      this.btnStopIduFallado.UseVisualStyleBackColor = true;
      this.btnStopIduFallado.Click += new System.EventHandler(this.btnStopIduFallado_Click);
      // 
      // tbctrlIduOdu
      // 
      this.tbctrlIduOdu.Controls.Add(this.tbpgIdu);
      this.tbctrlIduOdu.Controls.Add(this.tbpgOdu);
      this.tbctrlIduOdu.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbctrlIduOdu.Location = new System.Drawing.Point(0, 0);
      this.tbctrlIduOdu.Name = "tbctrlIduOdu";
      this.tbctrlIduOdu.SelectedIndex = 0;
      this.tbctrlIduOdu.Size = new System.Drawing.Size(423, 271);
      this.tbctrlIduOdu.TabIndex = 8;
      // 
      // tbpgIdu
      // 
      this.tbpgIdu.Controls.Add(this.button1);
      this.tbpgIdu.Controls.Add(this.btnStopIdu);
      this.tbpgIdu.Controls.Add(this.btnStopIduFallado);
      this.tbpgIdu.Controls.Add(this.btnStartIdu);
      this.tbpgIdu.Controls.Add(this.lblLogIdu);
      this.tbpgIdu.Controls.Add(this.label1);
      this.tbpgIdu.Location = new System.Drawing.Point(4, 22);
      this.tbpgIdu.Name = "tbpgIdu";
      this.tbpgIdu.Padding = new System.Windows.Forms.Padding(3);
      this.tbpgIdu.Size = new System.Drawing.Size(415, 245);
      this.tbpgIdu.TabIndex = 0;
      this.tbpgIdu.Text = "IDU";
      this.tbpgIdu.UseVisualStyleBackColor = true;
      // 
      // tbpgOdu
      // 
      this.tbpgOdu.Controls.Add(this.button2);
      this.tbpgOdu.Controls.Add(this.btnStopOduOk);
      this.tbpgOdu.Controls.Add(this.btnStopOduFallado);
      this.tbpgOdu.Controls.Add(this.btnStartOdu);
      this.tbpgOdu.Controls.Add(this.lblLogOdu);
      this.tbpgOdu.Controls.Add(this.label3);
      this.tbpgOdu.Location = new System.Drawing.Point(4, 22);
      this.tbpgOdu.Name = "tbpgOdu";
      this.tbpgOdu.Padding = new System.Windows.Forms.Padding(3);
      this.tbpgOdu.Size = new System.Drawing.Size(415, 245);
      this.tbpgOdu.TabIndex = 1;
      this.tbpgOdu.Text = "ODU";
      this.tbpgOdu.UseVisualStyleBackColor = true;
      // 
      // btnStopOduOk
      // 
      this.btnStopOduOk.Location = new System.Drawing.Point(132, 28);
      this.btnStopOduOk.Name = "btnStopOduOk";
      this.btnStopOduOk.Size = new System.Drawing.Size(118, 34);
      this.btnStopOduOk.TabIndex = 9;
      this.btnStopOduOk.Text = "STOP ODU";
      this.btnStopOduOk.UseVisualStyleBackColor = true;
      this.btnStopOduOk.Click += new System.EventHandler(this.btnStopOduOk_Click);
      // 
      // btnStopOduFallado
      // 
      this.btnStopOduFallado.Location = new System.Drawing.Point(132, 64);
      this.btnStopOduFallado.Name = "btnStopOduFallado";
      this.btnStopOduFallado.Size = new System.Drawing.Size(118, 34);
      this.btnStopOduFallado.TabIndex = 12;
      this.btnStopOduFallado.Text = "STOP ODU FALLADO";
      this.btnStopOduFallado.UseVisualStyleBackColor = true;
      this.btnStopOduFallado.Click += new System.EventHandler(this.btnStopOduFallado_Click);
      // 
      // btnStartOdu
      // 
      this.btnStartOdu.Location = new System.Drawing.Point(36, 51);
      this.btnStartOdu.Name = "btnStartOdu";
      this.btnStartOdu.Size = new System.Drawing.Size(75, 23);
      this.btnStartOdu.TabIndex = 8;
      this.btnStartOdu.Text = "Start ODU";
      this.btnStartOdu.UseVisualStyleBackColor = true;
      this.btnStartOdu.Click += new System.EventHandler(this.btnStartOdu_Click);
      // 
      // lblLogOdu
      // 
      this.lblLogOdu.AutoSize = true;
      this.lblLogOdu.Location = new System.Drawing.Point(129, 144);
      this.lblLogOdu.Name = "lblLogOdu";
      this.lblLogOdu.Size = new System.Drawing.Size(31, 13);
      this.lblLogOdu.TabIndex = 11;
      this.lblLogOdu.Text = "ODU";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(21, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "ODU";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(133, 104);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(116, 34);
      this.button1.TabIndex = 8;
      this.button1.Text = "STOP IDU FALLA MANUAL";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(133, 104);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(118, 34);
      this.button2.TabIndex = 13;
      this.button2.Text = "STOP ODU FALLA MANUAL";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(423, 271);
      this.Controls.Add(this.tbctrlIduOdu);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Generador de Señales IDU/ODU";
      this.tbctrlIduOdu.ResumeLayout(false);
      this.tbpgIdu.ResumeLayout(false);
      this.tbpgIdu.PerformLayout();
      this.tbpgOdu.ResumeLayout(false);
      this.tbpgOdu.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnStartIdu;
    private System.Windows.Forms.Button btnStopIdu;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblLogIdu;
    private System.Windows.Forms.Button btnStopIduFallado;
    private System.Windows.Forms.TabControl tbctrlIduOdu;
    private System.Windows.Forms.TabPage tbpgIdu;
    private System.Windows.Forms.TabPage tbpgOdu;
    private System.Windows.Forms.Button btnStopOduOk;
    private System.Windows.Forms.Button btnStopOduFallado;
    private System.Windows.Forms.Button btnStartOdu;
    private System.Windows.Forms.Label lblLogOdu;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}

