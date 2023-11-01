using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SYMLicense
{
    public string fecha_pago { get; set; }
    public string dias_pendientes { get; set; }
    public string estado { get; set; }
    

}
public class RespuestaSYMLICENSE<TModel> where TModel : class
{
    [JsonProperty("fecha_pago")]
    public string fecha_pago { get; set; }

    [JsonProperty("dias_pendientes_pago")]
    public string dias_pendientes { get; set; }

    [JsonProperty("estado")]
    public string estado { get; set; }

    

}

