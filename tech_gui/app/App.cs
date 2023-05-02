using Models;

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
            Console.Write(MENU);
            int command = Convert.ToInt32(Console.ReadLine());
            switch(command)
            {
                case 0:
                    Environment.Exit(0);
                    break;  
                case 1:
                    if (this.role != Levels.NONE)
                        this.role = Levels.NONE;
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 2:
                    if(this.role == Levels.NONE)
                    {
                        Levels levels = this.userManager.tryAuthorize();
                        if(levels == Levels.STUDENT)
                        {
                            int id = this.userManager.getIdUser(this.userManager.Login);
                            this.studentCode = this.studentManager.getStudentByIdUser(id);
                        }
                        this.role = levels;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                    break;
                case 3:
                    if (this.role != Levels.NONE)
                        this.studentManager.viewAllStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 4:
                    if (this.role != Levels.NONE)
                        this.studentManager.viewStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 5:
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.addStudent();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 6:
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.changeStudentGroup();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 7:
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.setRoom();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 8:
                    if (this.role == Levels.KAMEDAN)
                        this.studentManager.returnRoom();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 9:
                    if (this.role != Levels.NONE)
                        this.thingManager.viewAllThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 10:
                    if(this.role == Levels.MANAGER)
                        this.thingManager.viewFreeThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 11:
                    if (this.role == Levels.MANAGER)
                        this.thingManager.addNewThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 12:
                    if (this.role == Levels.MANAGER)
                        this.thingManager.giveStudentThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 13:
                    if (this.role == Levels.MANAGER)
                        this.thingManager.returnStudentThing();
                    else
                        Console.WriteLine("Эту команду невозможно выполнить в текущем статусе!");
                    break;
                case 14:
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
