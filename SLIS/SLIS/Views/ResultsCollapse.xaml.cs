using Newtonsoft.Json; 
using SLIS.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SLIS.Class.myDeserializedClass;

namespace SLIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsCollapse : ContentPage
    {
        List<PatietResults> rlist = new List<PatietResults>();
        List<Profiles> newProfile = new List<Profiles>();
        List<TestResStatus> newStatus = new List<TestResStatus>();
        String Labno, error, pdfLink, Patientname;
        GenericClass genericclass = new GenericClass(); 
        List<MarkedCriticalTests> criticalList = new List<MarkedCriticalTests>();
        private void resultsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            foreach (var pro in newProfile)
            {
              pro.IsVisible=false;
            }
            var selectedProf = e.Item as Profiles;
            //if (!(selectedProf.IsVisible = true))
            //{
            //    selectedProf.IsVisible = true;
            //}
            //else
            //{
            //    selectedProf.IsVisible = false;
            //} 
            selectedProf.IsVisible = true;
            selectedProf.TheHeight = 40 * selectedProf.Results.Count+40;
            resultsList.ItemsSource = null;
            resultsList.ItemsSource = newProfile;  
            resultsList.HeightRequest = selectedProf.TheHeight + (newProfile.Count*40)+150;
        }

        private async void shareApp_Clicked(object sender, EventArgs e)
        {
           await Share.RequestAsync(new ShareTextRequest 
               {
               Text= pdfLink,
               Title="Get a copy of your results PDF"
            });
        }

       private async void btnReleaseOne_Clicked(object sender, EventArgs e)
        { 
           
            string testcode = "";
            testcode = ((Button)sender).CommandParameter.ToString();
            testcode = genericclass.GetTestcode(testcode);
            ////===============Mark as critical================= 
            //string url = Application.Current.Properties["host"].ToString() + "api/Update/" + txtLabNo.Text + "/MARK"; //+ txtPatientNameOrLabNumber.Text;
            //var stringContent = new StringContent("");
            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            //client.DefaultRequestHeaders.Add("Test", testcode);
            //var response = await client.PostAsync(url, stringContent);
            //String res = await response.Content.ReadAsStringAsync(); 
            ////===============End Mark as critical=================            
            //===============Release Results=================  
            string url = Application.Current.Properties["host"].ToString() + "api/Update";
            var stringContent = new StringContent("");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            client.DefaultRequestHeaders.Add("LabNumber", txtLabNo.Text);
            client.DefaultRequestHeaders.Add("Test", testcode);
           // client.DefaultRequestHeaders.Add("Test", testcode);
            var response = await client.PostAsync(url, stringContent);
            String res = await response.Content.ReadAsStringAsync();
            //===============End Release results=================
            DataResponse respo;
            respo = (DataResponse)JsonConvert.DeserializeObject(res, (typeof(DataResponse)));
            //await DisplayAlert(respo.status, respo.response, "OK");
            string comment = await DisplayPromptAsync(respo.status, "Do you want to save comment to "+ testcode+" result(s)", "Yes","No");
            
            if (string.IsNullOrEmpty(comment))
            {
               
            }
            else
            {
                string urlcom = Application.Current.Properties["host"].ToString() + "api/Update/"+ txtLabNo.Text;
                var stringContentcom = new StringContent("");
                var clientcom = new HttpClient();
                clientcom.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
                clientcom.DefaultRequestHeaders.Add("Test", testcode);
                clientcom.DefaultRequestHeaders.Add("Parameter", "Comment");
                clientcom.DefaultRequestHeaders.Add("OldValue", "-");
                clientcom.DefaultRequestHeaders.Add("NewValue", comment);
                clientcom.DefaultRequestHeaders.Add("Reason", "Mobileapp add comment");
                clientcom.DefaultRequestHeaders.Add("Extra", "");
                var responsecom = await clientcom.PutAsync(urlcom, stringContentcom);
                String rescom = await responsecom.Content.ReadAsStringAsync();
                //===============End Release results================= 
                DataResponse respocom;
                respocom = (DataResponse)JsonConvert.DeserializeObject(rescom, (typeof(DataResponse)));
                await DisplayAlert(respocom.status, respocom.response, "OK");
            }
        }

        private void cboCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MarkedCriticalTests r = new MarkedCriticalTests();
            var checkbox = (CheckBox)sender;
            string code= checkbox.BindingContext.ToString();
            code = genericclass.GetTestcode(code);
            if (e.Value.Equals(true))
            {                 
                r.test = code;
                criticalList.Add(r);
            }
            else
            {
                r.test = code;
                criticalList.Remove(r);
            }    
        }

        private async void btnMarkCritical_Clicked(object sender, EventArgs e)
        {
            string allcodes = "";
           //allcodes = string.Join(",", criticalList);
            //Console.WriteLine(allcodes);
            //await DisplayAlert("Hooyoh", allcodes, "OK");
            if (criticalList.Count == 0)
            {
                await DisplayAlert("Failed", "Please mark at least one subject", "OK");
                return;
            }
            for (int i = 0; i < criticalList.Count; i++)
            {
                if (i == 0)
                {
                    allcodes = criticalList[i].test.ToString();
                }
                else
                {
                    allcodes += "," + criticalList[i].test.ToString();
                }
            }
            //===============Mark as critical================= 
            string url = Application.Current.Properties["host"].ToString() + "api/Update/" + txtLabNo.Text + "/MARK"; //+ txtPatientNameOrLabNumber.Text;
            var stringContent = new StringContent("");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            client.DefaultRequestHeaders.Add("Test", allcodes);
            var response = await client.PostAsync(url, stringContent);
            String res = await response.Content.ReadAsStringAsync();            
            DataResponse respo;
            respo = (DataResponse)JsonConvert.DeserializeObject(res, (typeof(DataResponse)));
            await DisplayAlert(respo.status, respo.response, "OK");
            //===============End Mark as critical=================
            criticalList.Clear();
        }

        private async void btnUnMarkCritical_Clicked(object sender, EventArgs e)
        {
            string allcodes = "";
            //allcodes = string.Join(",", criticalList);
            //Console.WriteLine(allcodes);
            //await DisplayAlert("Hooyoh", allcodes, "OK");
            if (criticalList.Count == 0)
            {
                await DisplayAlert("Failed", "Please mark at least one subject", "OK");
                return;
            }
            for (int i = 0; i < criticalList.Count; i++)
            {
                if (i == 0)
                {
                    allcodes = criticalList[i].test.ToString();
                }
                else
                {
                    allcodes += ","+ criticalList[i].test.ToString() ;
                }
            }
            //===============Mark as critical================= 
            string url = Application.Current.Properties["host"].ToString() + "api/Update/" + txtLabNo.Text + "/UNMARK"; 
            var stringContent = new StringContent("");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            client.DefaultRequestHeaders.Add("Test", allcodes);
            var response = await client.PostAsync(url, stringContent);
            String res = await response.Content.ReadAsStringAsync();
            DataResponse respo;
            respo = (DataResponse)JsonConvert.DeserializeObject(res, (typeof(DataResponse)));
            await DisplayAlert(respo.status, respo.response, "OK");
            //===============End Mark as critical=================
            criticalList.Clear();
        }

        public ResultsCollapse(string labNumber, string patientName,string sex,string dob, string age,string pdflink,string diag,string gender, string contact,string IDnum,string critical)
        {
            InitializeComponent();
            Labno = labNumber;
            GetPatientTestsFromAPI();
            txtPname.Text = patientName;
           // txtGender.Source = sex + ".png";
            txtDOB.Text = dob;
            txtGender.Text = age;
            txtID.Text = IDnum;
            txtGender.Text = gender;
            txtPhone.Text = contact;
            txtrDG.Text = diag;

        }
        private async Task GetPatientTestsFromAPI()
        {
            string url = Application.Current.Properties["host"].ToString() + "api/Main/" + Labno;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            client.DefaultRequestHeaders.Add("Format", "pdf");
            var response = await client.GetAsync(url);
            String res = await response.Content.ReadAsStringAsync(); 
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(res);   
            
            newProfile = myDeserializedClass.Profile;              
            //resultsList.ItemsSource = newProfile;
            //resultsList.HeightRequest =200+( 40* myDeserializedClass.Profile.Count); 

            txtLabNo.Text = Labno;
            txtAuthorizedBy.Text = myDeserializedClass.Credential.AuthorizedBy;
            txtrEPORTdATE.Text = myDeserializedClass.Credential.ReportDate;
            txtReportedBy.Text = myDeserializedClass.Credential.ReportedBy;

            pdfLink = myDeserializedClass.PDF;
            Patientname = myDeserializedClass.PatientDetailes.PatientName;
            activityindicator.IsVisible = false;
                                 

            //GetResultsStatus();

            string staturl = Application.Current.Properties["host"].ToString() + "api/TestResultsStatus/" + Labno;
            var statclient = new HttpClient();
            statclient.DefaultRequestHeaders.Clear();
            statclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            var statresponse = await statclient.GetAsync(staturl);
            String statres = await statresponse.Content.ReadAsStringAsync();
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            ReleaseRoot relstat = JsonConvert.DeserializeObject<ReleaseRoot>(statres);


            //checking released or not here
            newStatus = relstat.TestResStatus;
            for (int i = 0; i < newProfile.Count; i++)
            {
                string rel;
                rel = "PENDING";

                for (int j = 0; j < newStatus.Count; j++)
                {
                    newStatus[j].Test = genericclass.GetProfileName(newStatus[j].Test);
                    if (newProfile[i].Profile == newStatus[j].Test)
                    {
                        newProfile[i].ReleaseStatus = newStatus[j].Release_Status;

                        if (newProfile[i].ReleaseStatus == "PENDING")
                        {
                            newProfile[i].IsVisibleRelease = true;
                        }
                        else if (newProfile[i].ReleaseStatus == "RELEASED")
                        {
                            newProfile[i].IsVisibleRelease = false;
                        }
                        break;
                    }
                    else
                    {
                        newProfile[i].ReleaseStatus = "PENDING";
                    }
                }
            }
            //end checking released or not here

            if (string.IsNullOrEmpty(myDeserializedClass.PatientDetailes.Critical.ToString()))
            {
                btnMarkCritical.IsVisible = true;
                btnUnMarkCritical.IsVisible = false;
                for (int i = 0; i < newProfile.Count; i++)
                {
                    newProfile[i].image = "eppendorf";
                }
            }
            else
            {
                btnMarkCritical.IsVisible = false;
                btnUnMarkCritical.IsVisible = true;

                string[] crittest;
                crittest = myDeserializedClass.PatientDetailes.Critical.Split(',');
                
                for (int i = 0; i < newProfile.Count; i++)
                {
                    newProfile[i].image = "eppendorf";

                    //crittest[j] = genericclass.GetProfileName(crittest[j]);

                    for (int j = 0; j < crittest.Length; j++)
                    {
                        crittest[j] = genericclass.GetProfileName(crittest[j]);

                        if (crittest[j].ToString() == newProfile[i].Profile.ToString())
                        {
                            newProfile[i].image = "crit";
                         // break;
                        }
                        else
                        {
                            //newProfile[i].image = "eppendorf";
                            //if (j == crittest.Length-1)
                            //{
                            //    break;
                            //}
                            //break;
                        }

                    } 
                }
            }
            resultsList.ItemsSource = newProfile;
            resultsList.HeightRequest = 200 + (40 * myDeserializedClass.Profile.Count);

            //===============Check results status=====================
            //returns list of tests capturestatus, release status
            //pick release status
            //check each variable from list to profile code
            //release status
            //
            //
            //=====================================
        }

        private async Task GetResultsStatus()
        { 
            string staturl = Application.Current.Properties["host"].ToString() + "api/TestResultsStatus/" + Labno;
            var statclient = new HttpClient();
            statclient.DefaultRequestHeaders.Clear();
            statclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            var statresponse = await statclient.GetAsync(staturl);
            String statres = await statresponse.Content.ReadAsStringAsync();
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            ReleaseRoot relstat = JsonConvert.DeserializeObject<ReleaseRoot>(statres);              
        }
    //
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ResultsPDF(Labno ));
            // await Navigation.PushAsync(new ViewResults(myselectedLabnumber.LabNumber));
            if (Labno == "Status-Failed")
            {
                await DisplayAlert("Falied to load PDF", error, "OK");
                return;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ResultsPDF(pdfLink, Patientname));
            }
        }

    }
}