using GUIManage;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StudentWindow : Form
    {
        private GUIRoomManager roomManager;
        private GUIStudentManager studentManager;
        private GUIThingManager thingManager;
        private GUIReportManager reportManager;
        string studentCode;
        public StudentWindow(GUIRoomManager roomManager, GUIStudentManager studentManager, GUIThingManager thingManager, GUIReportManager reportManager, string studentCode)
        {
            InitializeComponent();
            this.roomManager = roomManager;
            this.studentManager = studentManager;
            this.thingManager = thingManager;
            this.reportManager = reportManager;
            this.studentCode = studentCode;
        }
        private void actionButton_Click(object sender, EventArgs e)
        {
            if (action1.Checked)
            {
                List<Thing> allThing = this.thingManager.getStudentThing(this.studentCode);
                this.dataTable.Rows.Clear();
                this.dataTable.Columns.Clear();
                this.dataTable.Columns.Add("ID", "ID");
                this.dataTable.Columns.Add("CodeThing", "Код вещи");
                this.dataTable.Columns.Add("Type", "Тип");
                this.dataTable.Columns.Add("Room", "Комната");
                foreach (Thing thing in allThing)
                    if (thing.Id_room == 1)
                        this.dataTable.Rows.Add(thing.Id_thing, thing.Code, thing.Type, "В складе");
                    else
                    {
                        Room room = this.roomManager.GetRoom(thing.Id_room);
                        this.dataTable.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
            else if (action2.Checked)
            {
                List<Student> allStudent = this.studentManager.getAllStudent();
                this.dataTable.Rows.Clear();
                this.dataTable.Columns.Clear();
                this.dataTable.Columns.Add("ID", "Id");
                this.dataTable.Columns.Add("Name", "Имя");
                this.dataTable.Columns.Add("Group", "Группа");
                this.dataTable.Columns.Add("Code", "Код студента");
                this.dataTable.Columns.Add("Room", "Комната");
                foreach (Student student in allStudent)
                {
                    string room = (student.Id_room < 1) ? "Не живёт" : roomManager.GetRoom(student.Id_room).Number.ToString();
                    this.dataTable.Rows.Add(student.Id_student, student.Name, student.Group, student.StudentCode, room);
                }
            }
            else
            {
                if (code_student.Text.Length <= 0)
                {
                    MessageBox.Show("Введите код студента!", "Error");
                    return;
                }
                if (room_number.Text.Length <= 0)
                {
                    MessageBox.Show("Введите номер комнаты!", "Error");
                    return;
                }
                if (infor.Text.Length <= 0)
                {
                    MessageBox.Show("Введите информацию заявления!", "Error");
                    return;
                }
                int roomNumber;
                bool check = int.TryParse(room_number.Text, out roomNumber);
                if (check == false)
                {
                    MessageBox.Show("Введите номер комнаты еще раз!", "Error");
                    return;
                }
                string codeStudent = code_student.Text;
                string information = infor.Text;
                try
                {
                    this.reportManager.addReport(codeStudent, roomNumber, information);
                    MessageBox.Show("Удалось добавить новое заявление.", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void action3_CheckedChanged(object sender, EventArgs e)
        {
            if (action3.Checked)
                this.groupBox2.Visible = true;
            else this.groupBox2.Visible = false;
        }
    }
}
