using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPRAS2.modelos;
using System.Data.SQLite;

namespace COMPRAS2.servicios
{
    public class SqliteHandler
    {

        public static bool insertRegister(Movimientos movimiento)
        {
            // Cadena de conexión a la base de datos SQLite
            string connectionString = "Data Source="+VG.dbsqlite+";Version=3;";
            try {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        // Query SQL para insertar un registro en la tabla "Movements"
                        cmd.CommandText = "INSERT INTO Movements (idMovimiento, idLugar, idUsuario, idDispositivo, cantidad_actual, idTipoMov, Status_sync_azure, fecha_db) " +
                                          "VALUES (@idMovimiento, @idLugar, @idUsuario, @idDispositivo, @cantidad_actual, @idTipoMov, @Status_sync_azure, @fecha_db)";

                        // Parámetros
                        cmd.Parameters.AddWithValue("@idMovimiento", movimiento.idMovimiento);
                        cmd.Parameters.AddWithValue("@idLugar", movimiento.LugarId); 
                        cmd.Parameters.AddWithValue("@idUsuario", movimiento.usuarioId); 
                        cmd.Parameters.AddWithValue("@idDispositivo", movimiento.dispositivoId); 
                        cmd.Parameters.AddWithValue("@cantidad_actual", movimiento.cantidad_Actual); 
                        cmd.Parameters.AddWithValue("@idTipoMov", movimiento.tipoMovId); 
                        cmd.Parameters.AddWithValue("@Status_sync_azure", 0); 
                        cmd.Parameters.AddWithValue("@fecha_db", DateTime.Now);

                        // Ejecutar la consulta SQL INSERT
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                //logging error
                return false;
            }
            

           
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
