using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SuanMing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            var lunar = LunarSolarConverter.SolarToLunar(
                new Solar()
                {
                    solarYear = inputDate.Date.Year ,
                    solarDay =inputDate.Date.Day,
                    solarMonth =inputDate.Date.Month
                });
            outputTB.Text = "农历" + lunar.lunarYear + "年"+ lunar.lunarMonth + "月初" + lunar.lunarDay;

            double liang = SuanMingClass.GetLiang(lunar.lunarYear, lunar.lunarDay, lunar.lunarMonth, inputTime.Time.Hours);
            liangTB.Text = liang + " 两";

            commentTB.Text = SuanMingClass.GetComment(liang).Replace("，", Environment.NewLine);
        }
    }
}
