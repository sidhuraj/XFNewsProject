using BottomBar.XamarinForms;
using News.ViewModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace News
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : BottomBarPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            //NavigationPage.SetHasBackButton(this, false);


            //c# code behind commands:navigation bar inside insert the searchbar
            //var titleView = new SearchBar { HeightRequest = 44, WidthRequest = 300 };
            //NavigationPage.SetTitleView(this, titleView);
        }
    }
}
