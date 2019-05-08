using OBD2_Code_Reader.Models;

namespace OBD2_Code_Reader.Models.AutoReaders
{
    public class Fuel : IAutoReading
    {       
            public Fuel(int value)
            {
                Value = value;
            }

            public int Value { get; }
        
    }
}
