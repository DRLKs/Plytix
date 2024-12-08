﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class ProductosRelacionadosListar : Form
    {
        grupo11DBEntities db = new grupo11DBEntities();
        public ProductosRelacionadosListar()
        {
            InitializeComponent();
            CargarProductosRelacionados();
        }

        private void CargarProductosRelacionados()
        {
            ProductosRelaciondosdataGridView.DataSource = db.PRODRELACIONADOS.ToList();
        }
    }
}
