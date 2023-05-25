using Models;
using NLog;

namespace Main
{
    internal class App
    {
        private StudentManager studentManager;
        private ThingManager thingManager;
        private RoomManager roomManager;
        private UserManager userManager;
        private Levels role;
        private string studentCode;
        string MENU = "\n0.Выйти из программы.\n1.Выйти из аккаунта.\n2.Войти в аккаунт.\n3.Посмотреть список студентов.\n" +
            "4.Посмотреть детали студента.\n5.Добавить нового студента.\n6.Изменить группу студента.\n7.Заселить студента.\n" +
            "8.Выселить студента.\n9.Посмотреть список вещей.\n10.Посмотреть список свободных вещей.\n11.Добавить новую вещь.\n" +
            "12.Выдать новую вещь студенту.\n13. Забрать вещь у студента.\n14.Посмотреть список вещей студента\n15.Посмотреть список комнат\nВведите команду: ";
        public App(UserManager userManager, StudentManager studentManager, RoomManager roomManager, ThingManager thingManager)
        {
            this.userManager = userManager;
            this.studentManager = studentManager;
            this.roomManager = roomManager;
            this.thingManager = thingManager;
            this.role = Levels.NONE;
            this.studentCode = "";
        }
        public void menu()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Console.Write(MENU);
            int command = Convert.ToInt32(Console.ReadLine());
            switch(command)
            {
                case 0:
                    log.Info("User exit.");
                    Environment.Exit(0);
                    break;  
                case 1:
                    if (this.role != Levels.NONE)
                    {
                        log.Info("User logout successfully.");
                        this.role = Levels.NONE;
                    }
                    else
                    {
                        log.Info("User logout unsuccessfully");
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    }
                    break;
                case 2:
                    log.Info("User login.");
                    if(this.role == Levels.NONE)
                    {
                        Levels levels = this.userManager.tryAuthorize();
                        if(levels == Levels.STUDENT)
                        {
                            int id = this.userManager.getIdUser(this.userManager.Login);
                            this.studentCode = this.studentManager.getStudentByIdUser(id);
                        }
                        this.role = levels;
                        log.Info("User login successfully.");
                    }
                    else
                    {
                        log.Info("User login failed.");
                        Console.WriteLine("Error");
                    }
                    break;
                case 3:
                    log.Info("User views all students.");
                    if (this.role != Levels.NONE)
                        this.studentManager.viewAllStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 4:
                    log.Info("User views student's informations.");
                    if (this.role != Levels.NONE)
                        this.studentManager.viewStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 5:
                    log.Info("User adds new student.");
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.addStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 6:
                    log.Info("User changes student's group.");
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.changeStudentGroup();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 7:
                    log.Info("User sets room for student.");
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.setRoom();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 8:
                    log.Info("User gets room from student.");
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.returnRoom();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 9:
                    log.Info("User views all things.");
                    if (this.role != Levels.NONE)
                        this.thingManager.viewAllThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 10:
                    log.Info("User views all free things.");
                    if(this.role == Levels.MANAGER)
                        this.thingManager.viewFreeThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 11:
                    log.Info("User adds new thing.");
                    if (this.role == Levels.MANAGER)
                        this.thingManager.addNewThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 12:
                    log.Info("User gives thing to student.");
                    if (this.role == Levels.MANAGER)
                        this.thingManager.giveStudentThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 13:
                    log.Info("User gets thing from student.");
                    if (this.role == Levels.MANAGER)
                        this.thingManager.returnStudentThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 14:
                    log.Info("User views student's things.");
                    if(this.role == Levels.MANAGER || this.role == Levels.KAMEDAN)
                    {
                        this.thingManager.viewStudentThing();
                    }
                    else if (this.role == Levels.STUDENT)
                    {
                        this.thingManager.viewStudentThingForStudent(this.studentCode);
                    }
                    else
                    {
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    }
                    break;
                case 15:
                    log.Info("User views all rooms.");
                    if (this.role != Levels.NONE)
                        this.roomManager.printAllRoom();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                default:
                    Console.WriteLine("Такой команды не существует!\nВведите заново!");
                    break;
            }
        }
    }
}
