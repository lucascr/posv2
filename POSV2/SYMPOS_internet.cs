using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.ComponentModel;

namespace POSV2
{

    public class WebClientEx : WebClient
    {   
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    }
    class SYMPOS_internet
    {
        public event Action<bool> RunCompleted;
        private BackgroundWorker bg = new BackgroundWorker();        

        static bool last_ping;
        public void th_do_ping()
        {
            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(bg_DoPing);
            //bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync();
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.RunCompleted (last_ping);
        }
        private void bg_DoPing(object sender, DoWorkEventArgs e)
        {
            check_internet();
        }
        public bool check_internet(){
            return check_internet_ping_php();
        }
        private bool check_internet_ping_php() {
            bool respuesta = false;
            last_ping = respuesta;
            string result_Ping_php = "";
            
            VarCompany my_company = DB.CheckCompanyPOS();
            NameValueCollection inputs_ping_php = new NameValueCollection();
            inputs_ping_php.Add("token", my_company.cloud_api_token);
            inputs_ping_php.Add("data", "80");
            string myserver = my_company.cloud_api_prod;
            
            using (WebClientEx wc = new WebClientEx()){
                try{
                    wc.Timeout = 2500;
                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice_Ping.php", inputs_ping_php);                    
                    result_Ping_php = Encoding.UTF8.GetString(bret);

                }catch (WebException e){
                    //How do I capture this from the UI to show the error in a message box?                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run check_internet_ping_php. : " + e.Message.ToString());
                }catch (Exception ex){
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run check_internet_ping_php. : " + ex.Message.ToString());
                }
            }
            if (result_Ping_php.ToString().Length > 0)
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run check_internet_ping_php. : true " + result_Ping_php.ToString());
                respuesta = true;
            }
            else {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run check_internet_ping_php. : false ");
            }
            last_ping = respuesta;
            return respuesta;
        }
        private  void reportTTL(){
        }

    }
}
