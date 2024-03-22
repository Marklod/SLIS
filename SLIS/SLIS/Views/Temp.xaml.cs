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
    public partial class Temp : ContentPage
    {
        public Temp()
        {
            InitializeComponent();
        }

        private void signin_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = true;
        }

        private void rgstr_Clicked(object sender, EventArgs e)
        {
            overlay.IsVisible = true;
        }

        private void cncll_Clicked(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
        }

        private void cncll1_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = false;
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = false;
        }
    }
}