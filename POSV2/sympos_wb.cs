using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSV2
{
    public partial class sympos_wb : Form
    {
        public sympos_wb()
        {
            InitializeComponent();
        }
        public sympos_wb(string url)
        {
            Console.Write(url);
            InitializeComponent();
            webBrowser1.Navigate(url);
            this.Show();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //webBrowser1.Print();
            //webBrowser1.ShowPrintDialog();
            //webBrowser1.ShowPrintPreviewDialog();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }
    }
}
