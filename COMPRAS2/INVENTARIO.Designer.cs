
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.INVENTARIOTITLE = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.btnEditarMovimientos = new System.Windows.Forms.Button();
            this.btnActualizarBDD = new System.Windows.Forms.Button();
            this.btnActualizarProducto = new System.Windows.Forms.Button();
            this.btnSALIDA = new System.Windows.Forms.Button();
            this.btnReingresarProducto = new System.Windows.Forms.Button();
            this.btnAgregarNuevoProducto = new System.Windows.Forms.Button();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.btnBuscador = new System.Windows.Forms.Button();
            this.pboxBuscador = new System.Windows.Forms.PictureBox();
            this.bTNBack = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
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
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventario.ColumnHeadersHeight = 45;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInventario.EnableHeadersVisualStyles = false;
            this.dgvInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvInventario.Location = new System.Drawing.Point(24, 220);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInventario.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInventario.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(1230, 561);
            this.dgvInventario.TabIndex = 3;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.txtBUSCADOR.Location = new System.Drawing.Point(180, 110);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 29;
            this.txtBUSCADOR.Text = "Search";
            // 
            // btnEditarMovimientos
            // 
            this.btnEditarMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarMovimientos.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnEditarMovimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarMovimientos.FlatAppearance.BorderSize = 0;
            this.btnEditarMovimientos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditarMovimientos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditarMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarMovimientos.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarMovimientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnEditarMovimientos.Location = new System.Drawing.Point(941, 801);
            this.btnEditarMovimientos.Name = "btnEditarMovimientos";
            this.btnEditarMovimientos.Size = new System.Drawing.Size(175, 39);
            this.btnEditarMovimientos.TabIndex = 38;
            this.btnEditarMovimientos.Text = "EDITAR MOVIMIENTOS";
            this.btnEditarMovimientos.UseVisualStyleBackColor = false;
            this.btnEditarMovimientos.Click += new System.EventHandler(this.btnEditarMovimientos_Click);
            // 
            // btnActualizarBDD
            // 
            this.btnActualizarBDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarBDD.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarBDD.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnActualizarBDD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizarBDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarBDD.FlatAppearance.BorderSize = 0;
            this.btnActualizarBDD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnActualizarBDD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizarBDD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarBDD.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarBDD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnActualizarBDD.Location = new System.Drawing.Point(579, 801);
            this.btnActualizarBDD.Name = "btnActualizarBDD";
            this.btnActualizarBDD.Size = new System.Drawing.Size(175, 39);
            this.btnActualizarBDD.TabIndex = 37;
            this.btnActualizarBDD.Text = "ACTUALIZAR BDD";
            this.btnActualizarBDD.UseVisualStyleBackColor = false;
            this.btnActualizarBDD.Click += new System.EventHandler(this.btnActualizarBDD_Click);
            // 
            // btnActualizarProducto
            // 
            this.btnActualizarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizarProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnActualizarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarProducto.FlatAppearance.BorderSize = 0;
            this.btnActualizarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnActualizarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnActualizarProducto.Location = new System.Drawing.Point(760, 801);
            this.btnActualizarProducto.Name = "btnActualizarProducto";
            this.btnActualizarProducto.Size = new System.Drawing.Size(175, 39);
            this.btnActualizarProducto.TabIndex = 36;
            this.btnActualizarProducto.Text = "EDITAR LUGARES";
            this.btnActualizarProducto.UseVisualStyleBackColor = false;
            this.btnActualizarProducto.Click += new System.EventHandler(this.btnActualizarProducto_Click);
            // 
            // btnSALIDA
            // 
            this.btnSALIDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSALIDA.BackColor = System.Drawing.Color.Transparent;
            this.btnSALIDA.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnSALIDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSALIDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSALIDA.FlatAppearance.BorderSize = 0;
            this.btnSALIDA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSALIDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
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
            // btnReingresarProducto
            // 
            this.btnReingresarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReingresarProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnReingresarProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnReingresarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReingresarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReingresarProducto.FlatAppearance.BorderSize = 0;
            this.btnReingresarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReingresarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReingresarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReingresarProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReingresarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnReingresarProducto.Location = new System.Drawing.Point(245, 801);
            this.btnReingresarProducto.Name = "btnReingresarProducto";
            this.btnReingresarProducto.Size = new System.Drawing.Size(189, 39);
            this.btnReingresarProducto.TabIndex = 34;
            this.btnReingresarProducto.Text = "REINGRESAR PRODUCTO";
            this.btnReingresarProducto.UseVisualStyleBackColor = false;
            this.btnReingresarProducto.Click += new System.EventHandler(this.btnReingresarProducto_Click);
            // 
            // btnAgregarNuevoProducto
            // 
            this.btnAgregarNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarNuevoProducto.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarNuevoProducto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnAgregarNuevoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarNuevoProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarNuevoProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevoProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarNuevoProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
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
            // btnEscanear
            // 
            this.btnEscanear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEscanear.BackColor = System.Drawing.Color.Transparent;
            this.btnEscanear.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnEscanear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEscanear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEscanear.FlatAppearance.BorderSize = 0;
            this.btnEscanear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEscanear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscanear.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscanear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnEscanear.Location = new System.Drawing.Point(567, 157);
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
            this.btnBuscador.Location = new System.Drawing.Point(145, 110);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(31, 25);
            this.btnBuscador.TabIndex = 30;
            this.btnBuscador.UseVisualStyleBackColor = false;
            // 
            // pboxBuscador
            // 
            this.pboxBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxBuscador.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pboxBuscador.Location = new System.Drawing.Point(120, 100);
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
            this.bTNBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bTNBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 19;
            this.bTNBack.UseVisualStyleBackColor = false;
            this.bTNBack.Click += new System.EventHandler(this.bkBack_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnActualizar.Location = new System.Drawing.Point(1140, 30);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 39);
            this.btnActualizar.TabIndex = 46;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEditarMovimientos);
            this.Controls.Add(this.btnActualizarBDD);
            this.Controls.Add(this.btnActualizarProducto);
            this.Controls.Add(this.btnSALIDA);
            this.Controls.Add(this.btnReingresarProducto);
            this.Controls.Add(this.btnAgregarNuevoProducto);
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
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label INVENTARIOTITLE;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Button btnBuscador;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pboxBuscador;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.Button btnAgregarNuevoProducto;
        private System.Windows.Forms.Button btnReingresarProducto;
        private System.Windows.Forms.Button btnSALIDA;
        private System.Windows.Forms.Button btnActualizarProducto;
        private System.Windows.Forms.Button btnActualizarBDD;
        private System.Windows.Forms.Button btnEditarMovimientos;
        private System.Windows.Forms.Button btnActualizar;
    }
}