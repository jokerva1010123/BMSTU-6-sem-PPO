using Models;
using BL;

namespace Main
{
    public class ReportManager
    {
        private RepairReportServices reportServices;

        public ReportManager(RepairReportServices reportServices)
        {
            this.reportServices = reportServices;
        }

        public void addReport()
        {
            Console.Write("Введите код студента: ");
            string code_student = Console.ReadLine();

            Console.Write("Введите номер комнаты: ");
            int room_number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите информации: ");
            string info = Console.ReadLine();

            try
            {
                this.reportServices.addReport(code_student, room_number, info);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void changeStatus()
        {
            Console.Write("Введите id заявдения: ");
            int id_report = Convert.ToInt32(Console.ReadLine());

            try
            {
                this.reportServices.changeStatus(id_report);
                Console.WriteLine("Все хорошо.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getReport()
        {
            Console.Write("Введите id заявдения: ");
            int id_report = Convert.ToInt32(Console.ReadLine());

            try
            {
                RepairReport report = this.reportServices.getReport(id_report);
                Console.WriteLine("ID_Report: " + report.Id_report + 
                    "\nКод студента: " + report.Code_student+ "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                if (report.Status == STATUS.DONE)
                    Console.WriteLine("Статус: Все хорошо");
                else Console.WriteLine("Статус: Плохо");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getReportByRoom()
        {
            Console.Write("Введите номер комнаты: ");
            int room_number = Convert.ToInt32(Console.ReadLine());

            try
            {
                List<RepairReport> allreport = this.reportServices.getReportByRoom(room_number);
                foreach (RepairReport report in allreport)
                {
                    Console.WriteLine("ID_Report: " + report.Id_report +
                    "\nКод студента: " + report.Code_student + "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                    if (report.Status == STATUS.DONE)
                        Console.WriteLine("Статус: Все хорошо");
                    else Console.WriteLine("Статус: Плохо");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getReportByStudent()
        {
            Console.Write("Введите код студент: ");
            string code_student = Console.ReadLine();

            try
            {
                List<RepairReport> allreport = this.reportServices.getReportByStudent(code_student);
                foreach(RepairReport report in allreport)
                {
                    Console.WriteLine("ID_Report: " + report.Id_report +
                    "\nКод студента: " + report.Code_student + "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                    if (report.Status == STATUS.DONE)
                        Console.WriteLine("Статус: Все хорошо");
                    else Console.WriteLine("Статус: Плохо");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void viewAllReport()
        {
            try
            {
                List<RepairReport> allreport = this.reportServices.getAllRepairReport();
                foreach (RepairReport report in allreport)
                {
                    Console.WriteLine("ID_Report: " + report.Id_report +
                    "\nКод студента: " + report.Code_student + "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                    if (report.Status == STATUS.DONE)
                        Console.WriteLine("Статус: Все хорошо");
                    else Console.WriteLine("Статус: Плохо");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void viewAllDoneReport()
        {
            try
            {
                List<RepairReport> allreport = this.reportServices.getAllDoneReports();
                foreach (RepairReport report in allreport)
                {
                    Console.WriteLine("ID_Report: " + report.Id_report +
                    "\nКод студента: " + report.Code_student + "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                    if (report.Status == STATUS.DONE)
                        Console.WriteLine("Статус: Все хорошо");
                    else Console.WriteLine("Статус: Плохо");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void viewAllNotDoneReport()
        {
            try
            {
                List<RepairReport> allreport = this.reportServices.getAllNotDoneReports();
                foreach (RepairReport report in allreport)
                {
                    Console.WriteLine("ID_Report: " + report.Id_report +
                    "\nКод студента: " + report.Code_student + "\nНомер комнаты: " + report.Room_number +
                    "\nСтатус: " + "\nИнформация: " + report.Info);
                    if (report.Status == STATUS.DONE)
                        Console.WriteLine("Статус: Все хорошо");
                    else Console.WriteLine("Статус: Плохо");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
