using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MinimalApiProject;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // API endpoint mapping
        app.MapGet("/Drivers", GetDrivers);
        app.MapGet("/Drivers/{id}", GetDriver);
        app.MapGet("/DriversImage/{id}", GetDriverImage);
        app.MapPost("/Drivers", InsertDriver);
        app.MapPut("/Drivers", UpdateDriver);
        app.MapDelete("/Drivers", DeleteDriver);
    }
    private static async Task<IResult> GetDriverImage(int id, IDriverData data)
    {
        // This just returns the jpg

        //var mimeType = "image/jpg";
        //var path = @"Alonso.jpg";
        //return Results.File(path, contentType: mimeType);

        // This returns a string with the path to the jpg
        try
        {
            return Results.Ok(await data.GetDriverImagePath(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetDrivers(IDriverData data)
    {
        try
        {
            return Results.Ok(await data.GetDrivers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetDriver(int id, IDriverData data)
    {
        try
        {
            var results = (await data.GetDriver(id));
            if (results == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(results);

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertDriver(DriverModel driver, IDriverData data)
    {
        try
        {
            await data.InsertDriver(driver);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateDriver(DriverModel driver, IDriverData data)
    {
        try
        {
            await data.UpdateDriver(driver);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteDriver(int id, IDriverData data)
    {
        try
        {
            await data.DeleteDriver(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
