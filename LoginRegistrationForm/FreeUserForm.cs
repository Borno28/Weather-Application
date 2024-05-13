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
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace LoginRegistrationForm
{
    public partial class FreeUserForm : Form
    {
        public FreeUserForm()
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

                labClouds.Text = Info.clouds.all.ToString()+"%";
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


        DateTime ConvertDateTime(long sec)
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

                UserControl1 FUC;
                for (int i = 0; i < 8; i++)
                {
                    FUC = new UserControl1();
                    FUC.labMainWeather.Text = ForecastInfo.daily[i].weather[0].main;
                    FUC.labWeatherDescription.Text = ForecastInfo.daily[i].weather[0].description;
                    FUC.labDT.Text = convertDateTime(ForecastInfo.daily[i].dt).ToString("dd/MM/yyyy");

                    // Add FUC to the panel or any other container
                    FLP.Controls.Add(FUC);
                }
            }
        }

        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();
            return day;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
        }

        private void labTempareture_Click(object sender, EventArgs e)
        {

        }

        private void FreeUserForm_Load(object sender, EventArgs e)
        {

        }

        private void TBCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void labPressure_Click(object sender, EventArgs e)
        {

        }

        private void labSunset_Click(object sender, EventArgs e)
        {

        }

        private void labSunrise_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void labWeather_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void labClouds_Click(object sender, EventArgs e)
        {

        }

        private void labDetails_Click(object sender, EventArgs e)
        {

        }

        private void labCondition_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void labHumanidity_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labUser_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 lForm = new Form1();
            lForm.Show();
            this.Hide();
        }

        private void FLP_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
