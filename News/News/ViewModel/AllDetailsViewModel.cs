using News.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;
using News.SQLite;

namespace News.ViewModel
{
    public class AllDetailsViewModel: BaseViewModel
    {
        Article mArticle;
        SQLiteConnection conn;
        public AllDetailsViewModel()
        {

            conn = DependencyService.Get<SQLiteConn>().GetConnection();
            conn.CreateTable<BookMarkModel>();
            MessagingCenter.Subscribe<MOVIESViewModel, Article>(this, "Movies", (sender, arg) =>
            {
                this.mArticle = arg;
                BindingData();
            });
            MessagingCenter.Subscribe<FASHIONViewModel, Article>(this, "Fashion", (sender, arg) =>
             {
                 this.mArticle = arg;
                 BindingData();
             });
            MessagingCenter.Subscribe<MODELViewModel, Article>(this, "Model", (sender, arg) =>
            {
                this.mArticle = arg;
                BindingData();
            });

            bookmark = new Command(savedBookMark);
          
        }

        private void savedBookMark()
        {
            BookMarkModel lBookMarkModel = new BookMarkModel();

            lBookMarkModel.title = mArticle.title;
            lBookMarkModel.author = mArticle.author;
            lBookMarkModel.urlToImage = mArticle.urlToImage;
            lBookMarkModel.content = mArticle.content;
            lBookMarkModel.description = mArticle.description;
            lBookMarkModel.publishedAt = mArticle.publishedAt;

            //TODO Need to add all items
            int results = conn.Insert(lBookMarkModel); // TO SEND
            if(results > 0)
            {
                App.Current.MainPage.DisplayAlert("BookMark", "Book mark items saved successfully", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Bookmark", "Bookmark Saved failed, Could you please try again", "OK");
            }
        }

        
        private ICommand _bookmark;
        public ICommand bookmark
        {
            set { _bookmark = value; }
            get { return _bookmark; }
        }

        private String _imgArticle;
        public string imgArticle
        {
            set { _imgArticle = value; }

            get { return _imgArticle; }

        }
        private string _Title;
        public string Title
        {
            set
            {
                _Title = value;
            }
            get
            {
                return _Title;
            }
        }
        private string _PublishedAt;
        public string PublishedAt
        {
            set
            {
                _PublishedAt = value;
            }
            get
            {
                return _PublishedAt;
            }
        }
        private string _Author;
        public string Author
        {
            set
            {
                _Author = value;
            }
            get
            {
                return _Author;
            }
        }
        private string _Content;
        public string Content
        {
            set
            {
                _Content = value;
            }
            get
            {
                return _Content;
            }
        }
        private void BindingData()
        {
            _imgArticle = mArticle.urlToImage;
            _Title = mArticle.title;
            _PublishedAt = mArticle.publishedAt.ToString();
            _Author = mArticle.author;
            _Content = mArticle.content;


            RaisePropertyChanged("imgArticle");
            RaisePropertyChanged("Title");
            RaisePropertyChanged("PublishedAt");
            RaisePropertyChanged("Author");
            RaisePropertyChanged("Content");
        }



















    }
    }
