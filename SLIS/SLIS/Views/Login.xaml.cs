using SLIS.Views.Patient;
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
    public partial class Login : ContentPage
    {
        public Login(string type, string title)
        {
            InitializeComponent();
            App.Current.Properties["type"] = type;
            txtLoginAs.Text = title;
        }
         
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties["type"].ToString() == "DOCTOR")
            {
                Application.Current.MainPage = new NavigationPage(new FlyoutPage1());
            }
            if (Application.Current.Properties["type"].ToString() == "PATIENT")
            {
                Application.Current.MainPage = new NavigationPage(new TabbedPage1());
            }
            if (Application.Current.Properties["type"].ToString() == "EMPLOYEE")
            {
                Application.Current.MainPage = new NavigationPage(new FlyoutPage1());
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}