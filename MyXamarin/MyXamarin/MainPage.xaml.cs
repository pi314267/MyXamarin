using MyXamarin.Model;
using MyXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            DevExpress.XamarinForms.CollectionView.Initializer.Init();

            var vm = new MainPageViewModel();
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
