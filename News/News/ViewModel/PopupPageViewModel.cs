using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace News.ViewModel
{
     public class PopupPageViewModel
    {
        public PopupPageViewModel()
        {
            _login = new Command(Getlogin);
            pOPRooT = new Command(GetPopRoot);
        }
        private ICommand _login;
        public ICommand login { set { _login = value; } get { return _login;  } }

        private void Getlogin()
        {
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
        private ICommand pOPRooT;
        public ICommand POPRooT { set { pOPRooT = value; } get { return pOPRooT; } }

        private void GetPopRoot()
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }

}
