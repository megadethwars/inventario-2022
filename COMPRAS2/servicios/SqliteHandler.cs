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
        public static int max_attemps = 5;
        public static bool insertRegister(Movimientos movimiento)
        {
            // Cadena de conexión a la base de datos SQLite
            string connectionString = "Data Source="+VG.dbsqlite+";Version=3;";
            int count = 0;
            Program.log.Debug("insertando registro ---  " + movimiento.idMovimiento + "----" + movimiento.dispositivoId.ToString()+"---"+movimiento.codigo_Actual);
            while (count <= max_attemps)
            {
                count++;
                try
                {
                    
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
                catch (Exception ex)
                {
                    //logging error
                    Program.log.Error("error en escritura SQLite -- " + ex.Message);
                }
            }

            return false;
            
            

           
        }

        public static bool updateRegister(string idMovimiento,int dispositivoId)
        {
            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            string updateQuery = "UPDATE Movements SET Status_sync_azure = 1 WHERE idMovimiento ='"+idMovimiento+"' "+"and idDispositivo='"+ dispositivoId .ToString()+ "'";
            
            int count=0;
            Program.log.Debug("actualizando registro---"+idMovimiento+"----"+dispositivoId.ToString());
            while (count <= max_attemps)
            {
                count++;
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
                catch (Exception ex)
                {
                    Program.log.Error("error en actualizacion SQLite -- " + ex.Message);
                }
            }
            return false;

            
            

        }

        public static  List<Movimientos> Selectregister(string idMovimiento)
        {
            List<Movimientos> movimientosList = new List<Movimientos>();

            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            //string selectQueryjkjk = "SELECT * FROM Movements where idMovimiento ="+idMovimiento+ "and Status_sync_azure=0 and DATETIME(fecha_db, '+1 minute') < DATETIME('now', '-1 minute') order by fecha_db desc";
            string selectQuery = "SELECT * FROM Movements WHERE idMovimiento='" + idMovimiento + "' AND Status_sync_azure=0  order by fecha_db DESC;";
            int count = 0;

            while (count <= max_attemps)
            {
                count++;
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
                catch (Exception ex)
                {
                    Program.log.Error("error en consulta SQLite -- " + ex.Message);
                }
            }
            return null;
            
            
        }

        public static List<Movimientos> Selectregister()
        {
            List<Movimientos> movimientosList = new List<Movimientos>();

            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            
            string selectQuery = "SELECT * FROM Movements WHERE ((strftime('%s', datetime('now', 'localtime')) - strftime('%s', fecha_db)) / 60)>5 AND Status_sync_azure=0  order by fecha_db DESC limit 300;";
            int count = 0;

            while (count <= max_attemps)
            {
                count++;
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
                catch (Exception ex)
                {
                    Program.log.Error("error en consulta SQLite -- " + ex.Message);
                }
            }
            return null;
        }

        public bool deleteregister(string idMovimiento)
        {
            return true;
        }

        public static bool deleteregister()
        {
            string connectionString = "Data Source=" + VG.dbsqlite + ";Version=3;";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        // Query SQL para eliminar registros donde Status_sync_azure = 1
                        cmd.CommandText = "DELETE FROM Movements WHERE Status_sync_azure = 1 and ((strftime('%s', datetime('now', 'localtime')) - strftime('%s', fecha_db)) / 60)>43200";

                        // Ejecutar la consulta SQL DELETE
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Program.log.Info($"Se eliminaron  {rowsAffected} registros.");
                        Console.WriteLine($"Se eliminaron {rowsAffected} registros.");
                    }

                    connection.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                Program.log.Error("error en eliminacion SQLite -- " + ex.Message);
                return false;
            }
            
           
        }

    }

}
