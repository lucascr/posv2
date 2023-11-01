using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Specialized;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace POSV2
{
    class SYMPOS_API_Fe
    {
        public static string myserver = "";
        public string respuesta = "";
        public string getXMLRespuestasApi(string uuid, string api_pos)
        {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus = new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient()) {
                inputsFEGetStatus.Add("data", "43");
                inputsFEGetStatus.Add("invoice_uuid", uuid);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0) {
                    try {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch {
                        MessageBox.Show(DB.get_language("var_err") + " 6x142 GetStatus");
                    }
                }
                else {

                    MessageBox.Show("No hay respuesta del servidor API 6x141");
                }
            }
            #endregion
            return result;
        }
        public string getComprobantesApi(string uuid, string api_pos)
        {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus = new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient())
            {
                inputsFEGetStatus.Add("data", "21");
                inputsFEGetStatus.Add("invoice_uuid", uuid);

                first.cldNVC(inputsFEGetStatus);
                DB.debugIH(myserver, inputsFEGetStatus);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x242 GetStatus");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x241");
                }
            }
            #endregion
            return result;
        }

        public string getActividadEconomicaApi(string cedula)
        {

            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = my_company.cloud_api_prod;

            NameValueCollection inputsFEGetAE = new NameValueCollection();
            inputsFEGetAE.Add("cedula", cedula);

            string result;
            #region WC_ActividadEconomica
            using (WebClient wc = new WebClient())
            {
                byte[] bret = wc.UploadValues(myserver+"/apiAE.php", inputsFEGetAE);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x182 getActividadEconomicaApi");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x181");
                }
            }
            #endregion
            return result;
        }
        public MemoryStream getPdfApi2(string uuid, string api_pos)
        {
            MemoryStream pdfMemoryStream;
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;
             string pdfUrl =  myserver;

                    WebClient client = new WebClient();
                    try
                    {
                        pdfMemoryStream = new MemoryStream(client.DownloadData(pdfUrl));
                    }
                    finally
                    {
                        client.Dispose();
                    }
            return pdfMemoryStream;
        }
        public string getPdfApi(string uuid, string api_pos)
        {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus = new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_PDF
            using (WebClient wc = new WebClient())
            {
                inputsFEGetStatus.Add("data", "50");
                inputsFEGetStatus.Add("invoice_uuid", uuid);

                first.cldNVC(inputsFEGetStatus);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x242 GetStatus");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x241");
                }
            }
            #endregion
            return result;
        }
        public string getRespuestasApi(string uuid, string api_pos)
        {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus = new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient())
            {
                inputsFEGetStatus.Add("data", "33");
                inputsFEGetStatus.Add("invoice_uuid", uuid);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x33-2 GetStatus");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x33-1");
                }
            }
            #endregion
            return result;
        }
        public string getRespuestasClaveApi(string clave, string api_pos)
        {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus = new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient())
            {
                inputsFEGetStatus.Add("data", "34");
                inputsFEGetStatus.Add("xml", "1");
                inputsFEGetStatus.Add("tipo_invoice", api_pos);
                inputsFEGetStatus.Add("clave", clave);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x34-2 GetStatus");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x34-1");
                }
            }
            #endregion
            return result;
        }
        public string sendEmail(string uuid, string api_pos, string emailto){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run SYMPOS_API_fe.sendEmail : ");
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFESendEmail = new NameValueCollection();
            inputsFESendEmail.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient())
            {
                inputsFESendEmail.Add("data", "512");
                inputsFESendEmail.Add("invoice_uuid", uuid);
                inputsFESendEmail.Add("emailcc", emailto);
                
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFESendEmail);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length > 0)
                {
                    try
                    {
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                        
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x512-2 GetStatus");
                    }
                }
                else
                {

                    MessageBox.Show("No hay respuesta del servidor API 6x512-1");
                }
            }
            #endregion
            return result;
        }        
        public string getXMLApi(string uuid, string api_pos)
        {

            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus= new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient()){
                inputsFEGetStatus.Add("data", "41");
                inputsFEGetStatus.Add("invoice_uuid", uuid);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length> 0){
                    try{                        
                        //DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split(':')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split(':')[2] + "'  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch {
                        MessageBox.Show(DB.get_language("var_err") + " 6x41-2 GetStatus");
                    }                    
                }
                else{

                    MessageBox.Show("No hay respuesta del servidor API 6x41-1");
                }
            }
            #endregion
            return result;
        }
        public string getStatusApi(string uuid,string api_pos,bool con_msg = true) {
            VarCompany my_company = DB.CheckCompanyPOS();
            myserver = api_pos == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            NameValueCollection inputsFEGetStatus= new NameValueCollection();
            inputsFEGetStatus.Add("token", my_company.cloud_api_token);

            string result;
            #region WC_EnviosPendientes
            using (WebClient wc = new WebClient()){
                inputsFEGetStatus.Add("data", "40");
                inputsFEGetStatus.Add("invoice_uuid", uuid);
                byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEGetStatus);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length> 0){
                    try{                        
                        DB.e(" update invoice set invoice_hacienda_state='"+ result.ToString().Split('|')[1] + "', invoice_hacienda_ind_estado='"+ result.ToString().Split('|')[2] + "', invoice_fecha_emision='" + result.ToString().Split('|')[3] + "', invoice_hacienda_lastdate = now()  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch {
                        MessageBox.Show(DB.get_language("var_err") + " 6x40-2 GetStatus");
                    }
                    
                }
                else{
                    try
                    {
                        DB.e(" update invoice set invoice_hacienda_lastdate = now()  where invoice_uuid='" + uuid + "'", "", "");
                    }
                    catch
                    {
                        MessageBox.Show(DB.get_language("var_err") + " 6x40-1 GetStatus");
                    }
                    
                    if (con_msg) {
                        ////MessageBox.Show("No hay respuesta del servidor API 6x540");
                    }                        
                }
            }
            #endregion
            return result;
        }
        public void pendientes(bool th_bg = false){
            VarCompany my_company = DB.CheckCompanyPOS();
            NameValueCollection inputsFEPendientes = new NameValueCollection();
            NameValueCollection inputsFERespuestas = new NameValueCollection();
            NameValueCollection inputsFEEmails = new NameValueCollection();
            
            inputsFEPendientes.Add("token", my_company.cloud_api_token);
            inputsFERespuestas.Add("token", my_company.cloud_api_token);
            inputsFEEmails.Add("token", my_company.cloud_api_token);

            string result_EnviosPendientes = "";
            Boolean errores = true;

            myserver = my_company.cloud_api_type == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            #region WC_EnviosPendientes
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + " WC_EnviosPendientes");

            using (WebClient wc = new WebClient()){
                inputsFEPendientes.Add("data", "60");
                try
                {
                    //Uri algo = new Uri();
                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php" , inputsFEPendientes);
                    result_EnviosPendientes = Encoding.UTF8.GetString(bret);
                }
                catch (WebException e)
                {
                    //How do I capture this from the UI to show the error in a message box?         
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x60-3 e" + e.Message.ToString());
                    DB.enviar("6x60-3 e", "No hay respuesta del servidor API 6x60-3 e" + e.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 6x60 e" + e.Message.ToString());
                    
                }
                catch (Exception ex)
                {
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x60-2 ex" + ex.Message.ToString());
                    DB.enviar("6x60-2 ex", "No hay respuesta del servidor API 6x60-2 ex" + ex.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 6x60 ex" + ex.Message.ToString());
                    
                }
                
                if (result_EnviosPendientes.ToString().Length> 0){
                    //respuesta = result.ToString();
                }
                else{

                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x60-1");
                    DB.enviar("6x60-1", "No hay respuesta del servidor API 6x60-1 " + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 6x60");
                }
            }
            #endregion

            /*
            #region WC_RespuestsPendientes
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + " WC_RespuestsPendientes");
            string result_respuestasPendientes = "";
            using (WebClient wc = new WebClient()){
                inputsFERespuestas.Add("data", "30");
                byte[] bret ;
                try
                {
                    bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFERespuestas);
                    result_respuestasPendientes = Encoding.UTF8.GetString(bret);
                }
                catch (WebException e)
                {
                    //How do I capture this from the UI to show the error in a message box?                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + e.Message.ToString());
                }
                catch (Exception ex)
                {


                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + ex.Message.ToString());
                }



                if (result_respuestasPendientes.ToString().Length> 0){
                    //respuesta = result.ToString();
                }
                else{

                    MessageBox.Show("No hay respuesta del servidor API 6x30");
                }
            }
            #endregion
            */
            #region WC_SendEmails
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + " WC_SendEmails");
            string result_sendEmails = "";
            using (WebClient wc = new WebClient()){
                inputsFEEmails.Add("data", "51");
                try
                {

                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEEmails);
                    result_sendEmails = Encoding.UTF8.GetString(bret);
                }
                catch (WebException e)
                {
                    //How do I capture this from the UI to show the error in a message box?                    
                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x51 e" + e.Message.ToString());
                    DB.enviar("7x51 e", "No hay respuesta del servidor API 7x51 ex" + e.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 7x51 e" + e.Message.ToString());
                }
                catch (Exception ex)
                {

                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x51 ex" + ex.Message.ToString());
                    DB.enviar("7x51 ex", "No hay respuesta del servidor API 7x51 ex" + ex.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 7x51 ex" + ex.Message.ToString());
                }

                if (result_sendEmails.ToString().Length> 0){
                    //respuesta = result.ToString();
                }
                else{

                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x51");
                    DB.enviar("7x51", "No hay respuesta del servidor API 7x51" + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 7x51");
                }
            }
            #endregion
        }
        public void s3FE(string id_invoice) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run apife.s3FE : " + id_invoice.ToString());
            VarCompany my_company = DB.CheckCompanyPOS();
            NameValueCollection inputsFEs3 = new NameValueCollection();
            inputsFEs3.Add("token", my_company.cloud_api_token);

            myserver = my_company.cloud_api_type == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

            string result_s3="";
            Boolean errores = true;
            #region WC_S3
            using (WebClient wc = new WebClient()){
                inputsFEs3.Add("data", "8");
                //inputsFEs3.Add("id_invoice", id_invoice);
                
                try
                {
                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEs3);
                    result_s3 = Encoding.UTF8.GetString(bret);
                }
                catch (WebException e)
                {
                    //How do I capture this from the UI to show the error in a message box?
                    
                    //MessageBox.Show("No hay respuesta del servidor API 6x00 e" + e.Message.ToString());
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x-3" + e.Message.ToString());
                    DB.enviar("6x8-3", "No hay respuesta del servidor API 6x8-3" + "\r\n Computer :" + Environment.MachineName.ToString());

                }
                catch (Exception ex)
                {

                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x101" + ex.Message.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 6x00 ex" + ex.Message.ToString());
                    DB.enviar("6x8-2", "No hay respuesta del servidor API 6x8-2" + "\r\n Computer :" + Environment.MachineName.ToString());
                }
                
                if (result_s3.ToString().Length > 2){
                    respuesta = result_s3.ToString();
                }
                else{
                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 6x100");
                    DB.enviar("6x8-1", "No hay respuesta del servidor API 6x8-1" + "\r\n Computer :" + Environment.MachineName.ToString());
                    //MessageBox.Show("No hay respuesta del servidor API 6x00");
                }
            }
            #endregion
        }
        public void sendFE(string id_invoice)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run apife.sendFE : " + id_invoice.ToString());
            //Consigue Consecutivo Normal o Sin Internet
            SYMPOS_local_fe.createConsecutivo(id_invoice); //, my_company.company_identification.ToString()
            uploadFE(id_invoice);
            //Check Company Suc Ter tables API
        }
        public void sendMR(string id_invoice)
        {
            //Consigue Consecutivo Normal o Sin Internet
            SYMPOS_local_fe.createConsecutivo(id_invoice); //, my_company.company_identification.ToString()
            uploadMR(id_invoice);

        }
        public void uploadMR(string id_invoice){
            VarCompany my_company = DB.CheckCompanyPOS();

            NameValueCollection inputsMRHeaders = new NameValueCollection();
            NameValueCollection inputsFEXML = new NameValueCollection();

            inputsMRHeaders.Add("token", my_company.cloud_api_token);
            inputsFEXML.Add("token", my_company.cloud_api_token);

            string sql_load_invoice_mysql = "SELECT UNIX_TIMESTAMP(invoice_cd) as ui_cd,invoice.* from invoice where invoice_id='" + id_invoice + "' limit 1";
            string i_uuid = "";

            DataTable tDti = DB.q(sql_load_invoice_mysql, "", "");

            foreach (DataRow r in tDti.Rows)
            {
                #region HeadersNVC
                myserver = r["invoice_api_type"].ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

                inputsMRHeaders.Add("invoice_api_type", r["invoice_api_type"].ToString());
                inputsMRHeaders.Add("invoice_clave", r["invoice_clave"].ToString());
                inputsMRHeaders.Add("invoice_consecutivo", r["invoice_consecutivo"].ToString());

                //inputsMRHeaders.Add("invoice_actividad_economica", r["invoice_actividad_economica"].ToString());
                inputsMRHeaders.Add("invoice_tipo_doc", r["invoice_tipo_doc"].ToString());

                inputsMRHeaders.Add("pos_version", first.pos_version);

                //Receptor YO
                inputsMRHeaders.Add("invoice_company_type", r["invoice_company_type"].ToString());
                inputsMRHeaders.Add("invoice_company_identification", r["invoice_company_identification"].ToString());

                //Emisor Mi proveedor
                inputsMRHeaders.Add("invoice_client_type", r["invoice_client_type"].ToString());
                inputsMRHeaders.Add("invoice_client_identification", r["invoice_client_identification"].ToString());
                inputsMRHeaders.Add("invoice_client_name", r["invoice_client_name"].ToString());
                inputsMRHeaders.Add("invoice_client_email", r["invoice_client_email"].ToString());

                inputsMRHeaders.Add("invoice_ref_tipodoc", r["invoice_ref_TipoDoc"].ToString());
                inputsMRHeaders.Add("invoice_ref_numero", r["invoice_ref_Numero"].ToString());



                inputsMRHeaders.Add("invoice_currency", r["invoice_currency"].ToString());
                inputsMRHeaders.Add("invoice_exchange_rate", r["invoice_exchange_rate"].ToString());

                //inputsMRHeaders.Add("invoice_ref_tipodoc", r["invoice_ref_TipoDoc"].ToString());
                //inputsMRHeaders.Add("invoice_ref_numero", r["invoice_ref_Numero"].ToString());

                inputsMRHeaders.Add("invoice_totalimpuesto", r["invoice_TotalImpuesto"].ToString());
                inputsMRHeaders.Add("invoice_totalcomprobante", r["invoice_TotalComprobante"].ToString());

                inputsMRHeaders.Add("invoice_detalle_mensaje", r["invoice_detalle_mensaje"].ToString());
                
                //  
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + r["invoice_cd"]);
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + r["ui_cd"]);

                inputsMRHeaders.Add("invoice_cd", r["ui_cd"].ToString());

                
                i_uuid = r["invoice_uuid"].ToString();
                inputsMRHeaders.Add("invoice_uuid", i_uuid);
                inputsMRHeaders.Add("data", "1");
                #endregion
            }
            
            string result_saveHeaderMain="";
            Boolean errores = true;
            #region SaveHeaderMain
            using (WebClient wc = new WebClient()){
                try
                {
                    //DB.debugIH(myserver + "/apiGastos.php",inputsMRHeaders);

                    byte[] bret = wc.UploadValues(myserver + "/apiGastos.php", inputsMRHeaders);
                    result_saveHeaderMain = Encoding.UTF8.GetString(bret);
                }
                catch (WebException e)
                {
                    //How do I capture this from the UI to show the error in a message box?                    
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + e.Message.ToString());
                }
                catch (Exception ex)
                {


                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + ex.Message.ToString());
                }
                //DB.debugIH(myserver + "/apiGastos.php", inputsMRHeaders);
                if (result_saveHeaderMain.ToString().Length> 0){

                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result_saveHeaderMain.ToString());
                    if (result_saveHeaderMain.ToString() == i_uuid){
                        Application.DoEvents();
                        DB.e(" update invoice set invoice_remote_state=1 where invoice_id='" + id_invoice + "'", "", "");
                        errores = false;
                    }else{
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 1x01");
                        MessageBox.Show("Ocurrio un error en respuesta del servidor API 1x01 '"+ result_saveHeaderMain.ToString()+"'");
                    }
                }else{
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 1x00");
                    MessageBox.Show("No hay respuesta del servidor API 1x00");
                }
            }
            #endregion
            #region CreateXML
            if (!errores)
            {

                    #region WC_CreateXML
                    string result_Gastos = "";
                    using (WebClient wc = new WebClient()){

                        inputsFEXML.Add("data", "2");
                        inputsFEXML.Add("xml", "1");
                        inputsFEXML.Add("invoice_uuid", i_uuid);

                        byte[] bret = wc.UploadValues(myserver + "/apiGastos.php", inputsFEXML);
                        result_Gastos = Encoding.UTF8.GetString(bret);
                        if (result_Gastos.ToString().Length> 0){

                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result_Gastos.ToString());
                            this.respuesta = result_Gastos.ToString();
                            string[] respuestaArray = respuesta.Split('.');

                            if (respuestaArray[0].ToString() == "202" && respuestaArray[2].ToString() == i_uuid) {
                                DB.e(" update invoice set invoice_remote_state=7,invoice_hacienda_state='" + respuestaArray[0].ToString() + "',invoice_fecha_emision='" + respuestaArray[3].ToString() + "' where invoice_id='" + id_invoice + "'", "", "");
                                errores = false;
                            }else{
                                DB.e(" update invoice set invoice_remote_state=99,invoice_hacienda_state='" + respuestaArray[0].ToString() + "',invoice_fecha_emision='" + respuestaArray[3].ToString() + "' where invoice_id='" + id_invoice + "'", "", "");
                                //MessageBox.Show("Ocurrio un error en respuesta del servidor API 6x01 2 '"+ result_Gastos.ToString()+"'");
                            }
                        }else{
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x00");
                            MessageBox.Show("No hay respuesta del servidor API 7x00");
                        }
                    }
                    #endregion
            }
            #endregion

        }
        public void uploadFE(string id_invoice,bool th_bg =true){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run apife.uploadFE : " + id_invoice.ToString());
            //MessageBox.Show("Test2");
            VarCompany my_company = DB.CheckCompanyPOS();
            

            //Get Factura
            NameValueCollection inputsFEHeaders = new NameValueCollection();
            NameValueCollection inputsFEHeadersTotals = new NameValueCollection();
            NameValueCollection inputsFEHeadersCompany = new NameValueCollection();
            NameValueCollection inputsFEHeadersClient = new NameValueCollection();
            NameValueCollection inputsFEReferencia = new NameValueCollection();

            NameValueCollection inputsFEDetail = new NameValueCollection();
            NameValueCollection inputsFEClose = new NameValueCollection();
            NameValueCollection inputsFEXML = new NameValueCollection();
             
            inputsFEHeaders.Add("token", my_company.cloud_api_token);
            inputsFEHeadersCompany.Add("token", my_company.cloud_api_token);
            inputsFEHeadersClient.Add("token", my_company.cloud_api_token);
            inputsFEReferencia.Add("token", my_company.cloud_api_token);

            inputsFEHeadersTotals.Add("token", my_company.cloud_api_token);
            inputsFEClose.Add("token", my_company.cloud_api_token);

            inputsFEXML.Add("token", my_company.cloud_api_token);

            string sql_load_invoice_mysql = "SELECT UNIX_TIMESTAMP(invoice_cd) as ui_cd,invoice.* from invoice where invoice_id='" + id_invoice + "' limit 1";
            string i_uuid = "";
            bool hay_referencia = false;

            DataTable tDti = DB.q(sql_load_invoice_mysql, "", "",true, th_bg);

            foreach (DataRow r in tDti.Rows)
            {
                #region HeadersNVC
                myserver = r["invoice_api_type"].ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;

                inputsFEHeaders.Add("invoice_api_type", r["invoice_api_type"].ToString());
                inputsFEHeaders.Add("invoice_clave", r["invoice_clave"].ToString());
                inputsFEHeaders.Add("invoice_consecutivo", r["invoice_consecutivo"].ToString());

                inputsFEHeaders.Add("invoice_actividad_economica", r["invoice_actividad_economica"].ToString());
                inputsFEHeaders.Add("invoice_tipo_doc", r["invoice_tipo_doc"].ToString());

                inputsFEHeaders.Add("invoice_currency", r["invoice_currency"].ToString());
                inputsFEHeaders.Add("invoice_exchange_rate", r["invoice_exchange_rate"].ToString());
                inputsFEHeaders.Add("invoice_condicion_venta", r["invoice_condicion_venta"].ToString());
                inputsFEHeaders.Add("invoice_plazo_credito", r["invoice_plazo_credito"].ToString());
                inputsFEHeaders.Add("invoice_medio_pago", r["invoice_medio_pago"].ToString());
                inputsFEHeaders.Add("invoice_client_type", r["invoice_client_type"].ToString());
                //  
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : "+ r["invoice_cd"]);
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + r["ui_cd"]);
                
                inputsFEHeaders.Add("invoice_cd", r["ui_cd"].ToString());

                inputsFEHeaders.Add("pos_version", first.pos_version);
                inputsFEHeaders.Add("invoice_ref_tipodoc", r["invoice_ref_TipoDoc"].ToString());
                inputsFEHeaders.Add("invoice_ref_numero", r["invoice_ref_Numero"].ToString());
                string fecha_emision = "";
                if (r["invoice_ref_FechaEmision"].ToString().Length>0) {
                    fecha_emision = r["invoice_ref_FechaEmision"].ToString().Substring(0, 25);
                }
                
                inputsFEHeaders.Add("invoice_ref_fechaemision", fecha_emision);
                inputsFEHeaders.Add("invoice_ref_codigo", r["invoice_ref_Codigo"].ToString());
                inputsFEHeaders.Add("invoice_ref_razon", r["invoice_ref_Razon"].ToString());

                inputsFEHeaders.Add("invoice_xml_ver", r["invoice_xml_ver"].ToString());

                i_uuid = r["invoice_uuid"].ToString();
                inputsFEHeaders.Add("invoice_uuid", i_uuid);
                //Console.WriteLine(r["invoice_uuid"].ToString());
                inputsFEHeaders.Add("data", "1");

                
                /*
                if (r["invoice_ref_TipoDoc"].ToString().Length>0) {
                    hay_referencia = true;

                    inputsFEReferencia.Add("invoice_ref_tipodoc", r["invoice_ref_TipoDoc"].ToString());
                    inputsFEReferencia.Add("invoice_ref_numero", r["invoice_ref_Numero"].ToString());
                    inputsFEReferencia.Add("invoice_ref_fechaemision", r["invoice_ref_FechaEmision"].ToString());
                    inputsFEReferencia.Add("invoice_ref_codigo", r["invoice_ref_Codigo"].ToString());
                    inputsFEReferencia.Add("invoice_ref_razon", r["invoice_ref_Razon"].ToString());


                    inputsFEReferencia.Add("invoice_uuid", i_uuid);
                    inputsFEReferencia.Add("data", "1");
                }
                */


                inputsFEHeadersCompany.Add("invoice_company_type", r["invoice_company_type"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_identification", r["invoice_company_identification"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_name", r["invoice_company_name"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_email", r["invoice_company_email"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_addr_province", r["invoice_company_addr_province"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_addr_canton", r["invoice_company_addr_canton"].ToString());
                inputsFEHeadersCompany.Add("invoice_company_addr_district", r["invoice_company_addr_district"].ToString());

                inputsFEHeadersCompany.Add("invoice_uuid", i_uuid);
                inputsFEHeadersCompany.Add("data", "2");

                if (r["invoice_client_type"].ToString() != "0") {

                    inputsFEHeadersClient.Add("invoice_client_type", r["invoice_client_type"].ToString());
                    inputsFEHeadersClient.Add("invoice_client_identification", r["invoice_client_identification"].ToString());
                    inputsFEHeadersClient.Add("invoice_client_name", r["invoice_client_name"].ToString());
                    inputsFEHeadersClient.Add("invoice_client_email", r["invoice_client_email"].ToString());
                    inputsFEHeadersClient.Add("invoice_client_phone_number", r["invoice_client_phone_number"].ToString());

                    inputsFEHeadersClient.Add("invoice_uuid", i_uuid);
                    inputsFEHeadersClient.Add("data", "9");
                }

                inputsFEHeadersTotals.Add("invoice_TotalServGravados", r["invoice_TotalServGravados"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalServExentos", r["invoice_TotalServExentos"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalMercanciasGravadas", r["invoice_TotalMercanciasGravadas"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalMercanciasExentas", r["invoice_TotalMercanciasExentas"].ToString());

                inputsFEHeadersTotals.Add("invoice_TotalGravado", r["invoice_TotalGravado"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalExento", r["invoice_TotalExento"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalVenta", r["invoice_TotalVenta"].ToString());

                inputsFEHeadersTotals.Add("invoice_TotalDescuentos", r["invoice_TotalDescuentos"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalVentaNeta", r["invoice_TotalVentaNeta"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalImpuesto", r["invoice_TotalImpuesto"].ToString());
                inputsFEHeadersTotals.Add("invoice_TotalComprobante", r["invoice_TotalComprobante"].ToString());

                inputsFEHeadersTotals.Add("invoice_uuid", i_uuid);
                inputsFEHeadersTotals.Add("data", "3");
                
                #endregion
            }
            //Factura manda si es prod o testing
            string result;
            Boolean errores = true;
            #region SaveHeaderMain

            
            //inputsFEHeaders.Add("debug", "1");
            using (WebClient wc = new WebClient()){
                first.cldNVC(inputsFEHeaders);
                 byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEHeaders);
                result = Encoding.UTF8.GetString(bret);
                if (result.ToString().Length> 0){

                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                    if (result.ToString() == i_uuid){
                        DB.e(" update invoice set invoice_remote_state=1 where invoice_id='" + id_invoice + "'", "", "");
                        errores = false;
                    }else{
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 1x01");
                        MessageBox.Show("Ocurrio un error en respuesta del servidor API 1x01 '"+ result.ToString()+"' #"+ id_invoice);
                    }
                }else{
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 1x00");
                    MessageBox.Show("No hay respuesta del servidor API 1x00");
                }
            }
            #endregion
            /*
            if (!errores)
            {
                if (hay_referencia)
                {
                    inputsFEReferencia
                }
            }*/
                    

            #region SaveHeaderCompany
            if (!errores) {
                using (WebClient wc = new WebClient()){

                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEHeadersCompany);
                    result = Encoding.UTF8.GetString(bret);
                    if (result.ToString().Length> 0){

                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                        if (result.ToString() == i_uuid){
                            DB.e(" update invoice set invoice_remote_state=2 where invoice_id='" + id_invoice + "'", "", "");
                            errores = false;
                        }else{

                            MessageBox.Show("Ocurrio un error en respuesta del servidor API 2x01 '"+ result.ToString()+"'");
                        }
                    }else{

                        MessageBox.Show("No hay respuesta del servidor API 2x00");
                    }
                }
            }
            #endregion
            
            #region SaveHeaderClient
            if (!errores) {
                if (inputsFEHeadersClient.Count > 4) { 
                    using (WebClient wc = new WebClient()){

                        byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEHeadersClient);
                        result = Encoding.UTF8.GetString(bret);
                        if (result.ToString().Length> 0){

                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                            if (result.ToString() == i_uuid){
                                DB.e(" update invoice set invoice_remote_state=3 where invoice_id='" + id_invoice + "'", "", "");
                                errores = false;
                            }else{

                                MessageBox.Show("Ocurrio un error en respuesta del servidor API 2x01 '"+ result.ToString()+"'");
                            }
                        }else{

                            MessageBox.Show("No hay respuesta del servidor API 3x00");
                        }
                    }
                }
            }
            #endregion
            #region SaveHeaderTotal
            
            if (!errores) {
                using (WebClient wc = new WebClient()){

                    byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEHeadersTotals);
                    result = Encoding.UTF8.GetString(bret);
                    if (result.ToString().Length> 0){

                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                        if (result.ToString() == i_uuid){
                            DB.e(" update invoice set invoice_remote_state=4 where invoice_id='" + id_invoice + "'", "", "");
                            errores = false;
                        }else{

                            MessageBox.Show("Ocurrio un error en respuesta del servidor API 2x01 '"+ result.ToString()+"'");
                        }
                    }else{

                        MessageBox.Show("No hay respuesta del servidor API 4x00");
                    }
                }
            }
            #endregion
            #region SaveDetail
            if (!errores)
            {
                Boolean erroresDetail = false;
                string sql_load_invoice_detail_mysql = "SELECT * from invoice_detail where invoice_id='" + id_invoice + "'";
                
                DataTable tDtid = DB.q(sql_load_invoice_detail_mysql, "", "");
                foreach (DataRow r in tDtid.Rows)
                {
                    #region DetailNVC
                    inputsFEDetail.Clear();
                    inputsFEDetail.Add("token", my_company.cloud_api_token);
                    inputsFEDetail.Add("data", "4");

                    inputsFEDetail.Add("invoice_uuid", i_uuid);

                    inputsFEDetail.Add("invoice_id", r["invoice_id"].ToString());                    
                    
                    inputsFEDetail.Add("invoice_detail_line", r["invoice_detail_line"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_id", r["invoice_detail_product_id"].ToString());

                    inputsFEDetail.Add("invoice_detail_product_sym", r["invoice_detail_product_sym"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_sym_unit", r["invoice_detail_product_sym_unit"].ToString());

                    inputsFEDetail.Add("invoice_detail_product_sym_code_type", r["invoice_detail_product_sym_code_type"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_sym_barcode", r["invoice_detail_product_sym_barcode"].ToString());

                    inputsFEDetail.Add("invoice_detail_product_sym_tax_code", r["invoice_detail_product_sym_tax_code"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_sym_tax_code_iva", r["invoice_detail_product_sym_tax_code_iva"].ToString());

                    inputsFEDetail.Add("invoice_detail_product_sym_tax", r["invoice_detail_product_sym_tax"].ToString());

                    inputsFEDetail.Add("invoice_detail_qty", r["invoice_detail_qty"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_sym_description", r["invoice_detail_product_sym_description"].ToString());
                    inputsFEDetail.Add("invoice_detail_product_price", r["invoice_detail_product_price"].ToString());
                    inputsFEDetail.Add("invoice_detail_MontoTotal", r["invoice_detail_MontoTotal"].ToString());

                    inputsFEDetail.Add("invoice_detail_MontoDescuento", r["invoice_detail_MontoDescuento"].ToString());
                    inputsFEDetail.Add("invoice_detail_NaturalezaDescuento", r["invoice_detail_NaturalezaDescuento"].ToString());

                    inputsFEDetail.Add("invoice_detail_SubTotal", r["invoice_detail_SubTotal"].ToString());
                    inputsFEDetail.Add("invoice_detail_impuesto_Monto", r["invoice_detail_impuesto_Monto"].ToString());
                    inputsFEDetail.Add("invoice_detail_MontoTotalLinea", r["invoice_detail_MontoTotalLinea"].ToString());

                    inputsFEDetail.Add("invoice_detail_product_codigo_cabys", r["invoice_detail_product_codigo_cabys"].ToString());
                    

                    #endregion
                    #region WC_detail
                    using (WebClient wc = new WebClient()){
                        byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEDetail);
                        result = Encoding.UTF8.GetString(bret);
                        if (result.ToString().Length> 0){
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                            if (result.ToString() == i_uuid){
                                DB.e(" update invoice set invoice_remote_state=5 where invoice_id='" + id_invoice + "'", "", "", th_bg);
                                errores = false;
                            }else{
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 4x01");
                                //MessageBox.Show("Ocurrio un error en respuesta del servidor API 4x01 '"+ result.ToString()+"'");
                                DB.enviar("4x01", "Ocurrio un error en respuesta del servidor API 4x01" + "\r\n Computer :" + Environment.MachineName.ToString());
                                erroresDetail = true;
                            }
                        }else{
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 4x02");
                            //MessageBox.Show("No hay respuesta del servidor API 4x02");
                            DB.enviar("4x02", "No hay respuesta del servidor API 4x02" + "\r\n Computer :" + Environment.MachineName.ToString());
                            erroresDetail = true;
                        }
                    } //WebClient Detail
                    #endregion
                } //foreach Detail

                if (!erroresDetail)
                {   
                    if (DB.simplificado )
                    {
                        #region WC_CloseFE
                        using (WebClient wc = new WebClient())
                        {

                            inputsFEClose.Add("data", "55");
                            inputsFEClose.Add("invoice_uuid", i_uuid);

                            byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEClose);
                            result = Encoding.UTF8.GetString(bret);
                            if (result.ToString().Length > 0)
                            {

                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                                if (result.ToString() == i_uuid)
                                {
                                    DB.e(" update invoice set invoice_remote_state=55,invoice_hacienda_lastdate=now() where invoice_id='" + id_invoice + "'", "", "");
                                    errores = false;
                                }
                                else
                                {

                                    //MessageBox.Show("Ocurrio un error en respuesta del servidor API 5x01 '"+ result.ToString()+"'");
                                    DB.enviar("5x01", "No hay respuesta del servidor API 55x01" + "\r\n Computer :" + Environment.MachineName.ToString());
                                }
                            }
                            else
                            {
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 55x02");
                                //MessageBox.Show("No hay respuesta del servidor API 5x02");
                                DB.enviar("5x02", "No hay respuesta del servidor API 55x02" + "\r\n Computer :" + Environment.MachineName.ToString());
                            }
                        }
                        #endregion
                    }
                    else
                    {                    

                        #region WC_CloseFE
                        using (WebClient wc = new WebClient())
                        {

                            inputsFEClose.Add("data", "5");
                            inputsFEClose.Add("invoice_uuid", i_uuid);

                            byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEClose);
                            result = Encoding.UTF8.GetString(bret);
                            if (result.ToString().Length > 0)
                            {

                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                                if (result.ToString() == i_uuid)
                                {
                                    DB.e(" update invoice set invoice_remote_state=6,invoice_hacienda_lastdate=now() where invoice_id='" + id_invoice + "'", "", "");
                                    errores = false;
                                }
                                else
                                {

                                    //MessageBox.Show("Ocurrio un error en respuesta del servidor API 5x01 '"+ result.ToString()+"'");
                                    DB.enviar("5x01", "No hay respuesta del servidor API 5x01" + "\r\n Computer :" + Environment.MachineName.ToString());
                                }
                            }
                            else
                            {
                                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 5x02");
                                //MessageBox.Show("No hay respuesta del servidor API 5x02");
                                DB.enviar("5x02", "No hay respuesta del servidor API 5x02" + "\r\n Computer :" + Environment.MachineName.ToString());
                            }
                        }
                        #endregion

                        #region WC_CreateXML
                    using (WebClient wc = new WebClient())
                    {

                        inputsFEXML.Add("data", "6");
                        inputsFEXML.Add("xml", "1");
                        inputsFEXML.Add("invoice_uuid", i_uuid);

                        try
                        {
                            byte[] bret = wc.UploadValues(myserver + "/apiInvoice.php", inputsFEXML);
                            result = Encoding.UTF8.GetString(bret);
                        }
                        catch (WebException e)
                        {
                            //How do I capture this from the UI to show the error in a message box?         
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x60 e" + e.Message.ToString());
                            DB.enviar("7x060 e", "No hay respuesta del servidor API 7x60 e" + e.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                            //MessageBox.Show("No hay respuesta del servidor API 6x60 e" + e.Message.ToString());

                        }
                        catch (Exception ex)
                        {
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x60 ex" + ex.Message.ToString());
                            DB.enviar("7x061 ex", "No hay respuesta del servidor API 7x60 ex" + ex.Message.ToString() + "\r\n Computer :" + Environment.MachineName.ToString());
                            //MessageBox.Show("No hay respuesta del servidor API 6x60 ex" + ex.Message.ToString());

                        }






                        if (result.ToString().Length > 0)
                        {

                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : " + result.ToString());
                            this.respuesta = result.ToString();
                            string[] respuestaArray = respuesta.Split('.');

                            if (respuestaArray[0].ToString() == "202" && respuestaArray[2].ToString() == i_uuid)
                            {
                                DB.e(" update invoice set invoice_remote_state=7,invoice_hacienda_state='" + respuestaArray[0].ToString() + "',invoice_fecha_emision='" + respuestaArray[3].ToString() + "' where invoice_id='" + id_invoice + "'", "", "");
                                errores = false;
                            }
                            else
                            {
                                if (respuestaArray.Length > 1)
                                {
                                    DB.e(" update invoice set invoice_remote_state=99,invoice_hacienda_state='" + respuestaArray[0].ToString() + "',invoice_fecha_emision='" + respuestaArray[3].ToString() + "' where invoice_id='" + id_invoice + "'", "", "");
                                }
                                else
                                {
                                    DB.e(" update invoice set invoice_remote_state=99,invoice_hacienda_state='" + respuestaArray[0].ToString() + "' where invoice_id='" + id_invoice + "'", "", "");

                                }

                                //MessageBox.Show("Ocurrio un error en respuesta del servidor API 6x01 1 '"+ result.ToString()+"'");
                            }
                        }
                        else
                        {

                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "ERROR . : API 7x00");
                            //MessageBox.Show("No hay respuesta del servidor API 7x00");
                            DB.enviar("7x00", "No hay respuesta del servidor API 7x00" + "\r\n Computer :" + Environment.MachineName.ToString());
                        }
                    }
                    //EnviarManual

                    #endregion
                    }
                }
            }
            #endregion

            //Create XML   
            //Send Email

            //Download Background /// Puede ser al server/
        }
    }
}