namespace Models
{
    public enum STATUS
    { 
        NOTDONE,
        DONE
    }
    public class RepairReport
    {
        private int id_report;
        private string code_student;
        private int room_number;
        private STATUS status;
        private string info;
        public int Id_report { get => id_report; set => id_report = value; }
        public STATUS Status { get => status; set => status = value; }
        public string Info { get => info; set => info = value; }
        public int Room_number { get => room_number; set => room_number = value; }
        public string Code_student { get => code_student; set => code_student = value; }

        public RepairReport(int id_report, string code_student, int room_number, STATUS status, string info)
        {
            this.id_report = id_report;
            this.code_student = code_student;
            this.room_number = room_number;
            this.status = status;
            this.info = info;
        }
    }
}
