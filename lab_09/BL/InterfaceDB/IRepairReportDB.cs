using Models;

namespace InterfaceDB
{
    public interface IRepairReportDB
    {
        void addReport(RepairReport report);
        void changeStatus(int id_report);
        RepairReport? getReport(int id_report);
        List<RepairReport> getAllDoneReports();
        List<RepairReport> getAllNotDoneReports();
        List<RepairReport> getAllRepairReport();
    }
}