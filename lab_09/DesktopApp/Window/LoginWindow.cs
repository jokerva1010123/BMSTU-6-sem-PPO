using GUIManage;
using Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginWindow : Form
    {
        private GUILoginManager loginManager;
        private GUIRoomManager roomManager;
        private GUIThingManager thingManager;
        private GUIStudentManager studentManager;
        private GUIReportManager reportManager;
        public LoginWindow(GUILoginManager authManger, GUIRoomManager roomManager, GUIThingManager thingManager, GUIStudentManager studentManager, GUIReportManager reportManager)
        {
            InitializeComponent();
            this.loginManager = authManger;
            this.roomManager = roomManager;
            this.thingManager = thingManager;
            this.studentManager = studentManager;
            this.reportManager = reportManager;
        }

        private void enterButton_Click(object sender, System.EventArgs e)
        {
            string login = loginEdit.Text;
            string password = passwordEdit.Text;
            Levels level;
            try
            {
                level = this.loginManager.tryAuthorize(login, password);
            }
            catch
            {
                MessageBox.Show("Логин или пароль не правильны", "Error");
                return;
            }
            this.Hide();
            if (level == Levels.MANAGER)
            {
                ManagerWindow mw = new ManagerWindow(this.studentManager, this.thingManager, this.roomManager, this.reportManager);
                mw.ShowDialog();
                mw = null;
            }
            else if (level == Levels.KAMEDAN)
            {
                KamedanWindow kw = new KamedanWindow(this.studentManager, this.roomManager, this.thingManager);
                kw.ShowDialog();
                kw = null;
            }
            else if (level == Levels.STUDENT)
            {
                int id = this.loginManager.getIdUser(login);
                string studentCode = this.studentManager.getStudentCodeFromIdUser(id);
                StudentWindow st = new StudentWindow(this.roomManager, this.studentManager, this.thingManager, this.reportManager, studentCode);
                st.ShowDialog();
                st = null;
            }
            this.Show();
            this.loginEdit.Text = "";
            this.passwordEdit.Text = "";
        }
    }
}
