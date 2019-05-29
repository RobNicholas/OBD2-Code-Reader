namespace OBD2_Code_Reader.Models.AutoReaders

{
    public class FuelPressure : IAutoReading
    {
        public FuelPressure(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}

