
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
            this.btnDETENER = new System.Windows.Forms.Button();
            this.btnINICIAR = new System.Windows.Forms.Button();
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.OFDActualizar = new System.Windows.Forms.OpenFileDialog();
            this.porcentaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigoQR
            // 
            this.lblCodigoQR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCodigoQR.AutoSize = true;
            this.lblCodigoQR.Font = new System.Drawing.Font("Knockout 48 Featherweight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblCodigoQR.Location = new System.Drawing.Point(559, 197);
            this.lblCodigoQR.Name = "lblCodigoQR";
            this.lblCodigoQR.Size = new System.Drawing.Size(193, 32);
            this.lblCodigoQR.TabIndex = 56;
            this.lblCodigoQR.Text = "PORCENTAJE DE CARGA :";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Knockout 48 Featherweight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblNombreArchivo.Location = new System.Drawing.Point(559, 128);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(183, 32);
            this.lblNombreArchivo.TabIndex = 55;
            this.lblNombreArchivo.Text = "NOMBRE DEL ARCHIVO:";
            // 
            // lblTituloAgregarProducto
            // 
            this.lblTituloAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloAgregarProducto.AutoSize = true;
            this.lblTituloAgregarProducto.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAgregarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblTituloAgregarProducto.Location = new System.Drawing.Point(560, 30);
            this.lblTituloAgregarProducto.Name = "lblTituloAgregarProducto";
            this.lblTituloAgregarProducto.Size = new System.Drawing.Size(279, 42);
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
            // btnDETENER
            // 
            this.btnDETENER.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDETENER.BackColor = System.Drawing.Color.Transparent;
            this.btnDETENER.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnDETENER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDETENER.Cursor = System.Windows.Forms.Cursors.PanSW;
            this.btnDETENER.FlatAppearance.BorderSize = 0;
            this.btnDETENER.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDETENER.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDETENER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDETENER.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDETENER.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnDETENER.Location = new System.Drawing.Point(567, 412);
            this.btnDETENER.MaximumSize = new System.Drawing.Size(175, 39);
            this.btnDETENER.Name = "btnDETENER";
            this.btnDETENER.Size = new System.Drawing.Size(175, 39);
            this.btnDETENER.TabIndex = 61;
            this.btnDETENER.Text = "DETENER";
            this.btnDETENER.UseVisualStyleBackColor = false;
            this.btnDETENER.Click += new System.EventHandler(this.btnDETENER_Click);
            // 
            // btnINICIAR
            // 
            this.btnINICIAR.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnINICIAR.BackColor = System.Drawing.Color.Transparent;
            this.btnINICIAR.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnINICIAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnINICIAR.Cursor = System.Windows.Forms.Cursors.PanSW;
            this.btnINICIAR.FlatAppearance.BorderSize = 0;
            this.btnINICIAR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnINICIAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnINICIAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnINICIAR.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINICIAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnINICIAR.Location = new System.Drawing.Point(567, 339);
            this.btnINICIAR.MaximumSize = new System.Drawing.Size(175, 39);
            this.btnINICIAR.Name = "btnINICIAR";
            this.btnINICIAR.Size = new System.Drawing.Size(175, 39);
            this.btnINICIAR.TabIndex = 62;
            this.btnINICIAR.Text = "INICIAR";
            this.btnINICIAR.UseVisualStyleBackColor = false;
            this.btnINICIAR.Click += new System.EventHandler(this.btnINICIAR_Click);
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSeleccionarArchivo.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarArchivo.BackgroundImage = global::COMPRAS2.Properties.Resources.BUTTON2;
            this.btnSeleccionarArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeleccionarArchivo.Cursor = System.Windows.Forms.Cursors.PanSW;
            this.btnSeleccionarArchivo.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarArchivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarArchivo.Font = new System.Drawing.Font("Knockout 48 Featherweight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(567, 274);
            this.btnSeleccionarArchivo.MaximumSize = new System.Drawing.Size(175, 39);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(175, 39);
            this.btnSeleccionarArchivo.TabIndex = 63;
            this.btnSeleccionarArchivo.Text = "SELECCIONAR ARCHIVO";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = false;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // OFDActualizar
            // 
            this.OFDActualizar.FileName = "OFDActualizar";
            // 
            // porcentaje
            // 
            this.porcentaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.porcentaje.AutoSize = true;
            this.porcentaje.Font = new System.Drawing.Font("Knockout 48 Featherweight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.porcentaje.Location = new System.Drawing.Point(758, 197);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(42, 32);
            this.porcentaje.TabIndex = 64;
            this.porcentaje.Text = "0 %";
            // 
            // ACTUALIZAR_BDD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 788);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Controls.Add(this.btnINICIAR);
            this.Controls.Add(this.btnDETENER);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCodigoQR);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.lblTituloAgregarProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ACTUALIZAR_BDD";
            this.Text = "ACTUALIZAR_BDD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblTituloAgregarProducto;
        private System.Windows.Forms.Button btnDETENER;
        private System.Windows.Forms.Button btnINICIAR;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.OpenFileDialog OFDActualizar;
        private System.Windows.Forms.Label porcentaje;
    }
}