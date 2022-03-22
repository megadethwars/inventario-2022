
namespace COMPRAS2
{
    partial class INICIARSESION
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
            this.USERID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCERRAR = new System.Windows.Forms.PictureBox();
            this.btnMIN = new System.Windows.Forms.PictureBox();
            this.PASSWORD = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnSingIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCERRAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // USERID
            // 
            this.USERID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.USERID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.USERID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.USERID.Location = new System.Drawing.Point(87, 457);
            this.USERID.Name = "USERID";
            this.USERID.Size = new System.Drawing.Size(231, 24);
            this.USERID.TabIndex = 2;
            this.USERID.Text = "User ID";
            this.USERID.Click += new System.EventHandler(this.USERID_Click);
            this.USERID.Leave += new System.EventHandler(this.USERID_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Knockout 48 Featherweight", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.label1.Location = new System.Drawing.Point(114, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "INICIAR SESION";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCERRAR);
            this.panel1.Controls.Add(this.btnMIN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 37);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnCERRAR
            // 
            this.btnCERRAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCERRAR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCERRAR.Image = global::COMPRAS2.Properties.Resources.exit;
            this.btnCERRAR.Location = new System.Drawing.Point(370, 3);
            this.btnCERRAR.Name = "btnCERRAR";
            this.btnCERRAR.Size = new System.Drawing.Size(30, 30);
            this.btnCERRAR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnCERRAR.TabIndex = 6;
            this.btnCERRAR.TabStop = false;
            this.btnCERRAR.Click += new System.EventHandler(this.btnCERRAR_Click);
            // 
            // btnMIN
            // 
            this.btnMIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMIN.Image = global::COMPRAS2.Properties.Resources.min;
            this.btnMIN.Location = new System.Drawing.Point(334, 3);
            this.btnMIN.Name = "btnMIN";
            this.btnMIN.Size = new System.Drawing.Size(30, 30);
            this.btnMIN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMIN.TabIndex = 8;
            this.btnMIN.TabStop = false;
            this.btnMIN.Click += new System.EventHandler(this.btnMIN_Click);
            // 
            // PASSWORD
            // 
            this.PASSWORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PASSWORD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PASSWORD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.PASSWORD.Location = new System.Drawing.Point(85, 508);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(250, 24);
            this.PASSWORD.TabIndex = 12;
            this.PASSWORD.Text = "Password";
            this.PASSWORD.Click += new System.EventHandler(this.PASSWORD_Click);
            this.PASSWORD.Leave += new System.EventHandler(this.PASSWORD_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::COMPRAS2.Properties.Resources.Broadcast_Division;
            this.pictureBox3.Location = new System.Drawing.Point(67, 238);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(261, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::COMPRAS2.Properties.Resources.AVS_Design;
            this.pictureBox2.Location = new System.Drawing.Point(145, 204);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::COMPRAS2.Properties.Resources.AudioVideoSolutionsLogo;
            this.pictureBox1.Location = new System.Drawing.Point(144, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::COMPRAS2.Properties.Resources.Rectángulo_1_copia;
            this.pictureBox4.Location = new System.Drawing.Point(74, 443);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(261, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::COMPRAS2.Properties.Resources.Rectángulo_2_copia;
            this.pictureBox5.Location = new System.Drawing.Point(74, 499);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(261, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 18;
            this.pictureBox5.TabStop = false;
            // 
            // btnSingIn
            // 
            this.btnSingIn.BackgroundImage = global::COMPRAS2.Properties.Resources.specialbutton2;
            this.btnSingIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSingIn.FlatAppearance.BorderSize = 0;
            this.btnSingIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSingIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingIn.Location = new System.Drawing.Point(74, 690);
            this.btnSingIn.Name = "btnSingIn";
            this.btnSingIn.Size = new System.Drawing.Size(261, 54);
            this.btnSingIn.TabIndex = 20;
            this.btnSingIn.UseVisualStyleBackColor = true;
            this.btnSingIn.Click += new System.EventHandler(this.btnSingIn_Click);
            // 
            // INICIARSESION
            // 
            this.AcceptButton = this.btnSingIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 800);
            this.Controls.Add(this.btnSingIn);
            this.Controls.Add(this.USERID);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "INICIARSESION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIARSESION";
            this.Load += new System.EventHandler(this.INICIARSESION_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCERRAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox USERID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnCERRAR;
        private System.Windows.Forms.PictureBox btnMIN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PASSWORD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnSingIn;
    }
}