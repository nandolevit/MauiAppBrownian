using MauiAppBrownian.Brownian.ViewModels;

namespace MauiAppBrownian
{
    public partial class App : Application
    {
        public App(BrownianViewModel brownianViewModel)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(brownianViewModel));
        }
    }
}
