using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OBD.NET.Common.Devices;
using OBD.NET.Common.OBDData;
using OBD.NET.Communication;
using OBD2_Code_Reader.Models;
using OBD2_Code_Reader.Models.AutoReaders;

namespace AutoDashboard.UniversalApp.AutoReaders
{
    class ObdNetAutoReader : IAutoReader, IDisposable
    {
        private BluetoothSerialConnection _connection;
        private ELM327 _dev;
        private bool _isRunning = false;

        private int _rpmValue;
        private int _coolantTemp;
        private int _fuelPressure;
        //private int _fuelTankLevelInput;

        public async Task Initialize()
        {
            if (_isRunning) return;

            _connection = new BluetoothSerialConnection("SPP");
            _dev = new ELM327(_connection);
            await _dev.InitializeAsync();
            _isRunning = true;
        }

        public void Dispose()
        {
            _isRunning = false;
            _dev?.Dispose();
            _dev = null;
            _connection?.Dispose();
            _connection = null;
        }

        public async Task Update()
        {
            if (!_isRunning)
                return;

            var dataRpm = await _dev.RequestDataAsync<EngineRPM>();
            if (dataRpm != null)
            {
                _rpmValue = dataRpm.Rpm;
            }


            var dataCoolantTemp = await _dev.RequestDataAsync<EngineCoolantTemperature>();
            if (dataCoolantTemp != null)
            {
                _rpmValue = dataCoolantTemp.Temperature;
            }

            var dataFuelPressure = await _dev.RequestDataAsync<OBD.NET.Common.OBDData.FuelPressure>();
            if (dataFuelPressure != null)
            {
                _rpmValue = dataFuelPressure.Pressure;
            }

            //var dataFuelLevel = await _dev.RequestDataAsync<FuelTankLevelInput>();
            //if (dataCoolantTemp != null)
            //{
            //    _rpmValue = dataCoolantTemp.Level;
            //}
        }

        public Task<T> Get<T>() where T : IAutoReading
        {
            if (!_isRunning)
            {
                return null;
            }

            if (typeof(T) == typeof(Rpm))
            {
                return Task.FromResult(new Rpm(_rpmValue)) as Task<T>;
            }

            if (typeof(T) == typeof(CoolantTemp))
            {
                return Task.FromResult(new CoolantTemp(_coolantTemp)) as Task<T>;
            }

            if (typeof(T) == typeof(OBD2_Code_Reader.Models.AutoReaders.FuelPressure))
            {
                return Task.FromResult(new OBD2_Code_Reader.Models.AutoReaders.FuelPressure(_fuelPressure)) as Task<T>;
            }

            return null;
        }
    }
}
