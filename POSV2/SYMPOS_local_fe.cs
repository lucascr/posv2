using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace POSV2
{
    class SYMPOS_local_fe
    {
        public static string g_clave20 = "";
        public static string g_clave50 = "";
        public static bool createConsecutivo(string id_invoice) {
            //
            first myFirst = first.GetInstance();
            bool errorCreateConsecutivo = false;
            string estado_internet = "";
            string clave31, clave20, clave50;

            string c_pais = "506"; //3
            string c_fecha = ""; //6

            DataTable tDt = DB.q("select concat(dia,mes,ano) as fecha,emision from (select DATE_FORMAT(now(),'%d') as dia, DATE_FORMAT(now(),'%m') as mes, DATE_FORMAT(now(),'%y') as ano, now() as emision) as sqlf", "", "");
            if (tDt.HasErrors) {
                MessageBox.Show(DB.get_language("var_err") + " createConsecutivo1");
                DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009001', bita_error='createConsecutivo 01'", "", "");
                errorCreateConsecutivo = true;
            } else {
                if (tDt.Rows.Count > 0) {
                    c_fecha = tDt.Rows[0]["fecha"].ToString();
                } else {
                    MessageBox.Show(DB.get_language("var_err") + " createConsecutivo2");
                    DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009002', bita_error='createConsecutivo 02'", "", "");
                    errorCreateConsecutivo = true;
                }
            }

            DataTable tDti = DB.q("select * from invoice where invoice_id = '" + id_invoice + "'", "", "");
            if (tDt.HasErrors) {
                MessageBox.Show(DB.get_language("var_err") + " createConsecutivo3");
                DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009003', bita_error='createConsecutivo 03'", "", "");
                errorCreateConsecutivo = true;
            } else {
                if (tDti.Rows.Count > 0) {
                    if (tDti.Rows[0]["invoice_company_identification"].ToString().Length != 12) {
                        MessageBox.Show(DB.get_language("var_err") + " createConsecutivo.id");
                        DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009004', bita_error='createConsecutivo.id'", "", "");
                        errorCreateConsecutivo = true;
                    } else {
                        string company_identification = tDti.Rows[0]["invoice_company_identification"].ToString();
                        string suc = myFirst.getKey("pos_sucursal");
                        string ter = myFirst.getKey("pos_terminal");
                        
                        clave20 = suc + ter + tDti.Rows[0]["invoice_tipo_doc"].ToString();
                        clave31 = c_pais.ToString() + c_fecha.ToString() + company_identification + clave20;

                        if (clave31.ToString().Length == 31) {
                            string sql_table = "";

                            string tn = ""; //Table name
                            string tn_tipo = ""; //Table name tipo
                            string xml_ver = "";
                            if (tDti.Rows[0]["invoice_api_type"].ToString() == "1") {
                                tn = "_prod";
                                xml_ver = "4.3";
                            } else if (tDti.Rows[0]["invoice_api_type"].ToString() == "2") {
                                tn = "_test";
                                xml_ver = "4.3";
                            } else {
                                MessageBox.Show(DB.get_language("var_err") + " createConsecutivo.invoice_api_type");
                                DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009005', bita_error='createConsecutivo.invoice_api_type'", "", "");
                                errorCreateConsecutivo = true;
                            }
                            //de_" + tn + "_" + idc + "_" + suc + "_" + ter + "_nc like de_a_tm

                            //todos
                            //Solo FE y TE se pueden hacer en contingencia sin internet

                            //Todos
                            //Habia internet
                            estado_internet = "1";
                            //No hay internet  remote a 0, estado_internet a 3 

                            if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "01") { //Factura Electrónica
                                tn_tipo = "_fe";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "02") { //Nota Débido
                                tn_tipo = "_nd";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "03") { //Nota Crédito
                                tn_tipo = "_nc";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "04") { //Tiquete Electrónico
                                tn_tipo = "_te";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "05" || tDti.Rows[0]["invoice_tipo_doc"].ToString() == "06" || tDti.Rows[0]["invoice_tipo_doc"].ToString() == "07") {
                                tn_tipo = "_mr"; //Mensaje Receptor
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "08"){ //Factura electrónica de compras
                                tn_tipo = "_fec";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "90") { //Factura SYM Proforma
                                tn_tipo = "_fp";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "91") { //Factura Temporal
                                tn_tipo = "_ft";
                            } else if (tDti.Rows[0]["invoice_tipo_doc"].ToString() == "92") { //Cotizaciones
                                tn_tipo = "_cc";
                            } else {
                                MessageBox.Show(DB.get_language("var_err") + " createConsecutivo.invoice_tipo_doc");
                                DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009006', bita_error='createConsecutivo.invoice_tipo_doc'", "", "");
                                errorCreateConsecutivo = true;
                            }

                            Application.DoEvents();
                            sql_table = "de" + tn + "_" + company_identification + "_" + suc + "_" + ter + tn_tipo;
                            DB.WaitForEndOfRead();
                            DB.e(" insert into " + sql_table + " set ref_id='" + id_invoice + "'", "", "");
                            DB.WaitForEndOfRead();

                            if (DB.conectado) {
                                string t_lid = DB.lId.ToString();
                                Random rnd = new Random();
                                Application.DoEvents();
                                clave20 = clave20 + t_lid.PadLeft(10, '0');

                                //checkConsecutivo()
                                DataTable tDtConsecutivo = DB.q("select invoice_consecutivo from invoice where invoice_consecutivo ='" + clave20 + "' and invoice_company_identification = '" + tDti.Rows[0]["invoice_company_identification"].ToString() + "' and invoice_api_type= '" + tDti.Rows[0]["invoice_api_type"].ToString() +  "'" , "", "");
                                if (tDtConsecutivo.HasErrors)
                                {
                                    MessageBox.Show(DB.get_language("var_err") + " createConsecutivo99");
                                    DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009011', bita_error='createConsecutivo 11'", "", "");
                                    errorCreateConsecutivo = true;
                                }
                                else
                                {
                                    if (tDtConsecutivo.Rows.Count > 0)
                                    {
                                        MessageBox.Show(DB.get_language("var_err") + " createConsecutivo99");
                                        DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "' ,user_id='', bita_date=now(), bita_type='10009012', bita_error='createConsecutivo 12'", "", "");                                        
                                        errorCreateConsecutivo = true;
                                    }
                                    else {

                                    }
                                }
                                        

                                clave50 = clave31 + t_lid.PadLeft(10, '0') + estado_internet + rnd.Next(1, 99999999).ToString().PadLeft(8, '0');

                                if (clave20.ToString().Length == 20 && clave50.ToString().Length == 50 && errorCreateConsecutivo == false)
                                {


                                    DB.e(" update " + sql_table + " set clave='" + clave50 + "' where ref_id='" + id_invoice + "'", "", "");
                                    DB.e(" update invoice set invoice_local_state=invoice_local_state+1,invoice_xml_ver='"+ xml_ver + "',invoice_hacienda_state='" + estado_internet + "', invoice_consecutivo='" + clave20 + "',invoice_clave='" + clave50 + "' where invoice_id='" + id_invoice + "'", "", ""); //2
                                    g_clave20 = clave20.ToString();
                                    g_clave50 = clave50.ToString();
                                }
                                else {
                                    MessageBox.Show(DB.get_language("var_err") + " createConsecutivo clave20 clave50");
                                    DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "',user_id='', bita_date=now(), bita_type='10009007', bita_error='createConsecutivo clave20 clave50'", "", "");
                                    errorCreateConsecutivo = true;
                                }


                            } else {
                                MessageBox.Show(DB.get_language("var_err") + " createConsecutivo.insertid " );
                                DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "',user_id='', bita_date=now(), bita_type='10009008', bita_error='createConsecutivo insertid " + sql_table + "'", "", "");
                                errorCreateConsecutivo = true;
                            }


                        }
                        else
                        {
                            MessageBox.Show(DB.get_language("var_err") + " createConsecutivo 31");
                            DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "',user_id='', bita_date=now(), bita_type='10009009', bita_error='createConsecutivo 31'", "", "");
                            errorCreateConsecutivo = true;
                        }
                    }


                } else {
                    MessageBox.Show(DB.get_language("var_err") + " createConsecutivo4");
                    DB.e("insert into invoice_bita set invoice_id='" + id_invoice + "',user_id='', bita_date=now(), bita_type='10009010', bita_error='createConsecutivo 04'", "", "");
                    errorCreateConsecutivo = true;
                }
            }


            return errorCreateConsecutivo;
        }
        //newFe.saveInvoice(, , , , , );
        public static string SYMinvoiceUUID(string invoice_id) {
            string result = "";
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "Run .SYMinvoiceUUID : ");

            string sql_load_invoice_uuid = "select invoice_uuid from invoice where invoice_id = '" + invoice_id + "'";
        
            DataTable tDt = DB.q(sql_load_invoice_uuid, "", "");
            foreach (DataRow r in tDt.Rows)
            {
                result = r["invoice_uuid"].ToString();
                }
            return result;
        }
        
            public int SYMsaveGastosDetail(string gastos_id, string id_line,
            string id_producto, string product_sym, string product_sym_unit, string product_sym_code_type, string product_sym_barcode,
            string product_sym_tax_code, string product_sym_tax_code_iva, string product_sym_tax, string product_sym_description,
            string qty, string product_price, string monto_total, string sub_total, string total_tax, string total_linea, string MontoDescuento, string codigo_proveedor, string codigo_cabys)
        {
            if (product_sym_code_type.Length == 0)
            {
                product_sym_code_type = "01";
            }

            string sql_save_gastos_detail_mysql = "insert into gastos_detail set ";
            sql_save_gastos_detail_mysql += "gastos_id='" + gastos_id + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_line='" + id_line + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_id='" + id_producto + "',";

            if (product_sym_unit == "Unit")
            {
                product_sym_unit = "Unid";
            }
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym='" + product_sym + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_unit='" + product_sym_unit + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_code_type='" + product_sym_code_type + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_barcode='" + product_sym_barcode + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_tax_code='" + product_sym_tax_code + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_tax_code_iva='" + product_sym_tax_code_iva + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_tax='" + product_sym_tax + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_sym_description='" + product_sym_description + "',";

            sql_save_gastos_detail_mysql += "gastos_detail_product_codigo_proveedor='" + codigo_proveedor + "',";
            sql_save_gastos_detail_mysql += "gastos_detail_product_codigo_cabys='" + codigo_cabys + "',";
            

            sql_save_gastos_detail_mysql += "gastos_detail_qty='" + qty + "',";
            /*if (product_sym_unit == "Otros")
            {

            }
            else
            {
              */
                sql_save_gastos_detail_mysql += "gastos_detail_MontoDescuento='" + DB.GetDouble(MontoDescuento) + "',";
                sql_save_gastos_detail_mysql += "gastos_detail_product_price='" + DB.GetDouble(product_price) + "',";
                sql_save_gastos_detail_mysql += "gastos_detail_MontoTotal='" + DB.GetDouble(monto_total) + "',"; //Se obtiene de la multiplicación del campo “cantidad” por el campo “precio unitario”.
                sql_save_gastos_detail_mysql += "gastos_detail_SubTotal='" + DB.GetDouble(sub_total) + "',"; //Se obtiene de la resta del campo “monto total” menos monto de descuento concedido”
                sql_save_gastos_detail_mysql += "gastos_detail_impuesto_Monto='" + DB.GetDouble(total_tax) + "',";
                sql_save_gastos_detail_mysql += "gastos_detail_MontoTotalLinea='" + DB.GetDouble(total_linea) + "',";
            //}
            sql_save_gastos_detail_mysql += "gastos_detail_cd=now()";


            DB.e(sql_save_gastos_detail_mysql, "", "");
            if (DB.conectado)
            {
                //DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", "");
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }
        public int SYMsaveInvoiceDetail(string invoice_id, string id_line,
            string id_producto,string product_sym, string product_sym_unit, string product_sym_code_type, string product_sym_barcode, 
            string product_sym_tax_code,string product_sym_tax_code_iva, string product_sym_tax,  string product_sym_description,
            string qty, string product_price, string monto_total, string descuento, string descuento_razon, string sub_total, string total_tax,string total_linea,string codigo_cabys) {
            if (product_sym_code_type.Length == 0) {
                product_sym_code_type = "01";
            }

            string sql_save_invoice_detail_mysql = "insert into invoice_detail set ";
            sql_save_invoice_detail_mysql += "invoice_id='" + invoice_id + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_line='" + id_line + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_id='" + id_producto + "',";

            sql_save_invoice_detail_mysql += "invoice_detail_product_codigo_cabys='" + codigo_cabys + "',";
            

            if (product_sym_unit== "Unit") {
                product_sym_unit = "Unid";
            }
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym='" + product_sym + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_unit='" + product_sym_unit + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_code_type='" + product_sym_code_type + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_barcode='" + product_sym_barcode + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_tax_code='" + product_sym_tax_code + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_tax_code_iva='" + product_sym_tax_code_iva + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_tax='" + product_sym_tax + "',";
            sql_save_invoice_detail_mysql += "invoice_detail_product_sym_description='" + product_sym_description + "',";
            
            sql_save_invoice_detail_mysql += "invoice_detail_qty='" + qty+ "',";
            if (product_sym_unit == "Otros")
            {

            }else { 
                sql_save_invoice_detail_mysql += "invoice_detail_product_price='" + decimal.Parse(product_price) + "',";
                sql_save_invoice_detail_mysql += "invoice_detail_MontoTotal='" + decimal.Parse(monto_total) + "',"; //Se obtiene de la multiplicación del campo “cantidad” por el campo “precio unitario”.
                if (descuento == "") { descuento = "0"; }
                sql_save_invoice_detail_mysql += "invoice_detail_MontoDescuento='" + decimal.Parse(descuento) + "',";
                sql_save_invoice_detail_mysql += "invoice_detail_NaturalezaDescuento='" + descuento_razon + "',";
                sql_save_invoice_detail_mysql += "invoice_detail_SubTotal='" + decimal.Parse(sub_total) + "',"; //Se obtiene de la resta del campo “monto total” menos monto de descuento concedido”
                sql_save_invoice_detail_mysql += "invoice_detail_impuesto_Monto='" + decimal.Parse(total_tax) + "',"; 
                sql_save_invoice_detail_mysql += "invoice_detail_MontoTotalLinea='" + decimal.Parse(total_linea) + "',";
            }
            sql_save_invoice_detail_mysql += "invoice_detail_cd=now()";
            

            DB.e(sql_save_invoice_detail_mysql, "", "");
            if (DB.conectado)
            {
                //DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", "");
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }

        public int SYMUpdateInvoiceTotals(string invoice_id,
            string invoice_TotalServGravados,
            string invoice_TotalServExentos,
            string invoice_TotalMercanciasGravadas,
            string invoice_TotalMercanciasExentas,
            string invoice_TotalGravado,
            string invoice_TotalExento,
            string invoice_TotalVenta,
            string invoice_TotalDescuentos,
            string invoice_TotalVentaNeta,
            string invoice_TotalImpuesto,
            string invoice_TotalComprobante) {
            string sql_save_invoice_mysql = "update  invoice set ";

            sql_save_invoice_mysql += "invoice_TotalServGravados='" + decimal.Parse(invoice_TotalServGravados )+ "',";
            sql_save_invoice_mysql += "invoice_TotalServExentos='" + decimal.Parse(invoice_TotalServExentos) + "',";
            sql_save_invoice_mysql += "invoice_TotalMercanciasGravadas='" + decimal.Parse(invoice_TotalMercanciasGravadas) + "',";
            sql_save_invoice_mysql += "invoice_TotalMercanciasExentas='" + decimal.Parse(invoice_TotalMercanciasExentas) + "',";
            sql_save_invoice_mysql += "invoice_TotalGravado='" + decimal.Parse(invoice_TotalGravado) + "',";
            sql_save_invoice_mysql += "invoice_TotalExento='" + decimal.Parse(invoice_TotalExento) + "',";
            sql_save_invoice_mysql += "invoice_TotalVenta='" + decimal.Parse(invoice_TotalVenta) + "',";
            sql_save_invoice_mysql += "invoice_TotalDescuentos='" + decimal.Parse(invoice_TotalDescuentos) + "',";
            sql_save_invoice_mysql += "invoice_TotalVentaNeta='" + decimal.Parse(invoice_TotalVentaNeta) + "',";
            sql_save_invoice_mysql += "invoice_TotalImpuesto='" + decimal.Parse(invoice_TotalImpuesto) + "',";
            sql_save_invoice_mysql += "invoice_TotalComprobante='" + decimal.Parse(invoice_TotalComprobante) + "' ";            

            sql_save_invoice_mysql += "where invoice_id='" + invoice_id+ "'";

            DB.e(sql_save_invoice_mysql, "", "");
            if (DB.conectado)
            {
                DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", "");
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }

        public int SYMUpdateInvoiceCompany(string invoice_id, VarCompany my_company) {
            string sql_save_invoice_mysql = "update invoice set ";
            sql_save_invoice_mysql += "invoice_company_type='" + my_company.company_type + "',";
            sql_save_invoice_mysql += "invoice_company_identification='" + my_company.company_identification + "',";
            sql_save_invoice_mysql += "invoice_company_name='" + my_company.company_name + "',";
            sql_save_invoice_mysql += "invoice_company_email='" + my_company.company_email + "',";
            sql_save_invoice_mysql += "invoice_company_addr_province='" + my_company.company_addr_province + "',";
            sql_save_invoice_mysql += "invoice_company_addr_canton='" + my_company.company_addr_canton + "',";
            sql_save_invoice_mysql += "invoice_company_addr_district='" + my_company.company_addr_district + "',";
            sql_save_invoice_mysql += "invoice_api_type='" + my_company.cloud_api_type  + "' ";
            
            sql_save_invoice_mysql += "where invoice_id='" + invoice_id + "'";

            DB.e(sql_save_invoice_mysql, "", "");
            if (DB.conectado)
            {
                DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", "");
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }
        
        public int SYMUpdateInvoiceClient(string invoice_id, VarCompany my_company) {
            string sql_save_invoice_mysql = "update invoice set ";
            sql_save_invoice_mysql += "invoice_client_id='" + my_company.id_company + "',";
            sql_save_invoice_mysql += "invoice_client_type='" + my_company.company_type + "',";
            sql_save_invoice_mysql += "invoice_client_identification='" + my_company.company_identification + "',";
            sql_save_invoice_mysql += "invoice_client_name='" + my_company.company_name + "',";
            sql_save_invoice_mysql += "invoice_client_phone_number='" + my_company.company_phone + "',";
            sql_save_invoice_mysql += "invoice_client_email='" + my_company.company_email + "' ";
                        
            //sql_save_invoice_mysql += "invoice_company_addr_province='" + my_company.company_addr_province + "',";
            //sql_save_invoice_mysql += "invoice_company_addr_canton='" + my_company.company_addr_canton + "',";
            //sql_save_invoice_mysql += "invoice_company_addr_district='" + my_company.company_addr_district + "',";            

            sql_save_invoice_mysql += "where invoice_id='" + invoice_id + "'";

            DB.e(sql_save_invoice_mysql, "", "");
            if (DB.conectado)
            {
                DB.e(" update invoice set invoice_local_state=invoice_local_state+1 where invoice_id='" + invoice_id + "'", "", "");
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }

        

        public int SYMsaveMR(string cmb_invoice_document_type,
            VarCompany my_company,string emisor_type,string emisor_identification, string emisor_name, string emisor_email, 
            string tipo_doc_referencia,string doc_referencia_clave,string doc_referencia_fecha ,
            string invoice_TotalImpuesto,string invoice_TotalComprobante, string txt_Currency, 
            string txt_tipocambio,            string invoice_TotalServGravados,            string invoice_TotalServExentos,
            string invoice_TotalMercanciasGravadas,            string invoice_TotalMercanciasExentas,
            string invoice_TotalGravado,            string invoice_TotalExento,            string invoice_TotalVenta,            string invoice_TotalDescuentos,
            string invoice_TotalVentaNeta,
            string invoice_condicion_venta, string invoice_plazo_credito, string invoice_medio_pago, string invoice_gasto_compra, string detalle_mensaje
            ) {

            string sql_save_invoice_mysql = "insert into invoice set ";
            sql_save_invoice_mysql += "invoice_cd=now(),";
            sql_save_invoice_mysql += "invoice_uuid=UUID(),";
            sql_save_invoice_mysql += "invoice_local_state='1',";
            sql_save_invoice_mysql += "invoice_api_type='" + my_company.cloud_api_type + "',";

            //Receptor YO
            sql_save_invoice_mysql += "invoice_company_type='" + my_company.company_type + "',";
            sql_save_invoice_mysql += "invoice_company_identification='" + my_company.company_identification + "',";

            //Emisor Mi proveedor
            sql_save_invoice_mysql += "invoice_client_type='" + emisor_type + "',";
            sql_save_invoice_mysql += "invoice_client_identification='" + emisor_identification + "',";
            sql_save_invoice_mysql += "invoice_client_name='" + emisor_name + "',";            
            sql_save_invoice_mysql += "invoice_client_email='" + emisor_email + "', ";
            
            sql_save_invoice_mysql += "invoice_ref_TipoDoc='" + tipo_doc_referencia + "', ";
            sql_save_invoice_mysql += "invoice_ref_Numero='" + doc_referencia_clave + "', ";
            sql_save_invoice_mysql += "invoice_ref_FechaEmision='" + doc_referencia_fecha + "', ";
            sql_save_invoice_mysql += "invoice_ref_FechaEmision_cd= REPLACE(SUBSTRING(TRIM('" + doc_referencia_fecha + "'), 1, 19), 'T', ' '), ";
            sql_save_invoice_mysql += "invoice_currency='" + txt_Currency + "', ";
            sql_save_invoice_mysql += "invoice_exchange_rate='" + txt_tipocambio + "', ";

            sql_save_invoice_mysql += "invoice_condicion_venta='" + invoice_condicion_venta + "', ";
            sql_save_invoice_mysql += "invoice_plazo_credito='" + invoice_plazo_credito + "', ";
            sql_save_invoice_mysql += "invoice_medio_pago='" + invoice_medio_pago + "', ";
            sql_save_invoice_mysql += "invoice_gasto_compra='" + invoice_gasto_compra + "', ";

            sql_save_invoice_mysql += "invoice_detalle_mensaje='" + detalle_mensaje + "', ";
            
            sql_save_invoice_mysql += "invoice_TotalImpuesto='" + decimal.Parse(invoice_TotalImpuesto) + "', ";
            sql_save_invoice_mysql += "invoice_TotalComprobante='" + decimal.Parse(invoice_TotalComprobante) + "', ";

            sql_save_invoice_mysql += "invoice_TotalServGravados='" + decimal.Parse(invoice_TotalServGravados) + "',";
            sql_save_invoice_mysql += "invoice_TotalServExentos='" + decimal.Parse(invoice_TotalServExentos) + "',";
            sql_save_invoice_mysql += "invoice_TotalMercanciasGravadas='" + decimal.Parse(invoice_TotalMercanciasGravadas) + "',";
            sql_save_invoice_mysql += "invoice_TotalMercanciasExentas='" + decimal.Parse(invoice_TotalMercanciasExentas) + "',";
            sql_save_invoice_mysql += "invoice_TotalGravado='" + decimal.Parse(invoice_TotalGravado) + "',";
            sql_save_invoice_mysql += "invoice_TotalExento='" + decimal.Parse(invoice_TotalExento) + "',";
            sql_save_invoice_mysql += "invoice_TotalVenta='" + decimal.Parse(invoice_TotalVenta) + "',";
            sql_save_invoice_mysql += "invoice_TotalDescuentos='" + decimal.Parse(invoice_TotalDescuentos) + "',";
            sql_save_invoice_mysql += "invoice_TotalVentaNeta='" + decimal.Parse(invoice_TotalVentaNeta) + "',";

            sql_save_invoice_mysql += "invoice_tipo_doc='" + cmb_invoice_document_type + "'";

            DB.e(sql_save_invoice_mysql , "", "");
            if (DB.conectado)
            {
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }

        public int SYMsaveInvoice(string cmb_invoice_actividad_economica,
            string cmb_invoice_document_type,
            string cmb_invoice_cur,string txt_invoice_cur,
            string cmb_invoice_sale_type,string txt_invoice_credit_days,string txt_invoice_medio_pago,bool chk_invoice_client) {
            string sql_save_invoice_mysql = "insert into invoice set ";
            sql_save_invoice_mysql += "invoice_cd=now(),";
            sql_save_invoice_mysql += "invoice_uuid=UUID(),";
            sql_save_invoice_mysql += "invoice_local_state='1',";
            sql_save_invoice_mysql += "invoice_currency='"+ cmb_invoice_cur+ "',";
            if (cmb_invoice_cur == "USD") { 
                sql_save_invoice_mysql += "invoice_exchange_rate='"+ txt_invoice_cur + "',";
            }

            sql_save_invoice_mysql += "invoice_condicion_venta='"+ cmb_invoice_sale_type + "',";
            if (cmb_invoice_sale_type == "02") { 
                sql_save_invoice_mysql += "invoice_plazo_credito='"+ txt_invoice_credit_days + "',";
            }
            sql_save_invoice_mysql += "invoice_medio_pago='"+ txt_invoice_medio_pago + "',";
            if (!chk_invoice_client) { 
                sql_save_invoice_mysql += "invoice_client_type='0',";
            }
            
            sql_save_invoice_mysql += "invoice_actividad_economica='" + cmb_invoice_actividad_economica + "',";

            sql_save_invoice_mysql += "invoice_tipo_doc='" + cmb_invoice_document_type + "'";

            DB.e(sql_save_invoice_mysql , "", "");
            if (DB.conectado)
            {
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }

        public int SYMsaveAnularInvoiceReferenciaLocal(string origin_invoice_uuid,string new_invoice_id)
        {
            
            string sql_load_invoices_main_new_mysql = "select * from invoice where invoice_id='" + new_invoice_id + "' limit 1";
            DataTable tDt = DB.q(sql_load_invoices_main_new_mysql, "", "");
            string sql_save_AnularinvoiceReferencia_mysql = "";
            foreach (DataRow r in tDt.Rows)
            {
                 sql_save_AnularinvoiceReferencia_mysql = "update invoice set invoice_ref_TipoDoc='"+ r["invoice_tipo_doc"].ToString() + "',invoice_ref_Numero='" + r["invoice_clave"].ToString() + "',invoice_ref_Codigo='" + r["invoice_ref_Codigo"].ToString() + "',invoice_ref_FechaEmision='" + r["invoice_fecha_emision"].ToString() + "'  where invoice_uuid = '" + origin_invoice_uuid + "'";
            }

            DB.e(sql_save_AnularinvoiceReferencia_mysql, "", "");
            if (DB.conectado)
            {
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }
        public int SYMsaveAnularInvoice(string origin_invoice_uuid) {
            string sql_save_Anularinvoice_mysql = "insert into invoice(invoice_cd, invoice_uuid, invoice_local_state, invoice_actividad_economica, invoice_tipo_doc, ";
            sql_save_Anularinvoice_mysql += " invoice_currency, invoice_exchange_rate, invoice_condicion_venta, invoice_plazo_credito, invoice_medio_pago, invoice_client_type,";
            sql_save_Anularinvoice_mysql += " invoice_ref_TipoDoc, invoice_ref_Numero, invoice_ref_FechaEmision,";
            sql_save_Anularinvoice_mysql += " invoice_ref_Codigo, invoice_ref_Razon)";
            sql_save_Anularinvoice_mysql += " (select now(), UUID(), '1', invoice_actividad_economica, '03', ";
            sql_save_Anularinvoice_mysql += " invoice_currency, invoice_exchange_rate, invoice_condicion_venta, invoice_plazo_credito, invoice_medio_pago, invoice_client_type, ";
            sql_save_Anularinvoice_mysql += " invoice_tipo_doc, invoice_clave, invoice_fecha_emision, ";
            sql_save_Anularinvoice_mysql += " '01', 'ANULAR FACTURA'  from invoice where invoice.invoice_uuid = '" + origin_invoice_uuid + "') ";
            DB.e(sql_save_Anularinvoice_mysql, "", "");
            if (DB.conectado)
            {
                //MessageBox.Show(DB.get_language("var_ok"));
                return 1;
            }
            else
            {
                //MessageBox.Show(DB.get_language("var_err"));
                return 0;
            }
        }
    }
}
