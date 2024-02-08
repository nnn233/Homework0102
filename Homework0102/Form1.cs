using ContactLibrary;

namespace Homework0102
{
    public partial class Form1 : Form
    {
        private readonly ContactProvider contactProvider;
        private int id;
        private bool isProgramEvent = false;

        public Form1()
        {
            contactProvider = new();
            InitializeComponent();
            LoadContacts(contactProvider.GetContacts());
            textBoxName.TextChanged += TextBox_TextChanged;
            textBoxNumber.TextChanged += TextBox_TextChanged;
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            isProgramEvent = true;
            if (textBoxSearch.Text == "")
                LoadContacts(contactProvider.GetContacts());
            else LoadContacts(contactProvider.GetContactsByInitialLetters(textBoxSearch.Text.Trim().ToLower()));
            isProgramEvent = false;
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (isProgramEvent)
                return;
            DataGridViewCell cell = dataGridView1.SelectedCells[0];
            var row = dataGridView1.Rows[cell.RowIndex];
            if (row != null)
            {
                row.Selected = true;
                buttonUpdate.Enabled = true;
                buttonDelete.Enabled = true;
                id = (int)row.Cells["Id"].Value;
                textBoxName.Text = (string)row.Cells["Contact_name"].Value;
                textBoxNumber.Text = (string)row.Cells["Number"].Value;
                buttonAdd.Enabled = false;
            }
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            if (textBoxNumber.MaskCompleted && textBoxName.Text != "" &&
                contactProvider.GetContactByName(textBoxName.Text.Trim()) == null)
                buttonAdd.Enabled = true;
        }

        private void LoadContacts(List<Contact> list)
        {
            dataGridView1.Rows.Clear();
            if (list.Count > 0)
            {
                dataGridView1.Visible = true;
                foreach (Contact item in list)
                    dataGridView1.Rows.Add(item.Id, item.Name, item.Number);
            }
            else dataGridView1.Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (contactProvider.GetContactByName(textBoxName.Text.Trim()) != null)
                MessageBox.Show(" онтакт с таким именем уже существует! ”кажите другое им€ или обновите существующий контакт");
            else
            {
                contactProvider.Add(textBoxName.Text, textBoxNumber.Text);
                ClearFields();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (textBoxName.Text != "" && textBoxNumber.Text != "")
                {
                    contactProvider.Update(new Contact(id, textBoxName.Text, textBoxNumber.Text));
                    ClearFields();
                }
                else MessageBox.Show("ѕол€ не могут быть пустыми!");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                contactProvider.Delete(id);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            id = 0;
            textBoxName.Clear();
            textBoxNumber.Clear();
            isProgramEvent = true;
            if (textBoxSearch.Text == "")
                LoadContacts(contactProvider.GetContacts());
            else LoadContacts(contactProvider.GetContactsByInitialLetters(textBoxSearch.Text.Trim().ToLower()));
            isProgramEvent = false;
        }
    }
}