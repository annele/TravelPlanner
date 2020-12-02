using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public WeatherForDay Weather;
        public CityResult UserSelectedCityResult;

        private CityResult myVar = new CityResult();

       // public ObservableCollection<WeatherForDay> WeatherForDay { get; set; } = new ObservableCollection<WeatherForDay>();

        public ObservableCollection<CityResult> CityResults { get; set; } = new ObservableCollection<CityResult>();

        public MainWindow()
        {   

            InitializeComponent();
           
            wd = new GetWeatherData();
           // wd.GetWeatherForDay(335012);

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



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            but.Background = Brushes.Red;
     

            var x = wd.GetLocations(CitySearch.Text);
            // var y = x[0];
            CityResults.Clear();
            foreach(var res in x)
                CityResults.Add(res);
           
        

        }

        private void ListCityResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var crListView = sender as ListView;
            UserSelectedCityResult = crListView.SelectedItem as CityResult;
            crListView.Visibility = Visibility.Collapsed;

            

        }

        private void CitySearch_TextChanged(object sender, TextChangedEventArgs e)
       {
            var tb = sender as TextBlock;
            ListCitryResult.Visibility = Visibility.Visible;


        }

        private void WeatherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cityKey = UserSelectedCityResult.ID;
            Weather = wd.GetWeatherFor5Days(cityKey);
      
        }
    }
}
