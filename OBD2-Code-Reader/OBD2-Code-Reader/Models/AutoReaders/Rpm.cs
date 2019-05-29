namespace OBD2_Code_Reader.Models.AutoReaders

{
    public class Rpm : IAutoReading
    {
          public Rpm(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
