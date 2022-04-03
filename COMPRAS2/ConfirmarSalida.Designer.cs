
namespace COMPRAS2
{
    partial class ConfirmarSalida
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
            this.lblConfirmarSalida = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbpass = new System.Windows.Forms.TextBox();
            this.cbLugares = new System.Windows.Forms.ComboBox();
            this.bl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConfirmarSalida
            // 
            this.lblConfirmarSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblConfirmarSalida.AutoSize = true;
            this.lblConfirmarSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblConfirmarSalida.Location = new System.Drawing.Point(560, 30);
            this.lblConfirmarSalida.Name = "lblConfirmarSalida";
            this.lblConfirmarSalida.Size = new System.Drawing.Size(357, 39);
            this.lblConfirmarSalida.TabIndex = 70;
            this.lblConfirmarSalida.Text = "CONFIRMAR SALIDA";
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
            this.btnBack.TabIndex = 69;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(540, 192);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(216, 20);
            this.tbUsuario.TabIndex = 71;
            // 
            // tbpass
            // 
            this.tbpass.Location = new System.Drawing.Point(540, 286);
            this.tbpass.Name = "tbpass";
            this.tbpass.Size = new System.Drawing.Size(216, 20);
            this.tbpass.TabIndex = 72;
            // 
            // cbLugares
            // 
            this.cbLugares.FormattingEnabled = true;
            this.cbLugares.Location = new System.Drawing.Point(540, 390);
            this.cbLugares.Name = "cbLugares";
            this.cbLugares.Size = new System.Drawing.Size(216, 21);
            this.cbLugares.TabIndex = 73;
            // 
            // bl1
            // 
            this.bl1.AutoSize = true;
            this.bl1.ForeColor = System.Drawing.SystemColors.Control;
            this.bl1.Location = new System.Drawing.Point(537, 157);
            this.bl1.Name = "bl1";
            this.bl1.Size = new System.Drawing.Size(43, 13);
            this.bl1.TabIndex = 74;
            this.bl1.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(537, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(537, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Lugar de destino";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(540, 461);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(112, 38);
            this.btAceptar.TabIndex = 77;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // ConfirmarSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bl1);
            this.Controls.Add(this.cbLugares);
            this.Controls.Add(this.tbpass);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.lblConfirmarSalida);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmarSalida";
            this.Text = "ConfirmarSalida";
            this.Load += new System.EventHandler(this.ConfirmarSalida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfirmarSalida;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbpass;
        private System.Windows.Forms.ComboBox cbLugares;
        private System.Windows.Forms.Label bl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAceptar;
    }
}