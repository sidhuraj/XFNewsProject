using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.ViewModel
{
     public class WebviewViewModel
    {
        public WebviewViewModel()
        {
            _webview = new Command(GetView);
        }
        private ICommand _webview;
        public ICommand webview { set {
                _webview = value;
            } get { return _webview; } }

         private void GetView()
        {
            CheckConnectivity(); //Package:Xam.plugin.Connectivity then continue here
            //var url = "http://" + urlntry.Text;
            //Browser.Source = url;
        }

        private void CheckConnectivity()
        {
           if(CrossConnectivity.Current.IsConnected)
            {
                App.Current.MainPage.DisplayAlert("Messsage", "Internet Connected", "ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Messsage", " No Internet Connected", "ok");
            }
        }
    }
}
