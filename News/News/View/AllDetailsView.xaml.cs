using News.ViewModel;
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
    public partial class AllDetailsView : ContentPage
    {
        public AllDetailsView()
        {
            InitializeComponent();
            BindingContext = new AllDetailsViewModel();
        }

      
    }
}