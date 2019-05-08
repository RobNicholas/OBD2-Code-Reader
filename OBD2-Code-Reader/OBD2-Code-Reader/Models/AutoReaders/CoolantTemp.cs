namespace OBD2_Code_Reader.Models.AutoReaders
{
    public class CoolantTemp : IAutoReading
    {
        public CoolantTemp(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
