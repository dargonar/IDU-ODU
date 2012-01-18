namespace LabelManager
{
  partial class Form1
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
      this.dtgEnsayos = new System.Windows.Forms.DataGridView();
      this.dtDesde = new System.Windows.Forms.DateTimePicker();
      this.dtHasta = new System.Windows.Forms.DateTimePicker();
      this.lblFrom = new System.Windows.Forms.Label();
      this.lblHasta = new System.Windows.Forms.Label();
      this.btnSelectEnsayos = new System.Windows.Forms.Button();
      this.chkEsIdu = new System.Windows.Forms.CheckBox();
      this.cmbModelosFrom1 = new System.Windows.Forms.ComboBox();
      this.btnPrint = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cmbModelosTo4 = new System.Windows.Forms.ComboBox();
      this.cmbModelosTo3 = new System.Windows.Forms.ComboBox();
      this.cmbModelosTo2 = new System.Windows.Forms.ComboBox();
      this.cmbModelosTo1 = new System.Windows.Forms.ComboBox();
      this.cmbModelosFrom4 = new System.Windows.Forms.ComboBox();
      this.cmbModelosFrom3 = new System.Windows.Forms.ComboBox();
      this.cmbModelosFrom2 = new System.Windows.Forms.ComboBox();
      this.btnconvertModelos = new System.Windows.Forms.Button();
      this.cmbModeloFilter = new System.Windows.Forms.ComboBox();
      this.cmbImprimirDesde = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.chkPrintBulto = new System.Windows.Forms.CheckBox();
      this.chkPrintProducto = new System.Windows.Forms.CheckBox();
      this.lblCantidad = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dtgEnsayos)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // dtgEnsayos
      // 
      this.dtgEnsayos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dtgEnsayos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dtgEnsayos.Location = new System.Drawing.Point(12, 70);
      this.dtgEnsayos.Name = "dtgEnsayos";
      this.dtgEnsayos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dtgEnsayos.Size = new System.Drawing.Size(1067, 308);
      this.dtgEnsayos.TabIndex = 0;
      // 
      // dtDesde
      // 
      this.dtDesde.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtDesde.Location = new System.Drawing.Point(116, 14);
      this.dtDesde.Name = "dtDesde";
      this.dtDesde.Size = new System.Drawing.Size(322, 20);
      this.dtDesde.TabIndex = 1;
      this.dtDesde.Value = new System.DateTime(2010, 7, 29, 6, 0, 0, 0);
      // 
      // dtHasta
      // 
      this.dtHasta.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtHasta.Location = new System.Drawing.Point(116, 40);
      this.dtHasta.Name = "dtHasta";
      this.dtHasta.Size = new System.Drawing.Size(322, 20);
      this.dtHasta.TabIndex = 2;
      this.dtHasta.Value = new System.DateTime(2010, 7, 29, 15, 0, 0, 0);
      // 
      // lblFrom
      // 
      this.lblFrom.AutoSize = true;
      this.lblFrom.Location = new System.Drawing.Point(13, 18);
      this.lblFrom.Name = "lblFrom";
      this.lblFrom.Size = new System.Drawing.Size(38, 13);
      this.lblFrom.TabIndex = 3;
      this.lblFrom.Text = "Desde";
      // 
      // lblHasta
      // 
      this.lblHasta.AutoSize = true;
      this.lblHasta.Location = new System.Drawing.Point(13, 44);
      this.lblHasta.Name = "lblHasta";
      this.lblHasta.Size = new System.Drawing.Size(35, 13);
      this.lblHasta.TabIndex = 4;
      this.lblHasta.Text = "Hasta";
      // 
      // btnSelectEnsayos
      // 
      this.btnSelectEnsayos.Location = new System.Drawing.Point(868, 39);
      this.btnSelectEnsayos.Name = "btnSelectEnsayos";
      this.btnSelectEnsayos.Size = new System.Drawing.Size(175, 23);
      this.btnSelectEnsayos.TabIndex = 5;
      this.btnSelectEnsayos.Text = "Seleccionar ensayos entre fechas";
      this.btnSelectEnsayos.UseVisualStyleBackColor = true;
      this.btnSelectEnsayos.Click += new System.EventHandler(this.btnSelectEnsayos_Click);
      // 
      // chkEsIdu
      // 
      this.chkEsIdu.AutoSize = true;
      this.chkEsIdu.Location = new System.Drawing.Point(817, 42);
      this.chkEsIdu.Name = "chkEsIdu";
      this.chkEsIdu.Size = new System.Drawing.Size(45, 17);
      this.chkEsIdu.TabIndex = 6;
      this.chkEsIdu.Text = "IDU";
      this.chkEsIdu.UseVisualStyleBackColor = true;
      this.chkEsIdu.CheckedChanged += new System.EventHandler(this.chkEsIdu_CheckedChanged);
      // 
      // cmbModelosFrom1
      // 
      this.cmbModelosFrom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosFrom1.FormattingEnabled = true;
      this.cmbModelosFrom1.Location = new System.Drawing.Point(6, 19);
      this.cmbModelosFrom1.Name = "cmbModelosFrom1";
      this.cmbModelosFrom1.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosFrom1.TabIndex = 7;
      // 
      // btnPrint
      // 
      this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPrint.Location = new System.Drawing.Point(721, 495);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new System.Drawing.Size(358, 23);
      this.btnPrint.TabIndex = 8;
      this.btnPrint.Text = "Imprimir Etiquetas de Ensayos Seleccionados";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox1.Controls.Add(this.cmbModelosTo4);
      this.groupBox1.Controls.Add(this.cmbModelosTo3);
      this.groupBox1.Controls.Add(this.cmbModelosTo2);
      this.groupBox1.Controls.Add(this.cmbModelosTo1);
      this.groupBox1.Controls.Add(this.cmbModelosFrom4);
      this.groupBox1.Controls.Add(this.cmbModelosFrom3);
      this.groupBox1.Controls.Add(this.cmbModelosFrom2);
      this.groupBox1.Controls.Add(this.btnconvertModelos);
      this.groupBox1.Controls.Add(this.cmbModelosFrom1);
      this.groupBox1.Location = new System.Drawing.Point(12, 384);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(444, 189);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      this.groupBox1.Visible = false;
      // 
      // cmbModelosTo4
      // 
      this.cmbModelosTo4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosTo4.FormattingEnabled = true;
      this.cmbModelosTo4.Location = new System.Drawing.Point(225, 100);
      this.cmbModelosTo4.Name = "cmbModelosTo4";
      this.cmbModelosTo4.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosTo4.TabIndex = 18;
      // 
      // cmbModelosTo3
      // 
      this.cmbModelosTo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosTo3.FormattingEnabled = true;
      this.cmbModelosTo3.Location = new System.Drawing.Point(225, 73);
      this.cmbModelosTo3.Name = "cmbModelosTo3";
      this.cmbModelosTo3.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosTo3.TabIndex = 17;
      // 
      // cmbModelosTo2
      // 
      this.cmbModelosTo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosTo2.FormattingEnabled = true;
      this.cmbModelosTo2.Location = new System.Drawing.Point(225, 46);
      this.cmbModelosTo2.Name = "cmbModelosTo2";
      this.cmbModelosTo2.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosTo2.TabIndex = 16;
      // 
      // cmbModelosTo1
      // 
      this.cmbModelosTo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosTo1.FormattingEnabled = true;
      this.cmbModelosTo1.Location = new System.Drawing.Point(225, 19);
      this.cmbModelosTo1.Name = "cmbModelosTo1";
      this.cmbModelosTo1.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosTo1.TabIndex = 15;
      // 
      // cmbModelosFrom4
      // 
      this.cmbModelosFrom4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosFrom4.FormattingEnabled = true;
      this.cmbModelosFrom4.Location = new System.Drawing.Point(6, 100);
      this.cmbModelosFrom4.Name = "cmbModelosFrom4";
      this.cmbModelosFrom4.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosFrom4.TabIndex = 14;
      // 
      // cmbModelosFrom3
      // 
      this.cmbModelosFrom3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosFrom3.FormattingEnabled = true;
      this.cmbModelosFrom3.Location = new System.Drawing.Point(6, 73);
      this.cmbModelosFrom3.Name = "cmbModelosFrom3";
      this.cmbModelosFrom3.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosFrom3.TabIndex = 13;
      // 
      // cmbModelosFrom2
      // 
      this.cmbModelosFrom2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cmbModelosFrom2.FormattingEnabled = true;
      this.cmbModelosFrom2.Location = new System.Drawing.Point(6, 46);
      this.cmbModelosFrom2.Name = "cmbModelosFrom2";
      this.cmbModelosFrom2.Size = new System.Drawing.Size(201, 21);
      this.cmbModelosFrom2.TabIndex = 12;
      // 
      // btnconvertModelos
      // 
      this.btnconvertModelos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnconvertModelos.Location = new System.Drawing.Point(185, 156);
      this.btnconvertModelos.Name = "btnconvertModelos";
      this.btnconvertModelos.Size = new System.Drawing.Size(253, 23);
      this.btnconvertModelos.TabIndex = 11;
      this.btnconvertModelos.Text = "Convertir Modelos de Ensayos Seleccionados";
      this.btnconvertModelos.UseVisualStyleBackColor = true;
      this.btnconvertModelos.Click += new System.EventHandler(this.btnconvertModelos_Click);
      // 
      // cmbModeloFilter
      // 
      this.cmbModeloFilter.FormattingEnabled = true;
      this.cmbModeloFilter.Location = new System.Drawing.Point(493, 40);
      this.cmbModeloFilter.Name = "cmbModeloFilter";
      this.cmbModeloFilter.Size = new System.Drawing.Size(318, 21);
      this.cmbModeloFilter.TabIndex = 19;
      // 
      // cmbImprimirDesde
      // 
      this.cmbImprimirDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbImprimirDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbImprimirDesde.FormattingEnabled = true;
      this.cmbImprimirDesde.Location = new System.Drawing.Point(721, 403);
      this.cmbImprimirDesde.Name = "cmbImprimirDesde";
      this.cmbImprimirDesde.Size = new System.Drawing.Size(358, 21);
      this.cmbImprimirDesde.TabIndex = 20;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(606, 406);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Imprimir en Impresora:";
      // 
      // chkPrintBulto
      // 
      this.chkPrintBulto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.chkPrintBulto.AutoSize = true;
      this.chkPrintBulto.Checked = true;
      this.chkPrintBulto.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkPrintBulto.Location = new System.Drawing.Point(721, 432);
      this.chkPrintBulto.Name = "chkPrintBulto";
      this.chkPrintBulto.Size = new System.Drawing.Size(225, 17);
      this.chkPrintBulto.TabIndex = 22;
      this.chkPrintBulto.Text = "IMPRIMIR ETIQUETA DE BULTO (CAJA)";
      this.chkPrintBulto.UseVisualStyleBackColor = true;
      // 
      // chkPrintProducto
      // 
      this.chkPrintProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.chkPrintProducto.AutoSize = true;
      this.chkPrintProducto.Checked = true;
      this.chkPrintProducto.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkPrintProducto.Location = new System.Drawing.Point(721, 459);
      this.chkPrintProducto.Name = "chkPrintProducto";
      this.chkPrintProducto.Size = new System.Drawing.Size(215, 17);
      this.chkPrintProducto.TabIndex = 23;
      this.chkPrintProducto.Text = "IMPRIMIR ETIQUETA DE PRODUCTO";
      this.chkPrintProducto.UseVisualStyleBackColor = true;
      // 
      // lblCantidad
      // 
      this.lblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCantidad.Location = new System.Drawing.Point(674, 384);
      this.lblCantidad.Name = "lblCantidad";
      this.lblCantidad.Size = new System.Drawing.Size(405, 13);
      this.lblCantidad.TabIndex = 24;
      this.lblCantidad.Text = "Cantidad:";
      this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(452, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 13);
      this.label2.TabIndex = 25;
      this.label2.Text = "Modelo";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1091, 585);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblCantidad);
      this.Controls.Add(this.chkPrintProducto);
      this.Controls.Add(this.chkPrintBulto);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cmbImprimirDesde);
      this.Controls.Add(this.cmbModeloFilter);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnPrint);
      this.Controls.Add(this.chkEsIdu);
      this.Controls.Add(this.btnSelectEnsayos);
      this.Controls.Add(this.lblHasta);
      this.Controls.Add(this.lblFrom);
      this.Controls.Add(this.dtHasta);
      this.Controls.Add(this.dtDesde);
      this.Controls.Add(this.dtgEnsayos);
      this.Name = "Form1";
      this.ShowIcon = false;
      this.Text = "Impresor Offline de Etiquetas";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      ((System.ComponentModel.ISupportInitialize)(this.dtgEnsayos)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dtgEnsayos;
    private System.Windows.Forms.DateTimePicker dtDesde;
    private System.Windows.Forms.DateTimePicker dtHasta;
    private System.Windows.Forms.Label lblFrom;
    private System.Windows.Forms.Label lblHasta;
    private System.Windows.Forms.Button btnSelectEnsayos;
    private System.Windows.Forms.CheckBox chkEsIdu;
    private System.Windows.Forms.ComboBox cmbModelosFrom1;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnconvertModelos;
    private System.Windows.Forms.ComboBox cmbModelosFrom4;
    private System.Windows.Forms.ComboBox cmbModelosFrom3;
    private System.Windows.Forms.ComboBox cmbModelosFrom2;
    private System.Windows.Forms.ComboBox cmbModelosTo4;
    private System.Windows.Forms.ComboBox cmbModelosTo3;
    private System.Windows.Forms.ComboBox cmbModelosTo2;
    private System.Windows.Forms.ComboBox cmbModelosTo1;
    private System.Windows.Forms.ComboBox cmbModeloFilter;
    private System.Windows.Forms.ComboBox cmbImprimirDesde;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkPrintBulto;
    private System.Windows.Forms.CheckBox chkPrintProducto;
    private System.Windows.Forms.Label lblCantidad;
    private System.Windows.Forms.Label label2;
  }
}

