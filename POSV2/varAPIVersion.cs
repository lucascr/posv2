using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SYMVersion
{
    public string query { get; set; }
    public string id_version { get; set; }    

}
public class RespuestaSYMVERSION<TModel> where TModel : class
{
    [JsonProperty("cuenta")]
    public string Cuenta { get; set; }
    
    [JsonProperty("symsql")]
    public IList<TModel> symsql { get; set; }
    
}

