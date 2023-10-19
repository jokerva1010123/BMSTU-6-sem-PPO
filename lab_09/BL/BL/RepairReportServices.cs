using Models;
using InterfaceDB;
using NLog;
using Error;
using System.Collections.Generic;

namespace BL
{
    public class RepairReportServices
    {
        private IRepairReportDB irepairDB;
        private readonly IStudentDB istudentDB;
        private readonly IRoomDB iroomDB;
        public IRepairReportDB IrepairDB { get => irepairDB; set => irepairDB = value; }

        public RepairReportServices(IRepairReportDB irepairDB, IStudentDB studentDB, IRoomDB roomDB)
        {
            this.IrepairDB = irepairDB;
            this.iroomDB = roomDB;
            this.istudentDB = studentDB;
        }
        public void addReport(string code_student, int room_number, string info)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            int id_student = this.istudentDB.getIdStudentFromCode(code_student);
            if (id_student <= 0) 
            {
                log.Info("User adds new report unsuccessfully.");
                throw new StudentNotFoundException();
            }
            List<Room> rooms = this.iroomDB.getAllRoom();
            int flag = 0;
            foreach (Room room in rooms)
                if (room.Number == room_number)
                    flag = 1;
            if (flag == 0)
            {
                log.Info("User adds new report unsuccessfully.");
                throw new RoomNotFoundException();
            }
            this.irepairDB.addReport(new RepairReport(-1, code_student, room_number, 0, info));
            log.Info("User adds new report successfully.");
        }
        public void changeStatus(int id_report)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            List<RepairReport> reports = this.irepairDB.getAllRepairReport();
            foreach (RepairReport repair in reports)
                if (repair.Id_report == id_report)
                {
                    if (repair.Status == STATUS.DONE)
                    {
                        log.Info("User changes report's status unsuccessfully.");
                        throw new ChangeStatusErrorException();
                    }
                    else
                    {
                        this.irepairDB.changeStatus(id_report);
                        log.Info("User adds new report successfully.");
                    }
                    return;
                }
            log.Info("User changes report's status unsuccessfully.");
            throw new ReportNotFoundException();
        }
        public RepairReport? getReport(int id_report)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            RepairReport? report = this.irepairDB.getReport(id_report);
            if (report == null)
            {
                log.Info("User sees report's infomations by code unsuccessfully.");
                throw new ReportNotFoundException();
            }
            log.Info("User sees report's infomations by code successfully.");
            return report;
        }
        public List<RepairReport> getReportByRoom(int room_number)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            List<Room> rooms = this.iroomDB.getAllRoom();
            int flag = 0;
            foreach (Room room in rooms)
                if (room.Number == room_number)
                    flag = 1;
            if (flag == 0)
            {
                log.Info("User sees report's infomations by room's number unsuccessfully.");
                throw new RoomNotFoundException();
            }
            List <RepairReport> allreports = this.irepairDB.getAllRepairReport();
            List <RepairReport> result = new List<RepairReport>();
            foreach (RepairReport report in allreports)
                if(report.Room_number == room_number)
                    result.Add(report);
            return result;
        }
        public List<RepairReport> getReportByStudent(string code_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            int id_student = this.istudentDB.getIdStudentFromCode(code_student);
            if (id_student <= 0)
            {
                log.Info("User sees report's infomations by student's code unsuccessfully.");
                throw new StudentNotFoundException();
            }
            List<RepairReport> allreports = this.irepairDB.getAllRepairReport();
            List<RepairReport> result = new List<RepairReport>();
            foreach (RepairReport report in allreports)
                if (report.Code_student == code_student)
                    result.Add(report);
            return result;
        }
        public List<RepairReport> getAllDoneReports()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User sees all done report successfully.");
            return this.irepairDB.getAllDoneReports();
        }
        public List<RepairReport> getAllNotDoneReports()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User sees all not done report successfully.");
            return this.irepairDB.getAllNotDoneReports();
        }
        public List<RepairReport> getAllRepairReport()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User sees all report successfully.");
            return this.irepairDB.getAllRepairReport();
        }
    }
}
