using BL;
using Models;

namespace GUIManage
{
    public class GUIReportManager
    {
        private RepairReportServices reportServices;
        public GUIReportManager(RepairReportServices reportServices)
        {
            this.reportServices = reportServices;
        }

        public void addReport(string codeStudent, int roomNumber, string info)
        {
            this.reportServices.addReport(codeStudent, roomNumber, info);
        }
        public void changeStatus(int id_report)
        {
            this.reportServices.changeStatus(id_report);
        }
        public List<RepairReport> getAllReport()
        {
            return this.reportServices.getAllRepairReport();
        }
        public List<RepairReport> getAllDoneReport()
        {
            return this.reportServices.getAllDoneReports();
        }
        public List<RepairReport> getAllNotDoneReport()
        {
            return this.reportServices.getAllNotDoneReports();
        }
    }
}
