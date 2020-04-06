using News.Model;
using News.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace News.ViewModel
{
    public class FASHIONViewModel : BaseViewModel
    {
        public FASHIONViewModel()
        {

            GetFashionList();

        }
        private List<Article> _MoviesList;
        public List<Article> MoviesList
        {
            set { _MoviesList = value; }
            get { return _MoviesList; }
        }

        private Article _SelectMovie;
        public Article SelectMovie
        {
            set
            {
                _SelectMovie = value;
                App.Current.MainPage.Navigation.PushAsync(new AllDetailsView());
                MessagingCenter.Send(this, "Fashion", _SelectMovie);
            }
            get { return _SelectMovie; }
        }

        private async void GetFashionList()
        {

            HttpClient objHttpClient = new HttpClient();
            var MovList = await objHttpClient.GetStringAsync("https://newsapi.org/v2/everything?q=apple&from=2020-01-27&to=2020-01-27&sortBy=popularity&apiKey=2d59f81be6044ca597eab896ba7af147");
            var rootobject = JsonConvert.DeserializeObject<MovelModel>(MovList.ToString());
            if (rootobject.status == "ok")
            {
                var articles = rootobject.articles;
                _MoviesList = articles;
            }
            else
            {

            }
            RaisePropertyChanged("MoviesList");
        }
    }
}
