using System;
using System.Windows.Forms;
using BL;
using DA;
using GUIManage;
using WindowsFormsApp1;

namespace Main
{
    internal static class Program
    {
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

            GUILoginManager authManager = new GUILoginManager(userServices);
            GUIRoomManager roomManager = new GUIRoomManager(roomServices);
            GUIStudentManager studentManager = new GUIStudentManager(studentServices, userServices);
            GUIThingManager thingManager = new GUIThingManager(thingServices, studentServices, roomServices);

            Application.Run(new LoginWindow(authManager, roomManager, thingManager, studentManager));
        }
    }
}
