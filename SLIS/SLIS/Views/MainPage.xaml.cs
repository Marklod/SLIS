using Newtonsoft.Json;
using SLIS.Class;
using SLIS.Views;
using SLIS.Views.Employee;
using SLIS.Views.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SLIS
{
    public partial class MainPage : ContentPage
    {
         string type = "";
        public MainPage()
        {
            InitializeComponent();
            App.Current.Properties["host"] = "https://www.interpathresults.com/slismob/";
          //  App.Current.Properties["host"] = "http://129.232.187.246/slismob/";
            // App.Current.Properties["host"] = "http://192.168.100.20/slismob/";
            txtBranch.Items.Add("ALL");
            txtBranch.Items.Add("HARARE");
            txtBranch.Items.Add("KARIBA");
            txtBranch.Items.Add("BULAWAYO");
            txtBranch.Items.Add("CHITUNGWIZA");
            txtBranch.Items.Add("BINDURA");
            txtBranch.Items.Add("GWERU");
            txtBranch.Items.Add("MUTARE");
            txtBranch.Items.Add("MASVINGO");
            txtBranch.Items.Add("GWANDA");
            txtBranch.Items.Add("KWEKWE");            
        }
         
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Application.Current.MainPage = new NavigationPage(new Registration());
           // overlay1.IsVisible = false;
            Navigation.PushAsync(new NavigationPage(new Registration()));
        } 
        private void btnEmployee_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = true;
            pnButtons.Opacity = 0.2;
            pnButtons.IsEnabled = false;
            type = "Employee";
            App.Current.Properties["type"] = type;
            imgBranch.IsVisible = true;
            txtBranch.IsVisible = true;
            //Navigation.PushAsync(new NavigationPage(new Login("Employee", "EMPLOYEE LOGIN")));
        }

        private void btnPatient_ClickedAsync(object sender, EventArgs e)
        {
            overlay1.IsVisible = true;
            pnButtons.Opacity = 0.2;
            pnButtons.IsEnabled = false;
            type = "Patient";
            App.Current.Properties["type"] = type;
            //  string action = await DisplayActionSheet("ActionSheet: SavePhoto?", "Cancel", "Delete", "Photo Roll", "Email");
            //string result = await DisplayPromptAsync("Question 1", "What's your name?");
            // Navigation.PushAsync(new NavigationPage(new Login("Patient", "PATIENT LOGIN")));
        }

        //private async void btnDoctor_Clicked(object sender, EventArgs e)
        private void btnDoctor_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = true;
            pnButtons.Opacity = 0.2;
            pnButtons.IsEnabled = false;
            type = "Clinic_Doctor";
            App.Current.Properties["type"] = type;
            //Navigation.PushAsync(new NavigationPage(new Login("Clinic_Doctor", "DOCTOR'S LOGIN")));
            //Application.Current.MainPage = new NavigationPage(new Login("Clinic_Doctor", "DOCTOR'S LOGIN"));
            //await Application.Current.MainPage.Navigation.PushAsync(new Login("DOCTOR", "DOCTOR'S LOGIN"));
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            overlay1.IsVisible = false;
            pnButtons.Opacity = 1;
            pnButtons.IsEnabled = true;
            type = "";
            imgBranch.IsVisible = false;
            txtBranch.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //ScanView.TranslateTo(0, 0, 50);
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new FlyoutPage1());
            string url = Application.Current.Properties["host"].ToString() + "api/Main/" + type;
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
            if (type == "Clinic_Doctor")
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
                        App.Current.Properties["branch"] = "ALL";
                        Application.Current.MainPage = new NavigationPage(new TabbedMenu());
                    }
                }
            }
            if (type == "Patient")
            {
                App.Current.Properties["branch"] = "ALL";
                Application.Current.MainPage = new NavigationPage(new TabbedPage1());


                //SlisUser useer = new SlisUser(txtUsername.Text, txtPassword.Text);
                //string strialialize = JsonConvert.SerializeObject(useer);
                //var stringContent = new StringContent(strialialize);
                //var client = new HttpClient();
                //client.Timeout = TimeSpan.FromSeconds(30);
                //HttpResponseMessage response = await client.PostAsync(url, stringContent);
                //if (response.IsSuccessStatusCode)
                //{
                //    String results = await response.Content.ReadAsStringAsync();
                //    Response respo;
                //    respo = (Response)JsonConvert.DeserializeObject(results, (typeof(Response)));
                //    if (respo.Status == "Failed")
                //    {
                //        activityindicator.IsVisible = false;
                //        await DisplayAlert("Failed to Login", respo.Token, "OK");
                //        return;
                //    }
                //    else
                //    {
                //        App.Current.Properties["token"] = respo.Token;
                //        App.Current.Properties["id"] = respo.Id;
                //        App.Current.Properties["username"] = respo.Username;
                //        App.Current.Properties["name"] = respo.Name;
                //        App.Current.Properties["usertype"] = respo.UserType;
                //        Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                //    }
                //}
            }
            if (type == "Employee")
            {
                if (txtBranch.SelectedIndex == -1)
                {
                    await DisplayAlert("Invalid Branch !!", "Please select branch", "OK");
                    return;
                }
                //  SlisUser useer = new SlisUser("sailas", "Vincema1");
                SlisUser useer = new SlisUser(txtUsername.Text, txtPassword.Text);
                string strialialize = JsonConvert.SerializeObject(useer);
                var stringContent = new StringContent(strialialize);
                var client = new HttpClient();
                
                string branch = txtBranch.Items[txtBranch.SelectedIndex];
                client.DefaultRequestHeaders.Add("Branch", branch);               
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
                        App.Current.Properties["branch"] = branch;
                        Application.Current.MainPage = new NavigationPage(new TabbedMenu());
                    }
                }
            }
        }
    }
}
