
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
            this.btnAgregarNuevoProducto = new System.Windows.Forms.Button();
            this.btnReingresarProducto = new System.Windows.Forms.Button();
            this.btnSALIDA = new System.Windows.Forms.Button();
            this.btnActualizarProducto = new System.Windows.Forms.Button();
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
            this.INVENTARIOTITLE.Location = new System.Drawing.Point(560, 30);
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
            this.dgvInventario.Size = new System.Drawing.Size(1230, 533);
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
            this.lblProducto.Location = new System.Drawing.Point(27, 222);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(74, 16);
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
            this.txtBUSCADOR.Location = new System.Drawing.Point(181, 109);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 29;
            this.txtBUSCADOR.Text = "Search";
            // 
            // tableLayoutPanel1
            // 
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
            this.btnEscanear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEscanear.FlatAppearance.BorderSize = 0;
            this.btnEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscanear.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscanear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnEscanear.Location = new System.Drawing.Point(573, 157);
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
            this.btnBuscador.Location = new System.Drawing.Point(144, 108);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(31, 25);
            this.btnBuscador.TabIndex = 30;
            this.btnBuscador.UseVisualStyleBackColor = false;
            // 
            // pboxBuscador
            // 
            this.pboxBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxBuscador.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pboxBuscador.Location = new System.Drawing.Point(123, 99);
            this.pboxBuscador.Name = "pboxBuscador";
            this.pboxBuscador.Size = new System.Drawing.Size(1036, 40);
            this.pboxBuscador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBuscador.TabIndex = 28;
            this.pboxBuscador.TabStop = false;
            // 
            // bTNBack
            // 
            this.bTNBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 19;
            this.bTNBack.UseVisualStyleBackColor = false;
            this.bTNBack.Click += new System.EventHandler(this.bkBack_Click);
            // 
            // btnAgregarNuevoProducto
            // 
            this.btnAgregarNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarNuevoProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarNuevoProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnAgregarNuevoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarNuevoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarNuevoProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevoProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNuevoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnAgregarNuevoProducto.Location = new System.Drawing.Point(30, 801);
            this.btnAgregarNuevoProducto.Name = "btnAgregarNuevoProducto";
            this.btnAgregarNuevoProducto.Size = new System.Drawing.Size(209, 39);
            this.btnAgregarNuevoProducto.TabIndex = 33;
            this.btnAgregarNuevoProducto.Text = "AGREGAR NUEVO PRODUCTO";
            this.btnAgregarNuevoProducto.UseVisualStyleBackColor = false;
            this.btnAgregarNuevoProducto.Click += new System.EventHandler(this.btnAgregarNuevoProducto_Click);
            // 
            // btnReingresarProducto
            // 
            this.btnReingresarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReingresarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnReingresarProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnReingresarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReingresarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReingresarProducto.FlatAppearance.BorderSize = 0;
            this.btnReingresarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReingresarProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReingresarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnReingresarProducto.Location = new System.Drawing.Point(245, 801);
            this.btnReingresarProducto.Name = "btnReingresarProducto";
            this.btnReingresarProducto.Size = new System.Drawing.Size(189, 39);
            this.btnReingresarProducto.TabIndex = 34;
            this.btnReingresarProducto.Text = "INGRESAR PRODUCTO";
            this.btnReingresarProducto.UseVisualStyleBackColor = false;
            this.btnReingresarProducto.Click += new System.EventHandler(this.btnReingresarProducto_Click);
            // 
            // btnSALIDA
            // 
            this.btnSALIDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSALIDA.BackColor = System.Drawing.Color.Transparent;
            this.btnSALIDA.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnSALIDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSALIDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSALIDA.FlatAppearance.BorderSize = 0;
            this.btnSALIDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSALIDA.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnSALIDA.Location = new System.Drawing.Point(440, 801);
            this.btnSALIDA.Name = "btnSALIDA";
            this.btnSALIDA.Size = new System.Drawing.Size(133, 39);
            this.btnSALIDA.TabIndex = 35;
            this.btnSALIDA.Text = "SALIDA";
            this.btnSALIDA.UseVisualStyleBackColor = false;
            this.btnSALIDA.Click += new System.EventHandler(this.btnSALIDA_Click);
            // 
            // btnActualizarProducto
            // 
            this.btnActualizarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnActualizarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarProducto.FlatAppearance.BorderSize = 0;
            this.btnActualizarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnActualizarProducto.Location = new System.Drawing.Point(579, 801);
            this.btnActualizarProducto.Name = "btnActualizarProducto";
            this.btnActualizarProducto.Size = new System.Drawing.Size(175, 39);
            this.btnActualizarProducto.TabIndex = 36;
            this.btnActualizarProducto.Text = "ACTUALIZAR LUGARES";
            this.btnActualizarProducto.UseVisualStyleBackColor = false;
            this.btnActualizarProducto.Click += new System.EventHandler(this.btnActualizarProducto_Click);
            // 
            // INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.btnActualizarProducto);
            this.Controls.Add(this.btnSALIDA);
            this.Controls.Add(this.btnReingresarProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.btnAgregarNuevoProducto);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.btnBuscador);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pboxBuscador);
            this.Controls.Add(this.bTNBack);
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
        private System.Windows.Forms.Button btnAgregarNuevoProducto;
        private System.Windows.Forms.Button btnReingresarProducto;
        private System.Windows.Forms.Button btnSALIDA;
        private System.Windows.Forms.Button btnActualizarProducto;
    }
}