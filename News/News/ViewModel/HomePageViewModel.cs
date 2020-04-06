//using Android.Support.V4.Content;
using News.Model;
using News.View;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.ViewModel
{
    public class HomePageViewModel:BaseViewModel
    {
        public string CityLocation = "Bangalore";
        public HomePageViewModel()
        {
           
            _home = new Command(Gethome);
            Bookmark = new Command(MoveBookMarkPage);
            camera = new Command(GetCamera);
            _login = new Command(GetLogin);
            Getweather();
            _Popup = new Command(Getpopup);
            absoluteOverlap = new Command(GetAbsoluteLayout);
            webViewPage = new Command(GetWebview);

        }
        private ICommand _Photocam;
        public ICommand Photocam { set { _Photocam = value; } get { return _Photocam; } }


        private ICommand webViewPage;
        public ICommand WebViewPage { set { webViewPage = value; } get { return webViewPage; } }

       private void GetWebview()
        {
            App.Current.MainPage.Navigation.PushAsync(new WebviewView());
        }
        private void GetLogin()
        {
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
            
        }


        private async void Getweather()
        {
            HttpClient objHttpClient = new HttpClient();
            var MovList = await objHttpClient.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=India&appid=eaa7116b20607bd1ee36840837a94b62");
            var rootobject = JsonConvert.DeserializeObject<WeatherClass.RootObject>(MovList.ToString());
            _temprature = rootobject.main.temp.ToString();
            _humadity = rootobject.main.humidity.ToString();
            _city = CityLocation;

            RaisePropertyChanged("temprature");
            RaisePropertyChanged("humadity");
            RaisePropertyChanged("city");

        }

        private ICommand absoluteOverlap;
        public ICommand AbsoluteOverlap { set { absoluteOverlap = value; } get { return absoluteOverlap; } }


         private void GetAbsoluteLayout()
        {
            //App.Current.MainPage.Navigation.PushAsync(new AbsoluteOverlapView());
            App.Current.MainPage.Navigation.PushModalAsync(new AbsoluteOverlapView()); //without navigation bar command
            //App.Current.MainPage.Navigation.RemovePage(new AbsoluteOverlapView());//complete remove thaT page donot show (or) go to page
        }

        private void MoveBookMarkPage()
        {
            App.Current.MainPage.Navigation.PushAsync(new BookmarkView());  
        }

        private ICommand _home;
        public ICommand Home
        {
            set { _home = value; }
            get { return _home; }
        }
        private void Gethome()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Home());
           
        }

        private ICommand _bookmark;
        public ICommand Bookmark
        {
            set { _bookmark = value; }
            get { return _bookmark; }
        }
        private ICommand camera;
        public ICommand Camera { set { camera = value; } get { return camera; } }
        private  async void  GetCamera()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported &&
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ": (No camera available.", "OK");
                return;
            }
            else
            {

            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Images",

                Name = DateTime.Now + "_test.jpg"
            });

            if (file == null)
                return;
            await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");
            //_Photocam = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }
        private string _temprature;
        public string temprature { set { _temprature = value; } get { return _temprature; } }
        private string _city;
        public string city { set { _city = value; } get { return _city; } }
        private string _humadity;
        public string humadity { set { _humadity = value; } get { return _humadity; } }

        private ICommand _login;
        public ICommand login { set 
            {
                _login = value;
               
            }
            get { return _login; } }
        private ICommand _Popup;
        public ICommand Popup {  set{ _Popup = value; } get { return _Popup; } }

        private void Getpopup()
        {
            App.Current.MainPage.Navigation.PushAsync(new PopupPageView());
        }
    }
}
