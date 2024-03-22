using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SLIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPDF : ContentPage
    {
        public ResultsPDF(string plink,string pname)
        { 
            InitializeComponent();
            myPDF.Uri = plink; 
            patname.Text = pname;
        }
    }
}