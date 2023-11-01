using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSV2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            first myFirst = first.GetInstance();
            first.cld("!----------------!Start!----------------!");
            //api.buscarCliente( DB.CheckCompanyPOS(), "11157060","");
            
            if (myFirst.checkKeys()=="1"){
                first.cld("!----------------!1!----------------!");
                myFirst.InitiaPRGTestDBMysql();
            }else{
                first.cld("!----------------!Config!----------------!");
                Application.Run(new frm_pos_main("Config"));
            }

        }
    }
}
