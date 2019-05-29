namespace OBD2_Code_Reader.Models.AutoReaders
{
    public class VIN : IAutoReading
    {
        public VIN(string value)
        {
            Value = value;
        }

        public string Value { get; }

    }
}
