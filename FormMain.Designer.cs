namespace WeatherForecast
{
  partial class FormMain
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      panelTop = new Panel();
      radioButtonFahrenheit = new RadioButton();
      radioButtonCelsius = new RadioButton();
      comboBoxCity = new ComboBox();
      buttonSearch = new Button();
      label3 = new Label();
      panelBottom = new Panel();
      labelStatusMessage = new Label();
      label1 = new Label();
      panelMiddle = new Panel();
      panelResultsTitle = new Panel();
      labelWeatherForCity = new Label();
      dailyConditions7 = new DailyConditions();
      dailyConditions6 = new DailyConditions();
      dailyConditions5 = new DailyConditions();
      dailyConditions4 = new DailyConditions();
      dailyConditions3 = new DailyConditions();
      dailyConditions2 = new DailyConditions();
      dailyConditions1 = new DailyConditions();
      toolTip = new ToolTip(components);
      label4 = new Label();
      panelTop.SuspendLayout();
      panelBottom.SuspendLayout();
      panelMiddle.SuspendLayout();
      panelResultsTitle.SuspendLayout();
      SuspendLayout();
      // 
      // panelTop
      // 
      panelTop.BorderStyle = BorderStyle.FixedSingle;
      panelTop.Controls.Add(radioButtonFahrenheit);
      panelTop.Controls.Add(radioButtonCelsius);
      panelTop.Controls.Add(comboBoxCity);
      panelTop.Controls.Add(buttonSearch);
      panelTop.Controls.Add(label3);
      panelTop.Dock = DockStyle.Top;
      panelTop.Location = new Point(0, 0);
      panelTop.Name = "panelTop";
      panelTop.Size = new Size(810, 69);
      panelTop.TabIndex = 0;
      // 
      // radioButtonFahrenheit
      // 
      radioButtonFahrenheit.AutoSize = true;
      radioButtonFahrenheit.Location = new Point(603, 36);
      radioButtonFahrenheit.Name = "radioButtonFahrenheit";
      radioButtonFahrenheit.Size = new Size(36, 19);
      radioButtonFahrenheit.TabIndex = 5;
      radioButtonFahrenheit.Text = "°F";
      toolTip.SetToolTip(radioButtonFahrenheit, "Show Temperatures in Fahrenheit");
      radioButtonFahrenheit.UseVisualStyleBackColor = true;
      // 
      // radioButtonCelsius
      // 
      radioButtonCelsius.AutoSize = true;
      radioButtonCelsius.Checked = true;
      radioButtonCelsius.Location = new Point(603, 11);
      radioButtonCelsius.Name = "radioButtonCelsius";
      radioButtonCelsius.Size = new Size(38, 19);
      radioButtonCelsius.TabIndex = 4;
      radioButtonCelsius.TabStop = true;
      radioButtonCelsius.Text = "°C";
      toolTip.SetToolTip(radioButtonCelsius, "Show temperatures in Celsius");
      radioButtonCelsius.UseVisualStyleBackColor = true;
      radioButtonCelsius.CheckedChanged += RadioButtonCelsius_CheckedChanged;
      // 
      // comboBoxCity
      // 
      comboBoxCity.DisplayMember = "DisplayName";
      comboBoxCity.FormattingEnabled = true;
      comboBoxCity.Location = new Point(80, 21);
      comboBoxCity.Name = "comboBoxCity";
      comboBoxCity.Size = new Size(316, 23);
      comboBoxCity.TabIndex = 3;
      comboBoxCity.Text = "<city to search>";
      toolTip.SetToolTip(comboBoxCity, "Enter a city name. If you omit the region or country, you'll be presented with a list of matching cities worldwide");
      comboBoxCity.SelectionChangeCommitted += ComboBoxCity_SelectionChangeCommitted;
      // 
      // buttonSearch
      // 
      buttonSearch.Location = new Point(413, 18);
      buttonSearch.Name = "buttonSearch";
      buttonSearch.Size = new Size(97, 31);
      buttonSearch.TabIndex = 2;
      buttonSearch.Text = "Search";
      buttonSearch.UseVisualStyleBackColor = true;
      buttonSearch.Click += ButtonSearch_Click;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(46, 24);
      label3.Name = "label3";
      label3.Size = new Size(28, 15);
      label3.TabIndex = 0;
      label3.Text = "City";
      // 
      // panelBottom
      // 
      panelBottom.BorderStyle = BorderStyle.FixedSingle;
      panelBottom.Controls.Add(labelStatusMessage);
      panelBottom.Controls.Add(label1);
      panelBottom.Dock = DockStyle.Bottom;
      panelBottom.Location = new Point(0, 517);
      panelBottom.Name = "panelBottom";
      panelBottom.Size = new Size(810, 23);
      panelBottom.TabIndex = 1;
      // 
      // labelStatusMessage
      // 
      labelStatusMessage.Dock = DockStyle.Fill;
      labelStatusMessage.Location = new Point(0, 0);
      labelStatusMessage.Name = "labelStatusMessage";
      labelStatusMessage.Size = new Size(603, 21);
      labelStatusMessage.TabIndex = 1;
      labelStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      label1.Dock = DockStyle.Right;
      label1.ForeColor = Color.Gray;
      label1.Location = new Point(603, 0);
      label1.Name = "label1";
      label1.Size = new Size(205, 21);
      label1.TabIndex = 0;
      label1.Text = "Data provided by Open-Meteo.com";
      label1.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // panelMiddle
      // 
      panelMiddle.BackColor = Color.WhiteSmoke;
      panelMiddle.Controls.Add(panelResultsTitle);
      panelMiddle.Controls.Add(dailyConditions7);
      panelMiddle.Controls.Add(dailyConditions6);
      panelMiddle.Controls.Add(dailyConditions5);
      panelMiddle.Controls.Add(dailyConditions4);
      panelMiddle.Controls.Add(dailyConditions3);
      panelMiddle.Controls.Add(dailyConditions2);
      panelMiddle.Controls.Add(dailyConditions1);
      panelMiddle.Dock = DockStyle.Fill;
      panelMiddle.Location = new Point(0, 69);
      panelMiddle.Name = "panelMiddle";
      panelMiddle.Size = new Size(810, 448);
      panelMiddle.TabIndex = 2;
      panelMiddle.Visible = false;
      // 
      // panelResultsTitle
      // 
      panelResultsTitle.Controls.Add(labelWeatherForCity);
      panelResultsTitle.Dock = DockStyle.Top;
      panelResultsTitle.Location = new Point(0, 0);
      panelResultsTitle.Name = "panelResultsTitle";
      panelResultsTitle.Size = new Size(810, 32);
      panelResultsTitle.TabIndex = 7;
      // 
      // labelWeatherForCity
      // 
      labelWeatherForCity.BackColor = Color.Blue;
      labelWeatherForCity.Dock = DockStyle.Fill;
      labelWeatherForCity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
      labelWeatherForCity.ForeColor = Color.White;
      labelWeatherForCity.Location = new Point(0, 0);
      labelWeatherForCity.Name = "labelWeatherForCity";
      labelWeatherForCity.Size = new Size(810, 32);
      labelWeatherForCity.TabIndex = 0;
      labelWeatherForCity.Text = "Weather for <city>";
      labelWeatherForCity.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // dailyConditions7
      // 
      dailyConditions7.BackColor = Color.White;
      dailyConditions7.Location = new Point(696, 52);
      dailyConditions7.Name = "dailyConditions7";
      dailyConditions7.Size = new Size(100, 377);
      dailyConditions7.TabIndex = 6;
      // 
      // dailyConditions6
      // 
      dailyConditions6.BackColor = Color.White;
      dailyConditions6.Location = new Point(582, 52);
      dailyConditions6.Name = "dailyConditions6";
      dailyConditions6.Size = new Size(100, 377);
      dailyConditions6.TabIndex = 5;
      // 
      // dailyConditions5
      // 
      dailyConditions5.BackColor = Color.White;
      dailyConditions5.Location = new Point(468, 52);
      dailyConditions5.Name = "dailyConditions5";
      dailyConditions5.Size = new Size(100, 377);
      dailyConditions5.TabIndex = 4;
      // 
      // dailyConditions4
      // 
      dailyConditions4.BackColor = Color.White;
      dailyConditions4.Location = new Point(354, 52);
      dailyConditions4.Name = "dailyConditions4";
      dailyConditions4.Size = new Size(100, 377);
      dailyConditions4.TabIndex = 3;
      // 
      // dailyConditions3
      // 
      dailyConditions3.BackColor = Color.White;
      dailyConditions3.Location = new Point(240, 52);
      dailyConditions3.Name = "dailyConditions3";
      dailyConditions3.Size = new Size(100, 377);
      dailyConditions3.TabIndex = 2;
      // 
      // dailyConditions2
      // 
      dailyConditions2.BackColor = Color.White;
      dailyConditions2.Location = new Point(126, 52);
      dailyConditions2.Name = "dailyConditions2";
      dailyConditions2.Size = new Size(100, 377);
      dailyConditions2.TabIndex = 1;
      // 
      // dailyConditions1
      // 
      dailyConditions1.BackColor = Color.White;
      dailyConditions1.Location = new Point(12, 52);
      dailyConditions1.Name = "dailyConditions1";
      dailyConditions1.Size = new Size(100, 377);
      dailyConditions1.TabIndex = 0;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.ForeColor = Color.Teal;
      label4.Location = new Point(273, 242);
      label4.Name = "label4";
      label4.Size = new Size(296, 15);
      label4.TabIndex = 3;
      label4.Text = "The 7-day forecast for the selected city will appear here";
      // 
      // FormMain
      // 
      AcceptButton = buttonSearch;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(810, 540);
      Controls.Add(panelMiddle);
      Controls.Add(label4);
      Controls.Add(panelBottom);
      Controls.Add(panelTop);
      Name = "FormMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "7 Day Weather Forecast";
      panelTop.ResumeLayout(false);
      panelTop.PerformLayout();
      panelBottom.ResumeLayout(false);
      panelMiddle.ResumeLayout(false);
      panelResultsTitle.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Panel panelTop;
    private Panel panelBottom;
    private Panel panelMiddle;
    private Label labelStatusMessage;
    private Label label1;
    private Button buttonSearch;
    private Label label3;
    private ToolTip toolTip;
    private DailyConditions dailyConditions4;
    private DailyConditions dailyConditions3;
    private DailyConditions dailyConditions2;
    private DailyConditions dailyConditions1;
    private DailyConditions dailyConditions7;
    private DailyConditions dailyConditions6;
    private DailyConditions dailyConditions5;
    private Label label4;
    private ComboBox comboBoxCity;
    private Panel panelResultsTitle;
    private Label labelWeatherForCity;
    private RadioButton radioButtonFahrenheit;
    private RadioButton radioButtonCelsius;
  }
}