using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUIManage;
using Models;

namespace WindowsFormsApp1
{
    public partial class KamedanWindow : Form
    {
        private GUIStudentManager studentManager;
        private GUIRoomManager roomManager;
        private GUIThingManager thingManager;
        public KamedanWindow(GUIStudentManager studentManager, GUIRoomManager roomManager, GUIThingManager thingManager)
        {
            InitializeComponent();
            this.studentManager = studentManager;
            this.roomManager = roomManager;
            this.thingManager = thingManager;
        }
        private void actionButton_Click(object sender, EventArgs e)
        {
            if (action1.Checked)
            {
                try
                {
                    if (LoginEdit.Text.Length < 1 || PasswordEdit.Text.Length < 1)
                    {
                        MessageBox.Show("Нужно добавить логин и пароль для нового студента", "Ошибка!");
                        return;
                    }
                    string name = NameEdit.Text;
                    string group = GroupEdit.Text;
                    string studentCode = StudentCodeEdit.Text;
                    string login = LoginEdit.Text;
                    string password = PasswordEdit.Text;
                    string id_roomStr = IdRoomEdit.Text;
                    int id_room = (id_roomStr.Length == 0) ? -1 : Convert.ToInt32(id_roomStr);
                    if (id_room != -1 && roomManager.GetRoom(id_room).RoomTypes != RoomType.StudentRoom)
                    {
                        MessageBox.Show("Это не комната для студента", "Ошибка!");
                        return;
                    }
                    this.studentManager.addNewStudent(name, group, studentCode, id_room, login, password);
                    MessageBox.Show("Удалось успешно добавить студента!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (action2.Checked)
            {
                try
                {
                    string studentCode = StudentCodeEdit.Text;
                    int id_room = Convert.ToInt32(IdRoomEdit.Text);
                    this.studentManager.setRoom(studentCode, id_room);
                    MessageBox.Show("Удалось успешно заселить студента!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (action3.Checked)
            {
                try
                {
                    string studentCode = StudentCodeEdit.Text;
                    this.studentManager.returnRoom(studentCode);
                    MessageBox.Show("Удалось успешно выселить студента!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (action4.Checked)
            {
                try
                {
                    string studentCode = StudentCodeEdit.Text;
                    string group = GroupEdit.Text;
                    this.studentManager.changeStudentGroup(studentCode, group);
                    MessageBox.Show("Удалось успешно изменить группу студента!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (action5.Checked)
            {
                try
                {
                    string studentCode = StudentCodeEdit.Text;
                    string name = NameEdit.Text;
                    this.studentManager.changeStudentName(studentCode, name);
                    MessageBox.Show("Удалось успешно изменить имя студента!", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else if (action6.Checked)
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
                    string room = (student.Id_room < 1) ? "Не живёт" : student.Id_room.ToString();
                    this.dataTable.Rows.Add(student.Id_student, student.Name, student.Group, student.StudentCode, room);
                }
            }
            else if (action7.Checked)
            {
                this.dataTable.Rows.Clear();
                this.dataTable.Columns.Clear();
                this.dataTable.Columns.Add("Id", "Id");
                this.dataTable.Columns.Add("Number", "Номер");
                this.dataTable.Columns.Add("Type", "Тип комнаты");
                this.dataTable.Columns[2].Width = 150;
                List<Room> allRoom = this.roomManager.getAllRoom();
                foreach (Room room in allRoom)
                    this.dataTable.Rows.Add(room.Id_room, room.Number, room.RoomTypes);
            }
            else
            {
                this.dataTable.Rows.Clear();
                this.dataTable.Columns.Clear();
                this.dataTable.Columns.Add("ID", "ID");
                this.dataTable.Columns.Add("CodeThing", "Код вещи");
                this.dataTable.Columns.Add("Type", "Тип");
                this.dataTable.Columns.Add("Room", "Комната");
                List<Thing> allThing = this.thingManager.getAllThing();
                foreach (Thing thing in allThing)
                    if (thing.Id_room == 1)
                        this.dataTable.Rows.Add(thing.Id_thing, thing.Code, thing.Type, "В складе");
                    else
                    {
                        Room room = this.roomManager.GetRoom(thing.Id_room);
                        this.dataTable.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
