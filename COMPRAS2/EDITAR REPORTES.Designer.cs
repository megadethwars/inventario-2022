
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
            this.bTNBack = new System.Windows.Forms.Button();
            this.INVENTARIOTITLE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bTNBack
            // 
            this.bTNBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 25;
            this.bTNBack.UseVisualStyleBackColor = false;
            // 
            // INVENTARIOTITLE
            // 
            this.INVENTARIOTITLE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.INVENTARIOTITLE.AutoSize = true;
            this.INVENTARIOTITLE.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INVENTARIOTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.INVENTARIOTITLE.Location = new System.Drawing.Point(560, 30);
            this.INVENTARIOTITLE.Name = "INVENTARIOTITLE";
            this.INVENTARIOTITLE.Size = new System.Drawing.Size(238, 42);
            this.INVENTARIOTITLE.TabIndex = 24;
            this.INVENTARIOTITLE.Text = "DETALLES DEL REPORTE";
            // 
            // EDITAR_REPORTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.INVENTARIOTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EDITAR_REPORTES";
            this.Text = "EDITAR_REPORTES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Label INVENTARIOTITLE;
    }
}