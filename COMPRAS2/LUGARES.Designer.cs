
namespace COMPRAS2
{
    partial class LUGARES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LUGARES));
            this.lblLugares = new System.Windows.Forms.Label();
            this.dgvLugares = new System.Windows.Forms.DataGridView();
            this.txtLugarDeseado = new System.Windows.Forms.TextBox();
            this.lblIngresarLugarDeseado = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.bTNBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLugares)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLugares
            // 
            this.lblLugares.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLugares.AutoSize = true;
            this.lblLugares.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblLugares.Location = new System.Drawing.Point(560, 30);
            this.lblLugares.Name = "lblLugares";
            this.lblLugares.Size = new System.Drawing.Size(103, 42);
            this.lblLugares.TabIndex = 66;
            this.lblLugares.Text = "LUGARES";
            // 
            // dgvLugares
            // 
            this.dgvLugares.AllowUserToOrderColumns = true;
            this.dgvLugares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLugares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLugares.Location = new System.Drawing.Point(364, 99);
            this.dgvLugares.Name = "dgvLugares";
            this.dgvLugares.Size = new System.Drawing.Size(537, 551);
            this.dgvLugares.TabIndex = 67;
            // 
            // txtLugarDeseado
            // 
            this.txtLugarDeseado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLugarDeseado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(8)))), ((int)(((byte)(70)))));
            this.txtLugarDeseado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLugarDeseado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugarDeseado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.txtLugarDeseado.Location = new System.Drawing.Point(477, 709);
            this.txtLugarDeseado.Name = "txtLugarDeseado";
            this.txtLugarDeseado.Size = new System.Drawing.Size(331, 26);
            this.txtLugarDeseado.TabIndex = 75;
            this.txtLugarDeseado.Text = "Ingrese Lugar Deseado";
            // 
            // lblIngresarLugarDeseado
            // 
            this.lblIngresarLugarDeseado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIngresarLugarDeseado.AutoSize = true;
            this.lblIngresarLugarDeseado.Font = new System.Drawing.Font("Knockout 48 Featherweight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresarLugarDeseado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.lblIngresarLugarDeseado.Location = new System.Drawing.Point(531, 674);
            this.lblIngresarLugarDeseado.Name = "lblIngresarLugarDeseado";
            this.lblIngresarLugarDeseado.Size = new System.Drawing.Size(198, 32);
            this.lblIngresarLugarDeseado.TabIndex = 74;
            this.lblIngresarLugarDeseado.Text = "INGRESAR NUEVO LUGAR:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(591, 753);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 34);
            this.btnOK.TabIndex = 76;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // bTNBack
            // 
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(20, 20);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 77;
            this.bTNBack.UseVisualStyleBackColor = true;
            this.bTNBack.Click += new System.EventHandler(this.bTNBack_Click);
            // 
            // LUGARES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1279, 861);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLugarDeseado);
            this.Controls.Add(this.lblIngresarLugarDeseado);
            this.Controls.Add(this.dgvLugares);
            this.Controls.Add(this.lblLugares);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LUGARES";
            this.Text = "LUGARES";
            this.Load += new System.EventHandler(this.LUGARES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLugares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLugares;
        private System.Windows.Forms.DataGridView dgvLugares;
        private System.Windows.Forms.TextBox txtLugarDeseado;
        private System.Windows.Forms.Label lblIngresarLugarDeseado;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button bTNBack;
    }
}