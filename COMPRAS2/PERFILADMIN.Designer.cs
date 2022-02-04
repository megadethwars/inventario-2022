
namespace COMPRAS2
{
    partial class PERFILADMIN
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
            this.button1 = new System.Windows.Forms.Button();
            this.MARCA = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MARCA)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::COMPRAS2.Properties.Resources.AGREGARFOTO;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(746, 540);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(314, 61);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MARCA
            // 
            this.MARCA.Image = global::COMPRAS2.Properties.Resources.AVS_DESIGNE;
            this.MARCA.Location = new System.Drawing.Point(12, 12);
            this.MARCA.Name = "MARCA";
            this.MARCA.Size = new System.Drawing.Size(144, 129);
            this.MARCA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MARCA.TabIndex = 12;
            this.MARCA.TabStop = false;
            // 
            // PERFILADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MARCA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PERFILADMIN";
            this.Text = "PERFILADMIN";
            ((System.ComponentModel.ISupportInitialize)(this.MARCA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MARCA;
        private System.Windows.Forms.Button button1;
    }
}