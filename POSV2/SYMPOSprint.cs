using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.IO;
using System.Threading;

namespace POSV2
{
    class SYMPOSprint
    {
        public static string my_id_invoice;
        public static string my_id_abono;        
        //public  static Font my_selFont;
        public int printpos(string id_invoice){
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printpos : ");
            
            first myFirst = first.GetInstance();
            //,Font selFont
            my_id_invoice = id_invoice;
            //my_selFont = selFont;            
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printpos : " + myFirst.getKey("pos_printer_type"));
            if (myFirst.getKey("pos_printer_type") == "2")
            {
                printInvoicePOS(id_invoice);
            }
            else {
                printInvoiceCarta(id_invoice);
            }
                return 0;
        }
        public int printpos_abono(string id_abono)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printpos_abono : ");

            first myFirst = first.GetInstance();
            //,Font selFont
            my_id_abono = id_abono;
            //my_selFont = selFont;            
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printpos : " + myFirst.getKey("pos_printer_type"));
            if (myFirst.getKey("pos_printer_type") == "2")
            {
                printAbono(my_id_abono);
            }

            return 0;
        }
        
        private void printAbono(string id_abono){
            first myFirst = first.GetInstance();
            string printer_list = myFirst.getKey("cmb_printer_list");
            if (printer_list != "")
            {
                PrintDocument recordDoc = new PrintDocument();

                //recordDoc.DocumentName = "Customer Receipt";
                recordDoc.DocumentName = "abono_" + id_abono;
                //recordDoc.PrintPage += new PrintPageEventHandler(SYMPOSprint.ProvideContent); // function below
                recordDoc.PrintPage += new PrintPageEventHandler(SYMPOSprint.PrintReceiptAbonoSB); // function below
                recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
                                                                           // Comment if debugging 
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = printer_list;
                recordDoc.PrinterSettings = ps;
                try
                {
                    recordDoc.PrinterSettings.PrintFileName = "abono_" + id_abono;
                    recordDoc.Print();
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error imprimiendo");
                    ps.PrinterName = "";
                    recordDoc.PrinterSettings = ps;
                }

                // --------------------------------------

                // Uncomment if debugging - shows dialog instead
                /*if (myFirst.getKey("pos_printer_type") =="3") { 
                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                printPrvDlg.Document = recordDoc;
                printPrvDlg.Width = 1200;
                printPrvDlg.Height = 800;
                printPrvDlg.ShowDialog();
                }*/
                // --------------------------------------

                recordDoc.Dispose();
            }
            else
            {
                MessageBox.Show("No printer detected");
            }
        }
        private void printInvoiceCarta(string id_invoice)
        {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printInvoiceCarta : ");

            SYMPOS_API_Fe _SYMFE = new SYMPOS_API_Fe();

            VarCompany my_company = DB.CheckCompanyPOS();

            string sql_load_invoice_mysql = "SELECT invoice_uuid FROM invoice where invoice_id='" + id_invoice + "'";
            string invoice_uuid = "";

            DataTable tDti = DB.q(sql_load_invoice_mysql, "", "");
            foreach (DataRow r in tDti.Rows)
            {
                if (r["invoice_uuid"].ToString().Length < 1)
                {
                    break;
                }
                invoice_uuid = r["invoice_uuid"].ToString();
            }
            Console.Write(invoice_uuid);

            /*WebBrowser wb = new WebBrowser();
            wb.Navigate("http://api.socialymas.com/api/apiInvoice.php?token=" + my_company.cloud_api_token + "&data=50&debug=0&invoice_uuid=" + invoice_uuid);
            wb.ShowPrintDialog();*/
            //wb.Print();

            Thread.Sleep(2000);


            sympos_wb swb = new sympos_wb("http://api.socialymas.com/api/apiInvoice.php?token="+ my_company.cloud_api_token + "&data=50&debug=0&invoice_uuid=" + invoice_uuid);
            //swb.Show();
            
            
            /*
            string myPdf = _SYMFE.getPdfApi2(invoice_uuid, "1");

            string path = @"c:\temp\factura.pdf";
            
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                File.WriteAllText(path, myPdf);
            }

            //byte[] byteArray = Encoding.UTF8.GetBytes(myPdf);
            //Stream myPdfStram = new MemoryStream(byteArray);

            first myFirst = first.GetInstance();
            string printer_list = myFirst.getKey("cmb_printer_list");
            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = printer_list;

            PdfDocument doc = new PdfDocument();
            //doc.LoadFromStream(myPdfStram);

            doc.LoadFromFile(path);
            //pdf.LoadFromFile("Sample.pdf");
            doc.Print();

            */
            //PdfFilePrinter printer = new PdfFilePrinter(@"C:\Documents and Settings\mike.smith\Desktop\Stuff\ReleaseNotesAndFolderList.pdf", " \\ny-dc-03\\IT-01");

            //var doc = Patagames.Pdf.Net.PdfDocument.Load("c:\test.pdf");  // Read PDF file

            //var printDoc = new Patagames.Pdf.Net. PdfPrintDocument(doc);
            //printDoc.Print();

            /*            using (var document = Patagames.Pdf.Net.PdfDocument.Load(myPdfStram))
                        {
                            document.
                            /*using (var printDocument = document.CreatePrintDocument())
                            {
                                printDocument.PrinterSettings.PrintFileName = "Letter_SkidTags_Report_9ae93aa7-4359-444e-a033-eb5bf17f5ce6.pdf";
                                printDocument.PrinterSettings.PrinterName = @"printerName";
                                printDocument.DocumentName = "file.pdf";
                                printDocument.PrinterSettings.PrintFileName = "file.pdf";
                                printDocument.PrintController = new StandardPrintController();
                                printDocument.Print();
                            }*/




            

        }
        private void printInvoicePOS(string id_invoice) {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .printInvoicePOS : ");

            first myFirst = first.GetInstance();
            string printer_list = myFirst.getKey("cmb_printer_list");
            if (printer_list != "")
            {

                PrintDocument recordDoc = new PrintDocument();

                //recordDoc.DocumentName = "Customer Receipt";
                recordDoc.DocumentName = "factura_" + id_invoice;
                
                //recordDoc.PrintPage += new PrintPageEventHandler(SYMPOSprint.ProvideContent); // function below
                recordDoc.PrintPage += new PrintPageEventHandler(SYMPOSprint.PrintReceiptInvoiceSB); // function below
                recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
                                                                           // Comment if debugging 
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = printer_list;
                recordDoc.PrinterSettings = ps;
                try {                    
                    recordDoc.PrinterSettings.PrintFileName = "factura_" + id_invoice;
                    recordDoc.Print();
                } catch {
                    MessageBox.Show("Ocurrió un error imprimiendo");
                    ps.PrinterName = "";
                    recordDoc.PrinterSettings = ps;
                }
                
                // --------------------------------------

                // Uncomment if debugging - shows dialog instead
                /*if (myFirst.getKey("pos_printer_type") =="3") { 
                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                printPrvDlg.Document = recordDoc;
                printPrvDlg.Width = 1200;
                printPrvDlg.Height = 800;
                printPrvDlg.ShowDialog();
                }*/
                // --------------------------------------

                recordDoc.Dispose();
            }
            else {
                MessageBox.Show("No printer detected");
            }

        }
        private static void PrintReceiptAbonoSB(object sender, PrintPageEventArgs e)
        {

            float x = 0;
            float y = 0;
            float width = 360.0F; // max width I found through trial and error
            float height = 0F;

            string tipo_linea = "1C";
            float cuenta_espacio_final = 0;
            string horizontal = "0";
            string tamano = "80";
            #region Config
            string sql_load_pos_config_mysql = "select * from company_pos_config where pos_name='pos1' and activo=1 ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                if (r["pos_var"].ToString() == "width")
                {
                    width = float.Parse(r["pos_val"].ToString());
                }
                if (r["pos_var"].ToString() == "lineas")
                {
                    tipo_linea = r["pos_val"].ToString();
                }
                if (r["pos_var"].ToString() == "espacio_final")
                {
                    cuenta_espacio_final = float.Parse(r["pos_val"].ToString());
                }
                if (r["pos_var"].ToString() == "horizontal")
                {
                    horizontal = r["pos_val"].ToString();
                }
                if (r["pos_var"].ToString() == "tamano")
                {
                    tamano = r["pos_val"].ToString();
                }

            }
            #endregion
            #region TiqueteHeader
            string sql_load_tiquete_header_mysql = "select * from company_tiquete where tiquete_tipo=1 and activo=1 order by tiquete_tipo,orden asc  ";

