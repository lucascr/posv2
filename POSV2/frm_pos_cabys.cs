using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSV2
{
    public partial class frm_pos_cabys : Form
    {
        string my_xls_path = "";

        string total_rows_loaded = "";
        List<class_xls_import.xls_import> Global_myList;
        bool cargaLista = false;

        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;
        public List<ComboBox> ListaCombos = new List<ComboBox>();


        public frm_pos_cabys()
        {
            InitializeComponent();
            if (DB.checkAsada()) {
                load_cmb_asada_tipo();
                load_cmb_asada_lectura();
            }
        }

        #region CABYS
        private void t1_OnProgressUpdate(int value)
        {
            // Its another thread so invoke back to UI thread
            base.Invoke((Action)delegate
            {
                //label1.Text += Convert.ToString(value);
                progressBar1.Value = value;
                lbl_progressBar1.Text = value.ToString();
                Application.DoEvents();
            });
        }
        void waitBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_progressBar1.Text = total_rows_loaded;
            activar_botones();
            //--------- END THREADS
            //this.Cursor = Cursors.Default;
            //TimeSpan elapsed = DateTime.Now.Subtract(StartTime);
            //MessageBox.Show(String.Format("{0} activities in {1:G}", TotalIteration, elapsed.ToString()));
            //MessageBox.Show("Termine");
            //Observer.Abort();
        }
        private void waitBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            //this.Text = e.ProgressPercentage.ToString();
        }

        private void desactivar_botones()
        {
            btn_read_excel.Enabled = false;
            btn_update_excel.Enabled = false;
        }
        private void activar_botones()
        {
            btn_read_excel.Enabled = true;
            btn_update_excel.Enabled = true;
        }

        private void btn_update_cabys_Click(object sender, EventArgs e)
        {

            SYMPOS_db_backup _symposbk = new SYMPOS_db_backup();
            _symposbk.CABYS();

        }
        private void cargar_cmb(ComboBox cmb, List<class_xls_import.xls_import> myList)
        {
            //List<class_xls_import.xls_import> new_list = new List<class_xls_import.xls_import>();
            Console.WriteLine(cmb.Name.ToString());
            ListaCombos.Add(cmb);

            List<class_xls_import.xls_import> new_list = new List<class_xls_import.xls_import>(myList);
            //new_list= myList;
            //new List<class_xls_import.xls_import>();
            cmb.DataSource = new_list;
            cmb.DisplayMember = "titulo_col";
            cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);

        }
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedIndex > 0)
            {
                int cuenta = 0;
                foreach (ComboBox selCmb in ListaCombos)
                {
                    cuenta++;
                    if (selCmb.SelectedIndex == cmb.SelectedIndex && selCmb.Name.ToString() != cmb.Name.ToString())
                    {
                        MessageBox.Show("El Item ya se encuentra seleccionado en " + selCmb.Name.ToString());
                        break;
                    }
                }
                //MessageBox.Show(cmb.SelectedItem.ToString());
            }
            //if (cargaLista) { BuscarFaltantes(); }


        }
        private int getId(ComboBox cmb)
        {
            if (cmb.SelectedIndex > 0)
            {
                return ((class_xls_import.xls_import)cmb.SelectedItem).id_columna;
            }
            else
            {
                return 0;
            }
        }

        private string procesar_cabys(string tabla_import) {
            string ret = "";

            try
            {
                /*string sql_select_cabys = @"update products
INNER JOIN product_import_cabys ON product_import_cabys.imp_codigobarras = products.product_sym_barcode  and product_import_cabys.imp_estado=1
set product_codigo_cabys = product_import_cabys.imp_cabys";
                DB.q(sql_select_cabys, "", "");
                ret = DB.public_dr.RecordsAffected.ToString();

                string sql_update_cabys = @"update product_import_cabys set imp_estado=2 where imp_estado=1";
                DB.q(sql_update_cabys, "", "");*/

                string sql_update_cabys = @"select product_import_cabys.imp_codigobarras ,products.product_sym_barcode from products
INNER JOIN product_import_cabys ON product_import_cabys.imp_codigobarras = products.product_sym_barcode  ";

                DataTable tDt = DB.q(sql_update_cabys, "", "");
                foreach (DataRow r in tDt.Rows)
                {

                }


            }
            catch (Exception e) {
                MessageBox.Show("Error importando 0x002 : " + e.ToString());
            }

            return ret;
        }

        private void btn_read_excel_Click(object sender, EventArgs e)
        {
            ListaCombos.Clear();
            if (DB.SuperLoginForm("excel"))
            {

            }
            cargaLista = false;
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog1.Title = "Importar Deudores";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    my_xls_path = openFileDialog1.FileName;
                    class_import myImport = new class_import();
                    myImport.OnProgressUpdate += t1_OnProgressUpdate;
                    if (my_xls_path.Length > 0)
                    {


                        List<class_xls_import.xls_import> myList = myImport.importExcelSCLA_LoadTitulos(my_xls_path);
                        Global_myList = myList;
                        //cmb_xls_nombre.DataSource = myList;
                        //cmb_xls_nombre.DisplayMember = "titulo_col";
                        if (!(myList == null))
                        {
                            class_xls_import.xls_list = myList;
                            lbl_xls_path.Text = my_xls_path.ToString();
                            lbl_xls_sheet.Text = class_xls_import.sheet_name.ToString();



                            cargar_cmb(cmb_xls_codigobarras, myList);
                            cargar_cmb(cmb_xls_cabys, myList);

                            cargar_cmb(cmb_xls_descripcion, myList);
                            cargar_cmb(cmb_xls_sku, myList);
                            cargaLista = true;

                            btn_update_excel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error y no se cargó el excel 1x03");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al cargar el path 1x01");
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error 1x02");
                }

            }
        }

        private void btn_update_excel_Click(object sender, EventArgs e)
        {

            if (cmb_xls_codigobarras.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un Codigo Barras");
                return;
            }
            if (cmb_xls_cabys.SelectedIndex < 1)
            {
                MessageBox.Show("Debe seleccionar un codigo CABYS");
                return;
            }
            desactivar_botones();

            class_xls_import.xls_import_col xls_col = new class_xls_import.xls_import_col();

            xls_col.id_codigobarras = getId(cmb_xls_codigobarras);
            xls_col.id_cabys = getId(cmb_xls_cabys);

            if (cmb_xls_descripcion.SelectedIndex > 0)
            {
                xls_col.id_sku_nombre = getId(cmb_xls_descripcion);
            }
            else {
                xls_col.id_sku_nombre = -1;
            }

            if (cmb_xls_sku.SelectedIndex > 0)
            {
                xls_col.id_sku = getId(cmb_xls_sku);
            }
            else
            {
                xls_col.id_sku = -1;
            }

            importExcelPOSCABYSV1(xls_col);

        }

        public void importExcelPOSCABYSV1(object xls_col)
        {
            BackgroundWorker waitBW = new BackgroundWorker();
            waitBW.WorkerReportsProgress = true;
            waitBW.DoWork += new DoWorkEventHandler(waitBW_DoWork_CABYS);

            waitBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(waitBW_RunWorkerCompleted);
            waitBW.ProgressChanged += new ProgressChangedEventHandler(waitBW_ProgressChanged);
            OnProgressUpdate += t1_OnProgressUpdate;

            object[] parameters = new object[] { lbl_xls_path.Text.ToString(), xls_col, class_xls_import.xls_list };
            try
            {
                waitBW.RunWorkerAsync(parameters);
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el thread");
            }
        }

        private void waitBW_DoWork_CABYS(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("waitBW_DoWork");
            //bg_importExcelSCLAv2(lbl_xls_path.Text.ToString(), ((cbi)cmb_dd_import_proyectos.SelectedItem).HiddenValue, sender as BackgroundWorker);
            //string my_proyect = ((cbi)cmb_dd_import_proyectos.SelectedItem).HiddenValue.ToString();
            object[] parameters = e.Argument as object[];

            bg_importExcelCABYS_V1((string)parameters[0], (class_xls_import.xls_import_col)parameters[1], (List<class_xls_import.xls_import>)parameters[2], "1", sender as BackgroundWorker);
            // lbl_xls_path.Text = "";
        }

        public void bg_importExcelCABYS_V1(string fn, object xls_col, object xls_name_col, string id_proyecto, BackgroundWorker bw)
        {
            Console.WriteLine("bg_importExcel_CABYS");

            class_xls_import.xls_import_col my_xls_col = (class_xls_import.xls_import_col)xls_col;

            class_import myImport = new class_import();

            List<class_xls_import.xls_import> myList = (List<class_xls_import.xls_import>)xls_name_col;
            if (myImport.IsFileLocked(fn))
            {
                MessageBox.Show("Ocurrió un error y no se pudo cargar el XLS");
                return;
            }

            if (my_xls_col.id_cabys == 0)
            {
                MessageBox.Show("Ocurrio un error y no se puede cargar");
                return;
            }
            System.Data.DataTable dt = null;

            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(1);
            }


            string sql_i_cabys = "", file_name_excel = "", sql_i_cabys_dup = "";
            string internal_i = "", codigobarras_actualizados = "";
            int total_deudores = 0;

            //Desactiva TODOS
            //cmb_tipo_import

            dt = ReadExcelToDatatble(lbl_xls_sheet.Text, fn, 1, 1);



            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;
            DataTable excelDataTable = dt;

            Random rnd = new Random();

            file_name_excel = (lbl_xls_path.Text.PadRight(255)).Trim().ToString();
            int this_excel_id = rnd.Next(10000, 99999);
            double totalperRow = ((double)1000 / Convert.ToDouble(excelDataTable.Rows.Count.ToString()));

            foreach (DataRow rowD in excelDataTable.Rows)
            {
                //9

                if ((rowD[my_xls_col.id_codigobarras].ToString()).Length > 0 && (rowD[my_xls_col.id_cabys].ToString()).Length > 0)
                {
                    //total_deudores++;                    
                    if (DB.i(rowD[my_xls_col.id_cabys].ToString()).Length == 13 || DB.i(rowD[my_xls_col.id_cabys].ToString()).Length == 12)
                    {

                        total_deudores = total_deudores + 1;
                        OnProgressUpdate((int)Math.Round(totalperRow * total_deudores));

                        sql_i_cabys = "insert ignore into product_import_cabys set imp_filename='" + file_name_excel + "',imp_codigobarras='" + DB.i(rowD[my_xls_col.id_codigobarras].ToString()) + "',imp_cabys='" + DB.i(rowD[my_xls_col.id_cabys].ToString().PadLeft(13, '0')) + "'";
                        sql_i_cabys_dup = "insert ignore into product_import_cabys_dup set imp_filename='" + file_name_excel + "',imp_codigobarras='" + DB.i(rowD[my_xls_col.id_codigobarras].ToString()) + "',imp_cabys='" + DB.i(rowD[my_xls_col.id_cabys].ToString().PadLeft(13, '0')) + "'";
                        if (my_xls_col.id_sku >= 0)
                        {
                            sql_i_cabys += ",imp_sku='" + DB.i(rowD[my_xls_col.id_sku].ToString()) + "'";
                            sql_i_cabys_dup += ",imp_sku='" + DB.i(rowD[my_xls_col.id_sku].ToString()) + "'";
                        }
                        if (my_xls_col.id_sku_nombre >= 0)
                        {
                            sql_i_cabys += ", imp_name='" + DB.i(rowD[my_xls_col.id_sku_nombre].ToString()) + "'";
                            sql_i_cabys_dup += ", imp_name='" + DB.i(rowD[my_xls_col.id_sku_nombre].ToString()) + "'";
                        }
                        sql_i_cabys += ",d_excel='" + this_excel_id + "',imp_date=now() ON DUPLICATE KEY UPDATE cuenta=cuenta+1;";
                        sql_i_cabys_dup += ",d_excel='" + this_excel_id + "',imp_date=now()";

                        DB.e(sql_i_cabys, "", "");

                        //sql_i_cabys_dup = "insert ignore into product_import_cabys_dup set imp_filename='" + file_name_excel + "',imp_codigobarras='" + DB.i(rowD[my_xls_col.id_codigobarras].ToString()) + "',imp_cabys='" + DB.i(rowD[my_xls_col.id_cabys].ToString().PadLeft(13, '0')) + "',imp_sku='" + DB.i(rowD[my_xls_col.id_sku].ToString()) + "', imp_name='" + DB.i(rowD[my_xls_col.id_sku_nombre].ToString()) + "' ,d_excel='" + this_excel_id + "',imp_date=now()";
                        DB.e(sql_i_cabys_dup, "", "");

                        internal_i = DB.lId;
                        file_name_excel = "";
                    }
                    else {
                        Console.WriteLine("ERROR Codigo " + rowD[my_xls_col.id_codigobarras].ToString());
                        Console.WriteLine("ERROR Codigo CABYS " + rowD[my_xls_col.id_cabys].ToString());
                    }
                    //save_c_deudores_db(my_xls_col.scla_clasificacion, rowD, internal_i, "scla_clasificacion");

                }
                else
                {
                    Console.WriteLine("ERROR Codigo " + rowD[my_xls_col.id_codigobarras].ToString());
                    Console.WriteLine("ERROR Codigo CABYS " + rowD[my_xls_col.id_cabys].ToString());
                    //                                Console.WriteLine(rowD[0].ToString());
                    //                                Console.WriteLine((rowD[0].ToString() + rowD[1].ToString()).ToString());
                }
            }
            total_rows_loaded = total_deudores.ToString();
            if (total_deudores == 0) {
                MessageBox.Show("Se terminó la importación de CABYS , No se importaron datos porque el CABYS seleccionado no cumple con los requisitos ");
            } else {
                //codigobarras_actualizados =procesar_cabys();
                //+ " Cargados y se actualizaron "+ codigobarras_actualizados.ToString() + " Productos "
                MessageBox.Show("Se terminó la importación de CABYS Satisfactoriamente de " + total_deudores.ToString());
            }
            //activar_botones();
        }
        public DataTable ReadExcelToDatatble(string worksheetName, string saveAsLocation, int HeaderLine, int ColumnStart)
        {
            System.Data.DataTable dataTable = new DataTable();
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range range;
            excel = new Microsoft.Office.Interop.Excel.Application();

            try
            {

                // Get Application object.
                excel.Visible = false;
                excel.DisplayAlerts = false;
                // Creation a new Workbook
                //excelworkBook = excel.Workbooks.Open(saveAsLocation);
                // Workk sheet
                /*excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)
                                      excelworkBook.Worksheets.Item["DEUDORES$"];*/
                /*excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)
                excelworkBook.Worksheets.Item[worksheetName];*/
                //excelSheet = (excel.Worksheet)exWbk.Sheets["Sheet1"];                
                //excelworkBook = excel.Workbooks.Open(saveAsLocation);
                //excelworkBook = excel.Workbooks.Open(saveAsLocation, 0, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelworkBook = excel.Workbooks.Open(saveAsLocation, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.Worksheets.get_Item(1);

                //Console.WriteLine(excelworkBook.Sheets.ToString() );
                //Console.WriteLine(excelworkBook.Worksheets.ToString());
                //Console.WriteLine(excelworkBook.Worksheets.Item(1).ToString());
                //excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.Worksheets.Item(1);// Sheets["DEUDORES$"];
                //excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.Sheets["DEUDORES$"];

                range = excelSheet.UsedRange;
                int cl = range.Columns.Count;
                // loop through each row and add values to our sheet
                int rowcount = range.Rows.Count;
                double totalperRow = ((double)1000 / Convert.ToDouble(rowcount));

                //create the header of table
                for (int j = ColumnStart; j <= cl; j++)
                {
                    dataTable.Columns.Add(Convert.ToString
                                         (range.Cells[HeaderLine, j].Value2), typeof(string));
                }
                //filling the table from  excel file                
                for (int i = HeaderLine + 1; i <= rowcount; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int j = ColumnStart; j <= cl; j++)
                    {

                        dr[j - ColumnStart] = Convert.ToString(range.Cells[i, j].Value2);
                    }

                    dataTable.Rows.InsertAt(dr, dataTable.Rows.Count + 1);


                    OnProgressUpdate((int)Math.Round(totalperRow * i));
                }

                //now close the workbook and make the function return the data table

                excelworkBook.Close();
                excel.Quit();
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                excel.Quit();
                excelSheet = null;
                range = null;
                excelworkBook = null;
                return null;
            }
            finally
            {

                excel.Quit();
                excelSheet = null;
                range = null;
                excelworkBook = null;
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {

            SYMPOS_db_backup _symposbk = new SYMPOS_db_backup();
            _symposbk.REMOTESql("sku.sql");
        }

        private void btn_update_sku_Click(object sender, EventArgs e)
        {
            procesar_REMOTEsql("sku");
        }
        private string procesar_REMOTEsql(string sql_table)
        {
            string ret = "";

            try
            {
                string sql_select_cabys = @"update products
INNER JOIN " + sql_table + " ON " + sql_table + @".imp_sku = products.product_sym_barcode 
set product_codigo_cabys = " + sql_table + ".imp_cabys";
                DB.q(sql_select_cabys, "", "");
                ret = DB.public_dr.RecordsAffected.ToString();

                string sql_update_cabys = @"update " + sql_table + " set imp_estado=2 where imp_estado=1";
                DB.q(sql_update_cabys, "", "");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error importando 0x002 : " + e.ToString());
            }

            return ret;
        }

        private void btn_actualizar_cabys_Click(object sender, EventArgs e)
        {
            string codigobarras_actualizados = procesar_cabys("product_import_cabys");
            MessageBox.Show(" Cargados y se actualizaron " + codigobarras_actualizados.ToString() + " Productos ");
        }


        private void btn_load_60k_Click(object sender, EventArgs e)
        {
            /*string codigobarras_actualizados = procesar_cabys("product_import_cabys_uni_1");
            MessageBox.Show(" Cargados y se actualizaron " + codigobarras_actualizados.ToString() + " Productos ");*/
            //60K
            //Descargar
            btn_load_60k.Enabled = false;
            SYMPOS_db_backup _symposbk = new SYMPOS_db_backup();
            _symposbk.REMOTESql("product_import_cabys_uni_1.sql");

            /*string sql_select_cabys = @"update products
INNER JOIN product_import_cabys ON product_import_cabys.imp_codigobarras = products.product_sym_barcode  and product_import_cabys.imp_estado=1
set product_codigo_cabys = product_import_cabys.imp_cabys";
            DB.q(sql_select_cabys, "", "");
            ret = DB.public_dr.RecordsAffected.ToString();

            string sql_update_cabys = @"update product_import_cabys set imp_estado=2 where imp_estado=1";
            DB.q(sql_update_cabys, "", "");*/



            /*
        try
        {
            string sql_update_cabys = @"select product_import_cabys_uni_1.imp_cabys ,products.product_sym_barcode from products
INNER JOIN product_import_cabys_uni_1 ON product_import_cabys_uni_1.imp_codigobarras = products.product_sym_barcode and products.product_codigo_cabys is null  ";
            string sql_update = "";

            DataTable tDt = DB.q(sql_update_cabys, "", "", true, false, false);
            foreach (DataRow r in tDt.Rows)
            {
                sql_update = "update products set product_codigo_cabys='" + r["imp_cabys"].ToString() + "' where product_sym_barcode='" + r["product_sym_barcode"].ToString() + "'";
                DB.e(sql_update, "", "");
            }
        }
        catch (Exception err)
        {
            MessageBox.Show("Error importando 0x002 : " + err.ToString());
        }*/
        }

        private void btn_cabys_60k_do_Click(object sender, EventArgs e)
        {
            btn_cabys_60k_do.Enabled = false;
            try
            {


                DB.q("alter table products add product_codigo_cabys_bk varchar(255) DEFAULT NULL;", "", "",false);
                DB.q("update products set product_codigo_cabys_bk = product_codigo_cabys where product_codigo_cabys is not null;", "", "", false);



                /*
                string sql_update_cabys = @"update products
INNER JOIN product_import_cabys_uni_1 ON product_import_cabys_uni_1.imp_codigobarras = products.product_sym_barcode and products.product_codigo_cabys is null
set products.product_codigo_cabys = product_import_cabys_uni_1.imp_cabys  ";

                DB.q(sql_update_cabys, "", "", true, false, false);
                */
                string sql_update_cabys = @"select product_import_cabys_uni_1.imp_cabys ,product_import_cabys_uni_1.imp_codigobarras from product_import_cabys_uni_1";
                string sql_update = "";

                DataTable tDt = DB.q(sql_update_cabys, "", "", true, false, false);
                string total = tDt.Rows.Count.ToString();
                int i = 1;
                foreach (DataRow r in tDt.Rows)
                {
                    sql_update = "update products set product_codigo_cabys='" + r["imp_cabys"].ToString() + "' where product_sym_barcode='" + r["imp_codigobarras"].ToString() + "'";
                    DB.e(sql_update, "", "");
                    i++;
                    lbl_progressBar1.Text = i.ToString() + "  de " + total.ToString();
                    Application.DoEvents();
                }

                MessageBox.Show("Proceso 2 Terminado");
                //MessageBox.Show("Codigos Actualizados : " + DB.public_dr.RecordsAffected.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("Error importando 0x002 : " + err.ToString());
            }
        }
        #endregion CABYS
        #region ASADA_Excel
        private void desactivar_botones_asada()
        {
            btn_import_excel.Enabled = false;
            btn_asada_subir_excel.Enabled = false;
        }
        private void activar_botones_asada()
        {
            btn_import_excel.Enabled = true;
            btn_asada_subir_excel.Enabled = true;
        }
        private void load_cmb_asada_tipo() {

            cmb_xls_asada_tipo.Items.Clear();
            string sql_load_pos_config_mysql = "select * from asada_tipo_tarifa  ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                cmb_xls_asada_tipo.Items.Add(new cba(r["asada_titulo"].ToString(), r["asada_consumo_fija_id"].ToString(), r["asada_dom_emp_id"].ToString(), r["asada_monto_fija"].ToString(), r["id_asada_tipo_tarifa"].ToString()));
            }
        }
        private void btn_import_excel_Click(object sender, EventArgs e)
        {
            ListaCombos.Clear();
            if (DB.SuperLoginForm("excel"))
            {

            }
            cargaLista = false;
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog1.Title = "Importar Deudores";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    my_xls_path = openFileDialog1.FileName;
                    class_import myImport = new class_import();
                    myImport.OnProgressUpdate += t1_OnProgressUpdate;
                    if (my_xls_path.Length > 0)
                    {


                        List<class_xls_import.xls_import> myList = myImport.importExcelSCLA_LoadTitulos(my_xls_path);
                        Global_myList = myList;
                        //cmb_xls_nombre.DataSource = myList;
                        //cmb_xls_nombre.DisplayMember = "titulo_col";
                        if (!(myList == null))
                        {
                            class_xls_import.xls_list = myList;
                            lbl_xls_path.Text = my_xls_path.ToString();
                            lbl_xls_sheet.Text = class_xls_import.sheet_name.ToString();


                            cargar_cmb(cmb_xls_num_medidor, myList);
                            cargar_cmb(cmb_xls_primera_lectura, myList);

                            cargar_cmb(cmb_xls_cedula, myList);
                            cargar_cmb(cmb_xls_nombre, myList);
                            cargar_cmb(cmb_xls_apellido, myList);
                            cargar_cmb(cmb_xls_telefono, myList);

                            cargaLista = true;

                            btn_asada_subir_excel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error y no se cargó el excel 1x03");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al cargar el path 1x01");
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error 1x02");
                }

            }
        }
        private void btn_asada_subir_excel_Click(object sender, EventArgs e)
        {

            if (cmb_xls_num_medidor.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un num medidor");
                return;
            }
            if (cmb_xls_asada_tipo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Tipo ");
                return;
            }
            desactivar_botones_asada();

            class_xls_import_asada.xls_import_col xls_col = new class_xls_import_asada.xls_import_col();

            xls_col.id_asada_tipo = ((cba)cmb_xls_asada_tipo.SelectedItem).hv_idTarifa;
            xls_col.sel_cmb = (cba)cmb_xls_asada_tipo.SelectedItem;

            xls_col.id_num_medidor= getId(cmb_xls_num_medidor);

            if (cmb_xls_primera_lectura.SelectedIndex > 0)            {
                xls_col.id_primera_lectura = getId(cmb_xls_primera_lectura);
            }            else            {
                xls_col.id_primera_lectura = -1;
            }

            if (cmb_xls_cedula.SelectedIndex > 0)            {
                xls_col.id_cedula = getId(cmb_xls_cedula);
            }            else            {
                xls_col.id_cedula = -1;
            }

            if (cmb_xls_nombre.SelectedIndex > 0)            {
                xls_col.id_nombre = getId(cmb_xls_nombre);
            }            else            {
                xls_col.id_nombre = -1;
            }
            if (cmb_xls_apellido.SelectedIndex > 0)            {
                xls_col.id_apellido = getId(cmb_xls_apellido);
            }            else            {
                xls_col.id_apellido = -1;
            }
            if (cmb_xls_telefono.SelectedIndex > 0)            {
                xls_col.id_telefono = getId(cmb_xls_telefono);
            }            else            {
                xls_col.id_telefono = -1;
            }
            importExcelPOSASADAV1(xls_col);
            activar_botones_asada();
        }
        public void importExcelPOSASADAV1(object xls_col)
        {
            BackgroundWorker waitBW = new BackgroundWorker();
            waitBW.WorkerReportsProgress = true;
            waitBW.DoWork += new DoWorkEventHandler(waitBW_DoWork_ASADA);

            waitBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(waitBW_RunWorkerCompleted);
            waitBW.ProgressChanged += new ProgressChangedEventHandler(waitBW_ProgressChanged);
            OnProgressUpdate += t1_OnProgressUpdate;

            object[] parameters = new object[] { lbl_xls_path.Text.ToString(), xls_col, class_xls_import_asada.xls_list };
            try
            {
                waitBW.RunWorkerAsync(parameters);
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el thread");
            }
        }
        private void waitBW_DoWork_ASADA(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];

            bg_importExcelASADA_V1((string)parameters[0], (class_xls_import_asada.xls_import_col)parameters[1], (List<class_xls_import_asada.xls_import>)parameters[2], "1", sender as BackgroundWorker);
        }

        public void bg_importExcelASADA_V1(string fn, object xls_col, object xls_name_col, string id_proyecto, BackgroundWorker bw)
        {
            Console.WriteLine("bg_importExcel_ASADA");

            class_xls_import_asada.xls_import_col my_xls_col = (class_xls_import_asada.xls_import_col)xls_col;

            class_import myImport = new class_import();

            List<class_xls_import_asada.xls_import> myList = (List<class_xls_import_asada.xls_import>)xls_name_col;
            if (myImport.IsFileLocked(fn))
            {
                MessageBox.Show("Ocurrió un error y no se pudo cargar el XLS");
                return;
            }

            if (my_xls_col.id_asada_tipo == "")
            {
                MessageBox.Show("Ocurrio un error y no se puede cargar");
                return;
            }
            System.Data.DataTable dt = null;

            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(1);
            }


            string sql_i_asada_cli = "", file_name_excel = "", sql_i_asada_cli_info = "";
            string internal_i = "";
            int total_deudores = 0;

            //Desactiva TODOS
            //cmb_tipo_import

            dt = ReadExcelToDatatble(lbl_xls_sheet.Text, fn, 1, 1);



            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;
            DataTable excelDataTable = dt;

            Random rnd = new Random();

            file_name_excel = (lbl_xls_path.Text.PadRight(255)).Trim().ToString();
            int this_excel_id = rnd.Next(10000, 99999);
            double totalperRow = ((double)1000 / Convert.ToDouble(excelDataTable.Rows.Count.ToString()));

            foreach (DataRow rowD in excelDataTable.Rows)
            {
                //9
                if ((my_xls_col.id_asada_tipo.ToString()).Length > 0 && (rowD[my_xls_col.id_num_medidor].ToString()).Length > 0){
                    total_deudores = total_deudores + 1;
                    OnProgressUpdate((int)Math.Round(totalperRow * total_deudores));


                    sql_i_asada_cli = "insert  into clients set client_cd=now()";
                    Console.WriteLine("-------------");
                    Console.WriteLine(rowD[my_xls_col.id_cedula].ToString());
                    Console.WriteLine(rowD[my_xls_col.id_cedula].ToString().Trim().Length);

                    sql_i_asada_cli_info = "insert  into asada_cli_info set id_asada_tipo_tarifa='"+ my_xls_col.id_asada_tipo + "'" +
                        ",asada_medidor='" + DB.i(rowD[my_xls_col.id_num_medidor].ToString()).Trim() + "'";

                    sql_i_asada_cli_info += ",asada_tipo_FC='" + my_xls_col.sel_cmb.hv_tipo_tarifaFIJACON.ToString() + "'" +
                            ",asada_tipo_DE='" + my_xls_col.sel_cmb.hv_tipo_tarifaDOMEMP.ToString() + "'";

                    if (my_xls_col.sel_cmb.hv_tipo_tarifaFIJACON.ToString() == "1")
                    {
                        //FIJA                        
                    }
                    else {
                        //CONSUMO
                        sql_i_asada_cli_info += ",asada_primer_lectura='"+ rowD[my_xls_col.id_primera_lectura].ToString().Trim() + "'";
                    }

                    if (DB.i(rowD[my_xls_col.id_cedula].ToString()).Length > 9 ){
                        //DIMEX si son domipro o Juridica si son EMPREGO
                        Console.WriteLine(DB.i(DB.ds(rowD[my_xls_col.id_nombre].ToString())).Trim() + " " + DB.i(DB.ds(rowD[my_xls_col.id_apellido].ToString())).Trim());

                        if (DB.i(rowD[my_xls_col.id_cedula].ToString()).Length == 10 && rowD[my_xls_col.id_cedula].ToString().ToCharArray()[0] =='3') 
                        {
                            //Puede SER EMPRESA
                            sql_i_asada_cli += ",client_identification_type='02',client_identification='" + rowD[my_xls_col.id_cedula].ToString().Trim() + "'";
                        }
                        else {
                            
                            if (rowD[my_xls_col.id_cedula].ToString().ToCharArray()[0] == '1')
                            {
                                sql_i_asada_cli += ",client_identification_type='03',client_identification='" + rowD[my_xls_col.id_cedula].ToString().Trim() + "'";
                            }
                            else
                            {
                                sql_i_asada_cli += ",client_identification_type='02',client_identification='" + rowD[my_xls_col.id_cedula].ToString().Trim() + "'";
                            }
                        }

                        
                    }
                    else if (DB.i(rowD[my_xls_col.id_cedula].ToString()).Trim().Length == 9 || DB.i(rowD[my_xls_col.id_cedula].ToString()).Trim().Length == 8){
                        //NACIONALES
                        sql_i_asada_cli += ",client_identification_type='01',client_identification='"+ rowD[my_xls_col.id_cedula].ToString().Trim() + "'";
                    }
                    else {
                        //FIND OUT

                        Console.WriteLine("-------------");
                        Console.WriteLine(rowD[my_xls_col.id_cedula].ToString());
                        Console.WriteLine(rowD[my_xls_col.id_cedula].ToString().Trim().Length);
                        Console.WriteLine( DB.i(DB.ds(rowD[my_xls_col.id_nombre].ToString())).Trim() + " " + DB.i(DB.ds(rowD[my_xls_col.id_apellido].ToString())).Trim() );
                        if (DB.i(rowD[my_xls_col.id_cedula].ToString()).Trim().Length == 0) {
                            //Sin CEDULA
                            //sql_i_asada_cli += "
                        }
                        else{
                            Console.WriteLine("ERROR ID " + DB.i(rowD[my_xls_col.id_cedula].ToString()));
                            sql_i_asada_cli += ",client_identification_type='01',client_identification='" + rowD[my_xls_col.id_cedula].ToString().Trim() + "'";

                        }
                    }

                    if (my_xls_col.id_nombre >= 0)
                    {
                        if (my_xls_col.id_apellido >= 0)
                        {
                            sql_i_asada_cli += ",client_name='" + DB.i(DB.ds(rowD[my_xls_col.id_nombre].ToString())).Trim() +" "+ DB.i(DB.ds(rowD[my_xls_col.id_apellido].ToString())).Trim() + "'";
                        }
                        else
                        {
                            sql_i_asada_cli += ",client_name ='" + DB.i(rowD[my_xls_col.id_nombre].ToString()).Trim() + "'";
                        }
                    }

                    if (my_xls_col.id_telefono >= 0)
                    {
                        sql_i_asada_cli += ",client_phone_country_number = '506',client_phone_number='" + DB.i(rowD[my_xls_col.id_telefono].ToString()).Trim() + "'";
                    }

                    DB.e(sql_i_asada_cli, "", "");
                    if (DB.lId == "") {
                        Console.WriteLine("ERROR ASADA " + sql_i_asada_cli);
                    }
                    sql_i_asada_cli_info += ",asada_cd=now(),client_id='"+DB.lId+"'";
                    DB.e(sql_i_asada_cli_info, "", "");


                }                else                {
                    Console.WriteLine("ERROR ASADA " + rowD[my_xls_col.id_num_medidor].ToString());
                    Console.WriteLine("ERROR Codigo ASADA " );
                    //                                Console.WriteLine(rowD[0].ToString());
                    //                                Console.WriteLine((rowD[0].ToString() + rowD[1].ToString()).ToString());
                }

                    ///--------------- CABYS

                ///---------------
            }
            total_rows_loaded = total_deudores.ToString();
            if (total_deudores == 0)
            {
                MessageBox.Show("Se terminó la importación de ASADA , No se importaron datos porque el ASADA seleccionado no cumple con los requisitos ");
            }
            else
            {
                //codigobarras_actualizados =procesar_cabys();
                //+ " Cargados y se actualizaron "+ codigobarras_actualizados.ToString() + " Productos "
                MessageBox.Show("Se terminó la importación de ASADA Satisfactoriamente de " + total_deudores.ToString());
            }
            //activar_botones();
        }
        #endregion ASADA_Excel

        #region ASADA_Excel_lecturas
        private void load_cmb_asada_lectura()
        {

            cmb_xls_asada_lectura_periodo.Items.Clear();

            var today = DateTime.Today;
            DateTime dateTime;
            DateTime thisMonth= new DateTime(today.Year, today.Month, 1);
            int count = -3;
                for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(i);
                dateTime = thisMonth.AddMonths(count);
                cmb_xls_asada_lectura_periodo.Items.Add(new cbi(dateTime.ToString("yyyy-MM"), dateTime.ToString("yyyy-MM")));
                count++;
            }

            

        }
        private void desactivar_botones_asada_lectura()
        {
            btn_import_excel_lecturas.Enabled = false;
            btn_asada_subir_lectura_excel.Enabled = false;
        }
        private void activar_botones_asada_lectura()
        {
            btn_import_excel_lecturas.Enabled = true;
            btn_asada_subir_lectura_excel.Enabled = true;
        }
        private void btn_import_excel_lecturas_Click(object sender, EventArgs e)
        {
            ListaCombos.Clear();
            if (DB.SuperLoginForm("excel"))
            {

            }
            cargaLista = false;
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog1.Title = "Importar Deudores";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    my_xls_path = openFileDialog1.FileName;
                    class_import myImport = new class_import();
                    myImport.OnProgressUpdate += t1_OnProgressUpdate;
                    if (my_xls_path.Length > 0)
                    {


                        List<class_xls_import.xls_import> myList = myImport.importExcelSCLA_LoadTitulos(my_xls_path);
                        Global_myList = myList;
                        //cmb_xls_nombre.DataSource = myList;
                        //cmb_xls_nombre.DisplayMember = "titulo_col";
                        if (!(myList == null))
                        {
                            class_xls_import.xls_list = myList;
                            lbl_xls_path.Text = my_xls_path.ToString();
                            lbl_xls_sheet.Text = class_xls_import.sheet_name.ToString();

                            cargar_cmb(cmb_xls_asada_lectura_medidor, myList);
                            cargar_cmb(cmb_xls_asada_lectura_lectura, myList);

                            cargar_cmb(cmb_xls_asada_lectura_nombre, myList);
                            cargar_cmb(cmb_xls_asada_lectura_apellido, myList);

                            cargaLista = true;

                            btn_asada_subir_lectura_excel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error y no se cargó el excel 1x03");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al cargar el path 1x01");
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error 1x02");
                }

            }
        }
        private void btn_asada_subir_lectura_excel_Click(object sender, EventArgs e)
        {

            if (cmb_xls_asada_lectura_medidor.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un num medidor");
                return;
            }
            if (cmb_xls_asada_lectura_lectura.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una Lectura ");
                return;
            }
            if (cmb_xls_asada_lectura_periodo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Periodo ");
                return;
            }
            desactivar_botones_asada_lectura();

            class_xls_import_asada_lectura.xls_import_col xls_col = new class_xls_import_asada_lectura.xls_import_col();

            xls_col.id_periodo = ((cbi)cmb_xls_asada_lectura_periodo.SelectedItem).HiddenValue;

            xls_col.id_num_medidor = getId(cmb_xls_asada_lectura_medidor);
            xls_col.id_lectura_periodo = getId(cmb_xls_asada_lectura_lectura);

            if (cmb_xls_asada_lectura_nombre.SelectedIndex > 0)
            {
                xls_col.id_nombre = getId(cmb_xls_asada_lectura_nombre);
            }
            else
            {
                xls_col.id_nombre = -1;
            }
            if (cmb_xls_asada_lectura_apellido.SelectedIndex > 0)
            {
                xls_col.id_apellido = getId(cmb_xls_asada_lectura_apellido);
            }
            else
            {
                xls_col.id_apellido = -1;
            }
            importExcelPOSASADALECTURAV1(xls_col);
            activar_botones_asada_lectura();
        }
        public void importExcelPOSASADALECTURAV1(object xls_col)
        {
            BackgroundWorker waitBW = new BackgroundWorker();
            waitBW.WorkerReportsProgress = true;
            waitBW.DoWork += new DoWorkEventHandler(waitBW_DoWork_ASADA_LECTURA);

            waitBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(waitBW_RunWorkerCompleted);
            waitBW.ProgressChanged += new ProgressChangedEventHandler(waitBW_ProgressChanged);
            OnProgressUpdate += t1_OnProgressUpdate;

            object[] parameters = new object[] { lbl_xls_path.Text.ToString(), xls_col, class_xls_import_asada.xls_list };
            try
            {
                waitBW.RunWorkerAsync(parameters);
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el thread");
            }
        }

        private void waitBW_DoWork_ASADA_LECTURA(object sender, DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];

            bg_importExcelASADA_LECTURA_V1((string)parameters[0], (class_xls_import_asada_lectura.xls_import_col)parameters[1], (List<class_xls_import_asada_lectura.xls_import>)parameters[2], "1", sender as BackgroundWorker);
        }
        public void bg_importExcelASADA_LECTURA_V1(string fn, object xls_col, object xls_name_col, string id_proyecto, BackgroundWorker bw)
        {
            Console.WriteLine("bg_importExcel_ASADA_LECTURA");

            class_xls_import_asada_lectura.xls_import_col my_xls_col = (class_xls_import_asada_lectura.xls_import_col)xls_col;

            class_import myImport = new class_import();

            List<class_xls_import_asada_lectura.xls_import> myList = (List<class_xls_import_asada_lectura.xls_import>)xls_name_col;
            if (myImport.IsFileLocked(fn))
            {
                MessageBox.Show("Ocurrió un error y no se pudo cargar el XLS");
                return;
            }

            if (my_xls_col.id_num_medidor.ToString() == "")
            {
                MessageBox.Show("Ocurrio un error y no se puede cargar");
                return;
            }
            System.Data.DataTable dt = null;

            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(1);
            }


            string sql_i_asada_cli = "", file_name_excel = "", sql_i_asada_cli_info_lectura = "", sql_i_asada_cli_info_lectura_del="", asada_lectura_excel="";
            string internal_id_cliente = "", internal_id="", last_lectura = "", diff_lectura="" , lectura_periodo="";
            int total_deudores = 0, int_lectura_periodo = 0, int_lectura_inicial = 0, int_diff_lectura = 0 ;

            //Desactiva TODOS
            //cmb_tipo_import

            dt = ReadExcelToDatatble(lbl_xls_sheet.Text, fn, 1, 1);



            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;
            DataTable excelDataTable = dt;

            Random rnd = new Random();

            file_name_excel = (lbl_xls_path.Text.PadRight(255)).Trim().ToString();
            int this_excel_id = rnd.Next(10000, 99999);
            double totalperRow = ((double)1000 / Convert.ToDouble(excelDataTable.Rows.Count.ToString()));
            //CARGAR TODOS LOS CLIENTES >
            string sql_update_periodo = "update asadas_lecturas set asada_lectura_activa=0 where asada_lectura_periodo='" + my_xls_col.id_periodo + "' and asada_lectura_factura is null";
            DB.e(sql_update_periodo, "", "");

            string sql_cargar_todas_lectura ="insert into asadas_lecturas(asada_lectura_periodo, client_id, asada_medidor, asada_ultima_lectura) "+
                "(select '"+ my_xls_col.id_periodo +"', client_id, asada_medidor,if (asada_tipo_FC = '1',null,if (asada_ultima_lectura is null,asada_primer_lectura,asada_ultima_lectura)) as last_lectura from asada_cli_info)";
            DB.e(sql_cargar_todas_lectura, "", "");

            foreach (DataRow rowD in excelDataTable.Rows)
            {
                //9
                if ((rowD[my_xls_col.id_num_medidor].ToString()).Length > 0)
                {
                    total_deudores = total_deudores + 1;
                    OnProgressUpdate((int)Math.Round(totalperRow * total_deudores));

                    internal_id_cliente = "0";
                    lectura_periodo = "";
                    last_lectura = "";
                    //Conseguir codigo de cliente

                    if (my_xls_col.id_nombre > 0 && my_xls_col.id_apellido > 0)
                    {
                        asada_lectura_excel = DB.i(DB.ds(rowD[my_xls_col.id_nombre].ToString())).Trim() + " " + DB.i(DB.ds(rowD[my_xls_col.id_apellido].ToString())).Trim();
                    }
                    Console.WriteLine(asada_lectura_excel);
                    
                    internal_id_cliente = "";
                    /*
                    sql_i_asada_cli = "SELECT client_id FROM clients where client_name='"+ asada_lectura_excel + "' limit 1";
                    DataTable tDtpcCliente = DB.q(sql_i_asada_cli, "", "");
                    foreach (DataRow r in tDtpcCliente.Rows)
                    {
                        internal_id_cliente = r["client_id"].ToString();
                    }

                    if (internal_id_cliente != "") {
                        sql_i_asada_cli = "SELECT * FROM asadas_lecturas " +
                        "where asada_lectura_periodo='" + my_xls_col.id_periodo + "' " +
                        "and asada_lectura_activa =1 " +
                        "and client_id= '" + internal_id_cliente + "' limit 1";
                    }else { 
                        sql_i_asada_cli = "SELECT * FROM asadas_lecturas " +
                        "where asada_lectura_periodo='" + my_xls_col.id_periodo + "' " +
                        "and asada_lectura_activa =1 " +
                        "and asada_medidor like '%-" + DB.i(rowD[my_xls_col.id_num_medidor].ToString()).Trim().PadLeft(3, '0') + "' limit 1";
                    }
                    */
                    sql_i_asada_cli = "SELECT * FROM asadas_lecturas " +
                        "where asada_lectura_periodo='" + my_xls_col.id_periodo + "' " +
                        "and asada_lectura_activa =1 " +
                        "and asada_medidor ='" + DB.i(rowD[my_xls_col.id_num_medidor].ToString()).Trim().PadLeft(3, '0') + "' limit 1";
                    internal_id = "";
                    DataTable tDtpc = DB.q(sql_i_asada_cli, "", "");
                    foreach (DataRow r in tDtpc.Rows)
                    {
                        //internal_id_cliente = r["client_id"].ToString();
                        internal_id = r["asada_lectura_id"].ToString();

                        last_lectura = r["asada_ultima_lectura"].ToString();
                        int_diff_lectura = 0;

                        if (last_lectura == "")
                        {
                            //ES FIJA

                        }
                        else {
                                int_lectura_inicial = 0;
                            int.TryParse(last_lectura, out int_lectura_inicial);

                            int_lectura_periodo = 0;
                            lectura_periodo = DB.i(rowD[my_xls_col.id_lectura_periodo].ToString()).Trim();
                            int.TryParse(lectura_periodo, out int_lectura_periodo);
                            int_diff_lectura = int_lectura_periodo - int_lectura_inicial;
                        }

                    }
                    if (internal_id == "") {
                        MessageBox.Show("ERROR ID");
                    }

                    Console.WriteLine("-------------");
                    Console.WriteLine(rowD[my_xls_col.id_num_medidor].ToString().Trim());
                    Console.WriteLine(rowD[my_xls_col.id_lectura_periodo].ToString().Trim());

                    if (my_xls_col.id_nombre > 0 && my_xls_col.id_apellido > 0){
                        asada_lectura_excel = DB.i(rowD[my_xls_col.id_nombre].ToString()).Trim() + " " + DB.i(rowD[my_xls_col.id_apellido].ToString()).Trim();
                    }

                    sql_i_asada_cli_info_lectura = "update asadas_lecturas set asada_lectura_activa=2" +
                        ",asada_lectura='"+ lectura_periodo + "'" +
                        ",asada_lectura_fecha=now()" +
                        ",asada_diff='" + int_diff_lectura.ToString() + "'" +
                        ",asada_lectura_excel='"+ asada_lectura_excel + "'" +
                        " where asada_lectura_id='" + internal_id + "'";
                    DB.e(sql_i_asada_cli_info_lectura, "", "");


                    //DB.e("update asadas_lecturas set asada_lectura_activa=2,asada_lectura_fecha=now(),asada_lectura='" + lectura_periodo + "',asada_diff='" + int_diff_lectura.ToString() + "',asada_lectura_excel='" + asada_lectura_excel + "' where  asada_lectura_id='" + internal_id + "'", "", "");

                    /*
                    sql_i_asada_cli_info_lectura_del = " update asadas_lecturas set asada_lectura_activa=0 where  asada_medidor='' and asada_lectura_periodo=''";

                    sql_i_asada_cli_info_lectura = "insert into asadas_lecturas set asada_medidor='" + DB.i(rowD[my_xls_col.id_num_medidor].ToString()).Trim() + "'" +
                        ",asada_lectura='" + DB.i(rowD[my_xls_col.id_lectura_periodo].ToString()).Trim() + "'" +
                        ",asada_diff=''" +
                        ",client_id='" + internal_id_cliente + "'" +
                        ",asada_lectura_excel='" + asada_lectura_excel + "'" +
                        ",asada_lectura_periodo='" + my_xls_col.id_periodo + "',asada_lectura_fecha=now()";
                        */

                }
                else
                {
                    Console.WriteLine("ERROR ASADA " + rowD[my_xls_col.id_num_medidor].ToString());
                    Console.WriteLine("ERROR Codigo ASADA ");
                    //                                Console.WriteLine(rowD[0].ToString());
                    //                                Console.WriteLine((rowD[0].ToString() + rowD[1].ToString()).ToString());
                }

                ///---------------
            }
            total_rows_loaded = total_deudores.ToString();
            if (total_deudores == 0)
            {
                MessageBox.Show("Se terminó la importación de LECTURA ASADA , No se importaron datos porque el LECTURA ASADA seleccionado no cumple con los requisitos ");
            }
            else
            {
                //codigobarras_actualizados =procesar_cabys();
                //+ " Cargados y se actualizaron "+ codigobarras_actualizados.ToString() + " Productos "
                MessageBox.Show("Se terminó la importación de LECTURA ASADA Satisfactoriamente de " + total_deudores.ToString());
            }
            //activar_botones_asada_lectura();
        }
        #endregion ASADA_Excel_lecturas

    }
}
