using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Error;
using Models;
using DA;
using BL;
using InterfaceDB;
using System.Data;

namespace Tests.DA
{
    [TestClass()]
    public class ReportDATests
    {
        [TestMethod()]
        public void getRoomTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            StudentDA studentDA = new StudentDA(args);
            RepairReportDA reportDA = new RepairReportDA(args);
            RepairReportServices reportServices = new RepairReportServices(reportDA, studentDA, roomDA);

            RepairReport? report = reportServices.getReport(1);
            Assert.AreEqual(report.Info, "Table is broken");
        }
        [TestMethod()]
        public void addReportTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            RoomServices roomServices = new RoomServices(roomDA);

            roomServices.addRoom(new Room(713, RoomType.StudentRoom));

            NpgsqlCommand command = new NpgsqlCommand(roomDA.getStrGetRoom(13), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomType)reader.GetInt32(2));
            reader.Close();

            Assert.AreEqual(room.Number, 713);
            Assert.AreEqual(room.RoomTypes, RoomType.StudentRoom);

            command = new NpgsqlCommand("delete from Rooms where number = 713", roomDA.Connector);
            command.ExecuteNonQuery();
        }
        [TestMethod()]
        public void changeStatusTest()
        {
            ConnectionArgs args = GetConnectArgs.getarg();
            RoomDA roomDA = new RoomDA(args);
            StudentDA studentDA = new StudentDA(args);
            RepairReportDA reportDA = new RepairReportDA(args);
            RepairReportServices reportServices = new RepairReportServices(reportDA, studentDA, roomDA);

            reportServices.changeStatus(2);

            NpgsqlCommand command = new NpgsqlCommand(reportDA.getStrChangeStatus(2), reportDA.Connector);
            command.ExecuteNonQuery();
            List<RepairReport> allReport = reportServices.getAllRepairReport();
            Assert.AreEqual(allReport[1].Status, STATUS.DONE);
            command = new NpgsqlCommand("update Reports set status = 0 where id_report = 2", roomDA.Connector);
            command.ExecuteNonQuery();
        }
    }
}