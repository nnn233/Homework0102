namespace Homework0102
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Contact_name = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxName = new TextBox();
            textBoxNumber = new MaskedTextBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            label4 = new Label();
            textBoxSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Contact_name, Number });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(51, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(702, 287);
            dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            Id.HeaderText = "";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.SortMode = DataGridViewColumnSortMode.NotSortable;
            Id.Visible = false;
            // 
            // Contact_name
            // 
            Contact_name.HeaderText = "";
            Contact_name.MinimumWidth = 6;
            Contact_name.Name = "Contact_name";
            Contact_name.ReadOnly = true;
            Contact_name.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Number
            // 
            Number.HeaderText = "";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(874, 62);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "Контакт";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(826, 108);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 5;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(826, 184);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 6;
            label3.Text = "Номер телефона";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(826, 131);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(175, 27);
            textBoxName.TabIndex = 7;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(826, 207);
            textBoxNumber.Mask = "+7 (000) 000 00 00";
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(175, 27);
            textBoxNumber.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.LightSeaGreen;
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(826, 268);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(175, 29);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.LightSeaGreen;
            buttonUpdate.Enabled = false;
            buttonUpdate.Location = new Point(826, 316);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(175, 29);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.LightSeaGreen;
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(826, 366);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(175, 29);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 62);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 12;
            label4.Text = "Поиск по имени";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(212, 59);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(179, 27);
            textBoxSearch.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1057, 450);
            Controls.Add(textBoxSearch);
            Controls.Add(label4);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxNumber);
            Controls.Add(textBoxName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxName;
        private MaskedTextBox textBoxNumber;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Contact_name;
        private DataGridViewTextBoxColumn Number;
        private Label label4;
        private TextBox textBoxSearch;
    }
}