using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;
using Newtonsoft.Json;

namespace COMPRAS2.servicios
{
    public static class SyncMoveManager
    {
        public delegate void EventHandlerStatus(int dato);

        public static event EventHandlerStatus eventStatus;

        public static int statusId = 0;

        // Método estático protegido para invocar el evento
        private static void OnEvent(int dato)
        {
            eventStatus?.Invoke(dato);
        }
        public async static void SyncMovesToAzure(string idMovement)
        {
            Program.log.Debug("Iniciando sincronizacion de movimientos....");
            OnEvent(1);
            statusId = 1;
            var movements = SqliteHandler.Selectregister(idMovement);
            if (movements != null)
            {
                foreach (Movimientos movement in movements)
                {
                    
                    if (await postMovementApi(movement))
                    {
                        SqliteHandler.updateRegister(movement.idMovimiento,movement.dispositivoId);
                    }
                    
                    
                }
                statusId = 0;
                OnEvent(0);
                Program.log.Debug("Sincronizacion terminada.");
            }
            
        }

        public static int requestStatus() {
            return statusId;
        }
        public async static void SyncMovesToAzurethread()
        {
            Program.log.Debug("Iniciando sincronizacion de movimientos thread....");
            var movements = SqliteHandler.Selectregister();

            if (movements != null)
            {
                OnEvent(1);
                statusId = 1;
                foreach (Movimientos movement in movements)
                {
                    if (await postMovementApi(movement))
                    {
                        SqliteHandler.updateRegister(movement.idMovimiento,movement.dispositivoId);
                    }
                }
                OnEvent(0);
                statusId = 0;
                Program.log.Debug("Sincronizacion terminada thread.");
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
                    Program.log.Error("error en el servicio, Conflicto--" + statusmessage.message);
                    return false;
                }

                else if (statusmessage.statuscode == 500)
                {
                    Program.log.Error("error en el servicio, eror interno--" + movement.dispositivoId);
                    return false;
                }
                else if (statusmessage.statuscode == 200)
                {


                }
                else if (statusmessage.statuscode == 404)
                {
                    //MessageBox.Show("error en el servicio, NO encontrado");
                    Program.log.Error("error en el servicio, NO encontrado--"+movement.dispositivoId);
                    return false;

                }
                movimientos.Clear();
                return true;
            }
            catch(Exception ex)
            {
                Program.log.Error("Ocurrio un error al sincronizar un movimiento ---"+ex.Message);
                return false;
            }
            
            return false;
        }

        public static  void WriteMovesToSqlite(List<Movimientos> movimientos,string idMovimiento,int idusuario)
        {
            Program.log.Info($"insertando {movimientos.Count} registros a BD local");
            foreach(Movimientos movement in movimientos)
            {
                movement.idMovimiento = idMovimiento;
                movement.usuarioId = idusuario;   
                SqliteHandler.insertRegister(movement);
            }
            

            SyncMovesToAzure(idMovimiento);
            
        }

        

        public static void deleteMovesSqlite()
        {
            SqliteHandler.deleteregister();
        }

    }
}
