using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;
using Newtonsoft.Json;

namespace COMPRAS2.servicios
{
    public class SyncMoveManager
    {
        public SyncMoveManager()
        {

        }
        public async static void SyncMovesToAzure(string idMovement)
        {
            var movements = SqliteHandler.Selectregister(idMovement);
            if (movements != null)
            {
                foreach (Movimientos movement in movements)
                {
                    if (await postMovementApi(movement))
                    {
                        SqliteHandler.updateRegister(movement.idMovimiento);
                    }
                }
            }
            

            //bool status = SqliteHandler.updateRegister(movement.idMovimiento);
        }

        public async void SyncMovesToAzurethread(string idMovement)
        {
            var movements = SqliteHandler.Selectregister();

            if (movements != null)
            {
                foreach (Movimientos movement in movements)
                {
                    if (await postMovementApi(movement))
                    {
                        SqliteHandler.updateRegister(movement.idMovimiento);
                    }
                }
            }

            

            //bool status = SqliteHandler.updateRegister(movement.idMovimiento);
        }

        private async static Task<bool> postMovementApi(Movimientos movement)
        {
            try
            {
                List<Movimientos> movimientos = new List<Movimientos>();
                movimientos.Add(movement);

                string json = JsonConvert.SerializeObject(movimientos,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                var url = HttpMethods.url + "movimientos";
                StatusMessage statusmessage = await HttpMethods.Post(url, json);

                if (statusmessage.statuscode == 409)
                {

                }

                else if (statusmessage.statuscode == 500)
                {

                }
                else if (statusmessage.statuscode == 200)
                {


                }
                else if (statusmessage.statuscode == 404)
                {
                    //MessageBox.Show("error en el servicio, NO encontrado");


                }
                movimientos.Clear();
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public static  void WriteMovesToSqlite(List<Movimientos> movimientos,string idMovimiento,int idusuario)
        {

            foreach(Movimientos movement in movimientos)
            {
                movement.idMovimiento = idMovimiento;
                movement.usuarioId = idusuario;   
                SqliteHandler.insertRegister(movement);
            }
            

            SyncMovesToAzure(idMovimiento);
            
        }

        

        public void deleteMovesSqlite()
        {

        }

    }
}
