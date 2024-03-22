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
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
            txtNam.Text = Application.Current.Properties["name"].ToString();
            txtLev.Text="Username : "+ Application.Current.Properties["username"].ToString();
            txtNam.Text= Application.Current.Properties["name"].ToString();
        }
    }
}