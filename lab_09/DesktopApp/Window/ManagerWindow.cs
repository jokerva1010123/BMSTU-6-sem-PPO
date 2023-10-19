using Error;
using GUIManage;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ManagerWindow : Form
    {
        private GUIStudentManager studentManager;
        private GUIThingManager thingManager;
        private GUIRoomManager roomManager;
        private GUIReportManager reportManager;
        public ManagerWindow(GUIStudentManager studentManager, GUIThingManager thingManager, GUIRoomManager roomManager, GUIReportManager reportManager)
        {
            InitializeComponent();
            this.studentManager = studentManager;
            this.thingManager = thingManager;
            this.roomManager = roomManager;
            this.reportManager = reportManager;
        }
        private void actionButton_Click(object sender, System.EventArgs e)
        {
            if (actionButton1.Checked)
            {
                try
                {
                    string type = typeEdit.Text;
                    int codeThing = Convert.ToInt32(codeThingEdit.Text);
                    this.thingManager.addThing(codeThing, type);
                    MessageBox.Show("Удалось успешно добавить вещь!", "Успех!");
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Ошибка!");
                }
            }
            else if (actionButton2.Checked)
            {
                try
                {
                    string studentCode = studentEdit.Text;
                    int codeThing = Convert.ToInt32(codeThingEdit.Text);
                    this.thingManager.giveStudentThing(studentCode, codeThing);
                    MessageBox.Show("Удалось успешно выдать вещь студенту!", "Успех!");
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Ошибка!");
                }
            }
            else if (actionButton3.Checked)
            {
                try
                {
                    string studentcode = studentEdit.Text;
                    int codeThing = Convert.ToInt32(codeThingEdit.Text);
                    this.thingManager.takeStudentThing(studentcode, codeThing);
                    MessageBox.Show("Удалось успешно забрать вещь студенту!", "Успех!");
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Ошибка!");
                }
            }
            else if (actionButton4.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("Name", "Имя");
                this.tableData.Columns.Add("Group", "Группа");
                this.tableData.Columns.Add("StudentCode", "Код студента");
                List<Student> alllStudent = this.studentManager.getAllStudent();
                foreach (Student student in alllStudent)
                    this.tableData.Rows.Add(student.Name, student.Group, student.StudentCode);
            }
            else if (actionButton5.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("Id", "Id");
                this.tableData.Columns.Add("Number", "Номер");
                this.tableData.Columns.Add("Type", "Тип комнаты");
                this.tableData.Columns[2].Width = 150;
                List<Room> allRoom = this.roomManager.getAllRoom();
                foreach (Room room in allRoom)
                    this.tableData.Rows.Add(room.Id_room, room.Number, room.RoomTypes);
            }
            else if (actionButton6.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("ID", "ID");
                this.tableData.Columns.Add("CodeThing", "Код вещи");
                this.tableData.Columns.Add("Type", "Тип");
                this.tableData.Columns.Add("Room", "Комната");
                List<Thing> allThing = this.thingManager.getAllThing();
                foreach (Thing thing in allThing)
                    if (thing.Id_room == 1)
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, "В складе");
                    else
                    {
                        Room room = this.roomManager.GetRoom(thing.Id_room);
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
            else if (actionButton7.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("ID", "ID");
                this.tableData.Columns.Add("CodeThing", "Код вещи");
                this.tableData.Columns.Add("Type", "Тип");
                this.tableData.Columns.Add("Room", "Комната");
                List<Thing> allThing = this.thingManager.getFreeThing();
                foreach (Thing thing in allThing)
                    if (thing.Id_room == 1)
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, "В складе");
                    else
                    {
                        Room room = this.roomManager.GetRoom(thing.Id_room);
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
            else if (actionButton8.Checked)
            {
                try
                {
                    int id_room = Convert.ToInt32(roomEdit.Text);
                    int codething = Convert.ToInt32(codeThingEdit.Text);
                    this.thingManager.transferThing(codething, id_room);
                    MessageBox.Show("Удалось успешно изменить места сохранения!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (radioButton9.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                try
                {
                    string studentCode = studentEdit.Text;
                    List<Thing> allThing = this.thingManager.getStudentThing(studentCode);
                    this.tableData.Columns.Add("ID", "ID");
                    this.tableData.Columns.Add("CodeThing", "Код вещи");
                    this.tableData.Columns.Add("Type", "Тип");
                    this.tableData.Columns.Add("Room", "Комната");
                    foreach (Thing thing in allThing)
                        if (thing.Id_room == 1)
                            this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, "В складе");
                        else
                        {
                            Room room = this.roomManager.GetRoom(thing.Id_room);
                            this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (actionButton10.Checked)
            {
                if (id_report.Text.Length <= 0)
                {
                    MessageBox.Show("Введите id заявления!", "Error");
                    return;
                }
                int id_reporta;
                bool check = int.TryParse(id_report.Text, out id_reporta);
                if (check == false)
                {
                    MessageBox.Show("Введите id заявления еще раз!", "Error");
                    return;
                }
                try
                {
                    this.reportManager.changeStatus(id_reporta);
                    MessageBox.Show("Удалось изменить статус заявления.", "Ошибка!");
                }
                catch (ChangeStatusErrorException)
                {
                    MessageBox.Show("Заявление уже выполнено.", "Ошибка!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (actionButton11.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                try
                {
                    List<RepairReport> allReport = this.reportManager.getAllReport();
                    this.tableData.Columns.Add("ID", "ID заявления");
                    this.tableData.Columns.Add("RoomNumber", "Номер комнаты");
                    this.tableData.Columns.Add("CodeStudent", "Код студента");
                    this.tableData.Columns.Add("Info", "Информация");
                    this.tableData.Columns.Add("Status", "Статус");
                    this.tableData.Columns[3].Width = 300;
                    foreach (RepairReport report in allReport)
                        if (report.Status == STATUS.DONE)
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Все хорошо");
                        else
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Плохо");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (actionButton12.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                try
                {
                    List<RepairReport> allReport = this.reportManager.getAllDoneReport();
                    this.tableData.Columns.Add("ID", "ID заявления");
                    this.tableData.Columns.Add("RoomNumber", "Номер комнаты");
                    this.tableData.Columns.Add("CodeStudent", "Код студента");
                    this.tableData.Columns.Add("Info", "Информация");
                    this.tableData.Columns.Add("Status", "Статус");
                    this.tableData.Columns[3].Width = 300;
                    foreach (RepairReport report in allReport)
                        if (report.Status == STATUS.DONE)
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Все хорошо");
                        else
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Плохо");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (actionButton13.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                try
                {
                    List<RepairReport> allReport = this.reportManager.getAllNotDoneReport();
                    this.tableData.Columns.Add("ID", "ID заявления");
                    this.tableData.Columns.Add("RoomNumber", "Номер комнаты");
                    this.tableData.Columns.Add("CodeStudent", "Код студента");
                    this.tableData.Columns.Add("Info", "Информация");
                    this.tableData.Columns.Add("Status", "Статус");
                    this.tableData.Columns[3].Width = 300;
                    foreach (RepairReport report in allReport)
                        if (report.Status == STATUS.DONE)
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Все хорошо");
                        else
                            this.tableData.Rows.Add(report.Id_report, report.Room_number, report.Code_student, report.Info, "Плохо");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actionButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (actionButton10.Checked)
            {
                this.label1.Visible = true;
                this.id_report.Visible = true;
            }
            else
            {
                this.label1.Visible = false;
                this.id_report.Visible = false;
            }
        }
    }
}
