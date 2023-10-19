using BL;
using DA;
using Microsoft.Extensions.Configuration;
using System.Text;
using MongoDB;
using Models;

namespace Main
{
	internal static class Program
    {
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var configuration = new ConfigurationBuilder().AddJsonFile("dbsettings.json");
            var config = configuration.Build();
            var useDB = config.GetSection("App").GetSection("UseDB").Value;
                 

            if (useDB is not null && useDB == "MongoDB")
            {
				var connectionString = config.GetSection("MongoDB").GetSection("ConnectionString").Value;
				try
				{
					UserMongo userMongo = new UserMongo(connectionString);
					ThingMongo thingMongo = new ThingMongo(connectionString);
					StudentMongo studentMongo = new StudentMongo(connectionString);
					RoomMongo roomMongo = new RoomMongo(connectionString);
					ReportMongo reportMongo = new ReportMongo(connectionString);

					UserServices userServices = new UserServices(userMongo);
					ThingServices thingServices = new ThingServices(thingMongo, roomMongo, studentMongo);
					RoomServices roomServices = new RoomServices(roomMongo);
					StudentServices studentServices = new StudentServices(studentMongo, roomMongo);
					RepairReportServices reportServices = new RepairReportServices(reportMongo, studentMongo, roomMongo);

					UserManager userManager = new UserManager(userServices);
					StudentManager studentManager = new StudentManager(userServices, studentServices);
					RoomManager roomManager = new RoomManager(roomServices);
					ThingManager thingManager = new ThingManager(thingServices, studentServices, roomServices);
					ReportManager reportManager = new ReportManager(reportServices);

					App app = new App(userManager, studentManager, roomManager, thingManager, reportManager);
					while (true)
					{
						app.menu();
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
			}
            else
            {
				var connectionString = config.GetSection("PostgreSql").GetConnectionString("ConnectionString");
				ConnectionArgs connectionArgs = new ConnectionArgs(connectionString);
				try
				{
					UserDA userDA = new UserDA(connectionArgs);
					StudentDA studentDA = new StudentDA(connectionArgs);
					ThingDA thingDA = new ThingDA(connectionArgs);
					RoomDA roomDA = new RoomDA(connectionArgs);
					RepairReportDA reportDA = new RepairReportDA(connectionArgs);

					UserServices userServices = new UserServices(userDA);
					RoomServices roomServices = new RoomServices(roomDA);
					StudentServices studentServices = new StudentServices(studentDA, roomDA);
					ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);
					RepairReportServices reportServices = new RepairReportServices(reportDA, studentDA, roomDA);

					UserManager userManager = new UserManager(userServices);
					StudentManager studentManager = new StudentManager(userServices, studentServices);
					RoomManager roomManager = new RoomManager(roomServices);
					ThingManager thingManager = new ThingManager(thingServices, studentServices, roomServices);
					ReportManager reportManager = new ReportManager(reportServices);

					App app = new App(userManager, studentManager, roomManager, thingManager, reportManager);
					while (true)
					{
						app.menu();
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
			}
        }
    }
}