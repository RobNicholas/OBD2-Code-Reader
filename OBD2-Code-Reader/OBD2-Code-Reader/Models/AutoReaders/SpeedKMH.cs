namespace OBD2_Code_Reader.Models.AutoReaders
{ 
    public class Speed : IAutoReading
    {
        public Speed(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public int ConvertToMPH()
        {
            return (int)(Value * 0.621371);
        }

    }
}
