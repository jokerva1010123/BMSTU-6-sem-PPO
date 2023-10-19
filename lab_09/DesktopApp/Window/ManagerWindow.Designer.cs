namespace WindowsFormsApp1
{
    partial class ManagerWindow
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableData = new DataGridView();
            exitButton = new Button();
            actionButton = new Button();
            groupBox2 = new GroupBox();
            id_report = new TextBox();
            label1 = new Label();
            typeEdit = new TextBox();
            codeThingEdit = new TextBox();
            roomEdit = new TextBox();
            studentEdit = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1232431 = new Label();
            groupBox1 = new GroupBox();
            actionButton13 = new RadioButton();
            actionButton12 = new RadioButton();
            actionButton11 = new RadioButton();
            actionButton10 = new RadioButton();
            radioButton9 = new RadioButton();
            actionButton8 = new RadioButton();
            actionButton7 = new RadioButton();
            actionButton6 = new RadioButton();
            actionButton5 = new RadioButton();
            actionButton4 = new RadioButton();
            actionButton3 = new RadioButton();
            actionButton2 = new RadioButton();
            actionButton1 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)tableData).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableData
            // 
            tableData.AllowUserToAddRows = false;
            tableData.AllowUserToDeleteRows = false;
            tableData.AllowUserToOrderColumns = true;
            tableData.AllowUserToResizeColumns = false;
            tableData.AllowUserToResizeRows = false;
            tableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableData.EditMode = DataGridViewEditMode.EditProgrammatically;
            tableData.Location = new Point(913, 21);
            tableData.Margin = new Padding(4, 3, 4, 3);
            tableData.Name = "tableData";
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tableData.RowsDefaultCellStyle = dataGridViewCellStyle1;
            tableData.Size = new Size(755, 635);
            tableData.TabIndex = 9;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            exitButton.Location = new Point(581, 753);
            exitButton.Margin = new Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(169, 46);
            exitButton.TabIndex = 8;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // actionButton
            // 
            actionButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            actionButton.Location = new Point(581, 683);
            actionButton.Margin = new Padding(4, 3, 4, 3);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(169, 46);
            actionButton.TabIndex = 7;
            actionButton.Text = "Выполнить";
            actionButton.UseVisualStyleBackColor = true;
            actionButton.Click += actionButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(id_report);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(typeEdit);
            groupBox2.Controls.Add(codeThingEdit);
            groupBox2.Controls.Add(roomEdit);
            groupBox2.Controls.Add(studentEdit);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1232431);
            groupBox2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(453, 21);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(443, 635);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Поля для ввода";
            // 
            // id_report
            // 
            id_report.Location = new Point(197, 290);
            id_report.Name = "id_report";
            id_report.Size = new Size(236, 29);
            id_report.TabIndex = 9;
            id_report.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 295);
            label1.Name = "label1";
            label1.Size = new Size(131, 24);
            label1.TabIndex = 8;
            label1.Text = "ID заявления:";
            label1.Visible = false;
            // 
            // typeEdit
            // 
            typeEdit.Location = new Point(196, 233);
            typeEdit.Margin = new Padding(4, 3, 4, 3);
            typeEdit.Name = "typeEdit";
            typeEdit.Size = new Size(237, 29);
            typeEdit.TabIndex = 7;
            // 
            // codeThingEdit
            // 
            codeThingEdit.Location = new Point(196, 168);
            codeThingEdit.Margin = new Padding(4, 3, 4, 3);
            codeThingEdit.Name = "codeThingEdit";
            codeThingEdit.Size = new Size(238, 29);
            codeThingEdit.TabIndex = 6;
            // 
            // roomEdit
            // 
            roomEdit.Location = new Point(196, 113);
            roomEdit.Margin = new Padding(4, 3, 4, 3);
            roomEdit.Name = "roomEdit";
            roomEdit.Size = new Size(240, 29);
            roomEdit.TabIndex = 5;
            // 
            // studentEdit
            // 
            studentEdit.Location = new Point(196, 54);
            studentEdit.Margin = new Padding(4, 3, 4, 3);
            studentEdit.Name = "studentEdit";
            studentEdit.Size = new Size(240, 29);
            studentEdit.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 239);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 24);
            label4.TabIndex = 3;
            label4.Text = "Тип вещи:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 174);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 24);
            label3.TabIndex = 2;
            label3.Text = "Код вещи:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 113);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 24);
            label2.TabIndex = 1;
            label2.Text = "ID комнаты:";
            // 
            // label1232431
            // 
            label1232431.AutoSize = true;
            label1232431.Location = new Point(7, 60);
            label1232431.Margin = new Padding(4, 0, 4, 0);
            label1232431.Name = "label1232431";
            label1232431.Size = new Size(138, 24);
            label1232431.TabIndex = 0;
            label1232431.Text = "Код студента:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(actionButton13);
            groupBox1.Controls.Add(actionButton12);
            groupBox1.Controls.Add(actionButton11);
            groupBox1.Controls.Add(actionButton10);
            groupBox1.Controls.Add(radioButton9);
            groupBox1.Controls.Add(actionButton8);
            groupBox1.Controls.Add(actionButton7);
            groupBox1.Controls.Add(actionButton6);
            groupBox1.Controls.Add(actionButton5);
            groupBox1.Controls.Add(actionButton4);
            groupBox1.Controls.Add(actionButton3);
            groupBox1.Controls.Add(actionButton2);
            groupBox1.Controls.Add(actionButton1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(14, 21);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(431, 635);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите действие:";
            // 
            // actionButton13
            // 
            actionButton13.AutoSize = true;
            actionButton13.Location = new Point(7, 584);
            actionButton13.Name = "actionButton13";
            actionButton13.Size = new Size(426, 28);
            actionButton13.TabIndex = 12;
            actionButton13.TabStop = true;
            actionButton13.Text = "Посмотреть все невыполненные заявления";
            actionButton13.UseVisualStyleBackColor = true;
            // 
            // actionButton12
            // 
            actionButton12.AutoSize = true;
            actionButton12.Location = new Point(7, 541);
            actionButton12.Name = "actionButton12";
            actionButton12.Size = new Size(404, 28);
            actionButton12.TabIndex = 11;
            actionButton12.TabStop = true;
            actionButton12.Text = "Посмотреть все выполненные заявления";
            actionButton12.UseVisualStyleBackColor = true;
            // 
            // actionButton11
            // 
            actionButton11.AutoSize = true;
            actionButton11.Location = new Point(7, 494);
            actionButton11.Name = "actionButton11";
            actionButton11.Size = new Size(275, 28);
            actionButton11.TabIndex = 10;
            actionButton11.TabStop = true;
            actionButton11.Text = "Посмотреть все заявления";
            actionButton11.UseVisualStyleBackColor = true;
            // 
            // actionButton10
            // 
            actionButton10.AutoSize = true;
            actionButton10.Location = new Point(7, 450);
            actionButton10.Name = "actionButton10";
            actionButton10.Size = new Size(281, 28);
            actionButton10.TabIndex = 9;
            actionButton10.TabStop = true;
            actionButton10.Text = "Изменить статус заявления";
            actionButton10.UseVisualStyleBackColor = true;
            actionButton10.CheckedChanged += actionButton10_CheckedChanged;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(7, 406);
            radioButton9.Margin = new Padding(4, 3, 4, 3);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(278, 28);
            radioButton9.TabIndex = 8;
            radioButton9.TabStop = true;
            radioButton9.Text = "Посмотреть вещи студента";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // actionButton8
            // 
            actionButton8.AutoSize = true;
            actionButton8.Location = new Point(7, 358);
            actionButton8.Margin = new Padding(4, 3, 4, 3);
            actionButton8.Name = "actionButton8";
            actionButton8.Size = new Size(319, 28);
            actionButton8.TabIndex = 7;
            actionButton8.TabStop = true;
            actionButton8.Text = "Изменить место хранения вещи";
            actionButton8.UseVisualStyleBackColor = true;
            // 
            // actionButton7
            // 
            actionButton7.AutoSize = true;
            actionButton7.Location = new Point(7, 309);
            actionButton7.Margin = new Padding(4, 3, 4, 3);
            actionButton7.Name = "actionButton7";
            actionButton7.Size = new Size(333, 28);
            actionButton7.TabIndex = 6;
            actionButton7.TabStop = true;
            actionButton7.Text = "Посмотреть все свободные вещи";
            actionButton7.UseVisualStyleBackColor = true;
            // 
            // actionButton6
            // 
            actionButton6.AutoSize = true;
            actionButton6.Location = new Point(7, 258);
            actionButton6.Margin = new Padding(4, 3, 4, 3);
            actionButton6.Name = "actionButton6";
            actionButton6.Size = new Size(351, 28);
            actionButton6.TabIndex = 5;
            actionButton6.TabStop = true;
            actionButton6.Text = "Посмотреть все вещи в общежитии";
            actionButton6.UseVisualStyleBackColor = true;
            // 
            // actionButton5
            // 
            actionButton5.AutoSize = true;
            actionButton5.Location = new Point(7, 213);
            actionButton5.Margin = new Padding(4, 3, 4, 3);
            actionButton5.Name = "actionButton5";
            actionButton5.Size = new Size(275, 28);
            actionButton5.TabIndex = 4;
            actionButton5.TabStop = true;
            actionButton5.Text = "Посмотреть список комнат";
            actionButton5.UseVisualStyleBackColor = true;
            // 
            // actionButton4
            // 
            actionButton4.AutoSize = true;
            actionButton4.Location = new Point(7, 169);
            actionButton4.Margin = new Padding(4, 3, 4, 3);
            actionButton4.Name = "actionButton4";
            actionButton4.Size = new Size(239, 28);
            actionButton4.TabIndex = 3;
            actionButton4.TabStop = true;
            actionButton4.Text = "Посмотреть студентов";
            actionButton4.UseVisualStyleBackColor = true;
            // 
            // actionButton3
            // 
            actionButton3.AutoSize = true;
            actionButton3.Location = new Point(7, 125);
            actionButton3.Margin = new Padding(4, 3, 4, 3);
            actionButton3.Name = "actionButton3";
            actionButton3.Size = new Size(257, 28);
            actionButton3.TabIndex = 2;
            actionButton3.TabStop = true;
            actionButton3.Text = "Забрать у студента вещь";
            actionButton3.UseVisualStyleBackColor = true;
            // 
            // actionButton2
            // 
            actionButton2.AutoSize = true;
            actionButton2.Location = new Point(7, 76);
            actionButton2.Margin = new Padding(4, 3, 4, 3);
            actionButton2.Name = "actionButton2";
            actionButton2.Size = new Size(234, 28);
            actionButton2.TabIndex = 1;
            actionButton2.TabStop = true;
            actionButton2.Text = "Выдать студенту вещь";
            actionButton2.UseVisualStyleBackColor = true;
            // 
            // actionButton1
            // 
            actionButton1.AutoSize = true;
            actionButton1.Location = new Point(7, 28);
            actionButton1.Margin = new Padding(4, 3, 4, 3);
            actionButton1.Name = "actionButton1";
            actionButton1.Size = new Size(168, 28);
            actionButton1.TabIndex = 0;
            actionButton1.TabStop = true;
            actionButton1.Text = "Добавить вещь";
            actionButton1.UseVisualStyleBackColor = true;
            // 
            // ManagerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1679, 820);
            Controls.Add(tableData);
            Controls.Add(exitButton);
            Controls.Add(actionButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ManagerWindow";
            Text = "Manager Window";
            ((System.ComponentModel.ISupportInitialize)tableData).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tableData;
        private Button exitButton;
        private Button actionButton;
        private GroupBox groupBox2;
        private TextBox typeEdit;
        private TextBox codeThingEdit;
        private TextBox roomEdit;
        private TextBox studentEdit;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1232431;
        private GroupBox groupBox1;
        private RadioButton radioButton9;
        private RadioButton actionButton8;
        private RadioButton actionButton7;
        private RadioButton actionButton6;
        private RadioButton actionButton5;
        private RadioButton actionButton4;
        private RadioButton actionButton3;
        private RadioButton actionButton2;
        private RadioButton actionButton1;
        private TextBox id_report;
        private Label label1;
        private RadioButton actionButton13;
        private RadioButton actionButton12;
        private RadioButton actionButton11;
        private RadioButton actionButton10;
    }
}