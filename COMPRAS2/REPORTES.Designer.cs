
namespace COMPRAS2
{
    partial class REPORTES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTES));
            this.lblREPORTES = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.txtNombreDelProducto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.btnAgregarFoto = new System.Windows.Forms.Button();
            this.btnOPCIONES = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btBUSCADOR = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblREPORTES
            // 
            this.lblREPORTES.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblREPORTES.AutoSize = true;
            this.lblREPORTES.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREPORTES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblREPORTES.Location = new System.Drawing.Point(560, 30);
            this.lblREPORTES.Name = "lblREPORTES";
            this.lblREPORTES.Size = new System.Drawing.Size(243, 42);
            this.lblREPORTES.TabIndex = 5;
            this.lblREPORTES.Text = "CREACION DE REPORTES";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblNombreProducto.Location = new System.Drawing.Point(328, 291);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(233, 20);
            this.lblNombreProducto.TabIndex = 16;
            this.lblNombreProducto.Text = "NOMBRE DEL PRODUCTO:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.label3.Location = new System.Drawing.Point(140, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descripcion:";
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.White;
            this.txtBUSCADOR.Location = new System.Drawing.Point(181, 109);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 25;
            this.txtBUSCADOR.Text = "Search";
            // 
            // txtNombreDelProducto
            // 
            this.txtNombreDelProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombreDelProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtNombreDelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreDelProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDelProducto.ForeColor = System.Drawing.Color.White;
            this.txtNombreDelProducto.Location = new System.Drawing.Point(298, 334);
            this.txtNombreDelProducto.Name = "txtNombreDelProducto";
            this.txtNombreDelProducto.Size = new System.Drawing.Size(600, 26);
            this.txtNombreDelProducto.TabIndex = 67;
            this.txtNombreDelProducto.Text = "Producto";
            this.txtNombreDelProducto.Click += new System.EventHandler(this.txtNombreDelProducto_Click);
            this.txtNombreDelProducto.Leave += new System.EventHandler(this.txtNombreDelProducto_Leave);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(144, 502);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(971, 162);
            this.txtDescripcion.TabIndex = 68;
            this.txtDescripcion.Text = "Escriba Aqui";
            this.txtDescripcion.Click += new System.EventHandler(this.txtDescripcion_Click);
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
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
            this.btnEscanear.Location = new System.Drawing.Point(567, 164);
            this.btnEscanear.Name = "btnEscanear";
            this.btnEscanear.Size = new System.Drawing.Size(107, 39);
            this.btnEscanear.TabIndex = 65;
            this.btnEscanear.Text = "ESCANEAR";
            this.btnEscanear.UseVisualStyleBackColor = false;
            // 
            // btnAgregarFoto
            // 
            this.btnAgregarFoto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarFoto.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnAgregarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarFoto.FlatAppearance.BorderSize = 0;
            this.btnAgregarFoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFoto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnAgregarFoto.Location = new System.Drawing.Point(553, 697);
            this.btnAgregarFoto.Name = "btnAgregarFoto";
            this.btnAgregarFoto.Size = new System.Drawing.Size(160, 39);
            this.btnAgregarFoto.TabIndex = 64;
            this.btnAgregarFoto.Text = "AGREGAR FOTO";
            this.btnAgregarFoto.UseVisualStyleBackColor = false;
            // 
            // btnOPCIONES
            // 
            this.btnOPCIONES.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOPCIONES.BackColor = System.Drawing.Color.Transparent;
            this.btnOPCIONES.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnOPCIONES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOPCIONES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOPCIONES.FlatAppearance.BorderSize = 0;
            this.btnOPCIONES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOPCIONES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOPCIONES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOPCIONES.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOPCIONES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnOPCIONES.Location = new System.Drawing.Point(455, 789);
            this.btnOPCIONES.Name = "btnOPCIONES";
            this.btnOPCIONES.Size = new System.Drawing.Size(160, 39);
            this.btnOPCIONES.TabIndex = 63;
            this.btnOPCIONES.Text = "OPCIONES";
            this.btnOPCIONES.UseVisualStyleBackColor = false;
            this.btnOPCIONES.Click += new System.EventHandler(this.btnOPCIONES_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(682, 795);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 34);
            this.btnOK.TabIndex = 62;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_ClickAsync);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::COMPRAS2.Properties.Resources.LINEA;
            this.pictureBox1.Location = new System.Drawing.Point(298, 281);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 3);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 50);
            this.btnBack.TabIndex = 29;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btBUSCADOR
            // 
            this.btBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btBUSCADOR.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btBUSCADOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBUSCADOR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBUSCADOR.FlatAppearance.BorderSize = 0;
            this.btBUSCADOR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btBUSCADOR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btBUSCADOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBUSCADOR.Location = new System.Drawing.Point(144, 108);
            this.btBUSCADOR.Name = "btBUSCADOR";
            this.btBUSCADOR.Size = new System.Drawing.Size(31, 25);
            this.btBUSCADOR.TabIndex = 27;
            this.btBUSCADOR.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pictureBox2.Location = new System.Drawing.Point(123, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1036, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // REPORTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombreDelProducto);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.btnAgregarFoto);
            this.Controls.Add(this.btnOPCIONES);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btBUSCADOR);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.lblREPORTES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "REPORTES";
            this.Text = "REPORTES";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblREPORTES;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.Button btBUSCADOR;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOPCIONES;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAgregarFoto;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.TextBox txtNombreDelProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}