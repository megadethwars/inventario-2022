
namespace COMPRAS2
{
    partial class ACTUALIZAR_BDD
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
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lblTituloAgregarProducto = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.OFDActualizar = new System.Windows.Forms.OpenFileDialog();
            this.porcentaje = new System.Windows.Forms.Label();
            this.btnSelArchivo = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCodigoQR
            // 
            this.lblCodigoQR.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCodigoQR.AutoSize = true;
            this.lblCodigoQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblCodigoQR.Location = new System.Drawing.Point(437, 608);
            this.lblCodigoQR.Name = "lblCodigoQR";
            this.lblCodigoQR.Size = new System.Drawing.Size(362, 31);
            this.lblCodigoQR.TabIndex = 56;
            this.lblCodigoQR.Text = "PORCENTAJE DE CARGA :";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblNombreArchivo.Location = new System.Drawing.Point(512, 125);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(333, 31);
            this.lblNombreArchivo.TabIndex = 55;
            this.lblNombreArchivo.Text = "NOMBRE DEL ARCHIVO:";
            // 
            // lblTituloAgregarProducto
            // 
            this.lblTituloAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloAgregarProducto.AutoSize = true;
            this.lblTituloAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAgregarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblTituloAgregarProducto.Location = new System.Drawing.Point(467, 30);
            this.lblTituloAgregarProducto.Name = "lblTituloAgregarProducto";
            this.lblTituloAgregarProducto.Size = new System.Drawing.Size(517, 39);
            this.lblTituloAgregarProducto.TabIndex = 54;
            this.lblTituloAgregarProducto.Text = "ACTUALIZAR BASE DE DATOS";
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
            this.btnBack.TabIndex = 57;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OFDActualizar
            // 
            this.OFDActualizar.FileName = "OFDActualizar";
            // 
            // porcentaje
            // 
            this.porcentaje.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.porcentaje.AutoSize = true;
            this.porcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.porcentaje.Location = new System.Drawing.Point(805, 608);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(60, 31);
            this.porcentaje.TabIndex = 64;
            this.porcentaje.Text = "0 %";
            // 
            // btnSelArchivo
            // 
            this.btnSelArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelArchivo.BackColor = System.Drawing.Color.Transparent;
            this.btnSelArchivo.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnSelArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelArchivo.FlatAppearance.BorderSize = 0;
            this.btnSelArchivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSelArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSelArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnSelArchivo.Location = new System.Drawing.Point(518, 195);
            this.btnSelArchivo.Name = "btnSelArchivo";
            this.btnSelArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelArchivo.Size = new System.Drawing.Size(197, 39);
            this.btnSelArchivo.TabIndex = 65;
            this.btnSelArchivo.Text = "SELECCIONAR ";
            this.btnSelArchivo.UseVisualStyleBackColor = false;
            this.btnSelArchivo.Click += new System.EventHandler(this.btnSelArchivo_Click);
            // 
            // btnInit
            // 
            this.btnInit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInit.BackColor = System.Drawing.Color.Transparent;
            this.btnInit.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnInit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInit.FlatAppearance.BorderSize = 0;
            this.btnInit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnInit.Location = new System.Drawing.Point(518, 261);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(197, 39);
            this.btnInit.TabIndex = 66;
            this.btnInit.Text = "INICIAR";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnStop.Location = new System.Drawing.Point(518, 320);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(197, 39);
            this.btnStop.TabIndex = 67;
            this.btnStop.Text = "DETENER";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ACTUALIZAR_BDD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 788);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnSelArchivo);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCodigoQR);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.lblTituloAgregarProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ACTUALIZAR_BDD";
            this.Text = "ACTUALIZAR_BDD";
            this.Load += new System.EventHandler(this.ACTUALIZAR_BDD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblTituloAgregarProducto;
        private System.Windows.Forms.OpenFileDialog OFDActualizar;
        private System.Windows.Forms.Label porcentaje;
        private System.Windows.Forms.Button btnSelArchivo;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStop;
    }
}