using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;

namespace COMPRAS2.servicios
{
    public class SyncMoveManager
    {
        public SyncMoveManager()
        {

        }
        public void SyncMovesToAzure(string idMovement)
        {
            var movement = SqliteHandler.Selectregister("fghfhfhfhfhf");
            int a = 1;

            bool status = SqliteHandler.updateRegister("fghfhfhfhfhf");
        }

        public  void WriteMovesToSqlite(List<Movimientos> movimientos)
        {
            Movimientos mov = new Movimientos();
            mov.idMovimiento = "123456";
            mov.dispositivoId = 10;
            mov.usuarioId = 1;
            mov.LugarId = 10;
            mov.tipoMovId = 2;
            mov.cantidad_Actual = 10;
            
            SqliteHandler.insertRegister(mov);
        }

        

        public void deleteMovesSqlite()
        {

        }

    }
}
