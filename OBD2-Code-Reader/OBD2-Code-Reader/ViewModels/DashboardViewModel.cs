using GalaSoft.MvvmLight;
using OBD2_Code_Reader.Models;
using OBD2_Code_Reader.Models.AutoReaders;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _rpms;
        private int _fuel;

        public DashboardViewModel(IAutoReader reader)
        {
            AutoReader = reader;          
        }        

        public IAutoReader AutoReader { get; set; }

        public int Rpm
        {
            get => _rpms;
            set => Set(ref _rpms, value);
        }


        public int Fuel
        {
            get => _fuel;
            set => Set(ref _fuel, value);
        }

        public async Task Update()
        {
            try
            {
                Rpm = (await AutoReader.Get<Rpm>())?.Value ?? 0;               
            }
            catch (Exception ex)
            {
                // intentionally ignore for now
            }
        }
    }
}
