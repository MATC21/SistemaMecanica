using SistemaMecanica.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SistemaMecanica
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new MasterPage();
            this.Detail = new NavigationPage(new DetailPage());
            App.MasterDet = this;
        }
    }
}
