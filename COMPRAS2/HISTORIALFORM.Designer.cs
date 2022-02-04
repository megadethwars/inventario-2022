
namespace COMPRAS2
{
    partial class HISTORIALFORM
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
            this.NAME = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NAME
            // 
            this.NAME.AutoSize = true;
            this.NAME.ForeColor = System.Drawing.Color.White;
            this.NAME.Location = new System.Drawing.Point(345, 222);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(64, 13);
            this.NAME.TabIndex = 0;
            this.NAME.Text = "HISTORIAL";
            // 
            // HISTORIALFORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NAME);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HISTORIALFORM";
            this.Text = "HISTORIAL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NAME;
    }
}