using BL;
using DA;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Main
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            //ConnectionArgs connectionArgs = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            var configuration = new ConfigurationBuilder().AddJsonFile("dbsettings.json");
            var config = configuration.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            ConnectionArgs connectionArgs = new ConnectionArgs(connectionString);

            UserDA userDA = new UserDA(connectionArgs);
            StudentDA studentDA = new StudentDA(connectionArgs);
            ThingDA thingDA = new ThingDA(connectionArgs);
            RoomDA roomDA = new RoomDA(connectionArgs);

            UserServices userServices = new UserServices(userDA);
            RoomServices roomServices = new RoomServices(roomDA);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            UserManager userManager = new UserManager(userServices);
            StudentManager studentManager = new StudentManager(userServices, studentServices, roomServices);
            RoomManager roomManager = new RoomManager(roomServices);
            ThingManager thingManager = new ThingManager(thingServices, studentServices, roomServices);

            App app = new App(userManager, studentManager, roomManager, thingManager);
            while(true)
            {
                app.menu();
            }
        }
    }
}