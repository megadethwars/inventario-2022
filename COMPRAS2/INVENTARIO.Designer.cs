
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.brnOPCIONES = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.btBUSCADOR = new System.Windows.Forms.Button();
            this.pboxBuscador = new System.Windows.Forms.PictureBox();
            this.bTNBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCompra = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1040, 319);
            this.dataGridView1.TabIndex = 3;
            // 
            // brnOPCIONES
            // 
            this.brnOPCIONES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.brnOPCIONES.BackColor = System.Drawing.Color.Transparent;
            this.brnOPCIONES.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.brnOPCIONES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.brnOPCIONES.FlatAppearance.BorderSize = 0;
            this.brnOPCIONES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnOPCIONES.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnOPCIONES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.brnOPCIONES.Location = new System.Drawing.Point(24, 587);
            this.brnOPCIONES.Name = "brnOPCIONES";
            this.brnOPCIONES.Size = new System.Drawing.Size(114, 39);
            this.brnOPCIONES.TabIndex = 6;
            this.brnOPCIONES.Text = "OPCIONES";
            this.brnOPCIONES.UseVisualStyleBackColor = false;
            this.brnOPCIONES.Click += new System.EventHandler(this.brnOPCIONES_Click);
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
            // btBUSCADOR
            // 
            this.btBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btBUSCADOR.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btBUSCADOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBUSCADOR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBUSCADOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBUSCADOR.Location = new System.Drawing.Point(49, 108);
            this.btBUSCADOR.Name = "btBUSCADOR";
            this.btBUSCADOR.Size = new System.Drawing.Size(31, 25);
            this.btBUSCADOR.TabIndex = 30;
            this.btBUSCADOR.UseVisualStyleBackColor = false;
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
            // INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1089, 647);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.btBUSCADOR);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pboxBuscador);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.brnOPCIONES);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.INVENTARIOTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "INVENTARIO";
            this.Text = "INVENTARIO";
            this.Load += new System.EventHandler(this.INVENTARIO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label INVENTARIOTITLE;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button brnOPCIONES;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Button btBUSCADOR;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pboxBuscador;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblSerie;
    }
}