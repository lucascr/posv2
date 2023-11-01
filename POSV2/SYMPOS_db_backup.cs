using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;

namespace POSV2
{
    class SYMPOS_db_backup
    {
        public event Action<int> ProgressChanged;
        private BackgroundWorker bg = new BackgroundWorker();

        private void OnProgressChanged(int progress)
        {
            var eh = ProgressChanged;
            if (eh != null)
            {
                eh(progress);
            }
        }
        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressChanged(e.ProgressPercentage);
        }
        public void th_do_backup() {

            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(bg_DoBackup);
            bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            bg.RunWorkerAsync();
        }
        public void th_do_backup_complete() {

            bg.WorkerReportsProgress = true;
            bg.DoWork += new DoWorkEventHandler(bg_DoBackup);
            bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync();
        }
        public void Backup() {
            first myFirst = first.GetInstance();
            if (!DB.conectado)
            {                
                myFirst.conectDBMysql();
            }
            if (DB.conectado)
            {
                // encryptdecrypt.Decrypt(str_config_db_username, myp), encryptdecrypt.Decrypt(str_config_db_password, myp), encryptdecrypt.Decrypt(str_config_db_database, myp), encryptdecrypt.Decrypt(str_config_db_port, myp)
                DoBackup(myFirst.get_str_config_db_host() ,myFirst.get_str_config_db_username(),myFirst.get_str_config_db_password(),myFirst.get_str_config_db_database(), false);
                DB.checkVersion();
            }
        }
        private void bg_DoBackup(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            this.bg.ReportProgress(10);
            first myFirst = first.GetInstance();
            if (!DB.conectado)
            {                
                myFirst.conectDBMysql();
            }
            if (DB.conectado)
            {
                // encryptdecrypt.Decrypt(str_config_db_username, myp), encryptdecrypt.Decrypt(str_config_db_password, myp), encryptdecrypt.Decrypt(str_config_db_database, myp), encryptdecrypt.Decrypt(str_config_db_port, myp)
                DoBackup(myFirst.get_str_config_db_host(), myFirst.get_str_config_db_username(),myFirst.get_str_config_db_password(),myFirst.get_str_config_db_database());
                DB.checkVersion();
            }
            
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
            this.bg.ReportProgress(100);
            // Handle what to do when complete.                        
        }
        public static string Compress(FileInfo fi)        {
            string ret="";
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile =
                                File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);

