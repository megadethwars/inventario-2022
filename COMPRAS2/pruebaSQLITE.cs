using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace COMPRAS2
{
    public partial class pruebaSQLITE : Form
    {
        public pruebaSQLITE()
        {
            InitializeComponent();
            
        }
        private void pruebaSQLITE_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Codigo", "Codigo");
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Origen", "Origen");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            InsertData(sqlite_conn);
            ReadData(sqlite_conn);
        }

        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
           
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
        
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
        public void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Productos2(Nombre VARCHAR(20), Codigo VARCHAR(20), Marca VARCHAR(20), Modelo VARCHAR(20), Origen VARCHAR(20),Cantidad INT)";
         
         sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }
        public void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Productos2(Nombre, Codigo, Marca, Modelo, Origen, Cantidad) VALUES('producto 1', 'AV00005','PRUEBA 1','POPO 1','CACA 1',5); ";
         sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Productos2(Nombre, Codigo, Marca, Modelo, Origen, Cantidad) VALUES('producto 2', 'AV00055','PRUEBA 2','POPO 21','CACA 2',7); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO Productos2(Nombre, Codigo, Marca, Modelo, Origen, Cantidad) VALUES('producto 2', 'AV00085','PRUEBA 2','POPO 12','CACA 3',9); ";
            sqlite_cmd.ExecuteNonQuery();


        }
        public void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Productos2";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader1 = sqlite_datareader.GetString(0);
                string myreader2 = sqlite_datareader.GetString(1);
                string myreader3 = sqlite_datareader.GetString(2);
                string myreader4 = sqlite_datareader.GetString(3);
                string myreader5 = sqlite_datareader.GetString(4);
                int myreader6 = sqlite_datareader.GetInt32(5);
                Console.WriteLine(myreader1);
                    string[] row = new string[] { myreader1 , myreader2, myreader3, myreader4, myreader5, myreader6.ToString() };
                dataGridView1.Rows.Add(row);
            }
            conn.Close();
        }
    }
}
