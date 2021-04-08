using System;
using Xamarin.Forms;

namespace HIITInteval
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void FieldsUnfocused(object sender, FocusEventArgs e)
        {
            ((MainViewModel)BindingContext).SetTimerValues();
        }
    }
}
