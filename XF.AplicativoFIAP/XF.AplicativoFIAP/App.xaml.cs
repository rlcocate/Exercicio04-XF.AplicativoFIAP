using Xamarin.Forms;
using XF.AplicativoFIAP.View;
using XF.AplicativoFIAP.ViewModel;

namespace XF.AplicativoFIAP
{
    public partial class App : Application
    {
        public static ProfessorViewModel ProfessorVM { get; set; }

        public App()
        {
            InitializeComponent();
            InicializeViewModel();

            MainPage = new NavigationPage(new ListarProfessores() { BindingContext = App.ProfessorVM });
        }

        protected void InicializeViewModel()
        {
            if (ProfessorVM == null)
            {
                ProfessorVM = new ProfessorViewModel();
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
