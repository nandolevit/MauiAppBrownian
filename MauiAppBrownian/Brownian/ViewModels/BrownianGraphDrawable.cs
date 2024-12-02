namespace MauiAppBrownian.Brownian.ViewModels
{
    internal class BrownianGraphDrawable : IDrawable
    {
        private readonly double[] prices;

        public BrownianGraphDrawable(double[] prices)
        {
            this.prices = prices;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (prices == null || prices.Length == 0) return;

            canvas.FillColor = Colors.White;
            canvas.FillRectangle(dirtyRect);

            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 2;

            float width = dirtyRect.Width / prices.Length;
            float height = dirtyRect.Height;

            for (int i = 1; i < prices.Length; i++)
            {
                float x1 = (i - 1) * width;
                float y1 = height - (float)(prices[i - 1] / prices.Max() * height);
                float x2 = i * width;
                float y2 = height - (float)(prices[i] / prices.Max() * height);

                canvas.DrawLine(x1, y1, x2, y2);
            }
        }
    }
}
