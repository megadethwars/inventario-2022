
namespace COMPRAS2
{
    partial class HIST
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
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.lblHISTORIAL = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnBUSQUEDAAVANZADA = new System.Windows.Forms.Button();
            this.btBUSCADOR = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.txtBUSCADOR.Location = new System.Drawing.Point(181, 153);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 32;
            this.txtBUSCADOR.Text = "Search";
            // 
            // lblHISTORIAL
            // 
            this.lblHISTORIAL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHISTORIAL.AutoSize = true;
            this.lblHISTORIAL.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHISTORIAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblHISTORIAL.Location = new System.Drawing.Point(560, 30);
            this.lblHISTORIAL.Name = "lblHISTORIAL";
            this.lblHISTORIAL.Size = new System.Drawing.Size(116, 42);
            this.lblHISTORIAL.TabIndex = 34;
            this.lblHISTORIAL.Text = "HISTORIAL";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(58, 240);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(1158, 583);
            this.dgvHistorial.TabIndex = 35;
            this.dgvHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnBUSQUEDAAVANZADA
            // 
            this.btnBUSQUEDAAVANZADA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBUSQUEDAAVANZADA.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnBUSQUEDAAVANZADA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBUSQUEDAAVANZADA.FlatAppearance.BorderSize = 0;
            this.btnBUSQUEDAAVANZADA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBUSQUEDAAVANZADA.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBUSQUEDAAVANZADA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnBUSQUEDAAVANZADA.Location = new System.Drawing.Point(530, 91);
            this.btnBUSQUEDAAVANZADA.Name = "btnBUSQUEDAAVANZADA";
            this.btnBUSQUEDAAVANZADA.Size = new System.Drawing.Size(187, 34);
            this.btnBUSQUEDAAVANZADA.TabIndex = 37;
            this.btnBUSQUEDAAVANZADA.Text = "BUSQUEDA AVANZADA";
            this.btnBUSQUEDAAVANZADA.UseVisualStyleBackColor = true;
            this.btnBUSQUEDAAVANZADA.Click += new System.EventHandler(this.btnBUSQUEDAAVANZADA_Click);
            // 
            // btBUSCADOR
            // 
            this.btBUSCADOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btBUSCADOR.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btBUSCADOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBUSCADOR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBUSCADOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBUSCADOR.Location = new System.Drawing.Point(144, 152);
            this.btBUSCADOR.Name = "btBUSCADOR";
            this.btBUSCADOR.Size = new System.Drawing.Size(31, 25);
            this.btBUSCADOR.TabIndex = 33;
            this.btBUSCADOR.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pictureBox2.Location = new System.Drawing.Point(123, 143);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1036, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 50);
            this.btnBack.TabIndex = 30;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // HIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.btnBUSQUEDAAVANZADA);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblHISTORIAL);
            this.Controls.Add(this.btBUSCADOR);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnBack);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HIST";
            this.Text = "HIST";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btBUSCADOR;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblHISTORIAL;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnBUSQUEDAAVANZADA;
    }
}