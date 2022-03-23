
namespace COMPRAS2
{
    partial class EMPLEADOS
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
            this.bTNBack = new System.Windows.Forms.Button();
            this.lblEMPLEADOS = new System.Windows.Forms.Label();
            this.btBUSCADOR = new System.Windows.Forms.Button();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btAgregarEmp = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // bTNBack
            // 
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTNBack.FlatAppearance.BorderSize = 0;
            this.bTNBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bTNBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 23;
            this.bTNBack.UseVisualStyleBackColor = true;
            this.bTNBack.Click += new System.EventHandler(this.bTNBack_Click);
            // 
            // lblEMPLEADOS
            // 
            this.lblEMPLEADOS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEMPLEADOS.AutoSize = true;
            this.lblEMPLEADOS.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMPLEADOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblEMPLEADOS.Location = new System.Drawing.Point(560, 30);
            this.lblEMPLEADOS.Name = "lblEMPLEADOS";
            this.lblEMPLEADOS.Size = new System.Drawing.Size(131, 42);
            this.lblEMPLEADOS.TabIndex = 35;
            this.lblEMPLEADOS.Text = "EMPLEADOS";
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
            this.btBUSCADOR.TabIndex = 38;
            this.btBUSCADOR.UseVisualStyleBackColor = false;
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
            this.txtBUSCADOR.TabIndex = 37;
            this.txtBUSCADOR.Text = "Search";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pictureBox2.Location = new System.Drawing.Point(123, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1036, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // btnEscanear
            // 
            this.btnEscanear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnEscanear.Location = new System.Drawing.Point(12, 810);
            this.btnEscanear.Name = "btnEscanear";
            this.btnEscanear.Size = new System.Drawing.Size(163, 39);
            this.btnEscanear.TabIndex = 39;
            this.btnEscanear.Text = "INGRESAR";
            this.btnEscanear.UseVisualStyleBackColor = false;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.ColumnHeadersHeight = 45;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 180);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1235, 560);
            this.dgvUsuarios.TabIndex = 40;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellMouseEnter);
            // 
            // btAgregarEmp
            // 
            this.btAgregarEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAgregarEmp.BackColor = System.Drawing.Color.Transparent;
            this.btAgregarEmp.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btAgregarEmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAgregarEmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAgregarEmp.FlatAppearance.BorderSize = 0;
            this.btAgregarEmp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btAgregarEmp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btAgregarEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregarEmp.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregarEmp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btAgregarEmp.Location = new System.Drawing.Point(239, 810);
            this.btAgregarEmp.Name = "btAgregarEmp";
            this.btAgregarEmp.Size = new System.Drawing.Size(187, 39);
            this.btAgregarEmp.TabIndex = 41;
            this.btAgregarEmp.Text = "AGREGAR EMPLEADO";
            this.btAgregarEmp.UseVisualStyleBackColor = false;
            this.btAgregarEmp.Click += new System.EventHandler(this.btAgregarEmp_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnActualizar.Location = new System.Drawing.Point(1140, 21);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 39);
            this.btnActualizar.TabIndex = 47;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // EMPLEADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btAgregarEmp);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.btBUSCADOR);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblEMPLEADOS);
            this.Controls.Add(this.bTNBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EMPLEADOS";
            this.Text = "EMPLEADOS";
            this.Load += new System.EventHandler(this.EMPLEADOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Label lblEMPLEADOS;
        private System.Windows.Forms.Button btBUSCADOR;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btAgregarEmp;
        private System.Windows.Forms.Button btnActualizar;
    }
}