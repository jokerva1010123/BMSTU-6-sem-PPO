using System;
using System.Windows.Forms;

namespace lab_05
{
    public partial class AuthWindow : Form
    {
        private GUIAuthManager authManager;
        private GUIRoomManager roomManager;
        private GUIThingManager thingManager;
        private GUIStudentManager studentManager;
        public AuthWindow(GUIAuthManager authManger, GUIRoomManager roomManager, GUIThingManager thingManager, GUIStudentManager studentManager)
        {
            InitializeComponent();
            this.authManager = authManger;
            this.roomManager = roomManager;
            this.thingManager = thingManager;
            this.studentManager = studentManager;
        }

        private void enterButton_Click(object sender, System.EventArgs e)
        {
            string login = loginEdit.Text;
            string password = passwordEdit.Text;
            try
            {
                Levels level = this.authManager.tryAuthorize(login, password);
                this.Hide();
                if (level == Levels.MANAGER)
                {
                    ManageWindow mw = new ManageWindow(this.authManager, this.studentManager, this.thingManager, this.roomManager);
                    mw.ShowDialog();
                    mw = null;
                }
                else if (level == Levels.KAMEDAN)
                {

                }
                else if (level == Levels.STUDENT)
                {

                }
                this.Show();
                this.loginEdit.Text = "";
                this.passwordEdit.Text = "";
            }
            catch
            {
                MessageBox.Show("Логин или пароль не правильны", "Error");
                return;
            }
        }
    }
}
