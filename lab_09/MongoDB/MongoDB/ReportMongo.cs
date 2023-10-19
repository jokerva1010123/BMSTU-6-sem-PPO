using InterfaceDB;
using Models;
using MongoDB.Driver;

namespace MongoDB
{
	public class ReportMongo : IRepairReportDB
	{
		private string connectionString = "";
		private const string database = "PPO";
		private const string ReportCollection = "Reports";
		private readonly IMongoCollection<RepairReport> reportCollection;

		public ReportMongo(string connectionString)
		{
			this.connectionString = connectionString;
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(database);
			reportCollection = db.GetCollection<RepairReport>(ReportCollection);
		}
		public void addReport(RepairReport report)
		{
			report.Id_report = getAllRepairReport().Count + 1;
			reportCollection.InsertOne(report);
		}
		public List<RepairReport> getAllRepairReport()
		{
			var projection = Builders<RepairReport>.Projection.Exclude("_id");
			var all = reportCollection.Find(_ => true).Project(projection).ToList();
			List<RepairReport> reports = new List<RepairReport>();
			foreach (var report in all)
				reports.Add(new RepairReport(report["Id_report"].ToInt32(), report["Code_student"].ToString(),
					report["Room_number"].ToInt32(), (STATUS)report["Status"].ToInt32(), report["Info"].ToString()));
			return reports;
		}
		public RepairReport getReport(int id_report)
		{
			var projection = Builders<RepairReport>.Projection.Exclude("_id");
			var report = reportCollection.Find(r=> r.Id_report == id_report).Project(projection).ToList();
			if (report == null) return null;
			return new RepairReport(report[0]["Id_report"].ToInt32(), report[0]["Code_student"].ToString(),
					report[0]["Room_number"].ToInt32(), (STATUS)report[0]["Status"].ToInt32(), report[0]["Info"].ToString());
		}
		public void changeStatus(int id_report)
		{
			var filter = Builders<RepairReport>.Filter.Eq(r => r.Id_report, id_report);
			var update = Builders<RepairReport>.Update.Set(r => r.Status, STATUS.DONE);
			reportCollection.UpdateOne(filter, update);
		}
		public List<RepairReport> getAllDoneReports()
		{
			var projection = Builders<RepairReport>.Projection.Exclude("_id");
			var all = reportCollection.Find(r=> r.Status == STATUS.DONE).Project(projection).ToList();
			List<RepairReport> reports = new List<RepairReport>();
			foreach (var report in all)
				reports.Add(new RepairReport(report["Id_report"].ToInt32(), report["Code_student"].ToString(),
					report["Room_number"].ToInt32(), (STATUS)report["Status"].ToInt32(), report["Info"].ToString()));
			return reports;
		}
		public List<RepairReport> getAllNotDoneReports()
		{
			var projection = Builders<RepairReport>.Projection.Exclude("_id");
			var all = reportCollection.Find(r => r.Status == STATUS.NOTDONE).Project(projection).ToList();
			List<RepairReport> reports = new List<RepairReport>();
			foreach (var report in all)
				reports.Add(new RepairReport(report["Id_report"].ToInt32(), report["Code_student"].ToString(),
					report["Room_number"].ToInt32(), (STATUS)report["Status"].ToInt32(), report["Info"].ToString()));
			return reports;
		}
	}
}
