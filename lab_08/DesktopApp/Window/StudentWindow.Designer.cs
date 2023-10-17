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
            this.exitButton = new System.Windows.Forms.Button();
            this.actionButton = new System.Windows.Forms.Button();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.action2 = new System.Windows.Forms.RadioButton();
            this.action1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(339, 653);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(123, 36);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // actionButton
            // 
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.Location = new System.Drawing.Point(339, 595);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(123, 34);
            this.actionButton.TabIndex = 7;
            this.actionButton.Text = "Выполнить";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(339, 22);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(538, 550);
            this.dataTable.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.action2);
            this.groupBox1.Controls.Add(this.action1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 173);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите действие:";
            // 
            // action2
            // 
            this.action2.AutoSize = true;
            this.action2.Location = new System.Drawing.Point(6, 110);
            this.action2.Name = "action2";
            this.action2.Size = new System.Drawing.Size(286, 28);
            this.action2.TabIndex = 1;
            this.action2.TabStop = true;
            this.action2.Text = "Посмотреть всех студентов";
            this.action2.UseVisualStyleBackColor = true;
            // 
            // action1
            // 
            this.action1.AutoSize = true;
            this.action1.Location = new System.Drawing.Point(6, 48);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(238, 28);
            this.action1.TabIndex = 0;
            this.action1.TabStop = true;
            this.action1.Text = "Посмотреть свои вещи";
            this.action1.UseVisualStyleBackColor = true;
            // 
            // StudentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 711);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentWindow";
            this.Text = "StudentWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton action2;
        private System.Windows.Forms.RadioButton action1;
    }
}