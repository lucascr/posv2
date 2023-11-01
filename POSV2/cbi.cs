using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cbi{ //ComboBoxItems
    string displayValue;
    string hiddenValue;

    //Constructor
    public cbi(string d, string h){
        displayValue = d;
        hiddenValue = h;
    }

    //Accessor
    public string HiddenValue{
        get{
            return hiddenValue;
        }
    }

    //Override ToString method
    public override string ToString(){
        return displayValue;
    }
}
