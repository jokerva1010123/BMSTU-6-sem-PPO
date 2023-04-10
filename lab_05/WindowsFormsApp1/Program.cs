using System;
using System.Windows.Forms;

namespace lab_05
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConnectionArgs connectionArgs = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);

            UserDA userDA = new UserDA(connectionArgs);
            StudentDA studentDA = new StudentDA(connectionArgs);
            ThingDA thingDA = new ThingDA(connectionArgs);
            RoomDA roomDA = new RoomDA(connectionArgs);

            UserServices userServices = new UserServices(userDA);
            RoomServices roomServices = new RoomServices(roomDA);
            StudentServices studentServices = new StudentServices(studentDA, roomDA);
            ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

            GUIAuthManager authManager = new GUIAuthManager(userServices);
            GUIRoomManager roomManager = new GUIRoomManager(roomServices);
            GUIStudentManager studentManager = new GUIStudentManager(studentServices, userServices, roomServices, thingServices);
            GUIThingManager thingManager = new GUIThingManager(thingServices, studentServices, roomServices);

            Application.Run(new AuthWindow(authManager, roomManager, thingManager, studentManager));
        }
    }
}
