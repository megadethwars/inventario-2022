using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using COMPRAS2.modelos;
using COMPRAS2.servicios;
using Newtonsoft.Json;
namespace COMPRAS2
{
    public partial class MENU2 : Form
    {
        MENU mainmenu;
        System.Timers.Timer timer;
        System.Timers.Timer timer2;
        System.Timers.Timer timerPolling;
        string pollingUniqueId;
        public MENU2(MENU mainMenu)
        {
            InitializeComponent();
            this.mainmenu = mainMenu;

            this.lbUsername.Text = CurrentUsers.username;
            timer = new System.Timers.Timer(300000);
            timer.Elapsed += TimerElapsed;
            timer.Start();

            timer2 = new System.Timers.Timer(451000);
            timer2.Elapsed += TimerElapsed2;
            timer2.Start();
        }

        private void ManejarEvento(int dato)
        {
            if (dato == 1) {
                this.lbStatus.Text = "Sincronizacion pendiente..";
            }

            if (dato == 0) {
                this.lbStatus.Text = "Sincronizacion Completa";
            }
        }

        public void StartMovementPolling(string uniqueId)
        {
            pollingUniqueId = uniqueId;
            this.Invoke((MethodInvoker)delegate
            {
                lbStatus.Text = "Procesando movimiento...";
                lbStatus.Visible = true;
                pbMovimiento.Minimum = 0;
                pbMovimiento.Maximum = 1;
                pbMovimiento.Value = 0;
                pbMovimiento.Visible = true;
            });

            timerPolling = new System.Timers.Timer(3000);
            timerPolling.Elapsed += TimerPollingElapsed;
            timerPolling.AutoReset = true;
            timerPolling.Start();
        }

        private async void TimerPollingElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                string url = "https://avsinventoryswagger25.azurewebsites.net/api/v1/movimientos/processMovements/status/" + pollingUniqueId;
                StatusMessage statusmessage = await HttpMethods.get(url);

                if (statusmessage.statuscode != 200 || string.IsNullOrEmpty(statusmessage.data))
                    return;

                MovementStatusResponse response = JsonConvert.DeserializeObject<MovementStatusResponse>(statusmessage.data);

                if (response == null)
                    return;

                if (response.status != "processing")
                {
                    StopMovementPolling();
                    this.Invoke((MethodInvoker)delegate
                    {
                        pbMovimiento.Visible = false;
                        int failed = response.failed_devices?.Count ?? 0;
                        int skipped = response.skipped_devices?.Count ?? 0;
                        if (failed > 0 || skipped > 0)
                            lbStatus.Text = $"✅ Completado | Fallidos: {failed} | Omitidos: {skipped}";
                        else
                            lbStatus.Text = "✅ Movimiento completado";
                    });
                }
                else
                {
                    int processed = response.processed_devices?.Count ?? 0;
                    int total = response.requested_devices > 0 ? response.requested_devices : 1;
                    this.Invoke((MethodInvoker)delegate
                    {
                        pbMovimiento.Maximum = total;
                        pbMovimiento.Value = Math.Min(processed, total);
                        lbStatus.Text = $"Procesando movimiento... ({processed}/{total})";
                    });
                }
            }
            catch { }
        }

        public void StopMovementPolling()
        {
            if (timerPolling != null)
            {
                timerPolling.Stop();
                timerPolling.Dispose();
                timerPolling = null;
            }
        }

        private  void TimerElapsed(object sender, ElapsedEventArgs e)
        {

            SyncMoveManager.SyncMovesToAzurethread();
        }

        private void TimerElapsed2(object sender, ElapsedEventArgs e)
        {

            SyncMoveManager.deleteMovesSqlite();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        
        private void AbrirFormHija(object formhija)
        {                      
            if (this.mainmenu.PANELCONTENEDOR.Controls.Count > 0)
                this.mainmenu.PANELCONTENEDOR.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainmenu.PANELCONTENEDOR.Controls.Add(fh);
            this.mainmenu.PANELCONTENEDOR.Tag = fh;
            fh.Show();
        }
        
        private void MIPERFIL_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Navigator.nextPage(new pruebaSQLITE());
            //Navigator.nextPage(new MIPERFIL());
        }       

        private void btnREPORTE_Click(object sender, EventArgs e)
        {            
            Navigator.nextPage(new REPORTES2());
        }

        private void btnINVENTARIO_Click(object sender, EventArgs e)
        {            
            Navigator.nextPage(new INVENTARIO());
        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {         
            Navigator.nextPage(new EMPLEADOS());
        }

        private void btnAJUSTES_Click(object sender, EventArgs e)
        {
            Navigator.nextPage(new AJUSTES());
        }

        private void btnHISTORIAL_Click(object sender, EventArgs e)
        {          
            Navigator.nextPage(new HIST() { Name="HIST"});
        }

        private void MENU2_Load(object sender, EventArgs e)
        {

        }

        ~MENU2()
        {
            timer.Stop();
        } 
    }
}
