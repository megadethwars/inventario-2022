
namespace COMPRAS2
{
    partial class EDITAR_REPORTES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDITAR_REPORTES));
            this.EDITARREPORTESTITLE = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblDComentarios = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // EDITARREPORTESTITLE
            // 
            this.EDITARREPORTESTITLE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EDITARREPORTESTITLE.AutoSize = true;
            this.EDITARREPORTESTITLE.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDITARREPORTESTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.EDITARREPORTESTITLE.Location = new System.Drawing.Point(560, 30);
            this.EDITARREPORTESTITLE.Name = "EDITARREPORTESTITLE";
            this.EDITARREPORTESTITLE.Size = new System.Drawing.Size(184, 42);
            this.EDITARREPORTESTITLE.TabIndex = 24;
            this.EDITARREPORTESTITLE.Text = "EDITAR REPORTES";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = global::COMPRAS2.Properties.Resources.LINEA;
            this.pictureBox5.Location = new System.Drawing.Point(375, 165);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(2000, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(550, 3);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 145;
            this.pictureBox5.TabStop = false;
            // 
            // lblDComentarios
            // 
            this.lblDComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDComentarios.AutoSize = true;
            this.lblDComentarios.Font = new System.Drawing.Font("Knockout 48 Featherweight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDComentarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblDComentarios.Location = new System.Drawing.Point(375, 170);
            this.lblDComentarios.Name = "lblDComentarios";
            this.lblDComentarios.Size = new System.Drawing.Size(125, 32);
            this.lblDComentarios.TabIndex = 128;
            this.lblDComentarios.Text = "COMENTARIOS:";
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(1150, 800);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 34);
            this.btnOK.TabIndex = 157;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.btnBack.TabIndex = 158;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtComentarios
            // 
            this.txtComentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(8)))), ((int)(((byte)(70)))));
            this.txtComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.txtComentarios.Location = new System.Drawing.Point(228, 246);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(860, 233);
            this.txtComentarios.TabIndex = 159;
            // 
            // EDITAR_REPORTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lblDComentarios);
            this.Controls.Add(this.EDITARREPORTESTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EDITAR_REPORTES";
            this.Text = "EDITAR REPORTES";
            this.Load += new System.EventHandler(this.EDITAR_REPORTES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EDITARREPORTESTITLE;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblDComentarios;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtComentarios;
    }
}