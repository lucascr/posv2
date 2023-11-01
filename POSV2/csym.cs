using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class csym
{ //ComboBoxItems
    string sym;
    string sym_tipo;
    string sym_code_type;
    string sym_unit;
    string sym_tax_code;
    string sym_tax_code_iva;
    string sym_tax_monto;
    string sym_inventory_type;

    //Constructor
    public csym(string t, string s,  string c_sym_code_type, string u, string tc_sym_tax_code, string tc_sym_tax_code_iva, string tm,string i_sym_inventory_type)
    {
        sym = s; //product_sym
        sym_tipo = t; //products_sym_tipo

        sym_code_type = c_sym_code_type; //product_sym_code_type
        sym_unit = u; //products_sym_unit_simbolo

        sym_tax_code= tc_sym_tax_code; //product_sym_tax_code
        sym_tax_code_iva = tc_sym_tax_code_iva; //product_sym_tax_code_iva
        sym_tax_monto = tm; //product_sym_tax

        sym_inventory_type = i_sym_inventory_type; //product_inventory_type
    }

    //Accessor

    public string h_sym
    {
        get
        {
            return sym;
        }
    }
    public string h_sym_code_type
    {
        get
        {
            return sym_code_type;
        }
    }
    public string h_sym_unit
    {
        get
        {
            return sym_unit;
        }
    }

    public string h_sym_tax_code
    {
        get
        {
            return sym_tax_code;
        }
    }
    public string h_sym_tax_code_iva
    {
        get
        {
            return sym_tax_code_iva;
        }
    }
    public string h_sym_tax_monto
    {
        get
        {
            return sym_tax_monto;
        }
    }

    public string h_sym_inventory_type
    {
        get
        {
            return sym_inventory_type;
        }
    }
    
    //Override ToString method
    public override string ToString()
    {
        return sym_tipo;
    }
}
