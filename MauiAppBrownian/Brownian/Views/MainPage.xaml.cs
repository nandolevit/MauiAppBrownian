using MauiAppBrownian.Brownian.ViewModels;
using Microsoft.Maui.Controls;

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
            if (e.PropertyName == "Prices")
            {
                BrownianGraph.Drawable = new BrownianGraphDrawable(_viewModel.Prices);
                BrownianGraph.Invalidate();
            }
        }
    }
}


