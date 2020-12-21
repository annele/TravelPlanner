using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public getTheForkWEbSiteData theFork;
        public WeatherResult Weather;
        public CityResult UserSelectedCityResult;
        public CafeResult UserSelectionCafeResult;
      
        

        public ObservableCollection<WeatherResult> WeatherResults { get; set; } = new ObservableCollection<WeatherResult>();

        public ObservableCollection<CityResult> CityResults { get; set; } = new ObservableCollection<CityResult>();

        public ObservableCollection<CafeResult> CafeResults { get; set; } = new ObservableCollection<CafeResult>();

        public MainWindow()
        {   

            InitializeComponent();
           
            wd = new GetWeatherData();
            theFork = new getTheForkWEbSiteData();
            InitialView();
            
          //  wd.GetWeatherFor5Days(335012);

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

        /// <summary>
        /// action done after clicking the button "Search": getLocations method is called and the location data is calculated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            but.Background = Brushes.Red;
            ListCitryResult.Visibility = Visibility.Visible;

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

            var cityKey = UserSelectedCityResult.ID;
            var w = wd.GetWeatherFor5Days(cityKey);
            foreach (var res in w)
            {
                WeatherResults.Add(res);
            }

            var wListView = sender as ListView;
            Weather = wListView.SelectedItem as WeatherResult;
            ListWeatherResult.Visibility = Visibility.Visible;
        }

        private void CitySearch_TextChanged(object sender, TextChangedEventArgs e)
       {
        //    var tb = sender as TextBlock;
        //    ListCitryResult.Visibility = Visibility.Visible;

        }


        private void GoBAckButton_Click(object sender, RoutedEventArgs e)
        {
            InitialView();
        }

        private void InitialView()
        {
            ListWeatherResult.Visibility = Visibility.Collapsed;
            ListCitryResult.Visibility = Visibility.Collapsed;
            CitySearch.Text = "";
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var btnSender = sender as Button;
            ListCafeResult.Visibility = Visibility.Visible;

           
            var cafeList = theFork.GetCafeResult(UserSelectedCityResult);    
            foreach(var res in cafeList)
            {
                CafeResults.Add(res);
            }


        }

        private void ListCafeResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var crListView = sender as ListView;
            UserSelectionCafeResult = crListView.SelectedItem as CafeResult;
           // crListView.Visibility = Visibility.Collapsed;
        }
    }
}
