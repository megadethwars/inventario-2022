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

        public static bool updateRegister(string idMovimiento)
        {
            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            string updateQuery = "UPDATE Movements SET Status_sync_azure = 1 WHERE idMovimiento ='"+idMovimiento+"'";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
                    {
                       

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public static  List<Movimientos> Selectregister(string idMovimiento)
        {
            List<Movimientos> movimientosList = new List<Movimientos>();

            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            //string selectQueryjkjk = "SELECT * FROM Movements where idMovimiento ="+idMovimiento+ "and Status_sync_azure=0 and DATETIME(fecha_db, '+1 minute') < DATETIME('now', '-1 minute') order by fecha_db desc";
            string selectQuery = "SELECT * FROM Movements WHERE ((strftime('%s', datetime('now', 'localtime')) - strftime('%s', fecha_db)) / 60)>5 AND idMovimiento='" + idMovimiento + "' AND Status_sync_azure=0  order by fecha_db DESC;";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, connection))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Movimientos movimiento = new Movimientos
                            {
                                idMovimiento = reader["idMovimiento"].ToString(),
                                LugarId = Convert.ToInt32(reader["idLugar"]),
                                usuarioId = Convert.ToInt32(reader["idUsuario"]),
                                dispositivoId = Convert.ToInt32(reader["idDispositivo"]),
                                cantidad_Actual = Convert.ToInt32(reader["cantidad_actual"]),
                                tipoMovId = Convert.ToInt32(reader["idTipoMov"])
                            };

                            movimientosList.Add(movimiento);
                        }
                    }

                    connection.Close();
                }
                return movimientosList;
            }
            catch(Exception ex)
            {
                return null;
            }
            
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
