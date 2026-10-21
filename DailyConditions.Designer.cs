namespace WeatherForecast
{
  partial class DailyConditions
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      pictureBox = new PictureBox();
      labelDay = new Label();
      labelDate = new Label();
      panel1 = new Panel();
      labelTemperatureHigh = new Label();
      labelTemperatureLow = new Label();
      panel2 = new Panel();
      label = new Label();
      labelPrecipitationsChance = new Label();
      labelMaxWind = new Label();
      label4 = new Label();
      labelCloudCover = new Label();
      label6 = new Label();
      temperatureBar = new TemperatureBar();
      ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
      SuspendLayout();
      // 
      // pictureBox
      // 
      pictureBox.Image = Properties.Resources.Sunny;
      pictureBox.InitialImage = null;
      pictureBox.Location = new Point(28, 6);
      pictureBox.Name = "pictureBox";
      pictureBox.Size = new Size(40, 40);
      pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox.TabIndex = 0;
      pictureBox.TabStop = false;
      // 
      // labelDay
      // 
      labelDay.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      labelDay.Location = new Point(16, 56);
      labelDay.Name = "labelDay";
      labelDay.Size = new Size(66, 23);
      labelDay.TabIndex = 1;
      labelDay.Text = "Today";
      labelDay.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // labelDate
      // 
      labelDate.Location = new Point(17, 82);
      labelDate.Name = "labelDate";
      labelDate.Size = new Size(66, 23);
      labelDate.TabIndex = 2;
      labelDate.Text = "Oct 20";
      labelDate.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // panel1
      // 
      panel1.BorderStyle = BorderStyle.FixedSingle;
      panel1.Location = new Point(7, 110);
      panel1.Name = "panel1";
      panel1.Size = new Size(86, 1);
      panel1.TabIndex = 3;
      // 
      // labelTemperatureHigh
      // 
      labelTemperatureHigh.AutoSize = true;
      labelTemperatureHigh.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
      labelTemperatureHigh.ForeColor = Color.Red;
      labelTemperatureHigh.Location = new Point(5, 123);
      labelTemperatureHigh.Name = "labelTemperatureHigh";
      labelTemperatureHigh.Size = new Size(27, 17);
      labelTemperatureHigh.TabIndex = 4;
      labelTemperatureHigh.Text = "26°";
      // 
      // labelTemperatureLow
      // 
      labelTemperatureLow.AutoSize = true;
      labelTemperatureLow.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
      labelTemperatureLow.ForeColor = Color.Blue;
      labelTemperatureLow.Location = new Point(5, 149);
      labelTemperatureLow.Name = "labelTemperatureLow";
      labelTemperatureLow.Size = new Size(27, 17);
      labelTemperatureLow.TabIndex = 5;
      labelTemperatureLow.Text = "18°";
      // 
      // panel2
      // 
      panel2.BorderStyle = BorderStyle.FixedSingle;
      panel2.Location = new Point(7, 277);
      panel2.Name = "panel2";
      panel2.Size = new Size(86, 1);
      panel2.TabIndex = 6;
      // 
      // label
      // 
      label.AutoSize = true;
      label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label.Location = new Point(10, 284);
      label.Name = "label";
      label.Size = new Size(79, 15);
      label.TabIndex = 7;
      label.Text = "Precipitations";
      label.TextAlign = ContentAlignment.TopCenter;
      // 
      // labelPrecipitationsChance
      // 
      labelPrecipitationsChance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
      labelPrecipitationsChance.ForeColor = Color.Blue;
      labelPrecipitationsChance.Location = new Point(24, 301);
      labelPrecipitationsChance.Name = "labelPrecipitationsChance";
      labelPrecipitationsChance.Size = new Size(51, 15);
      labelPrecipitationsChance.TabIndex = 8;
      labelPrecipitationsChance.Text = "1%";
      labelPrecipitationsChance.TextAlign = ContentAlignment.TopCenter;
      // 
      // labelMaxWind
      // 
      labelMaxWind.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
      labelMaxWind.ForeColor = Color.Blue;
      labelMaxWind.Location = new Point(9, 346);
      labelMaxWind.Name = "labelMaxWind";
      labelMaxWind.Size = new Size(84, 15);
      labelMaxWind.TabIndex = 10;
      labelMaxWind.Text = "2 km/h";
      labelMaxWind.TextAlign = ContentAlignment.TopCenter;
      // 
      // label4
      // 
      label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label4.Location = new Point(16, 331);
      label4.Name = "label4";
      label4.Size = new Size(67, 15);
      label4.TabIndex = 9;
      label4.Text = "Max Wind";
      label4.TextAlign = ContentAlignment.TopCenter;
      // 
      // labelCloudCover
      // 
      labelCloudCover.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
      labelCloudCover.ForeColor = Color.Blue;
      labelCloudCover.Location = new Point(16, 390);
      labelCloudCover.Name = "labelCloudCover";
      labelCloudCover.Size = new Size(68, 15);
      labelCloudCover.TabIndex = 12;
      labelCloudCover.Text = "1%";
      labelCloudCover.TextAlign = ContentAlignment.TopCenter;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label6.Location = new Point(14, 375);
      label6.Name = "label6";
      label6.Size = new Size(73, 15);
      label6.TabIndex = 11;
      label6.Text = "Cloud Cover";
      label6.TextAlign = ContentAlignment.TopCenter;
      // 
      // temperatureBar
      // 
      temperatureBar.BackColor = Color.LightGray;
      temperatureBar.Location = new Point(49, 123);
      temperatureBar.Name = "temperatureBar";
      temperatureBar.Size = new Size(14, 136);
      temperatureBar.TabIndex = 14;
      // 
      // DailyConditions
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(temperatureBar);
      Controls.Add(labelCloudCover);
      Controls.Add(label6);
      Controls.Add(labelMaxWind);
      Controls.Add(label4);
      Controls.Add(labelPrecipitationsChance);
      Controls.Add(label);
      Controls.Add(panel2);
      Controls.Add(labelTemperatureLow);
      Controls.Add(labelTemperatureHigh);
      Controls.Add(panel1);
      Controls.Add(labelDate);
      Controls.Add(labelDay);
      Controls.Add(pictureBox);
      Name = "DailyConditions";
      Size = new Size(100, 412);
      ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private PictureBox pictureBox;
    private Label labelDay;
    private Label labelDate;
    private Panel panel1;
    private Label labelTemperatureHigh;
    private Label labelTemperatureLow;
    private Panel panel2;
    private Label label;
    private Label labelPrecipitationsChance;
    private Label labelMaxWind;
    private Label label4;
    private Label labelCloudCover;
    private Label label6;
    private TemperatureBar temperatureBar;
  }
}
