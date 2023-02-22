using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

// Here we talk to get data, not the db access directly
public class DriverData : IDriverData
{
    private readonly ISqlDataAccess _db;

    public DriverData(ISqlDataAccess db)
    {
        _db = db;
    }


    public Task<IEnumerable<DriverModel>> GetDrivers() =>
        _db.LoadData<DriverModel, dynamic>(storeProcedure: "dbo.sp_GetAllDrivers", new { });

    // _db etc returns Task of IEnumerable, GetDrivers receives that

    public async Task<DriverModel?> GetDriver(int id)
    {
        var results = await _db.LoadData<DriverModel, dynamic>(
            storeProcedure: "dbo.sp_GetDriverById",
            new { Id = id });
        return results.FirstOrDefault(); // first record or default value for driver model (null)
    }

    public async Task InsertDriver(DriverModel driver) =>
        await _db.SaveData(storeProcedure: "dbo.sp_InsertDriver", new { driver.FirstName, driver.LastName, driver.Number, driver.PhotoPath });

    public async Task UpdateDriver(DriverModel driver) =>
        await _db.SaveData(storeProcedure: "dbo.sp_UpdateDriver", driver);

    public async Task DeleteDriver(int id) =>
        await _db.SaveData(storeProcedure: "dbo.sp_DeleteDriver", new { Id = id });

    public async Task<string?> GetDriverImagePath(int id)
    {
        var results = await _db.LoadData<string, dynamic>(
            storeProcedure: "dbo.sp_GetDriverPhotoPath",
            new { Id = id });
        return results.FirstOrDefault(); // first record or default value for driver model (null)
    }

}
