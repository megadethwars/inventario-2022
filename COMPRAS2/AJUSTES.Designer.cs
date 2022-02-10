
namespace COMPRAS2
{
    partial class AJUSTES
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
            this.lblPerfil = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblPerfil
            // 
            this.lblPerfil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblPerfil.Location = new System.Drawing.Point(490, 25);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(101, 42);
            this.lblPerfil.TabIndex = 20;
            this.lblPerfil.Text = "AJUSTES";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(111, 225);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 27;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // AJUSTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1089, 647);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AJUSTES";
            this.Text = "AJUSTES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}