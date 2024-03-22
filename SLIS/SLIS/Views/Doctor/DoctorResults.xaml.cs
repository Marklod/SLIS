using Newtonsoft.Json;
using Plugin.Connectivity;
using SLIS.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SLIS.Class.myDeserializedClass;
using static SLIS.Class.SearchClass;

namespace SLIS.Views.Doctor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorResults : ContentPage
    {

        List<Visits> vlist = new List<Visits>();
        List<TestResStatus> newStatus = new List<TestResStatus>();
        List<ReceivedMessages> mlist = new List<ReceivedMessages>();

        String  dfrom, dto,token;
        public DoctorResults()
        {
            InitializeComponent();
            //if (search == "PatientName")
            //{
            //    searchPatient();
            //}
            //else
            //{
                getVisitRes(Application.Current.Properties["branch"].ToString());
            //}
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
            if (App.Current.Properties["type"].ToString() == "Employee")
            {
                grdBranch.IsVisible=true;
            }
        }
        
        private async void menu_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("You Are About To Logout", "Are you sure you want to logout of the system?", "Proceed", "Cancel");
            //Debug.WriteLine("Answer: " + answer);
            if (answer ==true)
            {
                App.Current.Properties["token"] = null;
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }          
        }

        private void Picker1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //activityindicator.IsVisible = true;
            string branch = txtBranch.Items[txtBranch.SelectedIndex];
            getVisitRes(branch);
        }

        async private void searchLabOrPatient_Clicked(object sender, EventArgs e)
        {
            //if (txtPatientNameOrLabNumber.Text == "")
             if   (string.IsNullOrEmpty(txtPatientNameOrLabNumber.Text))
            {
                await DisplayAlert("Invalid Data !!", "Please enter patient name or lab number you are searching for", "OK");
                return;
            }
            activityindicator.IsVisible = true;
            //http://129.232.187.246/slismob/
            //string ppp = Application.Current.Properties["host"].ToString();
            //ppp.Replace("http://","");
            //ppp.Replace("/slismob/", "");
            //bool netwrk = await CrossConnectivity.Current.IsRemoteReachable(ppp);
            //if (netwrk == false)
            //{
            //    await DisplayAlert("Failed Connecting Server", "Check your internet (or server) connection and try again", "OK");
            //    return;
            //}
            // Application.Current.Properties["token"].ToString(); 
            //dto = DateTime.Now.ToString("dd/MM/yyyy");
            //dfrom = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy");
            //dto = dto.Replace("/", "");
            //dfrom = dfrom.Replace("/", "");

            //http://192.168.100.2/slismob/api/Main/21102022/22102022
            //string url = Application.Current.Properties["host"].ToString() + "api/Main/" + App.Current.Properties["type"].ToString();
            //string typee = "Lab Number";
            string typee = "patient name";
            string url = Application.Current.Properties["host"].ToString() + "api/SearchPatient/" + typee + "/" + txtPatientNameOrLabNumber.Text ;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            var response = await client.GetAsync(url);
            String res = await response.Content.ReadAsStringAsync();
            RootSearch mySearchDeserializedClass = JsonConvert.DeserializeObject<RootSearch>(res);
            //  activityindicator.IsVisible = false; 
            foreach (var pro in mySearchDeserializedClass.PatientList)
            {
                //var selectedProf = e.Item as Profiles;
                if (string.IsNullOrEmpty(pro.Critical.ToString()))
                {
                    pro.Critical ="non";
                }
                else
                {
                    pro.Critical= "crit";
                }
            }
            AllVisits.ItemsSource = mySearchDeserializedClass.PatientList;
            activityindicator.IsVisible = false;
        }
         
        async private void AllVisits_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var patvis = e.Item as Visits;
            var patientvis = e.Item as PatientList;
            string status = "";
            string labnumber = "";
            string pdfLink = "";
            string panme = "";
            string sexc = "";
            string idnum = "";
            string dob = "";
            string diag = "";
            string contact = ""; 
            string critical = ""; 

            if (patientvis == null & patvis == null)
            {
                return;
            }
             
            if (patientvis == null)
            {
                status = patvis.Status; 
            }
            else
            {
                status = patientvis.Status; 
            }

            if (App.Current.Properties["type"].ToString() == "Clinic_Doctor" && status == "PENDING")
            {
                await DisplayAlert("Results Pending", "This result(s) is not yet available", "OK");
                return;
            }
            else if (Application.Current.Properties["type"].ToString() == "Patient")
            {

            }
            else
            {
                if (patientvis == null)
                {
                    labnumber = patvis.LabNumber;
                    panme = patvis.PatientName;
                    sexc = patvis.Sex;
                    dob = patvis.DateOfBirth;
                    idnum = patvis.IDNumber;
                    diag = patvis.ClinicData;
                    contact = patvis.PhoneNumber;
                    critical = patvis.Critical;
                }
                else
                {
                    labnumber = patientvis.LabNumber;
                    panme = patientvis.PatientName;
                    dob = patientvis.DateOfBirth;
                    sexc = patientvis.Sex; 
                    idnum = patientvis.IDNumber;
                    diag = patientvis.ClinicalData;
                    contact = patientvis.PhoneNumber;
                    critical = patientvis.Critical;
                }
               
                if (Application.Current.Properties["type"].ToString() == "Patient")
                {
                    string url = "http://188.227.58.112/SLISMOB/api/Patient/" + labnumber + "/" + Application.Current.Properties["token"].ToString() + "/na/na/na/na/na/na";
                    var client = new HttpClient(); 
                    var response = await client.GetAsync(url); 
                    String results = await response.Content.ReadAsStringAsync(); 
                    SMSRespo respo; 
                    respo = (SMSRespo)JsonConvert.DeserializeObject(results, (typeof(SMSRespo))); 
                    if (respo.Status == "Success")
                    {
                       // await Application.Current.MainPage.Navigation.PushAsync(new ResultsPDF(respo.Response, "Covid"));
                        // await DisplayAlert("Successfully Send Password", "Your successfully send to your email", "OK");
                        //return;
                    }
                    else
                    {
                        await DisplayAlert("No Covid Certificate", respo.Response, "OK");
                        return;
                    }

                } 
                else
                {
                    //
                    string staturl = Application.Current.Properties["host"].ToString() + "api/TestResultsStatus/" + labnumber;
                    var statclient = new HttpClient();
                    statclient.DefaultRequestHeaders.Clear();
                    statclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
                    var statresponse = await statclient.GetAsync(staturl);
                    String statres = await statresponse.Content.ReadAsStringAsync();
                    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
                    ReleaseRoot relstat = JsonConvert.DeserializeObject<ReleaseRoot>(statres);
                    newStatus = relstat.TestResStatus;
                   int IsCap = 0;
                    for (int i = 0; i < newStatus.Count; i++)
                    {
                        if (newStatus[i].Capture_Status != "PENDING")
                        {
                            IsCap +=1;
                        }
                    }

                   if (IsCap==0)
                    {
                        await DisplayAlert("Results Pending", "This result(s) is not yet available", "OK");
                        return;
                    }
                    //Results detailed page here
                    // await Navigation.PushAsync(new ResultsDetailed(labnumber, panme));
                    //Results Collapsing page here
                    await Navigation.PushAsync(new ResultsCollapse(labnumber, panme,sexc,dob, idnum,pdfLink,diag, sexc, contact, idnum, critical));                    
                    AllVisits.SelectedItem = null;
                }
            }
        }
        private async Task getVisitRes(string branch)
        {
            activityindicator.IsVisible = true;
            //http://129.232.187.246/slismob/
            //string ppp = Application.Current.Properties["host"].ToString();
            //ppp.Replace("http://","");
            //ppp.Replace("/slismob/", "");
            //bool netwrk = await CrossConnectivity.Current.IsRemoteReachable(ppp);
            //if (netwrk == false)
            //{
            //    await DisplayAlert("Failed Connecting Server", "Check your internet (or server) connection and try again", "OK");
            //    return;
            //}
            // Application.Current.Properties["token"].ToString(); 
            if (App.Current.Properties["type"].ToString() == "Employee")
            {
                dto = DateTime.Now.ToString("dd/MM/yyyy");
                dfrom = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
                dto = dto.Replace("/", "");
                dfrom = dfrom.Replace("/", "");
            }
            if (App.Current.Properties["type"].ToString() == "Clinic_Doctor")
            {
                dto = DateTime.Now.ToString("dd/MM/yyyy");
                dfrom = DateTime.Now.AddDays(-60).ToString("dd/MM/yyyy");
                dto = dto.Replace("/", "");
                dfrom = dfrom.Replace("/", "");
            }
            //http://192.168.100.2/slismob/api/Main/21102022/22102022
            //string url = Application.Current.Properties["host"].ToString() + "api/Main/" + App.Current.Properties["type"].ToString();
            //string ttt = "";
            //ttt = Application.Current.Properties["token"].ToString();
            string url = Application.Current.Properties["host"].ToString() + "api/Main/" + dfrom + "/" + dto;
            //string branch = Application.Current.Properties["branch"].ToString();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
            client.DefaultRequestHeaders.Add("Branch", branch);
            //client.DefaultRequestHeaders.Add("Branch", "ALL");
            var response = await client.GetAsync(url);
            String res = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<Visits>>(res);
            //  activityindicator.IsVisible = false; 
            foreach (var pro in Items)
            {
                //var selectedProf = e.Item as Profiles;
                if (string.IsNullOrEmpty(pro.Critical.ToString()))
                {
                    pro.Critical = "non";
                }
                else
                {
                    pro.Critical = "crit";
                }
            }
            AllVisits.ItemsSource = Items;
            activityindicator.IsVisible = false;
        } 
    }

}