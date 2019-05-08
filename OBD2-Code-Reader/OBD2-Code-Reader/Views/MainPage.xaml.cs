using AutoDashboard.UniversalApp.AutoReaders;
using AutoDashboard.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OBD2_Code_Reader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private DashboardViewModel _vm;
        private ObdNetAutoReader _obdReader;
        public MainPage()
        {
            this.InitializeComponent();
            //_simulator = new SimulatedAutoReader();
            _obdReader = new ObdNetAutoReader();

            this.DataContext = _vm = new DashboardViewModel(_obdReader);
            //this.configuration.DataContext = new ConfigurationViewModel();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                await _obdReader.Update();
                await _vm.Update();
                await Task.Delay(100);
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await _obdReader.Initialize();
        }
    }
}
