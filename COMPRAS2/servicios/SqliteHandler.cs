using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;


namespace COMPRAS2.servicios
{
    public class SqliteHandler
    {

        public bool insertRegister(Movimientos movimiento)
        {
            return true;
        }

        public bool updateRegister(bool status)
        {
            return true;
        }

        public Movimientos Selectregister(string idMovimiento)
        {
            return null;
        }

        public Movimientos Selectregister(int id)
        {
            return null;
        }

        public bool deleteregister(string idMovimiento)
        {
            return true;
        }

        public bool deleteregister(int status)
        {
            return true;
        }

    }

}
