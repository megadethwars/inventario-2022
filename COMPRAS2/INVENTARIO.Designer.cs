
namespace COMPRAS2
{
    partial class INVENTARIO
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
            this.INVENTARIOTITLE = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.brnOPCIONES = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBUSCADOR = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btBUSCADOR = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bTNBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // INVENTARIOTITLE
            // 
            this.INVENTARIOTITLE.AutoSize = true;
            this.INVENTARIOTITLE.Font = new System.Drawing.Font("Knockout 48 Featherweight", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INVENTARIOTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(202)))));
            this.INVENTARIOTITLE.Location = new System.Drawing.Point(471, 26);
            this.INVENTARIOTITLE.Name = "INVENTARIOTITLE";
            this.INVENTARIOTITLE.Size = new System.Drawing.Size(129, 42);
            this.INVENTARIOTITLE.TabIndex = 2;
            this.INVENTARIOTITLE.Text = "INVENTARIO";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1040, 338);
            this.dataGridView1.TabIndex = 3;
            // 
            // brnOPCIONES
            // 
            this.brnOPCIONES.BackColor = System.Drawing.Color.Black;
            this.brnOPCIONES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnOPCIONES.ForeColor = System.Drawing.Color.Red;
            this.brnOPCIONES.Location = new System.Drawing.Point(24, 587);
            this.brnOPCIONES.Name = "brnOPCIONES";
            this.brnOPCIONES.Size = new System.Drawing.Size(114, 39);
            this.brnOPCIONES.TabIndex = 6;
            this.brnOPCIONES.Text = "OPCIONES";
            this.brnOPCIONES.UseVisualStyleBackColor = false;
            this.brnOPCIONES.Click += new System.EventHandler(this.brnOPCIONES_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(177, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Marca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(317, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Codigo QR:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(498, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modelo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(668, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Serie:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(797, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ubicacion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(976, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Dest:";
            // 
            // txtBUSCADOR
            // 
            this.txtBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(79)))));
            this.txtBUSCADOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBUSCADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBUSCADOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(75)))), ((int)(((byte)(120)))));
            this.txtBUSCADOR.Location = new System.Drawing.Point(86, 109);
            this.txtBUSCADOR.Name = "txtBUSCADOR";
            this.txtBUSCADOR.Size = new System.Drawing.Size(934, 19);
            this.txtBUSCADOR.TabIndex = 29;
            this.txtBUSCADOR.Text = "Search";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(478, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 39);
            this.button1.TabIndex = 31;
            this.button1.Text = "OPCIONES";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btBUSCADOR
            // 
            this.btBUSCADOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(18)))), ((int)(((byte)(77)))));
            this.btBUSCADOR.BackgroundImage = global::COMPRAS2.Properties.Resources.lupa;
            this.btBUSCADOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBUSCADOR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBUSCADOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBUSCADOR.Location = new System.Drawing.Point(49, 108);
            this.btBUSCADOR.Name = "btBUSCADOR";
            this.btBUSCADOR.Size = new System.Drawing.Size(31, 25);
            this.btBUSCADOR.TabIndex = 30;
            this.btBUSCADOR.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::COMPRAS2.Properties.Resources.SEARCH;
            this.pictureBox2.Location = new System.Drawing.Point(28, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1036, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // bTNBack
            // 
            this.bTNBack.BackgroundImage = global::COMPRAS2.Properties.Resources.BACK;
            this.bTNBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTNBack.Location = new System.Drawing.Point(28, 30);
            this.bTNBack.Name = "bTNBack";
            this.bTNBack.Size = new System.Drawing.Size(50, 50);
            this.bTNBack.TabIndex = 19;
            this.bTNBack.UseVisualStyleBackColor = true;
            this.bTNBack.Click += new System.EventHandler(this.bkBack_Click);
            // 
            // INVENTARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1089, 647);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btBUSCADOR);
            this.Controls.Add(this.txtBUSCADOR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bTNBack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brnOPCIONES);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.INVENTARIOTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "INVENTARIO";
            this.Text = "INVENTARIO";
            this.Load += new System.EventHandler(this.INVENTARIO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label INVENTARIOTITLE;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button brnOPCIONES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bTNBack;
        private System.Windows.Forms.Button btBUSCADOR;
        private System.Windows.Forms.TextBox txtBUSCADOR;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
    }
}