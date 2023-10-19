using Error;
using InterfaceDB;
using Models;
using NLog;
using Npgsql;

namespace DA
{
    public class RepairReportDA : IRepairReportDB
    {
        private string connectString;
        private NpgsqlConnection connector;

        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public RepairReportDA(ConnectionArgs Args)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            this.connectString = Args.getString();
            this.Connector = new NpgsqlConnection(this.connectString);
            if (this.Connector == null)
            {
                log.Error("No database error!");
                throw new DataBaseConnectException();
            }
            try
            {
                this.Connector.Open();
            }
            catch (Exception ex)
            {
                log.Error("Can't access database!");
            }
        }
        public void addReport(RepairReport report)
        {
            ConnectionCheck.checkConnection(this.Connector);
            report.Id_report = this.getAllRepairReport().Count + 1;
            string sql = getStrAddReport(report);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public void changeStatus(int id_report)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = getStrChangeStatus(id_report);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public RepairReport? getReport(int id_report)
        {
            ConnectionCheck.checkConnection(this.Connector);
            RepairReport? report = null;
            string sql = getStrGetReport(id_report);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                report = new RepairReport(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), 
                    (STATUS)reader.GetInt32(3), reader.GetString(4));
            }
            reader.Close();
            return report;
        }
        public List<RepairReport> getAllDoneReports()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<RepairReport> allReports = new List<RepairReport>();
            string sql = getStrGetAllDoneReports();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RepairReport report = new RepairReport(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                    (STATUS)reader.GetInt32(3), reader.GetString(4));
                    allReports.Add(report);
                }
            }
            reader.Close();
            return allReports;
        }
        public List<RepairReport> getAllNotDoneReports()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<RepairReport> allReports = new List<RepairReport>();
            string sql = getStrGetAllNotDoneReports();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RepairReport report = new RepairReport(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                    (STATUS)reader.GetInt32(3), reader.GetString(4));
                    allReports.Add(report);
                }
            }
            reader.Close();
            return allReports;
        }
        public List<RepairReport> getAllRepairReport()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<RepairReport> allReports = new List<RepairReport>();
            string sql = getStrGetAllRepairReport();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RepairReport report = new RepairReport(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                    (STATUS)reader.GetInt32(3), reader.GetString(4));
                    allReports.Add(report);
                }
            }
            reader.Close();
            return allReports;
        }
        private string getStrAddReport(RepairReport report)
        {
            return "insert into Reports(id_report, code_student, room_number, status, information) values ("
                + report.Id_report.ToString() + ", '" + report.Code_student + "', " + report.Room_number
                + ", 0, '" + report.Info + "' );";
        }
        public string getStrChangeStatus(int id_report)
        {
            return "update Reports set status = 1 where id_report = " + id_report;
        }
        private string getStrGetReport(int id_report)
        {
            return "select * from Reports where id_report = " + id_report;
        }
        private string getStrGetReportByRoom(int room_number)
        {
            return "select * from Reports where room_numver = " + room_number;
        }
        private string getStrGetReportByStudent(string code_student)
        {
            return "select * from Reports where code_student = " + code_student;
        }
        private string getStrGetAllDoneReports()
        {
            return "select * from Reports where status = 1";
        }
        private string getStrGetAllNotDoneReports()
        {
            return "select * from Reports where status = 0";
        }
        private string getStrGetAllRepairReport()
        {
            return "select * from Reports";
        }
    }
}
