using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GetWeatherData wd;
        public WeatherForDay TodaysWeather;
        public CityResult cityResult;

        public MainWindow()
        {
            InitializeComponent();

            wd = new GetWeatherData();

            try
            {
                //    var y = wd.GetLocations("London");




                // var x  = wd.GetWeatherForDay("335012");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            // wd.GetLocations("London");
        }

        private void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //do stuff
            // MessageBox.Show(lb1.SelectedItem.ToString());
         //   MessageBox.Show(((KeyValuePair<string, string>)lb1.SelectedItem).Key);

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = Brushes.Red;
            
           var x = wd.GetLocations(CitySearch.Text);
            
            foreach (var loc in x)             // Should be replaced with DataBindings
            {                                  // Should be replaced with DataBindings
                          // Should be replaced with DataBindings
                //CitySearch.Text = "boo!";
            }                                  // Should be replaced with DataBindings

        }

        private void cityresult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }       
}
