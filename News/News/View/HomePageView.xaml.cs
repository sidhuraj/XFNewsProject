﻿using Android.Content.PM;
using News.ViewModel;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : MasterDetailPage
    {
        public HomePageView()
        {
            InitializeComponent();

            BindingContext = new HomePageViewModel();

            

            NavigationPage.SetHasNavigationBar(this, false);

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));

        }

       

    }


}