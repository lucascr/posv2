using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace POSV2
{
    class SYMPOS_asadas
    {
        public void getPendientesFacturar() {
            /*select client_id,asada_medidor,lectura_menor,lectura_mayor,lectura_mayor-lectura_menor as diferencia ,datediff(ultima_lectura,now())
from (
select 
client_id,asada_medidor,
max(if(asada_lectura_facturada=1,asada_lectura_valor,0)) as lectura_menor,
max(if(asada_lectura_facturada=0,asada_lectura_valor,0)) as lectura_mayor,
max(asada_lectura_facturada_fecha) as ultima_lectura
from 
asadas_lecturas  
group by client_id,asada_medidor ) as base

*/

        }

        public string getConsumo(string id_tipo_tarifa, string consumo="0") {
            first.cld(DateTime.Now.ToString("h:mm:ss tt") + "A: SYMPOS_asadas.getConsumo");
            int tarifaBase = 0;
            string tipo_consumo_fija = "";
            string result = "";

            //GetTipoTarifa
            string select_tipo_tarifa = "select * from asada_tipo_tarifa where id_asada_tipo_tarifa=" + id_tipo_tarifa;

            DataTable tDtsel_Tipo_tarifa = DB.q(select_tipo_tarifa, "", "");
            int cuenta_tarifas = 0;
            foreach (DataRow r in tDtsel_Tipo_tarifa.Rows)
            {
                cuenta_tarifas++;
                tipo_consumo_fija = r["asada_consumo_fija_id"].ToString();
                if (Int32.Parse(r["asada_monto_fija"].ToString()) > 0) {
                    tarifaBase = Int32.Parse(r["asada_monto_fija"].ToString());

                }
            }


            //If Consumo

            //GetConsumo
            if (cuenta_tarifas == 1){
                if (tipo_consumo_fija == "2"){ //Tarifa Consumo
                    
                    string select_consumo= "select * from  asada_consumo where id_asada_tipo_tarifa=" + id_tipo_tarifa + " order by consumo_max asc";
                    DataTable tDtsel_consumo= DB.q(select_consumo, "", "");
                    int Total_Consumo_sumado= 0;
                    int Total_consumo = Int32.Parse(consumo);
                    int Sumo_consumo = 0;
                    foreach (DataRow r in tDtsel_consumo.Rows)
                    {
                        if (Total_Consumo_sumado != Total_consumo){
                            if (Total_consumo > Int32.Parse(r["consumo_max"].ToString())){

                                Sumo_consumo += (   Int32.Parse(r["consumo_max"].ToString()) - Total_Consumo_sumado) * Int32.Parse(r["monto"].ToString());                                
                                Total_Consumo_sumado = Int32.Parse(r["consumo_max"].ToString());
                            }
                            else{
                                Sumo_consumo += (Total_consumo - Total_Consumo_sumado) * Int32.Parse(r["monto"].ToString());
                                Total_Consumo_sumado = Total_consumo;
                            }

                        }else {
                            break;
                        }
                            /*
                            if (Total_consumo > 0)
                            {
                                if (Total_consumo > Int32.Parse(r["consumo_max"].ToString()))
                                {
                                    Sumo_consumo += Int32.Parse(r["consumo_max"].ToString()) * Int32.Parse(r["monto"].ToString());
                                    Total_consumo = Total_consumo - Int32.Parse(r["consumo_max"].ToString());
                                } else {
                                    Sumo_consumo += Total_consumo * Int32.Parse(r["monto"].ToString());
                                    Total_consumo = 0;
                                }
                            }else {
                                break;
                            }*/
        }
        result = (tarifaBase + Sumo_consumo).ToString();

                }
                else {
                    result = tarifaBase.ToString(); //Tarifa Fija
                }
            }else {
                MessageBox.Show("ASADAS - Ocurrio un error con los tipos de tarifas ");
            }

            return result;
        }

    }
}
