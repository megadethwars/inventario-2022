﻿
namespace COMPRAS2
{
    partial class SALIDA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.lblSALIDA = new System.Windows.Forms.Label();
            this.pboxBuscador = new System.Windows.Forms.PictureBox();
            this.bTNBack = new System.Windows.Forms.Button();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.btnBuscador = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.dgvSalida = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.White;
            this.txtBUSCADOR.Location = new System.Drawing.Point(191, 104);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(924, 19);
            this.txtBUSCADOR.TabIndex = 68;
            this.txtBUSCADOR.Text = "AGREGAR ID";
            this.txtBUSCADOR.Click += new System.EventHandler(this.txtBUSCADOR_Click);
            this.txtBUSCADOR.TextChanged += new System.EventHandler(this.txtBUSCADOR_TextChanged);
            this.txtBUSCADOR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckEnter);
            // 
            // lblSALIDA
            // 
            this.lblSALIDA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSALIDA.AutoSize = true;
            this.lblSALIDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSALIDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblSALIDA.Location = new System.Drawing.Point(560, 30);
            this.lblSALIDA.Name = "lblSALIDA";
            this.lblSALIDA.Size = new System.Drawing.Size(139, 39);
            this.lblSALIDA.TabIndex = 65;
            this.lblSALIDA.Text = "SALIDA";
            // 
            // pboxBuscador
            // 
            this.pboxBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxBuscador.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pboxBuscador.Location = new System.Drawing.Point(123, 83);
            this.pboxBuscador.Name = "pboxBuscador";
            this.pboxBuscador.Size = new System.Drawing.Size(1036, 56);
            this.pboxBuscador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBuscador.TabIndex = 67;
            this.pboxBuscador.TabStop = false;
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
            this.bTNBack.TabIndex = 66;
            this.bTNBack.UseVisualStyleBackColor = true;
            this.bTNBack.Click += new System.EventHandler(this.bTNBack_Click);
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCarrito.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCarrito.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnAgregarCarrito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCarrito.FlatAppearance.BorderSize = 0;
            this.btnAgregarCarrito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCarrito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnAgregarCarrito.Location = new System.Drawing.Point(1009, 669);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(234, 73);
            this.btnAgregarCarrito.TabIndex = 93;
            this.btnAgregarCarrito.Text = "AGREGAR AL CARRITO";
            this.btnAgregarCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click);
            // 
            // btnBuscador
            // 
            this.btnBuscador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btnBuscador.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btnBuscador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscador.FlatAppearance.BorderSize = 0;
            this.btnBuscador.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscador.Location = new System.Drawing.Point(154, 103);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(31, 25);
            this.btnBuscador.TabIndex = 101;
            this.btnBuscador.UseVisualStyleBackColor = false;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lbCount.Location = new System.Drawing.Point(1133, 51);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(26, 29);
            this.lbCount.TabIndex = 102;
            this.lbCount.Text = "0";
            // 
            // dgvSalida
            // 
            this.dgvSalida.AllowUserToOrderColumns = true;
            this.dgvSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalida.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalida.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.dgvSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalida.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalida.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalida.ColumnHeadersHeight = 45;
            this.dgvSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalida.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalida.EnableHeadersVisualStyles = false;
            this.dgvSalida.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvSalida.Location = new System.Drawing.Point(435, 169);
            this.dgvSalida.Name = "dgvSalida";
            this.dgvSalida.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSalida.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSalida.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalida.Size = new System.Drawing.Size(409, 573);
            this.dgvSalida.StandardTab = true;
            this.dgvSalida.TabIndex = 3;
            this.dgvSalida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalida_CellContentClick);
            this.dgvSalida.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCarritoSalida_CellMouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(265, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(328, 24);
            this.dataGridView1.TabIndex = 104;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SALIDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 788);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvSalida);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnBuscador);
            this.Controls.Add(this.btnAgregarCarrito);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pboxBuscador);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.lblSALIDA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SALIDA";
            this.Text = "SALIDA";
            this.Load += new System.EventHandler(this.SALIDA_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBuscador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pboxBuscador;
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Label lblSALIDA;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.Button btnBuscador;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.DataGridView dgvSalida;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}