using SLIS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SLIS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
         
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        } 
        private void btnEmployee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Login("EMPLOYEE", "EMPLOYEE LOGIN")));
        }

        private void btnPatient_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Login("PATIENT", "PATIENT LOGIN")));
        }

        //private async void btnDoctor_Clicked(object sender, EventArgs e)
        private void btnDoctor_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage.Navigation.PopAsync();
            Navigation.PushAsync(new NavigationPage(new Login("DOCTOR", "DOCTOR'S LOGIN")));
           
            //Navigation.PushAsync(new Login("DOCTOR", "DOCTOR'S LOGIN"));
            //Application.Current.MainPage = new NavigationPage(new Login("DOCTOR", "DOCTOR'S LOGIN"));
            // await Application.Current.MainPage.Navigation.PushAsync(new Login("DOCTOR", "DOCTOR'S LOGIN"));
        }
    }
}
