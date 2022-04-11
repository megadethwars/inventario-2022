using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPRAS2.servicios
{
    class Navigator
    {
        public static MENU mainmenu;
        public static MENU2 mainmenuOPT;
        public static void setMainMenu(MENU menu) {
            mainmenu = menu;
        }

        public static void setMainMenuoPT(MENU2 menu)
        {
            mainmenuOPT = menu;
        }

        public static void nextPage(Form form) {

            //if (mainmenu.PANELCONTENEDOR.Controls.Count > 0)
            //    mainmenu.PANELCONTENEDOR.Controls.RemoveAt(0);
            


            Form fh = form as Form;
            if (mainmenu.PANELCONTENEDOR.Controls.Count > 0) {
                foreach (Control control in mainmenu.PANELCONTENEDOR.Controls)
                {
                    control.Hide();
                }
            }
                

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            mainmenu.PANELCONTENEDOR.Controls.Add(fh);
            mainmenu.PANELCONTENEDOR.Tag = fh;
            
            fh.Show();
        }
        public static void backPage(string panelName,Control actCtrl) {
            

            int count = mainmenu.PANELCONTENEDOR.Controls.Count;
            string name = "";
            if (count > 0) {
                mainmenu.PANELCONTENEDOR.Controls.RemoveAt(count - 1);

                foreach (Control control in mainmenu.PANELCONTENEDOR.Controls)
                {
                    name = control.Name;
                }

                actCtrl.Dispose();
            }
            else
            {
                return;
            }

            count = mainmenu.PANELCONTENEDOR.Controls.Count;

            if (count == 0) {

                nextPage(mainmenuOPT);
                return;
            }

            Control[] controls = mainmenu.PANELCONTENEDOR.Controls.Find(name,true);

            foreach (Control ctrl in controls) {
                ctrl.Show();
            }

      

        }

        public static void GoMenu() {
            int count = mainmenu.PANELCONTENEDOR.Controls.Count;
            string name = "";
            if (count > 1)
            {
                string[] names = new string[count - 1];
                int temp = 0;
                foreach (Control control in mainmenu.PANELCONTENEDOR.Controls)
                {
                    if (control.Name != mainmenu.Name)
                    {

                        names[temp] = control.Name;
                        temp++;
                    }

                }

                foreach (string nm in names)
                {

                    Control[] controls = mainmenu.PANELCONTENEDOR.Controls.Find(nm, true);

                    foreach (Control ctl in controls)
                    {
                        mainmenu.PANELCONTENEDOR.Controls.RemoveByKey(nm);

                        ctl.Dispose();
                    }

                }

                Control[] controlsUnique = mainmenu.PANELCONTENEDOR.Controls.Find(mainmenu.Name, true);

                foreach (Control ctrl in controlsUnique)
                {
                    ctrl.Show();
                }
            }
            else
            {
                return;
            }
        }

    }
}
