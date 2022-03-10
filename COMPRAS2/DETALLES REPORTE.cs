﻿using COMPRAS2.modelos;
using COMPRAS2.servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPRAS2
{
    public partial class DETALLES_REPORTE : Form
    {
        Reportes reportes;
        public DETALLES_REPORTE(Reportes reportes)
        {
            InitializeComponent();
            this.reportes = reportes;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new EDITAR_REPORTES());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigator.backPage(this.Name, this);
        }

        private void DETALLES_REPORTE_Load(object sender, EventArgs e)
        {
            //lblNombre.Text = reportes.nombre;
            lblComentarios.Text = reportes.comentarios;
        }
    }
}
