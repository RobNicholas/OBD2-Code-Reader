using System.Threading.Tasks;

namespace OBD2_Code_Reader.Models
{
        public interface IAutoReader
        {
            Task<T> Get<T>() where T : IAutoReading;

        } 
}