            DataTable tDth = DB.q(sql_load_tiquete_header_mysql, "", "");
            foreach (DataRow r in tDth.Rows)
            {
                linea(r["tiquete_texto"].ToString(), r["fuente"].ToString(), r["align"].ToString(), ref x, ref y, ref width, ref height, ref e);
            }
            #endregion

            string format = "";
            string formatLinea = "{0,40}" + Environment.NewLine; ; //58
            string formatTotales = "";
            string format2C1 = "";
            string format2C2 = "";
            var stringBuilder = new StringBuilder();
            var stringBuilderInvoice = new StringBuilder();
            var stringBuilderTotales = new StringBuilder();


            string sql_load_abono = "select * from invoice_abonos where abono_id='"+ my_id_abono + "'";
                string sql_load_abono_uuid_facturas = "select iau.*,invoice.invoice_consecutivo,invoice_abono_total,invoice_TotalComprobante,(invoice_abono_total-invoice_TotalComprobante) as saldo from invoice inner join ( select* from invoice_abonos_uuid where abono_id = '" + my_id_abono + "' ) as iau using (invoice_id)";
            


            DataTable tDti = DB.q(sql_load_abono, "", "");
            foreach (DataRow r in tDti.Rows)
            {
                string sql_load_abono_cliente = "SELECT client_id,client_name,client_identification FROM clients WHERE clients.client_id = '"+ r["abono_client_id"].ToString() + "'  ";

                
                linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);
                linea("Abono # "+ r["abono_id"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                linea("Total Abono  " + decimal.Parse(r["abono_monto"].ToString()).ToString("N2"), "6", "1", ref x, ref y, ref width, ref height, ref e);


                DataTable tDtca = DB.q(sql_load_abono_cliente, "", "");
                foreach (DataRow rca in tDtca.Rows)
                {
                    linea("Cliente :" + rca["client_name"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea("Id :" + rca["client_identification"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                }
                /* 
                 stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["condicionVenta"].ToString(), r["medioPago"].ToString());
                 linea(stringBuilderInvoice.ToString(), "6C", "l", ref x, ref y, ref width, ref height, ref e);
                 */

                DataTable tDt = DB.q(sql_load_abono_uuid_facturas, "", "");
                decimal abono_total_aplicado = 0;
                foreach (DataRow d in tDt.Rows)
                {//(r["invoice_detail_product_price"].ToString()
                    stringBuilderInvoice.AppendFormat(formatLinea, "-".PadLeft(50, '-'));
                    stringBuilderInvoice.AppendFormat("{0,-40} " + Environment.NewLine, "Consecutivo");
                    stringBuilderInvoice.AppendFormat("{0,-40} " + Environment.NewLine, d["invoice_consecutivo"].ToString());
                    stringBuilderInvoice.AppendFormat("{0,-20} {1,20}" + Environment.NewLine, "Monto Factura : ", decimal.Parse(d["invoice_TotalComprobante"].ToString()).ToString("N2"));
                    stringBuilderInvoice.AppendFormat("{0,-20} {1,20}" + Environment.NewLine, "Monto Abono : ", decimal.Parse(d["invoice_abono_total"].ToString()).ToString("N2"));
                    stringBuilderInvoice.AppendFormat("{0,-25} {1,20}" + Environment.NewLine, "Saldo : ", decimal.Parse(d["saldo"].ToString()).ToString("N2"));
                    abono_total_aplicado += decimal.Parse(d["abonos_x_invoice_monto"].ToString());


                }
                stringBuilderInvoice.AppendFormat(formatLinea, "-".PadRight(50, '-'));
                //stringBuilderInvoice.AppendFormat("{0,-20} {1,20}" + Environment.NewLine, "Total abonos aplicados : ", decimal.Parse(abono_total_aplicado.ToString()).ToString("N2"));
                linea(stringBuilderInvoice.ToString(), "6C", "l", ref x, ref y, ref width, ref height, ref e);

                //stringBuilderInvoice.AppendFormat("{0,-20} {1,3} {2,20} " + Environment.NewLine, "5060.20"," | ", "0");

            }
        }
        private static void PrintReceiptInvoiceSB(object sender, PrintPageEventArgs e)
        {

            float x = 0;
            float y = 0;
            float width = 360.0F; // max width I found through trial and error
            float height = 0F;

            string tipo_linea = "1C";
            float cuenta_espacio_final = 0;
            string horizontal="0";
            string tamano = "80";

            bool saldo_invoice = false;
            string invoice_cliente_id = "0";

            #region Config
            string sql_load_pos_config_mysql = "select * from company_pos_config where pos_name='pos1' and activo=1 ";

            DataTable tDtpc = DB.q(sql_load_pos_config_mysql, "", "");
            foreach (DataRow r in tDtpc.Rows)
            {
                if (r["pos_var"].ToString() == "width")
                {
                    width = float.Parse(r["pos_val"].ToString());
                }
                if (r["pos_var"].ToString() == "lineas")
                {
                    tipo_linea = r["pos_val"].ToString();
                }
                if (r["pos_var"].ToString() == "espacio_final")
                {
                    cuenta_espacio_final = float.Parse(r["pos_val"].ToString());
                }
                if (r["pos_var"].ToString() == "horizontal")
                {
                    horizontal = r["pos_val"].ToString();
                }
                if (r["pos_var"].ToString() == "tamano") {
                    tamano= r["pos_val"].ToString();
                }
                if (r["pos_var"].ToString() == "saldo")
                {
                    saldo_invoice = true;
                }
            }
            #endregion
            #region TiqueteHeader
            string sql_load_tiquete_header_mysql = "select * from company_tiquete where tiquete_tipo=1 and activo=1 order by tiquete_tipo,orden asc  ";

            DataTable tDth = DB.q(sql_load_tiquete_header_mysql, "", "");
            foreach (DataRow r in tDth.Rows)
            {
                linea(r["tiquete_texto"].ToString(), r["fuente"].ToString(), r["align"].ToString(), ref x, ref y, ref width, ref height, ref e);
            }
            #endregion

            //fuente 8 - 44 caracteres
            //fuente 10 - 35 caracteres
            //fuente 12 - 28 caracteres     
            //f8-  123456789_123456789_123456789_123456789_1234 |


            //f8-  1234_123456789_1234567_123456789_123456789_1 | 1 linea
            //f8-  999  123456789_1234567 99,999.00 99,999.00 * |17 descripcion 1 linea
            //f8-  999  123456789_123456789_12345 99999 99999 * |25 descripcion 1 linea

            //f8-  123456789_123456789_123456789_123456789_1234 |44 descripcion 2 linea
            //f8-    99999      9,999,999.00   9,999,999.00   * |0 descripcion 2 linea
            string format = "";
            string formatLinea = "{0,58}" + Environment.NewLine; ; //58
            string formatTotales = "";
            string format2C1 = "";
            string format2C2 = "";
            var stringBuilder = new StringBuilder();
            var stringBuilderInvoice = new StringBuilder();
            var stringBuilderTotales = new StringBuilder();

            #region TiqueteInvoice
            //            string sql_load_tiquete_invoice_mysql = "select * from invoice where invoice_id='" + my_id_invoice + "'";


            string sql_load_tiquete_invoice_mysql = "SELECT invoice_client_type,invoice_client_identification,invoice_client_id,invoice_client_name,invoice_TotalExento,invoice_TotalGravado,invoice_TotalImpuesto,invoice_TotalComprobante,invoice_condicion_venta.condicionVenta,invoice_medio_pago.medioPago,invoice.invoice_id,invoice.invoice_cd,invoice.invoice_tipo_doc,invoice.invoice_clave,invoice.invoice_consecutivo,invoice.invoice_xml_ver,invoice_documento_referencia.documento FROM invoice " +
" INNER JOIN invoice_condicion_venta ON invoice_condicion_venta.codigo = invoice.invoice_condicion_venta INNER JOIN invoice_medio_pago ON invoice_medio_pago.codigo = invoice.invoice_medio_pago INNER JOIN invoice_documento_referencia ON invoice_documento_referencia.codigo = invoice.invoice_tipo_doc  where invoice_id='" + my_id_invoice + "'";


            DataTable tDti = DB.q(sql_load_tiquete_invoice_mysql, "", "");
            foreach (DataRow r in tDti.Rows)
            {
                if (r["invoice_clave"].ToString().Length < 1) {
                    break;
                }

                invoice_cliente_id = r["invoice_client_id"].ToString();
                //linea(r["tiquete_texto"].ToString(), r["fuente"].ToString(), r["align"].ToString(), ref x, ref y, ref width, ref height, ref e);
                if (tamano == "58"){


                    /*linea( r["invoice_clave"].ToString() + Environment.NewLine, "4", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);

                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "5", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);

                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);

                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "4C", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);

                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "5C", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);

                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "6C", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);*/

                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);
                    linea("Clave :" , "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(r["invoice_clave"].ToString() + Environment.NewLine, "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);


                    linea("Consecutivo :" + r["invoice_consecutivo"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea("Version :" + r["invoice_xml_ver"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);

                    //stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["documento"].ToString(), r["invoice_cd"].ToString());

                    linea(r["documento"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea(r["invoice_cd"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);

                    stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["condicionVenta"].ToString(), r["medioPago"].ToString());
                    linea(stringBuilderInvoice.ToString(), "6C", "l", ref x, ref y, ref width, ref height, ref e);

                    
                    if (r["invoice_client_type"].ToString() != "0")
                    {
                        linea("Cliente :", "6", "1", ref x, ref y, ref width, ref height, ref e);
                        linea(r["invoice_client_identification"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                        linea(r["invoice_client_name"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);                        

                    }

                }
                else
                { 
                    //80mm
                    linea("Clave :" + r["invoice_clave"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                    linea("Consecutivo :" + r["invoice_consecutivo"].ToString() + "         Version :" + r["invoice_xml_ver"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);


                    stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["documento"].ToString(), r["invoice_cd"].ToString());
                    stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["condicionVenta"].ToString(), r["medioPago"].ToString());
                    linea(stringBuilderInvoice.ToString(), "8C", "l", ref x, ref y, ref width, ref height, ref e);

                    if (r["invoice_client_type"].ToString() != "0")
                    {
                        linea("Cliente :", "6", "1", ref x, ref y, ref width, ref height, ref e);
                        linea(r["invoice_client_identification"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                        linea(r["invoice_client_name"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);                        
                    }
                }

                #region SaldoCliente
                if (saldo_invoice)
                {

                    if (invoice_cliente_id != "0")
                    {
                        linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);                        

                        string sql_w = " where invoice_client_id='" + invoice_cliente_id + "' and invoice_ref_Codigo is null  and (invoice_abono_estado =0 or invoice_abono_estado =1 or invoice_abono_estado =2) and invoice_condicion_venta='02' group by invoice_client_id";
                        string sql_load_cliente_saldo_mysql = "select sum(invoice_TotalComprobante-invoice_abono_total) as abono_saldo from invoice  ";
                        DataTable tDt_sc = DB.q(sql_load_cliente_saldo_mysql + sql_w, "", "");
                        foreach (DataRow r_sc in tDt_sc.Rows)
                        {
                            linea("Saldo total :" + decimal.Parse(r_sc["abono_saldo"].ToString()).ToString("N2"), "6", "1", ref x, ref y, ref width, ref height, ref e);
                            
                        }
                        linea(" ", "4", "1", ref x, ref y, ref width, ref height, ref e);
                    }

                }
                #endregion

                //invoice_xml_ver
                //stringBuilderInvoice.AppendFormat("{0,-20} {1,20} " + Environment.NewLine, r["documento"].ToString(), r["invoice_cd"].ToString());

                //linea("Fecha :" + r["invoice_cd"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);
                //linea("Fecha :" + r["invoice_cd"].ToString(), "6", "1", ref x, ref y, ref width, ref height, ref e);


                formatTotales = "{0,10} {1,15} " + Environment.NewLine;
                stringBuilderTotales.Clear();
                stringBuilderTotales.AppendFormat(formatTotales, "Exento :", decimal.Parse(r["invoice_TotalExento"].ToString()).ToString("N2"));
                stringBuilderTotales.AppendFormat(formatTotales, "Gravado :", decimal.Parse(r["invoice_TotalGravado"].ToString()).ToString("N2"));
                stringBuilderTotales.AppendFormat(formatTotales, "Impuesto :", decimal.Parse(r["invoice_TotalImpuesto"].ToString()).ToString("N2"));
                stringBuilderTotales.AppendFormat(formatTotales, "Total :", decimal.Parse(r["invoice_TotalComprobante"].ToString()).ToString("N2"));
                
                Console.WriteLine(stringBuilderTotales.ToString());
            }

            #endregion

            if (tipo_linea == "1C")
            {
                format = "{0,-3} {1,-26} {2,9} {3,13} {4,1}" + Environment.NewLine;
                stringBuilder.AppendFormat(format, "QTY", msvPc("DESCRIPCION", 19), "PRECIO", "MONTO", "T");
                //f8-  123456789_123456789_123456789_123456789_1234 |
                //linea("QTY-   DESCRIPCION      -    Precio    -    Monto    T", "8", "l", ref x, ref y, ref width, ref height, ref e);
            }
            else if (tipo_linea == "1N")
            {
                format = "{0,-4}|{1,30}|{2,10}|{3,11}|{4,1}" + Environment.NewLine;
                stringBuilder.AppendFormat(format, "-QTY", msvPc("- DESCRIPCION -", 30), "- PRECIO -", "- MONTO -", "T");
                
                // stringBuilder.Clear();
            }
            else if (tipo_linea == "2C")
            {
                format = "{0,-4}|{1,27}|{2,10}|{3,11}|{4,1}" + Environment.NewLine;
                format2C1 = "{0,58}" + Environment.NewLine;
                format2C2 = "{0,-26} {1,13} {2,13} {3,2}" + Environment.NewLine;

                if (tamano == "58")
                {
                    stringBuilder.AppendFormat(format2C1, msvPr("DESCRIPCION", 58));
                    //stringBuilder.AppendFormat(format2C1, "DESCRIPCION");
                    stringBuilder.AppendFormat(format2C2, "QTY", "PRECIO", "MONTO", "T");
                }
                else { //80mm
                    stringBuilder.AppendFormat(format, "QTY", msvPc("DESCRIPCION", 17), "PRECIO", "MONTO", "T");
                }
                    

                // stringBuilder.Clear();
            }


            if (horizontal == "1")
            {
                stringBuilder.AppendFormat(formatLinea, "-".PadRight(58, '-'));
            }

            #region invoice_detail
            string sql_load_invoice_detail_mysql = "select * from invoice_detail where invoice_id='" + my_id_invoice + "'";            
            string ExentoGravado = "";

            //decimal detail_qty, detail_price, detail_total;
            DataTable tDt = DB.q(sql_load_invoice_detail_mysql, "", "");
            foreach (DataRow r in tDt.Rows)
            {

                first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run . : "+ r["invoice_detail_product_sym_tax"].ToString());
                if (r["invoice_detail_product_sym_tax"].ToString() == "0.00") { ExentoGravado = "E"; } else { ExentoGravado = "G"; };
                if (tipo_linea == "1C")
                {
                    if (r["invoice_detail_product_sym_unit"].ToString() == "Otros")
                    {
                        stringBuilder.AppendFormat(format,
                         msvPr(decimal.Parse("").ToString("N0"), 4),
                         msvPr(r["invoice_detail_product_sym_description"].ToString(), 26),
                         msvPl(decimal.Parse("").ToString("N2"), 9),
                         msvPl(decimal.Parse("").ToString("N2"), 13),
                         ExentoGravado
                        );
                    }
                    else
                    {
                        stringBuilder.AppendFormat(format,
                         msvPr(decimal.Parse(r["invoice_detail_qty"].ToString()).ToString("N0"), 4),
                         msvPr(r["invoice_detail_product_sym_description"].ToString(), 26),
                         msvPl(decimal.Parse(r["invoice_detail_product_price"].ToString()).ToString("N2"), 9),
                         msvPl(decimal.Parse(r["invoice_detail_MontoTotalLinea"].ToString()).ToString("N2"), 13),
                         ExentoGravado
                        );
                    }
                        

                }
                else if (tipo_linea == "1N")
                {
                    if (r["invoice_detail_product_sym_unit"].ToString() == "Otros")
                    {
                        stringBuilder.AppendFormat(format,
                         msvPr(decimal.Parse("").ToString("N0"), 4),
                         msvPr(r["invoice_detail_product_sym_description"].ToString(), 30),
                         msvPl(decimal.Parse("").ToString("N0"), 10),
                         msvPl(decimal.Parse("").ToString("N2"), 11),
                         ExentoGravado
                        );
                    }
                    else
                    {
                        stringBuilder.AppendFormat(format,
                         msvPr(decimal.Parse(r["invoice_detail_qty"].ToString()).ToString("N0"), 4),
                         msvPr(r["invoice_detail_product_sym_description"].ToString(), 30),
                         msvPl(decimal.Parse(r["invoice_detail_product_price"].ToString()).ToString("N0"), 10),
                         msvPl(decimal.Parse(r["invoice_detail_MontoTotalLinea"].ToString()).ToString("N2"), 11),
                         ExentoGravado
                        );
                    }
                }else if (tipo_linea == "2C")
                {
                    stringBuilder.AppendFormat(format2C1,                         
                         msvPr(r["invoice_detail_product_sym_description"].ToString(), 58)
                        );
                    if (r["invoice_detail_product_sym_unit"].ToString() == "Otros"){

                    }else { 
                    stringBuilder.AppendFormat(format2C2,
                         msvPr(decimal.Parse(r["invoice_detail_qty"].ToString()).ToString("N0"), 6),
                         msvPl(decimal.Parse(r["invoice_detail_product_price"].ToString()).ToString("N0"), 13),
                         msvPl(decimal.Parse(r["invoice_detail_MontoTotalLinea"].ToString()).ToString("N2"), 13),
                         ExentoGravado
                        );
                    }
                }
                Console.WriteLine(stringBuilder.ToString());
            }
            if (horizontal == "1")
            {
                stringBuilder.AppendFormat(formatLinea, "-".PadRight(58, '-'));
            }
            #endregion
            Console.WriteLine(stringBuilder.ToString());
            linea(stringBuilder.ToString(), "6", "l", ref x, ref y, ref width, ref height, ref e);

            linea(stringBuilderTotales.ToString(), "8C", "l", ref x, ref y, ref width, ref height, ref e);

            

            #region TiqueteFooter
            string sql_load_tiquete_footer_mysql = "select * from company_tiquete where tiquete_tipo=2 and activo=1 order by tiquete_tipo,orden asc  ";

            DataTable tDtf = DB.q(sql_load_tiquete_footer_mysql, "", "");
            foreach (DataRow r in tDtf.Rows)
            {
                linea(r["tiquete_texto"].ToString(), r["fuente"].ToString(), r["align"].ToString(), ref x, ref y, ref width, ref height, ref e);
            }
            #endregion

            for (var i = 1; i <= cuenta_espacio_final; i++)
            {
                linea(" ", "8", "l", ref x, ref y, ref width, ref height, ref e);
            }
            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);
            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;

            //linea(COMMAND, "8", "l", ref x, ref y, ref width, ref height, ref e);
            //linea("\x1Bd\x06", "6", "l", ref x, ref y, ref width, ref height, ref e);
        }        
        private static void linea(string text, string fuente, string alignment, ref float x, ref float y, ref float width, ref float height, ref PrintPageEventArgs e)
        {
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font fontinUse = pFont(fuente);
            StringFormat formatInUse = pFormat(alignment);

            e.Graphics.DrawString(text, fontinUse, drawBrush, new RectangleF(x, y, width, height), formatInUse);
            y += e.Graphics.MeasureString(text, fontinUse).Height;
            Console.WriteLine(text);
        }        
        private static StringFormat pFormat(string format){
            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;

            StringFormat formatInUse;
            if (format == "c")
            {
                formatInUse = drawFormatCenter;
            }
            else if (format == "r")
            {
                formatInUse = drawFormatRight;
            }
            else if (format == "l")
            {
                formatInUse = drawFormatLeft;
            }
            else
            {
                formatInUse = drawFormatLeft;
            }
            return formatInUse;
        }
        private static Font pFont(string fuente) {
            /*            Font drawFontArial12Bold = new Font("DejaVu Sans Mono", 12, FontStyle.Bold);
                        Font drawFontArial10Regular = new Font("DejaVu Sans Mono", 10, FontStyle.Regular);
                        Font drawFontArial8Regular = new Font("DejaVu Sans Mono", 8, FontStyle.Regular);*/
            /*
Font drawFontArial12Bold = new Font("Courier", 12, FontStyle.Bold);
Font drawFontArial10Regular = new Font("Courier", 10, FontStyle.Regular);
Font drawFontArial8Regular = new Font("Courier", 8, FontStyle.Regular); 
*/
            /*Font drawFontArial12Bold = new Font("Lucida Console", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Lucida Console", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("Lucida Console", 8, FontStyle.Regular);*/

            /*Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("Arial", 8, FontStyle.Regular);*/
            /*Font drawFontArial12Bold = new Font("Courier New", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Courier New", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("Courier New", 8, FontStyle.Regular);*/
            //Font drawFontArial12Bold = new Font("Arial Unicode MS", 12, FontStyle.Bold);
            //Font drawFontArial10Regular = new Font("Arial Unicode MS", 10, FontStyle.Regular);
            //Font drawFontArial8Regular = new Font("Courier", 8, FontStyle.Regular);
            //Font drawFontArial8Regular = my_selFont;
            //Font drawFontArial8Regular = new Font("Consolas", 6, FontStyle.Regular);

            /*
            Font drawFontArial12Bold = new Font("OCR A", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("OCR A", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("OCR A", 8, FontStyle.Regular);*/
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font drawFontArial8Regular = new Font("Arial", 8, FontStyle.Regular);
            Font drawFontArial6Regular = new Font("Arial", 6, FontStyle.Regular);
            Font drawFontArial5Regular = new Font("Arial", 5, FontStyle.Regular);
            Font drawFontArial4Regular = new Font("Arial", 4, FontStyle.Regular);

            Font drawFontConsolas8Regular = new Font("Consolas", 8, FontStyle.Regular);
            Font drawFontConsolas6Regular = new Font("Consolas", 6, FontStyle.Regular);

            Font drawFontConsolas4CRegular = new Font("Consolas", 4, FontStyle.Regular);
            Font drawFontConsolas5CRegular = new Font("Consolas", 5, FontStyle.Regular);

            Font fontinUse;
            if (fuente == "12")
            {
                fontinUse = drawFontArial12Bold;
            }
            else if (fuente == "10")
            {
                fontinUse = drawFontArial10Regular;
            }
            else if (fuente == "8")
            {
                fontinUse = drawFontArial8Regular;
            }
            else if (fuente == "6")
            {
                fontinUse = drawFontArial6Regular;
            }
            else if (fuente == "5")
            {
                fontinUse = drawFontArial5Regular;
            }
            else if (fuente == "4")
            {
                fontinUse = drawFontArial4Regular;
            }
            else if (fuente == "8C")
            {
                fontinUse = drawFontConsolas8Regular;
            }
            else if (fuente == "6C")
            {
                fontinUse = drawFontConsolas6Regular;
            }
            else if (fuente == "4C")
            {
                fontinUse = drawFontConsolas4CRegular;
            }
            else if (fuente == "5C")
            {
                fontinUse = drawFontConsolas5CRegular;
            }
            else
            {
                fontinUse = drawFontArial8Regular;
            }
            return fontinUse;
        }

        private static string msvPc(string value, int maxLength)
        {
            int splitLen = (maxLength+value.Length) / 2;
            string getMsv = msv(value, maxLength);
            string pl = getMsv.PadLeft(splitLen, ' ');
            string pr = getMsv.PadRight(splitLen, ' ');
            return pr;
        }
        private static string msvPr( string value, int maxLength){
            string getMsv = msv(value, maxLength);
            return getMsv.PadRight(maxLength,' ');
        }
        private static string msvPl(string value, int maxLength){
            string getMsv = msv(value, maxLength);
            return getMsv.PadLeft(maxLength, ' ');            
        }
        private static string msv(string value, int maxLength){
            return value?.Substring(0, Math.Min(value.Length, maxLength)).Trim();
        }
        private static void ProvideContent(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            float fontHeight = font.GetHeight();

            int startX = 0;
            int startY = 0;
            int Offset = 20;

            
            e.PageSettings.PaperSize.Width = 50;
            graphics.DrawString("Welcome to MSST", new Font("Courier New", 8),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Ticket No:" + "4525554654545",
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;


            graphics.DrawString("Ticket Date :" + "21/12/215",
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String underLine = "------------------------------------------";

            graphics.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String Grosstotal = "Total Amount to Pay = " + "2566";

            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Grosstotal, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

        }
    }
}

/*

            linea("1", "10", "l", ref x, ref y, ref width, ref height, ref e);
            linea("1", "10", "c", ref x, ref y, ref width, ref height, ref e);
            linea("1", "10", "r", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea(" ", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_123456798_", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_", "10", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_", "10", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_", "10", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_", "10", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_123456798_", "10", "l", ref x, ref y, ref width, ref height, ref e);

            linea("", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("", "8", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("123456798_123456798_123456798_123456798_123456798_", "12", "l", ref x, ref y, ref width, ref height, ref e);

            linea("", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("", "12", "l", ref x, ref y, ref width, ref height, ref e);
            linea("", "12", "l", ref x, ref y, ref width, ref height, ref e);
*/
