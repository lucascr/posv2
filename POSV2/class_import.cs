using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace POSV2
{
    class class_import
    {

        public delegate void ProgressUpdate(int value);

        public event ProgressUpdate OnProgressUpdate;
        public List<class_xls_import.xls_import> importExcelSCLA_LoadTitulos(string fn)
        {
            if (IsFileLocked(fn))
            {
                MessageBox.Show("Archivo en uso");
                return null;
            }
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            String connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fn);

            List<class_xls_import.xls_import> xlsList = new List<class_xls_import.xls_import>();
            xlsList.Add(new class_xls_import.xls_import { titulo_col = "-NO APLICA-", id_columna = -1 });

            //string excelSheet_name = "";
            try
            {
                using (objConn = new OleDbConnection(connectionString))
                {
                    objConn.Open();
                    dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dt == null)
                    {
                        MessageBox.Show("Ocurrio un error y no se pueden cargar las hojas");
                        return null;
                    }
                    String[] excelSheets = new String[dt.Rows.Count];
                    int i = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        //excelSheet_name = excelSheets[i];
                        class_xls_import.sheet_name = excelSheets[i];
                        Console.WriteLine(row["TABLE_NAME"].ToString());
                        /*
                            if (row["TABLE_NAME"].ToString() == "DEUDORES$"){                                
                                
                            }else if (row["TABLE_NAME"].ToString() == "FIADORES$"){

                                
                            }else{
                                    Console.WriteLine(row["TABLE_NAME"].ToString());
                                    MessageBox.Show("Ocurrió un error, no existen las hojas a buscar 1x03");
                                return;
                            }
                            */

                        OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter("select * from [" + row["TABLE_NAME"].ToString() + "]", objConn);

                        DataSet excelDataSet = new DataSet();
                        DataTable excelDataTable = new DataTable();
                        objDA.Fill(excelDataTable);

                        int rows = excelDataTable.Rows.Count;
                        int cols = excelDataTable.Columns.Count;

                        DataRow rowD = excelDataTable.Rows[0];
                        foreach (DataColumn colD in excelDataTable.Columns)
                        {
                            Console.WriteLine(colD.ToString());
                            Console.WriteLine(rowD[colD.Ordinal].ToString());
                            xlsList.Add(new class_xls_import.xls_import { titulo_col = colD.ToString() + " ( " + rowD[colD.Ordinal].ToString() + " ) ", id_columna = colD.Ordinal, titulo_col_num = colD.ToString() });
                        }

                        break;
                        i++;
                    }
                    //MessageBox.Show("Se actualizaron " + total_deudores.ToString() + " deudores." + Environment.NewLine + "Se agregaron " + nuevos_deudores.ToString() + " registros nuevos" + Environment.NewLine + "Se agregaron " + nuevos_numeros.ToString() + " números nuevos");
                    //MessageBox.Show("Se actualizaron " + total_deudores.ToString() + " deudores. " + total_fiadores.ToString() + " fiadores." + Environment.NewLine + "Se agregaron " + nuevos_deudores.ToString() + " deudores y " + nuevos_fiadores.ToString() + " fiadores registros nuevos" + Environment.NewLine + "Se agregaron " + nuevos_numeros.ToString() + " números deudores nuevos y " + nuevos_numeros_fiadores.ToString() + " números fiadores nuevos");
                }
            }
            catch (Exception ex)
            {
                //return null;
                MessageBox.Show("Ocurrio un error grave " + ex.ToString());
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
            return xlsList;

        }

        public virtual bool IsFileLocked(string file)
        {
            FileStream stream = null;
            FileInfo myfile = new FileInfo(file);
            try
            {
                stream = myfile.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
