using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace LoginRegistrationForm
{
    public partial class GoldUserForm : Form
    {
        public GoldUserForm()
        {
            InitializeComponent();
        }
        string APIKey = "18dede3a5891aa7f0c4f991203e451c0";

        double lon;
        double lat;
        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, APIKey);
                var json = web.DownloadString(url);
                weatherInfo.root Info = JsonConvert.DeserializeObject<weatherInfo.root>(json);

                // pickIcon.ImageLocation ="https://api.openweathermap.org/img/wn/"+Info.weather[0]+".png";

                //pickIcon.ImageLocation = "D:\\Weather application\\icon\\images.png";

                labClouds.Text = Info.clouds.all.ToString() + "%";
                labHumanidity.Text = Info.main.humidity.ToString() + "hPa";
               labCondition.Text = Info.weather[0].main;
               labWeather.Text = Info.weather[0].main;
                labDetails.Text = Info.weather[0].description;
                labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();

                labWindSpeed.Text = Info.wind.speed.ToString() + "m/s";
                labPressure.Text = Info.main.pressure.ToString() + "hPa";
                // Convert temperature from Kelvin to Celsius
                double temperatureCelsius = KelvinToCelsius(Info.main.temp);
                labTempareture.Text = temperatureCelsius.ToString("0.00");

                lon = Info.coord.lon;
                lat = Info.coord.lat;

            }
        }
        private double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day;
        }


        void getForecast()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&exclude=current,%20minutely.hourly.alerts&appid={2}", lat, lon, APIKey);
                var json = web.DownloadString(url);
                weatherForcast.ForecastInfo ForecastInfo = JsonConvert.DeserializeObject<weatherForcast.ForecastInfo>(json);

                UserControl2 FUC2;
                for (int i = 0; i < 6; i++)
                {
                    FUC2 = new UserControl2();
                    FUC2.labMainWeather2.Text = ForecastInfo.daily[i].weather[0].main;
                    FUC2.labTemp.Text = ForecastInfo.daily[i].weather[0].description;
                    FUC2.labdate.Text = ConvertDateTime(ForecastInfo.daily[i].dt).ToString("dd/MM/yyyy");
                    //FUC2.labTemp.Text = ForecastInfo.daily[i].temp.ToString();
                    // Add FUC to the panel or any other container
                    FLP.Controls.Add(FUC2);
                }
            }
        }

        DateTime ConvertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 lForm = new Form1();
            lForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zoom.earth/places/bangladesh/#map=temperature/model=icon");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://www.thedailystar.net/todays-news");
        }
    }
}
