
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
    public class MOVIESViewModel:BaseViewModel
    {
        public MOVIESViewModel()
        {
            GetMoviesList();
          
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
            set {
                _SelectMovie = value;
                App.Current.MainPage.Navigation.PushAsync(new AllDetailsView());
                MessagingCenter.Send(this, "Movies", _SelectMovie);
            }
            get { return _SelectMovie; }
        }

        private async void GetMoviesList()
        {
            
                HttpClient objHttpClient = new HttpClient();
                var MovList = await objHttpClient.GetStringAsync("https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=2d59f81be6044ca597eab896ba7af147");
                var rootobject = JsonConvert.DeserializeObject<MovelModel>(MovList.ToString());
                if (rootobject.status == "ok")
                {
                    var articles = rootobject.articles;
                    _MoviesList = articles;
                }
                else
                {

                }
   
            //foreach(var item in articles)
            //{
            //    source.Add(item.source);
            //}

            RaisePropertyChanged("MoviesList");
        }
    }
}
            
        

