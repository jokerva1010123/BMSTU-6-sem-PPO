using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDB;
using Models;
using BL;
using Error;

namespace Tests.BL
{
    public class TestReportServices : IRepairReportDB
    {
        private List<RepairReport> reports;
        public TestReportServices(List<RepairReport> reports)
        {
            this.reports = reports;
        }
        public void addReport(RepairReport report)
        {
            report.Id_report = this.getAllRepairReport().Count + 1;
            this.reports.Add(report);
        }
        public void changeStatus(int id_report)
        {
            foreach (RepairReport report in this.reports)
                if (report.Id_report == id_report)
                    if (report.Status == STATUS.NOTDONE)
                        report.Status = STATUS.DONE;
                    else
                        throw new ChangeStatusErrorException();
        }
        public RepairReport? getReport(int id_report)
        {
            foreach (RepairReport report in this.reports)
                if (report.Id_report == id_report)
                    return report;
            return null;
        }
        public List<RepairReport> getAllDoneReports()
        {
            List<RepairReport> result = new List<RepairReport>();
            foreach (RepairReport report in this.reports)
                if (report.Status == STATUS.DONE)
                    result.Add(report);
            return result;
        }
        public List<RepairReport> getAllNotDoneReports()
        { 
            List<RepairReport> result = new List<RepairReport>();
            foreach (RepairReport report in this.reports)
                if(report.Status == STATUS.NOTDONE)
                    result.Add(report);
            return result;
        }
        public List<RepairReport> getAllRepairReport()
        {
            return this.reports;
        }
    }
    [TestClass()]
    public class ReportServicesTests
    {
        [TestMethod()]
        public void addReportTest()
        {
            List<RepairReport> reports = new List<RepairReport>
            {
                new RepairReport(1, "123321", 528, STATUS.DONE, "Table is broken"),
                new RepairReport(2, "1234321", 428, STATUS.NOTDONE, "Chair is broken")
            };
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomType.StudentRoom),
                new Room(2, 428, RoomType.StudentRoom),
                new Room(3, 101, RoomType.Storage)
            };
            List<Student> students = new List<Student>
            {
                new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
            };
            TestReportServices testReport = new TestReportServices(reports);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            RepairReportServices reportServices = new RepairReportServices(testReport, testStudent, testRoom);

            reportServices.addReport("1233321", 428, "Bed is broken");

            List<RepairReport> repairReports = reportServices.getAllRepairReport();

            Assert.AreEqual(repairReports.Count, 3);
        }
        [TestMethod()]
        public void changeStatusTest()
        {
            List<RepairReport> reports = new List<RepairReport>
                {
                    new RepairReport(1, "123321", 528, STATUS.DONE, "Table is broken"),
                    new RepairReport(2, "1234321", 428, STATUS.NOTDONE, "Chair is broken")
                };
            List<Room> rooms = new List<Room>
                {
                    new Room(1, 528, RoomType.StudentRoom),
                    new Room(2, 428, RoomType.StudentRoom),
                    new Room(3, 101, RoomType.Storage)
                };
            List<Student> students = new List<Student>
                {
                    new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                    new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                    new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
                };
            TestReportServices testReport = new TestReportServices(reports);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            RepairReportServices reportServices = new RepairReportServices(testReport, testStudent, testRoom);

            reportServices.changeStatus(2);

            List<RepairReport> repairReports = reportServices.getAllRepairReport();

            Assert.AreEqual(repairReports[1].Status, STATUS.DONE);
        }
        [TestMethod()]
        public void getReportTest()
        {
            List<RepairReport> reports = new List<RepairReport>
                {
                    new RepairReport(1, "123321", 528, STATUS.DONE, "Table is broken"),
                    new RepairReport(2, "1234321", 428, STATUS.NOTDONE, "Chair is broken")
                };
            List<Room> rooms = new List<Room>
                {
                    new Room(1, 528, RoomType.StudentRoom),
                    new Room(2, 428, RoomType.StudentRoom),
                    new Room(3, 101, RoomType.Storage)
                };
            List<Student> students = new List<Student>
                {
                    new Student(1, "Alex", "IU7-64", "1234321", 1, DateTime.Parse("06-02-2023"), 1),
                    new Student(2, "Anton", "IU7-63", "123321", 2, DateTime.Parse("07-02-2023"), 2),
                    new Student(3, "Makxim", "IU7-62", "1233321", 2, DateTime.Parse("05-02-2023"), 3)
                };
            TestReportServices testReport = new TestReportServices(reports);
            TestRoomServices testRoom = new TestRoomServices(rooms);
            TestStudentServices testStudent = new TestStudentServices(students);
            RepairReportServices reportServices = new RepairReportServices(testReport, testStudent, testRoom);

            reportServices.getReport(2);

            List<RepairReport> repairReports = reportServices.getAllRepairReport();

            Assert.AreEqual(repairReports[1].Info, "Chair is broken");
        }
    }
}
