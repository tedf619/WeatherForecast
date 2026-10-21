using System.Drawing.Drawing2D;

namespace WeatherForecast;

public partial class TemperatureBar : UserControl
{
  Color lightBlue = Color.FromArgb(70, 130, 180);
  Color lightRed = Color.FromArgb(255, 107, 107);

  double low, high, weeklyLow, weeklyHigh;

  public TemperatureBar()
  {
    InitializeComponent();
    DoubleBuffered = true;
  }

  public void SetTemperatures(WeatherData weatherData)
  {
    low = weatherData.TemperatureLow;
    high = weatherData.TemperatureHigh;
    weeklyLow = weatherData.TemperatureWeeklyLow;
    weeklyHigh = weatherData.TemperatureWeeklyHigh;

    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);

    if (ClientRectangle.Width <= 0 || ClientRectangle.Height <= 0) return;

    Graphics g = e.Graphics;
    g.SmoothingMode = SmoothingMode.AntiAlias;

    // paint the gray background
    using var backgroundBrush = new SolidBrush(BackColor);
    g.FillRectangle(backgroundBrush, ClientRectangle);

    // determine blue-to-red gradient area

    double totalSpan = weeklyHigh - weeklyLow;
    double highOffsetPct = (weeklyHigh - high) / totalSpan;
    double lowOffsetPct = (weeklyHigh - low) / totalSpan;

    int fillTop = (int)(highOffsetPct * Height);
    int fillBottom = (int)(lowOffsetPct * Height);
    int fillHeight = Math.Max(6, fillBottom - fillTop);

    // paint the blue-to-red gradient bar
    var topLeft = new Point(0, fillTop);
    var bottomRight = new Point(0, fillTop + fillHeight);
    using var gradientBrush = new LinearGradientBrush(topLeft, bottomRight, lightRed, lightBlue);
    g.FillRectangle(gradientBrush, 0, fillTop, Width, fillHeight);
  }
}
