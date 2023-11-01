using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VarCompany
{
    //Constructor
    public VarCompany(){}
    public string id_company { get; set; }
    public string company_type { get; set; }
    public string company_identification { get; set; }
    public string company_name { get; set; }

    public string company_email { get; set; }
    public string company_phone { get; set; }
    
    public string company_addr_province { get; set; }
    public string company_addr_canton { get; set; }
    public string company_addr_district { get; set; }

    public string cloud_api_token { get; set; }
    public string cloud_api_type { get; set; }
    public string cloud_api_prod { get; set; }
    public string cloud_api_test { get; set; }
    public string cloud_sync { get; set; }

    public string company_inventario { get; set; }

    public string company_actividad_economica { get; set; }

}

/*
  public class VarCompany
{ 
    string id_company;
    string company_type;
    string company_identification;
    string company_name;
    string cloud_api_token;
    string cloud_api_type;
    string cloud_api_prod;
    string cloud_api_test;
    string cloud_sync;

    //Constructor
    public VarCompany(string id, string type, string identification,
        string name
        ,string cloud_api_token
        , string cloud_api_type
        , string cloud_api_prod
        , string cloud_api_test
        , string cloud_sync
        )
    {
        id_company = id;
        company_type = type;
        company_identification = identification;
        company_name = name;
        cloud_api_token = cloud_api_token;
        cloud_api_type
        cloud_api_prod
        cloud_api_test
        cloud_sync
    }

    public string h_id_company
    {
        get
        {
            return id_company;
        }
    }
    public string h_company_type
    {
        get
        {
            return company_type;
        }
    }
    public string h_company_identification
    {
        get
        {
            return company_identification;
        }
    }
    public string h_company_name
    {
        get
        {
            return company_name;
        }
    }

    //Override ToString method
    public override string ToString()
    {
        return company_name;
    }
}

*/
