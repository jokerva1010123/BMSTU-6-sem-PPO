using BL;
using DA;
using Microsoft.Extensions.Configuration;
using GUIManage;
using WindowsFormsApp1;
using MongoDB;

namespace DesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			var configuration = new ConfigurationBuilder().AddJsonFile("dbsettings.json");
			var config = configuration.Build();
			var useDB = config.GetSection("App").GetSection("UseDB").Value;
            if(useDB is not null && useDB == "MongoDB")
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

					GUILoginManager authManager = new GUILoginManager(userServices);
					GUIRoomManager roomManager = new GUIRoomManager(roomServices);
					GUIStudentManager studentManager = new GUIStudentManager(studentServices, userServices);
					GUIThingManager thingManager = new GUIThingManager(thingServices, studentServices, roomServices);
					GUIReportManager reportManager = new GUIReportManager(reportServices);

					ApplicationConfiguration.Initialize();
					Application.Run(new LoginWindow(authManager, roomManager, thingManager, studentManager, reportManager));
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
			}
            else
            {
                var connectionString = config.GetSection("PostgreSql").GetSection("ConnectionString").Value;
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

                    GUILoginManager authManager = new GUILoginManager(userServices);
                    GUIRoomManager roomManager = new GUIRoomManager(roomServices);
                    GUIStudentManager studentManager = new GUIStudentManager(studentServices, userServices);
                    GUIThingManager thingManager = new GUIThingManager(thingServices, studentServices, roomServices);
                    GUIReportManager reportManager = new GUIReportManager(reportServices);

                    ApplicationConfiguration.Initialize();
                    Application.Run(new LoginWindow(authManager, roomManager, thingManager, studentManager, reportManager));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
			
        }
    }
}