                            /*Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());*/
                            first.cld("Compressed " + fi.Name.ToString() + " from " + fi.Length.ToString() + " to " + outFile.Length.ToString() + " bytes.");
                            ret = outFile.Name.ToString();
                        }
                    }
                }
            }
            return ret;
        }
        public static string Decompress(FileInfo fileToDecompress){
            string ret = "";
            using (FileStream originalFileStream = fileToDecompress.OpenRead()){
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[1024];
                        int nRead;
                        while ((nRead = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            decompressedFileStream.Write(buffer, 0, nRead);
                        }
                        //szOutFile = newFileName;
                        //Console.WriteLine("Decompressed: {0}", archFile.Name);
                        /*try
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }*/
                        //decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                        ret = newFileName.ToString();
                    }
                }
            }
            return ret;
        }


        public void REMOTESql( string remote_file, bool reportProgress = false)
        {
            string errores = "";
            first.cld("DoREMOTESql");
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : ");
            //Descargar CABYS
            string cabys_remoteUri = "http://www.socialymas.com/pos/";
            string cabys_fileName = remote_file+".zip", myStringWebResource = null;
            string cabys_local_filename = string.Format("{0}\\" + remote_file + ".zip", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);
            string cabys_local_filename_sql = string.Format("{0}\\" + remote_file, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : " + cabys_local_filename);
            if (File.Exists(@cabys_local_filename))
            {
                File.Delete(@cabys_local_filename);
            }
            // Create a new WebClient instance.
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = cabys_remoteUri + cabys_fileName;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run Downloading File  : " + cabys_remoteUri + cabys_fileName);
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", cabys_fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, cabys_local_filename);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", cabys_local_filename, myStringWebResource);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run Successfully Downloaded File  : " + cabys_remoteUri + cabys_fileName);

            if (reportProgress) { this.bg.ReportProgress(22); }
            try
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : A ");
                if (File.Exists(@cabys_local_filename))
                {
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : B ");
                    using (ZipFile zip = ZipFile.Read(cabys_local_filename))
                    {
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : C ");
                        foreach (ZipEntry e in zip)
                        {
                            if (File.Exists(@e.FileName.ToString()))
                            {
                                File.Delete(@e.FileName.ToString());
                            }
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : C " + @e.FileName.ToString());
                            e.Extract(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ExtractExistingFileAction.OverwriteSilently);

                             cabys_local_filename_sql = string.Format("{0}\\" + @e.FileName.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);

                        }
                    }

                    //Decompress
                    if (reportProgress) { this.bg.ReportProgress(23); }
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : D " + cabys_local_filename_sql);
                    if (File.Exists(cabys_local_filename_sql))
                    {
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql : E " + cabys_local_filename_sql);
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql readscript BEFORE : F ");
                        //MySql.Data.MySqlClient.MySqlScript script = new MySql.Data.MySqlClient.MySqlScript(DB.g, File.ReadAllText(cabys_local_filename_sql));
                        DB.readscript(cabys_local_filename_sql);
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoREMOTESql readscript DONE : F ");
                        MessageBox.Show("Proceso 1 Terminado");
                        if (reportProgress) { this.bg.ReportProgress(28); }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS readscript ERROR :  " + e.Message.ToString());
                errores += e.Message.ToString();
            }
            if (reportProgress) { this.bg.ReportProgress(29); }


        }
        public void CABYS(bool reportProgress = false) {
            string errores = "";
            first.cld("DoCABYS");
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : ");
            //Descargar CABYS
            string cabys_remoteUri = "http://www.socialymas.com/pos/";
            string cabys_fileName = "cabys.sql.zip", myStringWebResource = null;
            string cabys_local_filename = string.Format("{0}\\cabys.sql.zip", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);
            string cabys_local_filename_sql = string.Format("{0}\\cabys.sql", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : " + cabys_local_filename);
            if (File.Exists(@cabys_local_filename))
            {
                File.Delete(@cabys_local_filename);
            }
            // Create a new WebClient instance.
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = cabys_remoteUri + cabys_fileName;
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run Downloading File  : " + cabys_remoteUri + cabys_fileName);
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", cabys_fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, cabys_local_filename);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", cabys_local_filename, myStringWebResource);
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run Successfully Downloaded File  : " + cabys_remoteUri + cabys_fileName);

            if (reportProgress) { this.bg.ReportProgress(22); }
            try
            {
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : A " );
                if (File.Exists(@cabys_local_filename))
                {
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : B ");
                    using (ZipFile zip = ZipFile.Read(cabys_local_filename))
                    {
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : C ");
                        foreach (ZipEntry e in zip)
                        {
                            if (File.Exists(@e.FileName.ToString()))
                            {
                                File.Delete(@e.FileName.ToString());
                            }
                            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : C " + @e.FileName.ToString());
                            e.Extract(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                    
                    //Decompress
                    if (reportProgress) { this.bg.ReportProgress(23); }
                    first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : D " + cabys_local_filename_sql);
                    if (File.Exists(cabys_local_filename_sql))
                    {
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS : E " + cabys_local_filename_sql);
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS readscript BEFORE : F ");
                        //MySql.Data.MySqlClient.MySqlScript script = new MySql.Data.MySqlClient.MySqlScript(DB.g, File.ReadAllText(cabys_local_filename_sql));
                        DB.readscript(cabys_local_filename_sql);
                        first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS readscript DONE : F ");

                        if (reportProgress) { this.bg.ReportProgress(28); }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run DoCABYS readscript ERROR :  " + e.Message.ToString());
                errores += e.Message.ToString();
            }
            if (reportProgress) { this.bg.ReportProgress(29); }

            
        }
        private void DoBackup(string db_host, string db_user,string db_pass,string db_name,bool reportProgress = true) {
            //   if( )
            // path = @"D:\MySQL\MySQL Server 5.5\bin\mysqldump.exe -u " + txtBoxDBUsername.Text + @" -p " + txtBoxDBName.Text + @" > D:\C#\Client\Salesmate - EMC\SalesMate\Backup\" + maskeTxtBoxDBFile.Text + @"";
            first.cld("DoBackup");
            if (reportProgress) { this.bg.ReportProgress(20); }
            VarCompany my_company = DB.CheckCompanyPOS();

            first myFirst = first.GetInstance();
            string suc = myFirst.getKey("pos_sucursal");
            string ter = myFirst.getKey("pos_terminal");
            
            string myToken = my_company.cloud_api_token;
            string myserver = my_company.cloud_api_type.ToString() == "1" ? my_company.cloud_api_prod : my_company.cloud_api_test;
            string errores = "";
            string file_upload = "";
            string filename = string.Format("{0}\\"+ myToken + "_" + suc + ter +  "_db_{1:yyyyMMddHHmmss}.sql", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now);
            first.cld("Filename "+ filename.ToString());
                                   
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "C:\\AppServ\\MySQL\\bin\\mysqldump.exe";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            //psi.Arguments = " --no-defaults --databases symposv2 --tables products invoice invoice_detail --user="+ db_user + " --password="+ db_pass + " --result-file " + filename;
            psi.Arguments = " --no-defaults "+ db_name + " --no-create-db --host=" + db_host + " --user=" + db_user + " --password="+ db_pass + " --result-file \"" + filename + "\"";
            first.cld("PSI " + psi.Arguments.ToString());
            //psi.Arguments = " --no-defaults --databases symposv2 --tables --user=root --password=q1w2e3r4 --result-file " + filename;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            if (reportProgress) { this.bg.ReportProgress(30); }

            /*
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.ErrorDialog = false;
            */
            try
            {
                //Process process = Process.Start(psi);
                if (reportProgress) { this.bg.ReportProgress(40); }
                //StreamReader stdoutSR = process.StandardOutput;
                //string stdout = stdoutSR.ReadToEnd();
                
                using (Process process = Process.Start(psi))
                {
                    StreamReader stderrSR = process.StandardError;
                    string stderr = stderrSR.ReadToEnd();
                    process.WaitForExit();
                }
                if (reportProgress) { this.bg.ReportProgress(50); }
                FileInfo fi = new FileInfo(filename);
                if (reportProgress) { this.bg.ReportProgress(60); }
                
                string fileGz=Compress(fi);
                if (reportProgress) { this.bg.ReportProgress(70); }
                if (fileGz.ToString().Length > 0) {
                    
                    if (File.Exists(@filename))
                    {
                        File.Delete(@filename);
                    }
                    try
                    {
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {

                            client.Headers.Add("Content-Type", "binary/octet-stream");
                            string filePath = @fileGz.ToString();
                            first.cld("GZ " + filePath.ToString());
                            var serverPath = new Uri(@myserver + "/backup.php?token=" + myToken + "&pos=" + suc + ter );
                            first.cld("SP " + serverPath.ToString());
                            byte[] bret = client.UploadFile(serverPath,filePath);
                            string result = Encoding.UTF8.GetString(bret);
                            first.cld("R: " + result.ToString());
                            file_upload = filePath;
                            if (File.Exists(@filePath))
                            {
                                File.Delete(@filePath);
                            }
                        }

                    }
                    catch (Exception err)
                    {
                        //MessageBox.Show(err.Message);
                        errores += err.Message.ToString();
                        first.cld("ERROR db 1x001 " + errores.ToString());

                    }

                    if (reportProgress) { this.bg.ReportProgress(80); }
                }else {
                    first.cld("ERROR db 1x002 ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                errores += e.Message.ToString();
            }

            NameValueCollection inputs = new NameValueCollection();
            inputs.Add("token", myToken);
            inputs.Add("data", "1");
            inputs.Add("file", file_upload);
            inputs.Add("error", errores);
            if (reportProgress) { this.bg.ReportProgress(90); }
            using (System.Net.WebClient wclient = new System.Net.WebClient())
            {

                byte[] bret2 = wclient.UploadValues(myserver + "/apiBackup.php", inputs);

                string result2 = Encoding.UTF8.GetString(bret2);
            }

            if (reportProgress) { this.bg.ReportProgress(100); }
        }
    }
}
