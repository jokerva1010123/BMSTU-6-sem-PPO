namespace WindowsFormsApp1
{
    partial class KamedanWindow
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
            this.exitButton = new System.Windows.Forms.Button();
            this.actionButton = new System.Windows.Forms.Button();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PasswordEdit = new System.Windows.Forms.TextBox();
            this.LoginEdit = new System.Windows.Forms.TextBox();
            this.CodeThingEdit = new System.Windows.Forms.TextBox();
            this.IdRoomEdit = new System.Windows.Forms.TextBox();
            this.StudentCodeEdit = new System.Windows.Forms.TextBox();
            this.GroupEdit = new System.Windows.Forms.TextBox();
            this.NameEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.action5 = new System.Windows.Forms.RadioButton();
            this.action9 = new System.Windows.Forms.RadioButton();
            this.action7 = new System.Windows.Forms.RadioButton();
            this.action6 = new System.Windows.Forms.RadioButton();
            this.action4 = new System.Windows.Forms.RadioButton();
            this.action3 = new System.Windows.Forms.RadioButton();
            this.action2 = new System.Windows.Forms.RadioButton();
            this.action1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(586, 653);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(176, 46);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // actionButton
            // 
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.Location = new System.Drawing.Point(586, 581);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(176, 46);
            this.actionButton.TabIndex = 8;
            this.actionButton.Text = "Выполнить";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(803, 12);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(519, 549);
            this.dataTable.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PasswordEdit);
            this.groupBox2.Controls.Add(this.LoginEdit);
            this.groupBox2.Controls.Add(this.CodeThingEdit);
            this.groupBox2.Controls.Add(this.IdRoomEdit);
            this.groupBox2.Controls.Add(this.StudentCodeEdit);
            this.groupBox2.Controls.Add(this.GroupEdit);
            this.groupBox2.Controls.Add(this.NameEdit);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(378, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 550);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поля для ввода";
            // 
            // PasswordEdit
            // 
            this.PasswordEdit.Location = new System.Drawing.Point(169, 342);
            this.PasswordEdit.Name = "PasswordEdit";
            this.PasswordEdit.Size = new System.Drawing.Size(230, 29);
            this.PasswordEdit.TabIndex = 15;
            // 
            // LoginEdit
            // 
            this.LoginEdit.Location = new System.Drawing.Point(169, 292);
            this.LoginEdit.Name = "LoginEdit";
            this.LoginEdit.Size = new System.Drawing.Size(230, 29);
            this.LoginEdit.TabIndex = 14;
            // 
            // CodeThingEdit
            // 
            this.CodeThingEdit.Location = new System.Drawing.Point(169, 242);
            this.CodeThingEdit.Name = "CodeThingEdit";
            this.CodeThingEdit.Size = new System.Drawing.Size(230, 29);
            this.CodeThingEdit.TabIndex = 13;
            // 
            // IdRoomEdit
            // 
            this.IdRoomEdit.Location = new System.Drawing.Point(169, 192);
            this.IdRoomEdit.Name = "IdRoomEdit";
            this.IdRoomEdit.Size = new System.Drawing.Size(230, 29);
            this.IdRoomEdit.TabIndex = 12;
            // 
            // StudentCodeEdit
            // 
            this.StudentCodeEdit.Location = new System.Drawing.Point(169, 145);
            this.StudentCodeEdit.Name = "StudentCodeEdit";
            this.StudentCodeEdit.Size = new System.Drawing.Size(230, 29);
            this.StudentCodeEdit.TabIndex = 11;
            // 
            // GroupEdit
            // 
            this.GroupEdit.Location = new System.Drawing.Point(169, 93);
            this.GroupEdit.Name = "GroupEdit";
            this.GroupEdit.Size = new System.Drawing.Size(230, 29);
            this.GroupEdit.TabIndex = 10;
            // 
            // NameEdit
            // 
            this.NameEdit.Location = new System.Drawing.Point(169, 39);
            this.NameEdit.Name = "NameEdit";
            this.NameEdit.Size = new System.Drawing.Size(230, 29);
            this.NameEdit.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Пароль";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Код вещи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID Комнаты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Код студента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Группа студента";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя студента";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.action5);
            this.groupBox1.Controls.Add(this.action9);
            this.groupBox1.Controls.Add(this.action7);
            this.groupBox1.Controls.Add(this.action6);
            this.groupBox1.Controls.Add(this.action4);
            this.groupBox1.Controls.Add(this.action3);
            this.groupBox1.Controls.Add(this.action2);
            this.groupBox1.Controls.Add(this.action1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 550);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите действие:";
            // 
            // action5
            // 
            this.action5.AutoSize = true;
            this.action5.Location = new System.Drawing.Point(6, 238);
            this.action5.Name = "action5";
            this.action5.Size = new System.Drawing.Size(245, 28);
            this.action5.TabIndex = 8;
            this.action5.TabStop = true;
            this.action5.Text = "Изменить имя студента";
            this.action5.UseVisualStyleBackColor = true;
            // 
            // action9
            // 
            this.action9.AutoSize = true;
            this.action9.Location = new System.Drawing.Point(6, 394);
            this.action9.Name = "action9";
            this.action9.Size = new System.Drawing.Size(351, 28);
            this.action9.TabIndex = 7;
            this.action9.TabStop = true;
            this.action9.Text = "Посмотреть все вещи в общежитии";
            this.action9.UseVisualStyleBackColor = true;
            // 
            // action7
            // 
            this.action7.AutoSize = true;
            this.action7.Location = new System.Drawing.Point(6, 341);
            this.action7.Name = "action7";
            this.action7.Size = new System.Drawing.Size(221, 28);
            this.action7.TabIndex = 6;
            this.action7.TabStop = true;
            this.action7.Text = "Посмотреть комнаты";
            this.action7.UseVisualStyleBackColor = true;
            // 
            // action6
            // 
            this.action6.AutoSize = true;
            this.action6.Location = new System.Drawing.Point(6, 290);
            this.action6.Name = "action6";
            this.action6.Size = new System.Drawing.Size(239, 28);
            this.action6.TabIndex = 4;
            this.action6.TabStop = true;
            this.action6.Text = "Посмотреть студентов";
            this.action6.UseVisualStyleBackColor = true;
            // 
            // action4
            // 
            this.action4.AutoSize = true;
            this.action4.Location = new System.Drawing.Point(6, 190);
            this.action4.Name = "action4";
            this.action4.Size = new System.Drawing.Size(271, 28);
            this.action4.TabIndex = 3;
            this.action4.TabStop = true;
            this.action4.Text = "Изменить группу студента";
            this.action4.UseVisualStyleBackColor = true;
            // 
            // action3
            // 
            this.action3.AutoSize = true;
            this.action3.Location = new System.Drawing.Point(6, 141);
            this.action3.Name = "action3";
            this.action3.Size = new System.Drawing.Size(204, 28);
            this.action3.TabIndex = 2;
            this.action3.TabStop = true;
            this.action3.Text = "Выселить студента";
            this.action3.UseVisualStyleBackColor = true;
            // 
            // action2
            // 
            this.action2.AutoSize = true;
            this.action2.Location = new System.Drawing.Point(6, 89);
            this.action2.Name = "action2";
            this.action2.Size = new System.Drawing.Size(202, 28);
            this.action2.TabIndex = 1;
            this.action2.TabStop = true;
            this.action2.Text = "Заселить студента";
            this.action2.UseVisualStyleBackColor = true;
            // 
            // action1
            // 
            this.action1.AutoSize = true;
            this.action1.Location = new System.Drawing.Point(6, 39);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(205, 28);
            this.action1.TabIndex = 0;
            this.action1.TabStop = true;
            this.action1.Text = "Добавить студента";
            this.action1.UseVisualStyleBackColor = true;
            // 
            // KamedanWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 711);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "KamedanWindow";
            this.Text = "KamedanWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PasswordEdit;
        private System.Windows.Forms.TextBox LoginEdit;
        private System.Windows.Forms.TextBox CodeThingEdit;
        private System.Windows.Forms.TextBox IdRoomEdit;
        private System.Windows.Forms.TextBox StudentCodeEdit;
        private System.Windows.Forms.TextBox GroupEdit;
        private System.Windows.Forms.TextBox NameEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton action5;
        private System.Windows.Forms.RadioButton action9;
        private System.Windows.Forms.RadioButton action7;
        private System.Windows.Forms.RadioButton action6;
        private System.Windows.Forms.RadioButton action4;
        private System.Windows.Forms.RadioButton action3;
        private System.Windows.Forms.RadioButton action2;
        private System.Windows.Forms.RadioButton action1;
    }
}