using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.AplicativoFIAP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarProfessores : ContentPage
    {
        public ListarProfessores()
        {
            InitializeComponent();
        }
                
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
                await App.ProfessorVM.Carregar();
                lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}