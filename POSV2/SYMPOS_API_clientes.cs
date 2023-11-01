using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.ComponentModel;
namespace POSV2
{

    public class SYMPOS_API_clientes
    {
        public static string myserver = "";
        public event Action<int> ProgressChanged;
        public event Action<object> bgResultados;
        private BackgroundWorker bg = new BackgroundWorker();
        private void OnProgressChanged(int progress)
        {
            var eh = ProgressChanged;
            if (eh != null)
            {
                eh(progress);
            }
        }

        public void THbuscarCliente(VarCompany my_company, string cedula, string nombre)
        {
            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(bg_DobuscarCliente);
            bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            object[] parameters = new object[] { my_company, cedula, nombre };
            bg.RunWorkerAsync(parameters);


        }
        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressChanged(e.ProgressPercentage);
        }
        private void bg_DobuscarCliente(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            this.bg.ReportProgress(10);
            buscarCliente((VarCompany)parameters[0], (string)parameters[1], (string)parameters[2]);
            //e.Result = true;
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
            this.bg.ReportProgress(100);
            // Handle what to do when complete.                        
        }
        private void buscarCliente(VarCompany my_company, string cedula, string nombre)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run SYMPOS_API_clientes.buscarCliente : ");
            SYMPOS_API_clientes.myserver = my_company.cloud_api_type == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run SYMPOS_API_clientes.server : " + SYMPOS_API_clientes.myserver);
            string result;
            this.bg.ReportProgress(20);
            using (WebClient wc = new WebClient())
            {
                NameValueCollection inputs = new NameValueCollection();
                inputs.Add("token", my_company.cloud_api_token);
                inputs.Add("cedula", cedula);
                inputs.Add("nombre", nombre);
                this.bg.ReportProgress(30);
                byte[] bret = wc.UploadValues(myserver + "/cedulas.php", inputs);
                
                this.bg.ReportProgress(40);
                result = Encoding.UTF8.GetString(bret);
                this.bg.ReportProgress(50);
                try
                {
                    var response = JsonConvert.DeserializeObject<Respuesta<Clientes>>(result.ToString());
                    this.bg.ReportProgress(60);
                    if (response.Cuenta.ToString() == "0")
                    {
                        MessageBox.Show("No hay resultados 0x00");
                    }
                    else
                    {
                        this.bgResultados(response.Resultados);
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error descargando cliente 0x01");
                }
                this.bg.ReportProgress(100);
            }
        }

    }
}