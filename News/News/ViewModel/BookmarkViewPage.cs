using News.Model;
using News.SQLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.ViewModel
{
   public class BookmarkViewPage:BaseViewModel
    {
        
        SQLiteConnection conn;
        public BookmarkViewPage()
        {
            conn = DependencyService.Get<SQLiteConn>().GetConnection();
           
            DisplayDetails();
            _Delete = new Command(GetDelete);
        }
        
        void DisplayDetails()
        {
            var bookMarkItems = conn.Table<BookMarkModel>().ToList();
            Bookmarkpage = bookMarkItems;
        }

        private List<BookMarkModel> _Bookmarkpage;
        public List<BookMarkModel> Bookmarkpage { set { _Bookmarkpage = value; } get { return _Bookmarkpage; } }

        private BookMarkModel _selecteditem;
        public BookMarkModel selecteditem
        {
            set { _selecteditem = value; }
            get { return _selecteditem; }
        }

        private ICommand _Delete;
        public ICommand Delete { set { _Delete = value; } get { return _Delete; } }
        void GetDelete()
        {
            //delete process:selecteditem crete a private&public(using class name),
            //then create a button-private@public,write a method underbelow the delete line,with open brackets under selecteditem.any class property,
            //go to class-any class property top u use the"Primarykey" then it works

            conn.Delete<BookMarkModel>(_selecteditem.title); 
            App.Current.MainPage.DisplayAlert("List", "Bookmark deleted Sucessfully", "ok");
            DisplayDetails();
            
            RaisePropertyChanged("Bookmarkpage"); 

        }
    }
}
