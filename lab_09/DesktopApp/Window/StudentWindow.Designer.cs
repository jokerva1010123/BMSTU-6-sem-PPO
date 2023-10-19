namespace WindowsFormsApp1
{
    partial class StudentWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            exitButton = new Button();
            actionButton = new Button();
            dataTable = new DataGridView();
            groupBox1 = new GroupBox();
            action3 = new RadioButton();
            action2 = new RadioButton();
            action1 = new RadioButton();
            groupBox2 = new GroupBox();
            infor = new TextBox();
            room_number = new TextBox();
            code_student = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataTable).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            exitButton.Location = new Point(396, 753);
            exitButton.Margin = new Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(144, 42);
            exitButton.TabIndex = 8;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // actionButton
            // 
            actionButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            actionButton.Location = new Point(396, 687);
            actionButton.Margin = new Padding(4, 3, 4, 3);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(144, 39);
            actionButton.TabIndex = 7;
            actionButton.Text = "Выполнить";
            actionButton.UseVisualStyleBackColor = true;
            actionButton.Click += actionButton_Click;
            // 
            // dataTable
            // 
            dataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTable.Location = new Point(396, 25);
            dataTable.Margin = new Padding(4, 3, 4, 3);
            dataTable.Name = "dataTable";
            dataTable.Size = new Size(628, 635);
            dataTable.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(action3);
            groupBox1.Controls.Add(action2);
            groupBox1.Controls.Add(action1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(21, 25);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(351, 281);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите действие:";
            // 
            // action3
            // 
            action3.AutoSize = true;
            action3.Location = new Point(7, 201);
            action3.Name = "action3";
            action3.Size = new Size(277, 28);
            action3.TabIndex = 2;
            action3.TabStop = true;
            action3.Text = "Добавить новое заявление";
            action3.UseVisualStyleBackColor = true;
            action3.CheckedChanged += action3_CheckedChanged;
            // 
            // action2
            // 
            action2.AutoSize = true;
            action2.Location = new Point(7, 127);
            action2.Margin = new Padding(4, 3, 4, 3);
            action2.Name = "action2";
            action2.Size = new Size(286, 28);
            action2.TabIndex = 1;
            action2.TabStop = true;
            action2.Text = "Посмотреть всех студентов";
            action2.UseVisualStyleBackColor = true;
            // 
            // action1
            // 
            action1.AutoSize = true;
            action1.Location = new Point(7, 55);
            action1.Margin = new Padding(4, 3, 4, 3);
            action1.Name = "action1";
            action1.Size = new Size(238, 28);
            action1.TabIndex = 0;
            action1.TabStop = true;
            action1.Text = "Посмотреть свои вещи";
            action1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(infor);
            groupBox2.Controls.Add(room_number);
            groupBox2.Controls.Add(code_student);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(21, 349);
            groupBox2.Name = "groupBox2";
            groupBox2.RightToLeft = RightToLeft.No;
            groupBox2.Size = new Size(351, 325);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Введите информация";
            groupBox2.Visible = false;
            // 
            // infor
            // 
            infor.Location = new Point(7, 194);
            infor.Name = "infor";
            infor.Size = new Size(338, 29);
            infor.TabIndex = 5;
            // 
            // room_number
            // 
            room_number.Location = new Point(184, 99);
            room_number.Name = "room_number";
            room_number.Size = new Size(161, 29);
            room_number.TabIndex = 4;
            // 
            // code_student
            // 
            code_student.Location = new Point(184, 48);
            code_student.Name = "code_student";
            code_student.Size = new Size(161, 29);
            code_student.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 153);
            label3.Name = "label3";
            label3.Size = new Size(130, 24);
            label3.TabIndex = 2;
            label3.Text = "Информация:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 102);
            label2.Name = "label2";
            label2.Size = new Size(156, 24);
            label2.TabIndex = 1;
            label2.Text = "Номер комнаты:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 48);
            label1.Name = "label1";
            label1.Size = new Size(138, 24);
            label1.TabIndex = 0;
            label1.Text = "Код студента:";
            // 
            // StudentWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 820);
            Controls.Add(groupBox2);
            Controls.Add(exitButton);
            Controls.Add(actionButton);
            Controls.Add(dataTable);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StudentWindow";
            Text = "StudentWindow";
            ((System.ComponentModel.ISupportInitialize)dataTable).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button exitButton;
        private Button actionButton;
        private DataGridView dataTable;
        private GroupBox groupBox1;
        private RadioButton action2;
        private RadioButton action1;
        private RadioButton action3;
        private GroupBox groupBox2;
        private TextBox infor;
        private TextBox room_number;
        private TextBox code_student;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}