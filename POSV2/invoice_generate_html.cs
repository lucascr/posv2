using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace POSV2
{
    class invoice_generate_html
    {
        public List<string> rHtml = new List<string>();
        public List<string> rTxt = new List<string>();
        public List<string> rHtml_tabla_row = new List<string>();

        
        public List<string> rHtml_tabla_row_sub_td = new List<string>();

        public int countTD = 1;

        public void crear(string title) {
            this.rHtml.Add("<!DOCTYPE html><head>");
            this.rHtml.Add(" <style> table { border-collapse: collapse; width:100%; } th, td {text-align:left; padding:8px;} ");
            this.rHtml.Add(" tr:nth-child(even) { background-color:#f2f2f2 }  TD.excel { mso-number-format:\\@; } </style> ");
            this.rHtml.Add("<meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1'>");
          //  this.rHtml.Add("<link rel = 'stylesheet' href = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css'>");
        //this.rHtml.Add("<script src = 'https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js'></script>");
      //this.rHtml.Add("<script src = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js'></script>");

                     this.rHtml.Add("</head><body><center><h1>" + title + "</h1></center>");
            this.rTxt.Add( title);

        }
        public void add2(string title,string value)
        {
            countTD = 2;
            rHtml_tabla_row.Add("<tr><td>"+ title + "</td><td>"+ value + "</td></tr>");
            this.rTxt.Add(title + " : " + value);
        }

        public void addTRTD(string value)
        {
            rHtml_tabla_row.Add("<tr><td colspan=' " + countTD + "'>" + value + "</td></tr>");            

            this.rTxt.Add(value);
        }
        public void addTR()
        {
            rHtml_tabla_row.Add("<tr>"+ string.Join("", rHtml_tabla_row_sub_td.ToArray()) + "</tr>");
            countTD = 0;
            rHtml_tabla_row_sub_td.Clear();
        }
        public void addTD(string value)
        {
            rHtml_tabla_row_sub_td.Add("<td>" + value + "</td>");
            countTD++;
            this.rTxt.Add(value);
        }
        public void addTDStyle(string value, string style)
        {
            rHtml_tabla_row_sub_td.Add("<td class=\""+ style + "\">" + value + "</td>");
            countTD++;
            this.rTxt.Add(value);
        }
        public void crearTabla()
        {
            rHtml.Add("<table class='table table-striped'><tbody>");
            rHtml.Add(string.Join("", rHtml_tabla_row.ToArray()));
            rHtml.Add("</tbody></table>");
        }

        public string GetHTML() {
            return string.Join("", rHtml.ToArray())+ "</body></html>";

        }
    }
}
