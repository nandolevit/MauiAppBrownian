using MauiAppBrownian.Brownian.ViewModels;

namespace MauiAppBrownian
{
    public partial class MainPage : ContentPage
    {
        private readonly BrownianViewModel? _viewModel;

        public MainPage(BrownianViewModel brownianViewModel)
        {
            InitializeComponent();

            BindingContext = brownianViewModel;
            _viewModel = brownianViewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }


        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Prices") Execute();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Execute();
        }

        private void Execute()
        {
            BrownianGraph.Drawable = new BrownianGraphDrawable(_viewModel.Prices);
            BrownianGraph.Invalidate();
        }
    }
}


