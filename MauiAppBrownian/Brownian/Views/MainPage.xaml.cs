namespace MauiAppBrownian
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        //{
        //    var canvas = e.Surface.Canvas;
        //    canvas.Clear(SKColors.White);

        //    var viewModel = (BrownianMotionViewModel)BindingContext;
        //    var prices = viewModel.Prices.ToList();

        //    if (prices.Count == 0) return;

        //    float width = e.Info.Width;
        //    float height = e.Info.Height;
        //    float maxPrice = prices.Max().ToFloat();
        //    float minPrice = prices.Min().ToFloat();
        //    float priceRange = maxPrice - minPrice;

        //    var path = new SKPath();
        //    path.MoveTo(0, height - (prices[0] - minPrice) / priceRange * height);

        //    for (int i = 1; i < prices.Count; i++)
        //    {
        //        float x = (float)i / (prices.Count - 1) * width;
        //        float y = height - (prices[i] - minPrice) / priceRange * height;
        //        path.LineTo(x, y);
        //    }

        //    using (var paint = new SKPaint())
        //    {
        //        paint.Color = SKColors.Blue;
        //        paint.StrokeWidth = 2;
        //        paint.Style = SKPaintStyle.Stroke;
        //        canvas.DrawPath(path, paint);
        //    }
        //}
    }
}


