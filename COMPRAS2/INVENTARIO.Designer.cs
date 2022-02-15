
namespace COMPRAS2
{
    partial class INVENTARIO
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
            this.INVENTARIOTITLE = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCompra = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.btnBuscador = new System.Windows.Forms.Button();
            this.pboxBuscador = new System.Windows.Forms.PictureBox();
            this.bTNBack = new System.Windows.Forms.Button();
            this.btnOPCIONES = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).BeginInit();
            this.SuspendLayout();
            // 
            // INVENTARIOTITLE
            // 
            this.INVENTARIOTITLE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.INVENTARIOTITLE.AutoSize = true;
            this.INVENTARIOTITLE.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INVENTARIOTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.INVENTARIOTITLE.Location = new System.Drawing.Point(471, 26);
            this.INVENTARIOTITLE.Name = "INVENTARIOTITLE";
            this.INVENTARIOTITLE.Size = new System.Drawing.Size(129, 42);
            this.INVENTARIOTITLE.TabIndex = 2;
            this.INVENTARIOTITLE.Text = "INVENTARIO";
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToOrderColumns = true;
            this.dgvInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(24, 248);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(1040, 319);
            this.dgvInventario.TabIndex = 3;
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(3, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(142, 20);
            this.lblProducto.TabIndex = 12;
            this.lblProducto.Text = "Producto:";
            // 
            // lblMarca
            // 
            this.lblMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(151, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(142, 20);
            this.lblMarca.TabIndex = 13;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCodigoQR
            // 
            this.lblCodigoQR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodigoQR.AutoSize = true;
            this.lblCodigoQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoQR.ForeColor = System.Drawing.Color.White;
            this.lblCodigoQR.Location = new System.Drawing.Point(299, 0);
            this.lblCodigoQR.Name = "lblCodigoQR";
            this.lblCodigoQR.Size = new System.Drawing.Size(142, 20);
            this.lblCodigoQR.TabIndex = 14;
            this.lblCodigoQR.Text = "Codigo QR:";
            // 
            // lblModelo
            // 
            this.lblModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.ForeColor = System.Drawing.Color.White;
            this.lblModelo.Location = new System.Drawing.Point(447, 0);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(142, 20);
            this.lblModelo.TabIndex = 15;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.txtBUSCADOR.Location = new System.Drawing.Point(86, 109);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 29;
            this.txtBUSCADOR.Text = "Search";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.lblCompra, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOrigen, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSerie, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProducto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMarca, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblModelo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCodigoQR, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 222);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 20);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // lblCompra
            // 
            this.lblCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompra.AutoSize = true;
            this.lblCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompra.ForeColor = System.Drawing.Color.White;
            this.lblCompra.Location = new System.Drawing.Point(891, 0);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(146, 20);
            this.lblCompra.TabIndex = 35;
            this.lblCompra.Text = "Compra:";
            // 
            // lblOrigen
            // 
            this.lblOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.ForeColor = System.Drawing.Color.White;
            this.lblOrigen.Location = new System.Drawing.Point(743, 0);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(142, 20);
            this.lblOrigen.TabIndex = 34;
            this.lblOrigen.Text = "Origen:";
            // 
            // lblSerie
            // 
            this.lblSerie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.ForeColor = System.Drawing.Color.White;
            this.lblSerie.Location = new System.Drawing.Point(595, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(142, 20);
            this.lblSerie.TabIndex = 33;
            this.lblSerie.Text = "Serie:";
            // 
            // btnEscanear
            // 
            this.btnEscanear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEscanear.BackColor = System.Drawing.Color.Transparent;
            this.btnEscanear.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnEscanear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEscanear.FlatAppearance.BorderSize = 0;
            this.btnEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscanear.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscanear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnEscanear.Location = new System.Drawing.Point(478, 157);
            this.btnEscanear.Name = "btnEscanear";
            this.btnEscanear.Size = new System.Drawing.Size(114, 39);
            this.btnEscanear.TabIndex = 31;
            this.btnEscanear.Text = "ESCANEAR";
            this.btnEscanear.UseVisualStyleBackColor = false;
            // 
            // btnBuscador
            // 
            this.btnBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btnBuscador.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btnBuscador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscador.Location = new System.Drawing.Point(49, 108);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(31, 25);
            this.btnBuscador.TabIndex = 30;
            this.btnBuscador.UseVisualStyleBackColor = false;
            // 
            // pboxBuscador
            // 
            this.pboxBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxBuscador.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pboxBuscador.Location = new System.Drawing.Point(28, 99);
            this.pboxBuscador.Name = "pboxBuscador";
            this.pboxBuscador.Size = new System.Drawing.Size(1036, 40);
            this.pboxBuscador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBuscador.TabIndex = 28;
            this.pboxBuscador.TabStop = false;
            // 
            // bTNBack
            // 
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 19;
            this.bTNBack.UseVisualStyleBackColor = true;
            this.bTNBack.Click += new System.EventHandler(this.bkBack_Click);
            // 
            // btnOPCIONES
            // 
            this.btnOPCIONES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOPCIONES.BackColor = System.Drawing.Color.Transparent;
            this.btnOPCIONES.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnOPCIONES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOPCIONES.FlatAppearance.BorderSize = 0;
            this.btnOPCIONES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOPCIONES.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPCIONES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnOPCIONES.Location = new System.Drawing.Point(707, 587);
            this.btnOPCIONES.Name = "btnOPCIONES";
            this.btnOPCIONES.Size = new System.Drawing.Size(114, 39);
            this.btnOPCIONES.TabIndex = 6;
            this.btnOPCIONES.Text = "OPCIONES";
            this.btnOPCIONES.UseVisualStyleBackColor = false;
            this.btnOPCIONES.Click += new System.EventHandler(this.brnOPCIONES_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.button1.Location = new System.Drawing.Point(30, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 39);
            this.button1.TabIndex = 33;
            this.button1.Text = "AGREGAR NUEVO PRODUCTO";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.button2.Location = new System.Drawing.Point(245, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 39);
            this.button2.TabIndex = 34;
            this.button2.Text = "REINGRESAR PRODUCTO";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.button3.Location = new System.Drawing.Point(440, 587);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 39);
            this.button3.TabIndex = 35;
            this.button3.Text = "SALIDA";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.button4.Location = new System.Drawing.Point(526, 587);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 39);
            this.button4.TabIndex = 36;
            this.button4.Text = "ACTUALIZAR LUGARES";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1089, 647);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.btnBuscador);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pboxBuscador);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.btnOPCIONES);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.INVENTARIOTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "INVENTARIO";
            this.Text = "INVENTARIO";
            this.Load += new System.EventHandler(this.INVENTARIO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label INVENTARIOTITLE;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnOPCIONES;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Button btnBuscador;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pboxBuscador;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}