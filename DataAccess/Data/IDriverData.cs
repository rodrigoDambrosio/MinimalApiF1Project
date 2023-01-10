using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IDriverData
    {
        Task DeleteDriver(int id);
        Task<DriverModel?> GetDriver(int id);
        Task<IEnumerable<DriverModel>> GetDrivers();
        Task InsertDriver(DriverModel driver);
        Task UpdateDriver(DriverModel driver);
    }
}
