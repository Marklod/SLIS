using Newtonsoft.Json;
using Plugin.Connectivity;
using SLIS.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SLIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            txtGender.Items.Add("FEMALE");
            txtGender.Items.Add("MALE");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
            //With back arrow
            //Navigation.PushAsync(new NavigationPage(new MainPage ()));
        }

        async private void BtnReg_Clicked(object sender, EventArgs e)
        {
            bool netwrk = await CrossConnectivity.Current.IsRemoteReachable("www.google.com");
            if (netwrk == false)
            {
                await DisplayAlert("No Internet Access", "Check your internet connection and try again", "OK");
                return;
            } 

            string url = Application.Current.Properties["host"].ToString() + "api/Main/"; 
            List<PatientUser> pt = new List<PatientUser>();
            string gender = txtGender.Items[txtGender.SelectedIndex];
            pt.Add(new PatientUser(txtIDNo.Text.Trim(), txtPatientName.Text.Trim(), txtDOB.Date.ToString("dd/MM/yyyy").Trim(), txtPhone.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), gender.Trim()));
            string strserialize = JsonConvert.SerializeObject(pt);
            strserialize = strserialize.Replace(@"[", "").Replace(@"]", "");
            var stringContent = new StringContent(strserialize);
            var client = new HttpClient();
            var response = await client.PostAsync(url, stringContent);
            String result = await response.Content.ReadAsStringAsync();
            SMSRespo respo;
            respo = (SMSRespo)JsonConvert.DeserializeObject(result, (typeof(SMSRespo)));
            if (respo.Status == "Success")
            {
                await DisplayAlert("Successfully Register", respo.Response.ToString(), "OK");
                return;
            }
            else
            {
                await DisplayAlert("Fail To Register", respo.Response.ToString(), "OK");
                return;
            }

        }
    }
}