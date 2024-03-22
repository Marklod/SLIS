using Newtonsoft.Json;
using SLIS.Views.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using static SLIS.Class.SearchClass;
using Application = Xamarin.Forms.Application;

namespace SLIS.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenu : Xamarin.Forms.TabbedPage
    {
        public TabbedMenu()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        private void menu_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["token"] = null;
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

         private void search_Clicked(object sender, EventArgs e)
        {
            string searchk;
            searchk = "PatientName";
            Application.Current.MainPage = new NavigationPage(new DoctorResults());
        }
    }
}