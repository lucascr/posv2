using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cba //ASADA
{ //ComboBoxItems 
    string nombreTarifa;
    string tipoTarifaDOMEMP;
    string tipoTarifaFIJACON;
    string montoTarifa;
    string idTarifa;
    //Constructor
    public cba(string nombre_tarifa, string tipo_tarifa_FIJACONSUMO,string tipo_tarifa_DOMEMP, string monto_tarifa,string id_tarifa)
    {
        nombreTarifa= nombre_tarifa;
        tipoTarifaFIJACON = tipo_tarifa_FIJACONSUMO;
        tipoTarifaDOMEMP = tipo_tarifa_DOMEMP;       
        
        montoTarifa = monto_tarifa;
        idTarifa = id_tarifa;
    }

    //Accessor
    public string hv_monto_tarifa
    {
        get
        {
            return montoTarifa;
        }
    }
    public string hv_tipo_tarifaFIJACON
    {
        get
        {
            return tipoTarifaFIJACON;
        }
    }
    public string hv_tipo_tarifaDOMEMP
    {
        get
        {
            return tipoTarifaDOMEMP;
        }
    }
    public string hv_idTarifa
    {
        get
        {
            return idTarifa;
        }
    }

    //Override ToString method
    public override string ToString()
    {
        return nombreTarifa;
    }
}
