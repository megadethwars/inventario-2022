﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPRAS2.servicios
{
    public class VG
    {
        public static string url = "https://avsinventoryswagger25.azurewebsites.net/api/v1/";
        public static int offssetpage = 35;
        public static int id_current_lugar = 0;
        public static string current_lugar = "";
        public static string dbsqlite = "dbMovements.db";
    }
}
