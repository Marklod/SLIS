using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLIS.Class;
using SLIS.Views.Employee;
using SLIS.Views.Patient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
            activityindicator.IsVisible = false;
        }
         
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new FlyoutPage1());
            string url = Application.Current.Properties["host"].ToString() + "api/Main/" + App.Current.Properties["type"].ToString();
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                await DisplayAlert("Invalid Data !!", "Please enter username", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Invalid Data !!", "Please enter pasword", "OK");
                return;
            }
            activityindicator.IsVisible = true;
            if (Application.Current.Properties["type"].ToString() == "Clinic_Doctor")
            { 
                SlisUser useer = new SlisUser(txtUsername.Text, txtPassword.Text);
                //SlisUser useer = new SlisUser("oasis","abcdefg");
                string strialialize = JsonConvert.SerializeObject(useer); 
                var stringContent = new StringContent(strialialize);
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    Response respo;
                    respo = (Response)JsonConvert.DeserializeObject(results, (typeof(Response)));
                    if (respo.Status == "Failed")
                    {
                        activityindicator.IsVisible = false;
                        await DisplayAlert("Failed to Login", respo.Token, "OK");
                        return;
                    }
                    else
                    {
                        App.Current.Properties["token"] = respo.Token;
                        App.Current.Properties["id"] = respo.Id;
                        App.Current.Properties["username"] = respo.Username;
                        App.Current.Properties["name"] = respo.Name;
                        App.Current.Properties["usertype"] = respo.UserType;
                        Application.Current.MainPage = new NavigationPage(new TabbedMenu()); 
                    }
                }
            }
            if (Application.Current.Properties["type"].ToString() == "Patient")
            {
                //SlisUser useer = new SlisUser("sailas", "Vincema1");
                SlisUser useer = new SlisUser(txtUsername.Text , txtPassword.Text);
                string strialialize = JsonConvert.SerializeObject(useer); 
                var stringContent = new StringContent(strialialize);
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    Response respo;
                    respo = (Response)JsonConvert.DeserializeObject(results, (typeof(Response)));
                    if (respo.Status == "Failed")
                    {
                        activityindicator.IsVisible = false;
                        await DisplayAlert("Failed to Login", respo.Token, "OK");
                        return;
                    }
                    else
                    {
                        App.Current.Properties["token"] = respo.Token;
                        App.Current.Properties["id"] = respo.Id;
                        App.Current.Properties["username"] = respo.Username;
                        App.Current.Properties["name"] = respo.Name;
                        App.Current.Properties["usertype"] = respo.UserType;
                        Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                    }
                }
            }
            if (Application.Current.Properties["type"].ToString() == "Employee")
            { 
                SlisUser useer = new SlisUser("sailas", "Vincema1"); 
                string strialialize = JsonConvert.SerializeObject(useer); 
                var stringContent = new StringContent(strialialize);
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                HttpResponseMessage response = await client.PostAsync(url, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    Response respo;
                    respo = (Response)JsonConvert.DeserializeObject(results, (typeof(Response)));
                    if (respo.Status == "Failed")
                    {
                        activityindicator.IsVisible = false;
                        await DisplayAlert("Failed to Login", respo.Token, "OK");
                        return;
                    }
                    else
                    {
                        App.Current.Properties["token"] = respo.Token;
                        App.Current.Properties["id"] = respo.Id;
                        App.Current.Properties["username"] = respo.Username;
                        App.Current.Properties["name"] = respo.Name;
                        App.Current.Properties["usertype"] = respo.UserType;
                        Application.Current.MainPage = new NavigationPage(new TabbedMenu()); 
                    }
                } 
            }         
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ForgotPassword()); 
        }
    }
}