using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab_05
{
    public partial class ManageWindow : Form
    {
        private GUIAuthManager authManager;
        private GUIStudentManager studentManager;
        private GUIThingManager thingManager;
        private GUIRoomManager roomManger;
        public ManageWindow(GUIAuthManager authManager, GUIStudentManager studentManager, GUIThingManager thingManager, GUIRoomManager roomManager)
        {
            InitializeComponent();
            this.authManager = authManager;
            this.studentManager = studentManager;
            this.thingManager = thingManager;
            this.roomManger = roomManager;
        }
        private void actionButton_Click(object sender, System.EventArgs e)
        {
            string type = typeEdit.Text;
            if (actionButton1.Checked)
            {
                try
                {
                    int codeThing = Convert.ToInt32(codeThingEdit.Text);
                    this.thingManager.addThing(codeThing, type);
                    MessageBox.Show("Удалось успешно добавить вещь!", "Успех!");
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Ошибка!");
                }
            }
            else if(actionButton2.Checked)
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
            else if(actionButton3.Checked)
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
            else if(actionButton4.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("Name", "Имя");
                this.tableData.Columns.Add("Group", "Группа");
                this.tableData.Columns.Add("StudentCode", "Код студента");
                List<Student> alllStudent = this.studentManager.getAllStudent();
                foreach(Student student in alllStudent)
                    this.tableData.Rows.Add(student.Name, student.Group, student.StudentCode);
            }
            else if(actionButton5.Checked)
            {
                this.tableData.Rows.Clear();
                this.tableData.Columns.Clear();
                this.tableData.Columns.Add("Id", "Id");
                this.tableData.Columns.Add("Number", "Номер");
                this.tableData.Columns.Add("Type", "Тип комнаты");
                this.tableData.Columns[2].Width = 150;
                List<Room> allRoom = this.roomManger.getAllRoom();
                foreach (Room room in allRoom)
                    this.tableData.Rows.Add(room.Id_room, room.Number, room.RoomTypes);
            }
            else if(actionButton6.Checked)
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
                        Room room = this.roomManger.GetRoom(thing.Id_room);
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
            else if(actionButton7.Checked)
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
                        Room room = this.roomManger.GetRoom(thing.Id_room);
                        this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                    }
            }
            else if(actionButton8.Checked)
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
            else
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
                            Room room = this.roomManger.GetRoom(thing.Id_room);
                            this.tableData.Rows.Add(thing.Id_thing, thing.Code, thing.Type, room.Number);
                        }
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
    }
}
