using BL;
using DA;
using Microsoft.Extensions.Configuration;
using GUIManage;
using WindowsFormsApp1;

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
            var connectionString = config.GetConnectionString("DefaultConnection");
            ConnectionArgs connectionArgs = new ConnectionArgs(connectionString);
            try
            {
                UserDA userDA = new UserDA(connectionArgs);
                StudentDA studentDA = new StudentDA(connectionArgs);
                ThingDA thingDA = new ThingDA(connectionArgs);
                RoomDA roomDA = new RoomDA(connectionArgs);

                UserServices userServices = new UserServices(userDA);
                RoomServices roomServices = new RoomServices(roomDA);
                StudentServices studentServices = new StudentServices(studentDA, roomDA);
                ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

                GUILoginManager authManager = new GUILoginManager(userServices);
                GUIRoomManager roomManager = new GUIRoomManager(roomServices);
                GUIStudentManager studentManager = new GUIStudentManager(studentServices, userServices);
                GUIThingManager thingManager = new GUIThingManager(thingServices, studentServices, roomServices);

                ApplicationConfiguration.Initialize();
                Application.Run(new LoginWindow(authManager, roomManager, thingManager, studentManager));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}

