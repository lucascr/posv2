using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cbc{ //ComboBoxItems
    string nombreCanton;
    string search_id_canton;
    string save_id_canton;

    //Constructor
    public cbc(string c_name, string c_search,string c_save)
    {
        nombreCanton = c_name;
        search_id_canton = c_search;
        save_id_canton = c_save;
    }

    //Accessor
    public string hv_search{
        get{
            return search_id_canton;
        }
    }

    public string hv_save
    {
        get
        {
            return save_id_canton;
        }
    }

    //Override ToString method
    public override string ToString(){
        return nombreCanton;
    }
}
