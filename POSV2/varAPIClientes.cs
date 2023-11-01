using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Clientes
{
    public string cedula { get; set; }
    public string clasificacion { get; set; }
    public string nombre { get; set; }

}
public class Respuesta<TModel> where TModel : class
{
    [JsonProperty("cuenta")]
    public string Cuenta { get; set; }

    [JsonProperty("error")]
    public string Error { get; set; }
    

    [JsonProperty("resultados")]
    public IList<TModel> Resultados { get; set; }

    //[JsonProperty("type")]
    //public string Type { get; set; }

    //[JsonProperty("pagination")]
    //public Pagination Pagination { get; set; }
}

public class Pagination
{
    [JsonProperty("effective_limit")]
    public int? EffectiveLimit { get; set; }

    [JsonProperty("effective_offset")]
    public int? EffectiveOffset { get; set; }

    [JsonProperty("effective_page")]
    public int? EffectivePage { get; set; }

    [JsonProperty("next_offset")]
    public int? NextOffset { get; set; }

    [JsonProperty("next_page")]
    public int? NextPage { get; set; }
}
/*
public class VarAPIClientesRootObject
{
    public string cedula { get; set; }
    public string clasificacion { get; set; }
    public string nombre { get; set; }
}

public class RootObject
{
    public VarAPIClientesRootObject varAPIClientes_RootObject { get; set; }
}
*/
/*
public class varAPIClientes
{
    public string cedula { get; set; }
    public string clasificacion { get; set; }
    public string nombre { get; set; }
 
}
public class varAPIClientes_RootObject
{
    public List<varAPIClientes> data { get; set; }
}
    */
/*
public class Category
{

[JsonProperty("category_id")]
public int CategoryId { get; set; }

[JsonProperty("name")]
public string Name { get; set; }

[JsonProperty("meta_title")]
public string MetaTitle { get; set; }

[JsonProperty("meta_keywords")]
public string MetaKeywords { get; set; }

[JsonProperty("meta_description")]
public string MetaDescription { get; set; }

[JsonProperty("page_description")]
public string PageDescription { get; set; }

[JsonProperty("page_title")]
public string PageTitle { get; set; }

[JsonProperty("category_name")]
public string CategoryName { get; set; }

[JsonProperty("short_name")]
public string ShortName { get; set; }

[JsonProperty("long_name")]
public string LongName { get; set; }

[JsonProperty("num_children")]
public int NumChildren { get; set; }
}
public class Pagination
{
[JsonProperty("effective_limit")]
public int? EffectiveLimit { get; set; }

[JsonProperty("effective_offset")]
public int? EffectiveOffset { get; set; }

[JsonProperty("effective_page")]
public int? EffectivePage { get; set; }

[JsonProperty("next_offset")]
public int? NextOffset { get; set; }

[JsonProperty("next_page")]
public int? NextPage { get; set; }
}

public class Params
{
[JsonProperty("tag")]
public string Tag { get; set; }
}

public class Response<TModel> where TModel : class
{
[JsonProperty("count")]
public int Count { get; set; }

[JsonProperty("results")]
public IList<TModel> Results { get; set; }

[JsonProperty("params")]
public Params Params { get; set; }

[JsonProperty("type")]
public string Type { get; set; }

[JsonProperty("pagination")]
public Pagination Pagination { get; set; }
}
*/
