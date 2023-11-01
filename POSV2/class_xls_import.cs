using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSV2
{
    class class_xls_import
    {
        public static string sheet_name { get; set; }
        public static List<xls_import> xls_list { get; set; }
        public class xls_import_col
        {
            public int id_cabys { get; set; }
            public int id_sku { get; set; }
            public int id_codigobarras { get; set; }
            public int id_sku_nombre { get; set; }
            
        }
        public class xls_import
        {
            public int id_columna { get; set; }
            public string titulo_col { get; set; }
            public string titulo_col_num { get; set; }
        }
    }

    class class_xls_import_asada
    {
        public static string sheet_name { get; set; }
        public static List<xls_import> xls_list { get; set; }
        
        public class xls_import_col
        {
            public cba sel_cmb;

            public int id_cedula { get; set; }
            public int id_nombre { get; set; }
            public int id_apellido { get; set; }
            public int id_telefono { get; set; }

            public int id_num_medidor { get; set; }
            public int id_primera_lectura { get; set; }
            public string id_asada_tipo { get; set; }
            

        }
        public class xls_import
        {            
            public int id_columna { get; set; }
            public string titulo_col { get; set; }
            public string titulo_col_num { get; set; }
        }
    }

    class class_xls_import_asada_lectura
    {
        public static string sheet_name { get; set; }
        public static List<xls_import> xls_list { get; set; }

        public class xls_import_col
        {
            public cba sel_cmb;

            public int id_nombre { get; set; }
            public int id_apellido { get; set; }

            public string id_periodo { get; set; }

            public int id_num_medidor { get; set; }
            public int id_lectura_periodo { get; set; }


        }
        public class xls_import
        {
            public int id_columna { get; set; }
            public string titulo_col { get; set; }
            public string titulo_col_num { get; set; }
        }
    }
}
