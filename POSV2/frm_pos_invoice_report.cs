using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace POSV2
{
    public partial class frm_pos_invoice_report : Form
    {
        /*SELECT 
if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency,
products_tax_code.tax_code_descripcion,
gastos_detail.gastos_detail_product_sym_tax_code,
products_tax_code_iva.tax_code_iva_descripcion,
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',
if(gastos_detail.gastos_detail_product_sym_tax_code='01','08','')
,gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,
gastos_detail.gastos_detail_product_sym_tax,
gastos_detail.gastos_detail_MontoTotal,
gastos_detail.gastos_detail_MontoDescuento,
gastos_detail.gastos_detail_SubTotal,
gastos_detail.gastos_detail_impuesto_Monto,
gastos_detail.gastos_detail_MontoTotalLinea,
invoice.invoice_client_commercial_name,
invoice.invoice_client_identification,
invoice.invoice_client_name,
invoice.invoice_ref_Numero,
invoice.invoice_cd,
invoice.invoice_condicion_venta,
invoice.invoice_ref_FechaEmision,
gastos_detail.gastos_detail_product_sym_tax_code,
gastos_detail.gastos_detail_product_sym_tax_code_iva,
gastos_detail.gastos_detail_product_sym_tax
from invoice 
inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id 
left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code 
left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  
where invoice_api_type =1 and  (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  ) 
and invoice_ref_FechaEmision_cd BETWEEN '2019-07-01 00:00:00' and '2019-07-31 23:59:59' 
order by invoice_currency,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification 

 
            SELECT 
count(*),
if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency,
products_tax_code.tax_code_descripcion,
gastos_detail.gastos_detail_product_sym_tax_code,
products_tax_code_iva.tax_code_iva_descripcion,
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,
gastos_detail.gastos_detail_product_sym_tax,
sum(gastos_detail.gastos_detail_MontoTotal),
sum(gastos_detail.gastos_detail_MontoDescuento),
sum(gastos_detail.gastos_detail_SubTotal),
sum(gastos_detail.gastos_detail_impuesto_Monto),
sum(gastos_detail.gastos_detail_MontoTotalLinea),
invoice.invoice_client_commercial_name,
invoice.invoice_client_identification,
invoice.invoice_client_name,
invoice.invoice_ref_Numero,
invoice.invoice_cd,
invoice.invoice_condicion_venta,
invoice.invoice_ref_FechaEmision,
gastos_detail.gastos_detail_product_sym_tax_code,
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva2,
gastos_detail.gastos_detail_product_sym_tax
from invoice 
inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id 
left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code 
left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  
where invoice_api_type =1 and  (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  ) 
and invoice_ref_FechaEmision_cd BETWEEN '2019-07-01 00:00:00' and '2019-07-31 23:59:59' and gastos_detail.gastos_detail_MontoTotalLinea<=0
group by invoice_currency,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_Numero
order by invoice_currency,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_FechaEmision

            SELECT 
if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,
products_tax_code.tax_code_descripcion,
gastos_detail.gastos_detail_product_sym_tax_code,
products_tax_code_iva.tax_code_iva_descripcion,
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,
gastos_detail.gastos_detail_product_sym_tax,
gastos_detail.gastos_detail_MontoTotal,
gastos_detail.gastos_detail_MontoDescuento,
gastos_detail.gastos_detail_SubTotal,
gastos_detail.gastos_detail_impuesto_Monto,
gastos_detail.gastos_detail_MontoTotalLinea,
invoice.invoice_client_commercial_name,
invoice.invoice_client_identification,
invoice.invoice_client_name,
invoice.invoice_ref_Numero,
invoice.invoice_cd,
invoice.invoice_condicion_venta,
invoice.invoice_ref_FechaEmision,
gastos_detail.gastos_detail_product_sym_tax_code,
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva2,
gastos_detail.gastos_detail_product_sym_tax
from invoice 
inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id 
left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code 
left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  
where invoice_api_type =1 and  (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  ) 
and invoice_ref_FechaEmision_cd BETWEEN '2019-07-01 00:00:00' and '2019-07-31 23:59:59' 
group by invoice_currency_fix,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_Numero
order by invoice_currency_fix,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification

            SELECT 
if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,
gastos_detail_product_sym_tax_code, 
if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,
gastos_detail_product_sym_tax,
invoice.invoice_client_identification,
invoice.invoice_ref_Numero,
invoice.invoice_medio_pago,
invoice.invoice_condicion_venta,
invoice.invoice_plazo_credito
from invoice 
inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id 
left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code 
left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  
where invoice_api_type =1 and  (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  ) 
and invoice_ref_FechaEmision_cd BETWEEN '2019-07-01 00:00:00' and '2019-07-31 23:59:59' 
group by invoice_currency_fix,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_Numero
order by invoice_currency_fix,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification
             */

        string file_name = "";
        public frm_pos_invoice_report()
        {
            InitializeComponent();
        }
        private void frm_pos_invoice_report_Load(object sender, EventArgs e)
        {
            invoice_pos__r_dt1.Value.ToShortDateString();
            invoice_pos__r_dt2.Value.ToShortDateString();

        }

        

        private void btn_print_Click(object sender, EventArgs e)
        {
            invoice_wb1.Print();
            //invoice_wb1.ShowPrintDialog();

        }

        private void btn_invoice_ventas_Click(object sender, EventArgs e)
        {
            //ToString("yyyy-MM-dd")
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            string specialSQLTipoDoc_nc = "";
            if (invoice_pos__r_medio_pago.Checked)
            {
                specialSQL += ",sum(if(invoice_medio_pago='01',invoice_TotalComprobante,0)) as efectivo,sum(if (invoice_medio_pago = '01',0,invoice_TotalComprobante)) as tarjeta";
            }

            if (invoice_pos__r_condicion_venta.Checked)
            {
                specialSQL += ",sum(if(invoice_condicion_venta='01',invoice_TotalComprobante,0)) as contado,sum(if (invoice_condicion_venta = '02',invoice_TotalComprobante,0)) as credito";
            }

            /*invoice_pos__r_condicion_venta*/ 
            if (invoice_pos__r_td_fe.Checked)
            {
                specialSQLTipoDoc = " or invoice_tipo_doc = '01'";
            }
            if (invoice_pos__r_td_te.Checked)
            {
                specialSQLTipoDoc += " or invoice_tipo_doc = '04'";
            }

            if (invoice_pos__r_td_nc.Checked)
            {
                specialSQLTipoDoc_nc += " or invoice_tipo_doc = '03'";
            }
            
            //(invoice_hacienda_ind_estado= 'aceptado') and  
            string sql_invoice_api_type = "";
            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            string sql_report_invoices_mysql = "SELECT count(*) as facturas,invoice_currency, sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento, ";            
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalComprobante) as invoice_TotalComprobante " + specialSQL + " from invoice ";
            string sql_report_invoices_mysql_nc = sql_report_invoices_mysql;

            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '' " + specialSQLTipoDoc + ") and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' group by invoice_currency ";
            sql_report_invoices_mysql_nc += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '' " + specialSQLTipoDoc_nc + ") and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59'  group by invoice_currency ";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Ventas General del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Ventas General del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");



            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                gHtml.add2("Total Documentos", r["facturas"].ToString());
                gHtml.add2("Moneda", r["invoice_currency"].ToString());
                gHtml.add2("Total Exonerado", r["invoice_TotalExento"].ToString());
                gHtml.add2("Total Gravado", r["invoice_TotalGravado"].ToString());
                gHtml.add2("Total Impuestos", r["invoice_TotalImpuesto"].ToString());
                gHtml.add2("Total Comprobantes", r["invoice_TotalComprobante"].ToString());

                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Efectivo", r["efectivo"].ToString());
                    gHtml.add2("Total Tarjeta", r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Contado", r["contado"].ToString());
                    gHtml.add2("Total Credito", r["credito"].ToString());
                }

            }

            if (invoice_pos__r_td_nc.Checked)
            {
                DataTable tDt_nc = DB.q(sql_report_invoices_mysql_nc, "", "");
                gHtml.add2("<HR>", "<HR>");
                gHtml.add2("--Notas de Crédito--","");
                foreach (DataRow r in tDt_nc.Rows)
                {
                    gHtml.add2("Total NC", r["facturas"].ToString());
                    gHtml.add2("Moneda", r["invoice_currency"].ToString());
                    gHtml.add2("Total Exonerado", r["invoice_TotalExento"].ToString());
                    gHtml.add2("Total Gravado", r["invoice_TotalGravado"].ToString());
                    gHtml.add2("Total Impuestos", r["invoice_TotalImpuesto"].ToString());
                    gHtml.add2("Total Comprobantes", r["invoice_TotalComprobante"].ToString());


                }


            }


            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();

            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_invoice_ventas_diario_Click(object sender, EventArgs e)
        {
            //ToString("yyyy-MM-dd")
            string specialSQL = "";
            string specialSQLHead = "";
            string specialSQLDetail = "";
            string specialSQLTipoDoc = "";
            string SQLTipoDOC = "";

            if (invoice_pos__r_medio_pago.Checked)
            {
                //specialSQL += ",sum(if(invoice_medio_pago='01',invoice_TotalComprobante,0)) as efectivo,sum(if (invoice_medio_pago = '01',0,invoice_TotalComprobante)) as tarjeta";
                specialSQLHead += ",(efectivo-nc_efectivo) as efectivoNeto ,(tarjeta-nc_tarjeta) as tarjetaNeto ";
                specialSQLDetail += ",sum(if(invoice_medio_pago = '01',invoice_TotalComprobante,0)) as efectivo,sum(if (invoice_medio_pago = '01',0,invoice_TotalComprobante)) as tarjeta,sum(if(invoice_medio_pago = '01',if(invoice_tipo_doc = '03', invoice_TotalComprobante,0),0 )) as nc_efectivo,sum(if (invoice_medio_pago = '01',0, if(invoice_tipo_doc = '03',invoice_TotalComprobante,0) )) as nc_tarjeta ";
            }

            if (invoice_pos__r_condicion_venta.Checked)
            {
                specialSQL += ",sum(if(invoice_condicion_venta='01',invoice_TotalComprobante,0)) as contado,sum(if (invoice_condicion_venta = '02',invoice_TotalComprobante,0)) as credito";
            }
 
            if (invoice_pos__r_td_fe.Checked){
                specialSQLTipoDoc = " or invoice_tipo_doc = '01'";
                SQLTipoDOC += " / Tiquetes ";
            }
            if (invoice_pos__r_td_te.Checked){
                specialSQLTipoDoc += " or invoice_tipo_doc = '04'";
                SQLTipoDOC += " / Facturas ";
            }
            if (invoice_pos__r_td_nc.Checked)
            {
                specialSQLTipoDoc += " or invoice_tipo_doc = '03'";
                SQLTipoDOC += " / Notas de Credito";
            }


            if (invoice_pos__r_td_nc.Checked)
            {
                //specialSQLTipoDoc += " or invoice_tipo_doc = '03'";
            }
            
            /*invoice_pos__r_condicion_venta*/
            //(invoice_hacienda_ind_estado= 'aceptado') and

            string sql_invoice_api_type = "";
            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            /*
            string sql_report_invoices_mysql = "SELECT SUBSTR(invoice.invoice_cd, 1, 10) as dia,invoice_currency ,count(*) as facturas, sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento, ";
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalComprobante) as invoice_TotalComprobante " + specialSQL + " from invoice ";
            sql_report_invoices_mysql += " where "+ sql_invoice_api_type + " (invoice_tipo_doc = '' " + specialSQLTipoDoc + " ) and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59'  group by SUBSTR(invoice.invoice_cd, 1, 10), invoice_currency";
            */

            string sql_report_invoices_mysql = "select *,(invoice_TotalImpuesto-invoice_TotalImpuesto_Notas_Credito) as ImpuestoNeto ,(invoice_TotalComprobante-invoice_TotalComprobante_Notas_Credito) as TotalNeto " + specialSQLHead + " from ( SELECT ";
            sql_report_invoices_mysql += " SUBSTR(invoice.invoice_cd, 1, 10) as dia,invoice_currency ,count(*) as facturas,sum( if(invoice_tipo_doc != '03',invoice_TotalGravado,0) ) as invoice_TotalGravado,sum( if(invoice_tipo_doc != '03',invoice_TotalExento,0) ) as invoice_TotalExento,sum( if(invoice_tipo_doc != '03',invoice_TotalImpuesto,0) ) as invoice_TotalImpuesto,sum( if(invoice_tipo_doc != '03',invoice_TotalComprobante,0) ) as invoice_TotalComprobante,sum( if(invoice_tipo_doc = '03',invoice_TotalImpuesto,0) )  as invoice_TotalImpuesto_Notas_Credito,sum( if(invoice_tipo_doc = '03',invoice_TotalComprobante,0) )  as invoice_TotalComprobante_Notas_Credito " + specialSQLDetail + specialSQL;
            sql_report_invoices_mysql += " from invoice where " + sql_invoice_api_type +  " (invoice_tipo_doc = '' " + specialSQLTipoDoc + " )  and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' group by SUBSTR(invoice.invoice_cd, 1, 10), invoice_currency ) as master";


            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Ventas Diario del  ");            
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            gHtml.crear("Tipos de Documento :  " + SQLTipoDOC);
            
            file_name = "Reporte Ventas Diario del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");


            Console.Write(sql_report_invoices_mysql);
            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            gHtml.addTD("Dia");
            gHtml.addTD("# Documentos");
            gHtml.addTD("Moneda");
            gHtml.addTD("Gravado");
            gHtml.addTD("Exento");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (invoice_pos__r_medio_pago.Checked)
            {
                gHtml.addTD("Efectivo");
                gHtml.addTD("Tarjeta");

                gHtml.addTD("Efectivo Neto");
                gHtml.addTD("Tarjeta Neto");

            }

            gHtml.addTD("NC Impuesto ");
            gHtml.addTD("NC Total");

            gHtml.addTD("Impuesto Neto");
            gHtml.addTD("Total Neto");

            if (invoice_pos__r_condicion_venta.Checked)
            {
                gHtml.addTD("Contado");
                gHtml.addTD("Credito");
            }


            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["dia"].ToString());
                gHtml.addTD(r["facturas"].ToString());                
                gHtml.addTD(r["invoice_currency"].ToString());
                gHtml.addTD(r["invoice_TotalGravado"].ToString());
                gHtml.addTD(r["invoice_TotalExento"].ToString());
                gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante"].ToString());


                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD(r["efectivo"].ToString());
                    gHtml.addTD(r["tarjeta"].ToString());

                    gHtml.addTD(r["efectivoNeto"].ToString());
                    gHtml.addTD(r["tarjetaNeto"].ToString());
                }


                gHtml.addTD(r["invoice_TotalImpuesto_Notas_Credito"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante_Notas_Credito"].ToString());
                gHtml.addTD(r["ImpuestoNeto"].ToString());
                gHtml.addTD(r["TotalNeto"].ToString());

                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD(r["contado"].ToString());
                    gHtml.addTD(r["credito"].ToString());
                }   
                gHtml.addTR();
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_invoice_gastos_general_Click(object sender, EventArgs e)
        {
            //ToString("yyyy-MM-dd")
            DB.TemporalUpdateGastos();
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            string sql_special_group = "";

            //(invoice_hacienda_ind_estado= 'aceptado') and  
            string sql_invoice_api_type = " ( if(isnull(invoice_hacienda_ind_estado),'',invoice_hacienda_ind_estado) != 'rechazado' ) and ";
            if (!first.auto_debug)
            {
                sql_invoice_api_type += "invoice_api_type =1 and ";
            }

            if (invoice_pos__r_gastosycompras.Checked)
            {
                sql_special_group = " ,invoice_gasto_compra";
            }
            /*
            if (invoice_pos__r_medio_pago.Checked)
            {
                specialSQL += ",sum(if(invoice_medio_pago='01',invoice_TotalComprobante,0)) as efectivo,sum(if (invoice_medio_pago = '01',0,invoice_TotalComprobante)) as tarjeta";
            }

            if (invoice_pos__r_condicion_venta.Checked)
            {
                specialSQL += ",sum(if(invoice_condicion_venta='01',invoice_TotalComprobante,0)) as contado,sum(if (invoice_condicion_venta = '02',invoice_TotalComprobante,0)) as credito,";
            }*/


            string sql_report_invoices_mysql = "SELECT count(*) as facturas,invoice_gasto_compra,if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix, sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento, ";
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalDescuentos) as invoice_TotalDescuentos, sum(invoice_TotalComprobante) as invoice_TotalComprobante " + specialSQL + " from  ";

            sql_report_invoices_mysql += "(select * from invoice where invoice_ref_TipoDoc = '01' and(invoice_tipo_doc = '05' or invoice_tipo_doc = '06')  group by invoice_ref_Numero) as invoice";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' group by invoice_currency_fix" + sql_special_group;

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Gastos-Compras General del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Gastos-Compras General del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") ;



            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            foreach (DataRow r in tDt.Rows)
            {
                gHtml.add2("Total Documentos", r["facturas"].ToString());

                gHtml.add2("Moneda", r["invoice_currency_fix"].ToString());

                gHtml.add2("Total Gravado", r["invoice_TotalGravado"].ToString());
                gHtml.add2("Total Exento", r["invoice_TotalExento"].ToString());
                
                gHtml.add2("Total Descuentos", r["invoice_TotalDescuentos"].ToString());
                
                gHtml.add2("Total Impuestos", r["invoice_TotalImpuesto"].ToString());
                gHtml.add2("Total Comprobantes", r["invoice_TotalComprobante"].ToString());


                if (invoice_pos__r_gastosycompras.Checked)
                {

                    gHtml.add2("Gasto/Compra", gasto_compra(r["invoice_gasto_compra"].ToString()) );
                    
                }

                /*
                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Efectivo", r["efectivo"].ToString());
                    gHtml.add2("Total Tarjeta", r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Contado", r["contado"].ToString());
                    gHtml.add2("Total Credito", r["credito"].ToString());
                }
                */
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_invoice_gastos_diario_Click(object sender, EventArgs e)
        {
            //ToString("yyyy-MM-dd")
            DB.TemporalUpdateGastos();            
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            string sql_special_group = "";

            string sql_invoice_api_type = " ( if(isnull(invoice_hacienda_ind_estado),'',invoice_hacienda_ind_estado) != 'rechazado' )  and ";
            if (!first.auto_debug)
            {
                sql_invoice_api_type += "invoice_api_type =1 and ";
            }

            if (invoice_pos__r_gastosycompras.Checked)
            {
                sql_special_group = " ,invoice_gasto_compra";
            }

            string sql_report_invoices_mysql = "SELECT if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,SUBSTR(invoice.invoice_cd, 1, 10) as dia ,count(*) as facturas,invoice_gasto_compra, sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento,sum(invoice_TotalDescuentos) as invoice_TotalDescuentos, ";
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalComprobante) as invoice_TotalComprobante " + specialSQL + " from ";

            sql_report_invoices_mysql += "(select * from invoice where invoice_ref_TipoDoc = '01' and(invoice_tipo_doc = '05' or invoice_tipo_doc = '06')  group by invoice_ref_Numero) as invoice";

            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59'  group by invoice_currency_fix,SUBSTR(invoice.invoice_ref_FechaEmision_cd, 1, 10)" + sql_special_group;

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Gastos-Compras Diario del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));

            file_name = "Reporte Gastos-Compras Diarios del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");

            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            gHtml.addTD("Dia");
            gHtml.addTD("# Documentos");
            gHtml.addTD("Moneda");
            gHtml.addTD("Gravado");
            gHtml.addTD("Exento");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (invoice_pos__r_gastosycompras.Checked)
            {
                gHtml.addTD("Gasto/Compra");
            }
            /*
            if (invoice_pos__r_medio_pago.Checked)
            {
                gHtml.addTD("Efectivo");
                gHtml.addTD("Tarjeta");
            }
            if (invoice_pos__r_condicion_venta.Checked)
            {
                gHtml.addTD("Contado");
                gHtml.addTD("Credito");
            }*/
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["dia"].ToString());
                gHtml.addTD(r["facturas"].ToString());
                gHtml.addTD(r["invoice_currency_fix"].ToString());
                gHtml.addTD(r["invoice_TotalGravado"].ToString());
                gHtml.addTD(r["invoice_TotalExento"].ToString());
                gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante"].ToString());

                if (invoice_pos__r_gastosycompras.Checked)
                {
                    gHtml.addTD(gasto_compra(r["invoice_gasto_compra"].ToString()));
                    
                }
                /*

                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD(r["efectivo"].ToString());
                    gHtml.addTD(r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD(r["contado"].ToString());
                    gHtml.addTD(r["credito"].ToString());
                }*/
                gHtml.addTR();
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_invoice_ventas_clientes_Click(object sender, EventArgs e)
        {

            //ToString("yyyy-MM-dd")
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            if (invoice_pos__r_medio_pago.Checked)
            {
                specialSQL += ",sum(if(invoice_medio_pago='01',invoice_TotalComprobante,0)) as efectivo,sum(if (invoice_medio_pago = '01',0,invoice_TotalComprobante)) as tarjeta";
            }

            if (invoice_pos__r_condicion_venta.Checked)
            {
                specialSQL += ",sum(if(invoice_condicion_venta='01',invoice_TotalComprobante,0)) as contado,sum(if (invoice_condicion_venta = '02',invoice_TotalComprobante,0)) as credito";
            }

            if (invoice_pos__r_td_fe.Checked)
            {
                specialSQLTipoDoc = " or invoice_tipo_doc = '01'";
            }
            if (invoice_pos__r_td_te.Checked)
            {
                specialSQLTipoDoc += " or invoice_tipo_doc = '04'";
            }
            /*invoice_pos__r_condicion_venta*/
            //(invoice_hacienda_ind_estado= 'aceptado') and

            string sql_invoice_api_type = "";
            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            string sql_report_invoices_mysql = "SELECT invoice_currency,invoice_client_type,invoice_client_identification,invoice_client_name,count(*) as facturas,";
            sql_report_invoices_mysql += "sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento, ";
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalComprobante) as invoice_TotalComprobante " + specialSQL + " from invoice ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '' " + specialSQLTipoDoc + " )  and invoice_ref_Codigo is null and invoice_client_identification is not null and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59'  group by invoice_client_identification,invoice_currency";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Ventas Por Cliente del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Ventas Por Cliente del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");

            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            gHtml.addTD("Tipo Id");
            gHtml.addTD("Identificación");
            gHtml.addTD("Nombre");
            gHtml.addTD("# Documentos");
            gHtml.addTD("Moneda");            
            gHtml.addTD("Gravado");
            gHtml.addTD("Exento");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (invoice_pos__r_medio_pago.Checked)
            {
                gHtml.addTD("Efectivo");
                gHtml.addTD("Tarjeta");
            }
            if (invoice_pos__r_condicion_venta.Checked)
            {
                gHtml.addTD("Contado");
                gHtml.addTD("Credito");
            }
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["invoice_client_type"].ToString());
                gHtml.addTD(r["invoice_client_identification"].ToString());
                gHtml.addTD(r["invoice_client_name"].ToString());
                gHtml.addTD(r["facturas"].ToString());
                gHtml.addTD(r["invoice_currency"].ToString());                
                gHtml.addTD(r["invoice_TotalGravado"].ToString());
                gHtml.addTD(r["invoice_TotalExento"].ToString());
                gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante"].ToString());


                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD(r["efectivo"].ToString());
                    gHtml.addTD(r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD(r["contado"].ToString());
                    gHtml.addTD(r["credito"].ToString());
                }
                gHtml.addTR();
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "reporte_"+ file_name + ".xls";

            save.Filter = "Excel File | *.xls";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());


                    writer.WriteLine(invoice_wb1.DocumentText);


                writer.Dispose();

                writer.Close();

            }

        }

        private void btn_invoice_gastos_proveedor_Click(object sender, EventArgs e)
        {

            //ToString("yyyy-MM-dd")
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            string sql_special_group = "";

            //(invoice_hacienda_ind_estado= 'aceptado') and  
            string sql_invoice_api_type = " ( if(isnull(invoice_hacienda_ind_estado),'',invoice_hacienda_ind_estado) != 'rechazado' )  and ";
            if (!first.auto_debug)
            {
                sql_invoice_api_type += "invoice_api_type =1 and ";
            }

            if (invoice_pos__r_gastosycompras.Checked) {
                sql_special_group = " ,invoice_gasto_compra";
            }

            string sql_report_invoices_mysql = "SELECT count(*) as facturas,if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix, invoice_gasto_compra,sum(invoice_TotalGravado) as invoice_TotalGravado,sum(invoice_TotalExento) as invoice_TotalExento, ";
            sql_report_invoices_mysql += "sum(invoice_TotalImpuesto) as invoice_TotalImpuesto, sum(invoice_TotalDescuentos) as invoice_TotalDescuentos, sum(invoice_TotalComprobante) as invoice_TotalComprobante, ";
            sql_report_invoices_mysql += "invoice_client_identification,invoice_client_name,invoice_client_type,invoice_client_email " + specialSQL + " from  ";

            sql_report_invoices_mysql += "(select * from invoice where invoice_ref_TipoDoc = '01' and(invoice_tipo_doc = '05' or invoice_tipo_doc = '06')  group by invoice_ref_Numero) as invoice";

            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59'  group by invoice_currency_fix,invoice_client_identification " + sql_special_group + " order by invoice_client_name ";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Gastos-Compras Por Proveedor del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Gastos-Compras Por Proveedor del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");



            gHtml.addTD("Tipo Id");
            gHtml.addTD("Identificación");
            gHtml.addTD("Nombre");
            gHtml.addTD("# Documentos");
            gHtml.addTD("Moneda");
            gHtml.addTD("Gravado");
            gHtml.addTD("Exento");
            gHtml.addTD("Descuentos");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (invoice_pos__r_gastosycompras.Checked)
            {
                gHtml.addTD("Gasto/Compra");
            }

                DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {

                gHtml.addTD(r["invoice_client_type"].ToString());
                gHtml.addTD(r["invoice_client_identification"].ToString());
                gHtml.addTD(r["invoice_client_name"].ToString());
                gHtml.addTD(r["facturas"].ToString());
                gHtml.addTD(r["invoice_currency_fix"].ToString());
                gHtml.addTD(r["invoice_TotalGravado"].ToString());
                gHtml.addTD(r["invoice_TotalExento"].ToString());
                gHtml.addTD(r["invoice_TotalDescuentos"].ToString());
                gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante"].ToString());
                if (invoice_pos__r_gastosycompras.Checked)
                {
                    gHtml.addTD(gasto_compra(r["invoice_gasto_compra"].ToString()));
                    
                }

                    gHtml.addTR();
                /*
                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Efectivo", r["efectivo"].ToString());
                    gHtml.add2("Total Tarjeta", r["tarjeta"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.add2("<HR>", "<HR>");
                    gHtml.add2("Total Contado", r["contado"].ToString());
                    gHtml.add2("Total Credito", r["credito"].ToString());
                }
                */
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }
        private string gasto_compra(string tipo)
        {
            string respuesta = "";
            if (tipo == "01")
            {
                respuesta = "Gasto";
            }
            else if (tipo == "02")
            {
                respuesta = "Compra";
            }
            else
            {
                respuesta = "Sin Asignar";
            }
            return respuesta;
        }
        private void btn_invoice_gastos_x_impuesto_Click(object sender, EventArgs e)
        {

            DB.TemporalUpdateGastos();
            string specialSQL = "";
            string specialSQLTipoDoc = "";

            string last_gastos_detail_product_sym_tax_code = "-1";
            string last_gastos_detail_product_sym_tax_code_iva= "-1";

            //(invoice_hacienda_ind_estado= 'aceptado') and  
            string sql_invoice_api_type = "";

            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            /*
            string sql_report_invoices_mysql = "SELECT if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,gastos_detail.gastos_detail_product_sym_unit,products_tax_code.tax_code_descripcion,gastos_detail.gastos_detail_product_sym_tax_code,products_tax_code_iva.tax_code_iva_descripcion, ";
            sql_report_invoices_mysql  +="gastos_detail.gastos_detail_product_sym_tax_code_iva,gastos_detail.gastos_detail_product_sym_tax,sum(gastos_detail.gastos_detail_product_price) as gastos_detail_product_price,sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoToal, ";
            sql_report_invoices_mysql += "sum(gastos_detail.gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail.gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail.gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail.gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea ";
            sql_report_invoices_mysql += "from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql_report_invoices_mysql += "group by  invoice_currency_fix ,gastos_detail_product_sym_tax_code,gastos_detail_product_sym_tax_code_iva,gastos_detail_product_sym_tax order by gastos_detail_product_sym_tax_code, gastos_detail_product_sym_tax_code_iva";
            */

            /*string sql_report_invoices_mysql = "select count(*) as cuenta,if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,products_tax_code.tax_code_descripcion,gastos_detail.gastos_detail_product_sym_tax_code,products_tax_code_iva.tax_code_iva_descripcion, ";
            sql_report_invoices_mysql += "if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,gastos_detail.gastos_detail_product_sym_tax, ";
            sql_report_invoices_mysql += "sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoTotal,sum(gastos_detail.gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail.gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail.gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail.gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea, ";
            sql_report_invoices_mysql += "invoice.invoice_client_commercial_name,invoice.invoice_client_identification,invoice.invoice_client_name,invoice.invoice_ref_Numero,invoice.invoice_cd,invoice.invoice_condicion_venta,invoice.invoice_ref_FechaEmision ";
            sql_report_invoices_mysql += "from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql_report_invoices_mysql += "group by invoice_currency_fix,gastos_detail_product_sym_tax_code,sym_tax_code_iva,gastos_detail_product_sym_tax order by invoice_currency,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_FechaEmision";
            */

            string sql_report_invoices_mysql = "select if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,products_tax_code.tax_code_descripcion,products_tax_code_iva.tax_code_iva_descripcion,gastos_detail.gastos_detail_product_sym_tax_code, ";
            sql_report_invoices_mysql += " if (gastos_detail.gastos_detail_product_sym_tax_code_iva = '',if (gastos_detail.gastos_detail_product_sym_tax_code = '01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,gastos_detail.gastos_detail_product_sym_tax,sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoTotal, ";
            sql_report_invoices_mysql += " sum(gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea, ";
            sql_report_invoices_mysql += " invoice_TotalServGravados,invoice_TotalServExentos,invoice_TotalMercanciasGravadas,invoice_TotalMercanciasExentas,invoice_TotalGravado,invoice_TotalExento,invoice_TotalVenta,invoice_TotalDescuentos,invoice_TotalVentaNeta,invoice_TotalImpuesto,invoice_TotalComprobante,invoice_ref_Numero ";
            sql_report_invoices_mysql += " from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id  left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' and gastos_detail.gastos_detail_MontoTotalLinea > 0 ";
            sql_report_invoices_mysql += " group by invoice_currency_fix ,invoice_ref_Numero,gastos_detail_product_sym_tax_code,sym_tax_code_iva,gastos_detail_product_sym_tax order by invoice_currency_fix, gastos_detail_product_sym_tax_code, sym_tax_code_iva, gastos_detail_product_sym_tax, invoice_ref_Numero  ";
                                                                                                                                                                                
            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Compras por Tipo de Impuesto del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Compras por Tipo de Impuesto del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");
            Console.Write(sql_report_invoices_mysql.ToString());
            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");


            gHtml.addTD("Moneda");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("CodigoTarifa");
            gHtml.addTD("CodigoTarifa");
            gHtml.addTD("Tarifa IVA %");
            //gHtml.addTD("PrecioUnitarios");
            gHtml.addTD("MontoTotal");
            gHtml.addTD("MontoDescuento");
            gHtml.addTD("SubTotal");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");

            gHtml.addTD("Total Serv. Gravados");
            gHtml.addTD("Total Serv. Exentos");

            gHtml.addTD("Total Merc. Gravados");
            gHtml.addTD("Total Merc. Exentos");
            gHtml.addTD("Total Gravado");
            gHtml.addTD("Total Exento");

            gHtml.addTD("Total Venta");
            gHtml.addTD("Total Descuentos");
            gHtml.addTD("Total Venta Neta");
            gHtml.addTD("Total Impuesto");
            gHtml.addTD("Total Comprobante");
            gHtml.addTD("Clave Ref");
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
//                if (last_gastos_detail_product_sym_tax_code!= r["gastos_detail_product_sym_tax_code"].ToString() || last_gastos_detail_product_sym_tax_code_iva != r["sym_tax_code_iva"].ToString()) {
  /*                  gHtml.countTD = 7;
                    gHtml.addTRTD("<HR>");
                    gHtml.addTR();
                    gHtml.addTD("Código de Impuesto ("+ r["gastos_detail_product_sym_tax_code"].ToString() + ") "+ r["tax_code_descripcion"].ToString());
                    gHtml.addTD("Código de Tarifa (" + r["sym_tax_code_iva"].ToString() + ") "+ r["tax_code_iva_descripcion"].ToString());
                    last_gastos_detail_product_sym_tax_code = r["gastos_detail_product_sym_tax_code"].ToString();
                    last_gastos_detail_product_sym_tax_code_iva = r["sym_tax_code_iva"].ToString();
                    gHtml.addTR();
                    */
                    gHtml.addTD(r["invoice_currency_fix"].ToString());

                gHtml.addTD(r["tax_code_descripcion"].ToString());
                gHtml.addTD(r["gastos_detail_product_sym_tax_code"].ToString());

                gHtml.addTD(r["tax_code_iva_descripcion"].ToString());                
                gHtml.addTD(r["sym_tax_code_iva"].ToString());

                gHtml.addTD(r["gastos_detail_product_sym_tax"].ToString());
                //gHtml.addTD(r["gastos_detail_product_price"].ToString());
                gHtml.addTD(r["gastos_detail_MontoTotal"].ToString());
                    gHtml.addTD(r["gastos_detail_MontoDescuento"].ToString());
                    gHtml.addTD(r["gastos_detail_SubTotal"].ToString());
                    gHtml.addTD(r["gastos_detail_impuesto_Monto"].ToString());
                    gHtml.addTD(r["gastos_detail_MontoTotalLinea"].ToString());

                    gHtml.addTD(r["invoice_TotalServGravados"].ToString());
                    gHtml.addTD(r["invoice_TotalServExentos"].ToString());
                    gHtml.addTD(r["invoice_TotalMercanciasGravadas"].ToString());
                    gHtml.addTD(r["invoice_TotalMercanciasExentas"].ToString());
                    gHtml.addTD(r["invoice_TotalGravado"].ToString());
                    gHtml.addTD(r["invoice_TotalExento"].ToString());
                    gHtml.addTD(r["invoice_TotalVenta"].ToString());
                    gHtml.addTD(r["invoice_TotalDescuentos"].ToString());
                    gHtml.addTD(r["invoice_TotalVentaNeta"].ToString());
                    gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                    gHtml.addTD(r["invoice_TotalComprobante"].ToString());

                    gHtml.addTDStyle (r["invoice_ref_Numero"].ToString(), "excel");


                gHtml.addTR();
                    
                    







//                }
                

            }
            gHtml.crear("Reporte puede contener lineas de Documento Electrónico duplicado debido a diferentes impuestos dentro del mismo comprobante");
            gHtml.crearTabla();

            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void frm_pos_invoice_report_Resize(object sender, EventArgs e)
        {
            invoice_wb1.Width = (this.Width - (48));
            invoice_wb1.Height = (this.Height - (invoice_wb1.Top + 48));
        }

        private void btn_invoice_gastos_proveedor_detalle_Click(object sender, EventArgs e)
        {
            //ToString("yyyy-MM-dd")
            DB.TemporalUpdateGastos();
            string specialSQL = "";
            string specialSQLTipoDoc = "";
            string specialInner = "";

            string sql_invoice_api_type = " ( if(isnull(invoice_hacienda_ind_estado),'',invoice_hacienda_ind_estado) != 'rechazado' )  and ";
            if (!first.auto_debug)
            {
                sql_invoice_api_type += "invoice_api_type =1 and ";
            }


            if (invoice_pos__r_medio_pago.Checked)
            {
                //specialSQL += ",if(invoice_medio_pago='01',invoice_TotalComprobante,0) as efectivo,if (invoice_medio_pago = '01',0,invoice_TotalComprobante) as tarjeta";
                specialSQL += ",invoice_medio_pago,invoice_medio_pago.medioPago";
                specialInner += " left join invoice_medio_pago on invoice_medio_pago.codigo=invoice_medio_pago ";
            }

            if (invoice_pos__r_condicion_venta.Checked)
            {
                //specialSQL += ",if(invoice_condicion_venta='01',invoice_TotalComprobante,0) as contado,if (invoice_condicion_venta = '01',0,invoice_TotalComprobante) as credito,invoice_plazo_credito";
                specialSQL += ",invoice_condicion_venta,invoice_condicion_venta.condicionVenta,invoice_plazo_credito";
                specialInner += " left join invoice_condicion_venta on invoice_condicion_venta.codigo=invoice_condicion_venta ";
            }

            string sql_report_invoices_mysql = "SELECT if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,SUBSTR(invoice.invoice_cd, 1, 10) as dia ,invoice_gasto_compra, invoice_TotalGravado,invoice_TotalExento,invoice_TotalDescuentos, ";
            sql_report_invoices_mysql += "invoice_TotalImpuesto, invoice_TotalComprobante,invoice_client_identification,invoice_client_name,invoice_ref_Numero,invoice_ref_FechaEmision_cd  " + specialSQL + " from ";
            sql_report_invoices_mysql += "(select * from invoice where invoice_ref_TipoDoc = '01' and(invoice_tipo_doc = '05' or invoice_tipo_doc = '06')  group by invoice_ref_Numero) as invoice ";
            sql_report_invoices_mysql +=  specialInner;
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' order by invoice_client_identification,invoice_ref_FechaEmision_cd ";

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Gastos-Compras Detallado del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));

            file_name = "Reporte Gastos-Compras Detallado del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");

            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");

            gHtml.addTD("Dia");

            gHtml.addTD("Identificación");
            gHtml.addTD("Nombre");

            gHtml.addTD("Moneda");
            gHtml.addTD("Gravado");
            gHtml.addTD("Exento");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (invoice_pos__r_gastosycompras.Checked)
            {
                gHtml.addTD("Gasto/Compra");
            }
            gHtml.addTD("Clave Ref");
            gHtml.addTD("Fecha Emision Ref");

            if (invoice_pos__r_medio_pago.Checked)
            {
                gHtml.addTD("MedioPago");                
            }
            if (invoice_pos__r_condicion_venta.Checked)
            {
                gHtml.addTD("Condicion de venta");
                gHtml.addTD("Plazo");
            }
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                gHtml.addTD(r["dia"].ToString());

                gHtml.addTD(r["invoice_client_identification"].ToString());
                gHtml.addTD(r["invoice_client_name"].ToString());

                gHtml.addTD(r["invoice_currency_fix"].ToString());
                gHtml.addTD(r["invoice_TotalGravado"].ToString());
                gHtml.addTD(r["invoice_TotalExento"].ToString());
                gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                gHtml.addTD(r["invoice_TotalComprobante"].ToString());

                

                if (invoice_pos__r_gastosycompras.Checked)
                {
                    gHtml.addTD(gasto_compra(r["invoice_gasto_compra"].ToString()));

                }

                gHtml.addTDStyle(r["invoice_ref_Numero"].ToString(), "excel");
                gHtml.addTDStyle(r["invoice_ref_FechaEmision_cd"].ToString(), "excel");
                



                if (invoice_pos__r_medio_pago.Checked)
                {
                    gHtml.addTD("(" + r["invoice_medio_pago"].ToString() + ")" + r["medioPago"].ToString());
                }
                if (invoice_pos__r_condicion_venta.Checked)
                {
                    gHtml.addTD("(" + r["invoice_condicion_venta"].ToString()+ ")" + r["condicionVenta"].ToString());
                    gHtml.addTD(r["invoice_plazo_credito"].ToString());
                }

                gHtml.addTR();
            }

            gHtml.crearTabla();



            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_invoice_ventas_clientes_detallado_Click(object sender, EventArgs e)
        {

            string specialSQL = "";
            string specialSQLTipoDoc = "";

            string last_gastos_detail_product_sym_tax_code = "-1";
            string last_gastos_detail_product_sym_tax_code_iva = "-1";

            //(invoice_hacienda_ind_estado= 'aceptado') and  
            string sql_invoice_api_type = "";

            if (!first.auto_debug)
            {
                sql_invoice_api_type = "invoice_api_type =1 and ";
            }
            /*
            string sql_report_invoices_mysql = "SELECT if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,gastos_detail.gastos_detail_product_sym_unit,products_tax_code.tax_code_descripcion,gastos_detail.gastos_detail_product_sym_tax_code,products_tax_code_iva.tax_code_iva_descripcion, ";
            sql_report_invoices_mysql  +="gastos_detail.gastos_detail_product_sym_tax_code_iva,gastos_detail.gastos_detail_product_sym_tax,sum(gastos_detail.gastos_detail_product_price) as gastos_detail_product_price,sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoToal, ";
            sql_report_invoices_mysql += "sum(gastos_detail.gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail.gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail.gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail.gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea ";
            sql_report_invoices_mysql += "from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql_report_invoices_mysql += "group by  invoice_currency_fix ,gastos_detail_product_sym_tax_code,gastos_detail_product_sym_tax_code_iva,gastos_detail_product_sym_tax order by gastos_detail_product_sym_tax_code, gastos_detail_product_sym_tax_code_iva";
            */

            /*string sql_report_invoices_mysql = "select count(*) as cuenta,if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,products_tax_code.tax_code_descripcion,gastos_detail.gastos_detail_product_sym_tax_code,products_tax_code_iva.tax_code_iva_descripcion, ";
            sql_report_invoices_mysql += "if (gastos_detail.gastos_detail_product_sym_tax_code_iva= '',if(gastos_detail.gastos_detail_product_sym_tax_code='01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,gastos_detail.gastos_detail_product_sym_tax, ";
            sql_report_invoices_mysql += "sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoTotal,sum(gastos_detail.gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail.gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail.gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail.gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea, ";
            sql_report_invoices_mysql += "invoice.invoice_client_commercial_name,invoice.invoice_client_identification,invoice.invoice_client_name,invoice.invoice_ref_Numero,invoice.invoice_cd,invoice.invoice_condicion_venta,invoice.invoice_ref_FechaEmision ";
            sql_report_invoices_mysql += "from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva  ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '05' or invoice_tipo_doc = '06'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql_report_invoices_mysql += "group by invoice_currency_fix,gastos_detail_product_sym_tax_code,sym_tax_code_iva,gastos_detail_product_sym_tax order by invoice_currency,gastos_detail_product_sym_tax_code, sym_tax_code_iva,gastos_detail_product_sym_tax,invoice.invoice_client_identification,invoice.invoice_ref_FechaEmision";
            */

            /*string sql_report_invoices_mysql = "select if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,products_tax_code.tax_code_descripcion,products_tax_code_iva.tax_code_iva_descripcion,gastos_detail.gastos_detail_product_sym_tax_code, ";
            sql_report_invoices_mysql += " if (gastos_detail.gastos_detail_product_sym_tax_code_iva = '',if (gastos_detail.gastos_detail_product_sym_tax_code = '01','08',''),gastos_detail.gastos_detail_product_sym_tax_code_iva) as sym_tax_code_iva ,gastos_detail.gastos_detail_product_sym_tax,sum(gastos_detail.gastos_detail_MontoTotal) as gastos_detail_MontoTotal, ";
            sql_report_invoices_mysql += " sum(gastos_detail_MontoDescuento) as gastos_detail_MontoDescuento,sum(gastos_detail_SubTotal) as gastos_detail_SubTotal,sum(gastos_detail_impuesto_Monto) as gastos_detail_impuesto_Monto,sum(gastos_detail_MontoTotalLinea) as gastos_detail_MontoTotalLinea, ";
            sql_report_invoices_mysql += " invoice_TotalServGravados,invoice_TotalServExentos,invoice_TotalMercanciasGravadas,invoice_TotalMercanciasExentas,invoice_TotalGravado,invoice_TotalExento,invoice_TotalVenta,invoice_TotalDescuentos,invoice_TotalVentaNeta,invoice_TotalImpuesto,invoice_TotalComprobante,invoice_ref_Numero ";
            sql_report_invoices_mysql += " from invoice inner join gastos_detail on gastos_detail.gastos_id = invoice.invoice_id  left join products_tax_code on products_tax_code.tax_code_codigo = gastos_detail.gastos_detail_product_sym_tax_code left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = gastos_detail.gastos_detail_product_sym_tax_code_iva ";
            sql_report_invoices_mysql += " where " + sql_invoice_api_type + " (invoice_tipo_doc = '01' or invoice_tipo_doc = '04'  " + specialSQLTipoDoc + ") and invoice_ref_FechaEmision_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + " 23:59:59' and gastos_detail.gastos_detail_MontoTotalLinea > 0 ";
            sql_report_invoices_mysql += " group by invoice_currency_fix ,invoice_ref_Numero,gastos_detail_product_sym_tax_code,sym_tax_code_iva,gastos_detail_product_sym_tax order by invoice_currency_fix, gastos_detail_product_sym_tax_code, sym_tax_code_iva, gastos_detail_product_sym_tax, invoice_ref_Numero  ";*/
            string sql_report_invoices_mysql_columns= "", sql_report_invoices_mysql_group = "";

            if (!chkAgrupado.Checked)
            {
                sql_report_invoices_mysql_columns = @",
invoice_TotalServGravados,invoice_TotalServExentos,
invoice_TotalMercanciasGravadas,invoice_TotalMercanciasExentas,
invoice_TotalGravado,invoice_TotalExento,invoice_TotalVenta,invoice_TotalDescuentos,invoice_TotalVentaNeta,invoice_TotalImpuesto,invoice_TotalComprobante,invoice_clave";
                sql_report_invoices_mysql_group = ",invoice_clave";
            }

                string sql_report_invoices_mysql = @"select
                if (invoice.invoice_currency = '','CRC',invoice.invoice_currency) as invoice_currency_fix,
                products_tax_code.tax_code_descripcion,
                products_tax_code_iva.tax_code_iva_descripcion,
                invoice_detail_product_sym_tax_code,
                invoice_detail_product_sym_tax_code_iva as sym_tax_code_iva,
                invoice_detail.invoice_detail_product_sym_tax,
                sum(invoice_detail.invoice_detail_MontoTotal) as detail_MontoTotal,
                sum(invoice_detail.invoice_detail_MontoDescuento) as detail_MontoDescuento,
                sum(invoice_detail.invoice_detail_SubTotal) as detail_SubTotal,
                sum(invoice_detail.invoice_detail_impuesto_Monto) as detail_impuesto_Monto,
                sum(invoice_detail.invoice_detail_MontoTotalLinea) as detail_MontoTotalLinea " + sql_report_invoices_mysql_columns + @"
                FROM
                invoice
                INNER JOIN invoice_detail using (invoice_id)
                left join products_tax_code on products_tax_code.tax_code_codigo = invoice_detail_product_sym_tax_code
                left join products_tax_code_iva on products_tax_code_iva.tax_code_iva_codigo = invoice_detail_product_sym_tax_code_iva
                where " + sql_invoice_api_type + @" (invoice_tipo_doc = '01' or invoice_tipo_doc = '04' " + specialSQLTipoDoc + @" ) and invoice_cd BETWEEN '" + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + @" 00:00:00' " + @"and '" + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd") + @" 23:59:59' 
                and invoice_detail.invoice_detail_MontoTotalLinea > 0 
                group by invoice_currency_fix, invoice_detail_product_sym_tax_code, invoice_detail_product_sym_tax_code_iva, invoice_detail_product_sym_tax " + sql_report_invoices_mysql_group + @"
                order by invoice_currency_fix, invoice_detail_product_sym_tax_code, invoice_detail_product_sym_tax_code_iva, invoice_detail_product_sym_tax " + sql_report_invoices_mysql_group;

            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Ventas por Tipo de Impuesto del  ");
            gHtml.crear(invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd"));
            file_name = "Reporte Ventas por Tipo de Impuesto del  " + invoice_pos__r_dt1.Value.ToString("yyyy-MM-dd") + " al " + invoice_pos__r_dt2.Value.ToString("yyyy-MM-dd");
            Console.Write(sql_report_invoices_mysql.ToString());
            DataTable tDt = DB.q(sql_report_invoices_mysql, "", "");


            gHtml.addTD("Moneda");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("CodigoTarifa");
            gHtml.addTD("CodigoTarifa");
            gHtml.addTD("Tarifa IVA %");
            //gHtml.addTD("PrecioUnitarios");
            gHtml.addTD("MontoTotal");
            gHtml.addTD("MontoDescuento");
            gHtml.addTD("SubTotal");
            gHtml.addTD("Impuesto");
            gHtml.addTD("Total");
            if (!chkAgrupado.Checked)
            {
                gHtml.addTD("Total Serv. Gravados");
                gHtml.addTD("Total Serv. Exentos");

                gHtml.addTD("Total Merc. Gravados");
                gHtml.addTD("Total Merc. Exentos");
                gHtml.addTD("Total Gravado");
                gHtml.addTD("Total Exento");

                gHtml.addTD("Total Venta");
                gHtml.addTD("Total Descuentos");
                gHtml.addTD("Total Venta Neta");
                gHtml.addTD("Total Impuesto");
                gHtml.addTD("Total Comprobante");
                gHtml.addTD("Clave Ref");
            }
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                //                if (last_gastos_detail_product_sym_tax_code!= r["gastos_detail_product_sym_tax_code"].ToString() || last_gastos_detail_product_sym_tax_code_iva != r["sym_tax_code_iva"].ToString()) {
                /*                  gHtml.countTD = 7;
                                  gHtml.addTRTD("<HR>");
                                  gHtml.addTR();
                                  gHtml.addTD("Código de Impuesto ("+ r["gastos_detail_product_sym_tax_code"].ToString() + ") "+ r["tax_code_descripcion"].ToString());
                                  gHtml.addTD("Código de Tarifa (" + r["sym_tax_code_iva"].ToString() + ") "+ r["tax_code_iva_descripcion"].ToString());
                                  last_gastos_detail_product_sym_tax_code = r["gastos_detail_product_sym_tax_code"].ToString();
                                  last_gastos_detail_product_sym_tax_code_iva = r["sym_tax_code_iva"].ToString();
                                  gHtml.addTR();
                                  */
                gHtml.addTD(r["invoice_currency_fix"].ToString());

                gHtml.addTD(r["tax_code_descripcion"].ToString());
                gHtml.addTD(r["invoice_detail_product_sym_tax_code"].ToString());

                gHtml.addTD(r["tax_code_iva_descripcion"].ToString());
                gHtml.addTD(r["sym_tax_code_iva"].ToString());

                gHtml.addTD(r["invoice_detail_product_sym_tax"].ToString());
                //gHtml.addTD(r["gastos_detail_product_price"].ToString());
                gHtml.addTD(r["detail_MontoTotal"].ToString());
                gHtml.addTD(r["detail_MontoDescuento"].ToString());
                gHtml.addTD(r["detail_SubTotal"].ToString());
                gHtml.addTD(r["detail_impuesto_Monto"].ToString());
                gHtml.addTD(r["detail_MontoTotalLinea"].ToString());

                if (!chkAgrupado.Checked) {

                    gHtml.addTD(r["invoice_TotalServGravados"].ToString());
                    gHtml.addTD(r["invoice_TotalServExentos"].ToString());
                    gHtml.addTD(r["invoice_TotalMercanciasGravadas"].ToString());
                    gHtml.addTD(r["invoice_TotalMercanciasExentas"].ToString());
                    gHtml.addTD(r["invoice_TotalGravado"].ToString());
                    gHtml.addTD(r["invoice_TotalExento"].ToString());
                    gHtml.addTD(r["invoice_TotalVenta"].ToString());
                    gHtml.addTD(r["invoice_TotalDescuentos"].ToString());
                    gHtml.addTD(r["invoice_TotalVentaNeta"].ToString());
                    gHtml.addTD(r["invoice_TotalImpuesto"].ToString());
                    gHtml.addTD(r["invoice_TotalComprobante"].ToString());

                    gHtml.addTDStyle(r["invoice_clave"].ToString(), "excel");
                }
                


                gHtml.addTR();









                //                }


            }
            gHtml.crear("Reporte puede contener lineas de Documento Electrónico duplicado debido a diferentes impuestos dentro del mismo comprobante");
            gHtml.crearTabla();

            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;
        }

        private void btn_reporte_inventario_Click(object sender, EventArgs e)
        {
            string sql_report_inventario_combo_mysql = "";
            string sql_report_inventario_mysql = @"
SELECT
product_id,
if(active=1,'Activo','Inactivo') as estado,
CASE
    WHEN product_inventory_type = 0 THEN 'SERVICIOS'
    WHEN product_inventory_type = 1 THEN 'PRODUCTO'
    WHEN product_inventory_type = 2 THEN 'COMBO'
    ELSE 'DESCONOCIDO'
END as tipo_inventario,
product_inventory_type,
product_sym_stock,
product_sym_barcode,
product_sym_description,
product_sym_tax_code,
(select tax_code_descripcion from products_tax_code where products_tax_code.tax_code_codigo = products.product_sym_tax_code) as product_sym_tax_code_descripcion,
product_sym_tax_code_iva,
(select tax_code_iva_descripcion from products_tax_code_iva where products_tax_code_iva.tax_code_iva_codigo = products.product_sym_tax_code_iva) as product_sym_tax_code_iva_descripcion,
product_sym_tax,
product_currency,
product_price,
round(product_price * (1 + (product_sym_tax / 100)), 2) as product_price_iva,
product_codigo_cabys
FROM
products
order by active, product_inventory_type, product_sym_tax_code
";
            invoice_generate_html gHtml = new invoice_generate_html();
            gHtml.crear("Reporte Inventario al " + DateTime.Now.ToString("yyyy-M-d"));            
            file_name = "Reporte Inventario al "+ DateTime.Now.ToString("yyyy-M-d");
            Console.Write(sql_report_inventario_mysql.ToString());
            DataTable tDt = DB.q(sql_report_inventario_mysql, "", "");

            gHtml.addTD("Id");
            gHtml.addTD("Estado");
            gHtml.addTD("Tipo");
            gHtml.addTD("QTY");
            gHtml.addTD("Codigo de Barras");
            gHtml.addTD("Descripcion");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("Codigo Impuesto");
            gHtml.addTD("Codigo IVA");
            gHtml.addTD("Codigo IVA");
            gHtml.addTD("IVA");
            gHtml.addTD("Moneda");
            gHtml.addTD("Precio Unitario");
            gHtml.addTD("Precio IVA");
            gHtml.addTD("CABYS");
            gHtml.addTD("Descuento");
            gHtml.addTR();
            foreach (DataRow r in tDt.Rows)
            {
                if (r["product_inventory_type"].ToString() == "2")
                {
                    gHtml.add2("<HR>", "<HR>");
                }
                gHtml.addTD(r["product_id"].ToString());
                gHtml.addTD(r["estado"].ToString());
                gHtml.addTD(r["tipo_inventario"].ToString());
                gHtml.addTD(r["product_sym_stock"].ToString()); 
                gHtml.addTD(r["product_sym_barcode"].ToString());
                gHtml.addTD(r["product_sym_description"].ToString());
                gHtml.addTD(r["product_sym_tax_code"].ToString());
                gHtml.addTD(r["product_sym_tax_code_descripcion"].ToString());
                gHtml.addTD(r["product_sym_tax_code_iva"].ToString());
                gHtml.addTD(r["product_sym_tax_code_iva_descripcion"].ToString());
                gHtml.addTD(r["product_sym_tax"].ToString());
                gHtml.addTD(r["product_currency"].ToString());
                gHtml.addTD(r["product_price"].ToString());
                gHtml.addTD(r["product_price_iva"].ToString());
                gHtml.addTD(r["product_codigo_cabys"].ToString());

                //gHtml.addTD(r["product_codigo_cabys"].ToString()); //Monto Descuento Global

                gHtml.addTR();
                if (r["product_inventory_type"].ToString()=="2") {
                    sql_report_inventario_combo_mysql = @"SELECT
product_combo.product_id,
product_combo.product_sym_barcode_combo,
product_combo.product_combo_qty,
product_combo.product_combo_desc_porcentaje,
product_combo.product_combo_desc_monto,
products.product_sym_description
FROM
product_combo
INNER JOIN products ON product_combo.product_sym_barcode_combo = products.product_sym_barcode
where product_sym_barcode_parent = '"+ r["product_sym_barcode"].ToString() + "'";


                    DataTable tDtCombo = DB.q(sql_report_inventario_combo_mysql, "", "");

                    foreach (DataRow rc in tDtCombo.Rows)
                    {

                        gHtml.addTD(rc["product_id"].ToString());
                        gHtml.addTD("");
                        gHtml.addTD("Detalle Combo");
                        gHtml.addTD(rc["product_combo_qty"].ToString());
                        gHtml.addTD(rc["product_sym_barcode_combo"].ToString());
                        gHtml.addTD(rc["product_sym_description"].ToString());
                        gHtml.addTR();
                    }
                }
            }
            gHtml.crearTabla();

            invoice_wb1.Navigate("about:blank");
            if (invoice_wb1.Document != null)
            {
                invoice_wb1.Document.Write(string.Empty);
            }


            invoice_wb1.DocumentText = gHtml.GetHTML();
            btn_excel.Enabled = true;
            btn_print.Enabled = true;

        }
    }
}
