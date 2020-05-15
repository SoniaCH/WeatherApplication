
using WeatherApp.Persistance;
using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
//[assembly: ExportFont("Samantha.ttf")]
namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           
           

            MainPage = new WeatherView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
