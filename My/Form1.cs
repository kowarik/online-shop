using System;
using System.Data;
using System.Windows.Forms;

namespace My
{
    public partial class Form1 : Form
    {
        private DataSet d = new DataSet();
        private DataTable tovar = new DataTable();
        
        public Form1()
        {
            InitializeComponent();
            
            // Добавляем табличку к DataSet
            d.Tables.Add(tovar);
            // Создаём колонки таблички и добавляем их
            DataColumn dc1 = new DataColumn("ID", System.Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Name", System.Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("Price", System.Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("Description", System.Type.GetType("System.String"));

            tovar.Columns.Add(dc1);
            tovar.Columns.Add(dc2);
            tovar.Columns.Add(dc3);
            tovar.Columns.Add(dc4);

            var rand = new Random();
            for (int i = 1; i<=100; i++)
            {
                string[] dr = new string[] { $"{i}", $"Tovar {rand.Next(1, 1000)}", $"{rand.Next(100, 1000)}", "в наличии" };
                tovar.Rows.Add(dr);
            }
            dataGridView1.DataSource = tovar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv = tovar.DefaultView;
            dataGridView1.DataSource = dv;
            dv.Sort = "Price asc";
            dataGridView1.Columns[0].Width = 25;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dv = tovar.DefaultView;
            dataGridView1.DataSource = dv;
            dv.Sort = "Name asc";
            dataGridView1.Columns[0].Width = 25;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            textBox1.Text = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                DataTable zakaz = new DataTable();
                DataColumn dc1 = new DataColumn("ID", System.Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("Name", System.Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("Price", System.Type.GetType("System.String"));
                DataColumn dc4 = new DataColumn("Description", System.Type.GetType("System.String"));
                zakaz.Columns.Add(dc1);
                zakaz.Columns.Add(dc2);
                zakaz.Columns.Add(dc3);
                zakaz.Columns.Add(dc4);

                int a = dataGridView1.CurrentRow.Index;

                DataRow dr = zakaz.NewRow();
                dr["ID"] = dataGridView1.Rows[a].Cells[0].Value;
                dr["Name"] = dataGridView1.Rows[a].Cells[1].Value;
                dr["Price"] = dataGridView1.Rows[a].Cells[2].Value;
                dr["Description"] = dataGridView1.Rows[a].Cells[3].Value;
                zakaz.Rows.Add(dr);
                dataGridView2.DataSource = zakaz;
                textBox5.Text = Convert.ToString(dataGridView2.Rows[0].Cells[2].Value);
                textBox9.Text = Convert.ToString(dataGridView2.Rows[0].Cells[1].Value);
                tabControl1.SelectedTab = tabPage2;
                label25.Text = Convert.ToString(dataGridView2.Rows[0].Cells[2].Value);
            }
            else
            {
                label17.Text = "Выберите товар!";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((checkedListBox2.CheckedItems.Count == 1 && textBox6.Text.Length != 0 && textBox7.Text.Length != 0 && textBox8.Text.Length != 0) || 
                (checkedListBox3.CheckedItems.Count == 1) && checkedListBox2.CheckedItems.Count != checkedListBox3.CheckedItems.Count)
            {
                label14.Text = "Ожидание отправки администратором.";
                textBox10.Text = textBox3.Text;
                textBox11.Text = textBox2.Text;
                tabControl1.SelectedTab = tabPage4;

                DataTable admin = new DataTable();
                DataColumn dc1 = new DataColumn("ID", System.Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("Name", System.Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("Price", System.Type.GetType("System.String"));
                DataColumn dc4 = new DataColumn("Payment", System.Type.GetType("System.String"));
                DataColumn dc5 = new DataColumn("Phone", System.Type.GetType("System.String"));
                DataColumn dc6 = new DataColumn("Address", System.Type.GetType("System.String"));
                DataColumn dc7 = new DataColumn("FIO", System.Type.GetType("System.String"));
                admin.Columns.Add(dc1);
                admin.Columns.Add(dc2);
                admin.Columns.Add(dc3);
                admin.Columns.Add(dc4);
                admin.Columns.Add(dc5);
                admin.Columns.Add(dc6);
                admin.Columns.Add(dc7);
                int a = dataGridView2.CurrentRow.Index;
                DataRow dr = admin.NewRow();
                dr["ID"] = dataGridView2.Rows[a].Cells[0].Value;
                dr["Name"] = dataGridView2.Rows[a].Cells[1].Value;
                dr["Price"] = dataGridView2.Rows[a].Cells[2].Value;
                if (checkedListBox2.CheckedItems.Count == 1 || checkedListBox3.CheckedItems.Count == 1)
                {
                    dr["Payment"] = "+";
                }
                else dr["Payment"] = "-";
                dr["Phone"] = textBox4.Text;
                dr["Address"] = textBox3.Text;
                dr["FIO"] = textBox2.Text;
                admin.Rows.Add(dr);
                dataGridView3.DataSource = admin;
                textBox12.Text = Convert.ToString(dataGridView3.Rows[a].Cells[0].Value);
                textBox13.Text = Convert.ToString(dataGridView3.Rows[a].Cells[3].Value);
            }
            else
            {
                label19.Text = "Заполните\nсоответствующие поля!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                tabControl1.SelectedTab = tabPage3;
            }
            else
            {
                label18.Text = "Заполните все поля!";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable courier = new DataTable();
            DataColumn dc1 = new DataColumn("ID", System.Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Address", System.Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("Phone", System.Type.GetType("System.String"));
            courier.Columns.Add(dc1);
            courier.Columns.Add(dc2);
            courier.Columns.Add(dc3);
            int a = dataGridView3.CurrentRow.Index;
            DataRow dr = courier.NewRow();
            dr["ID"] = dataGridView3.Rows[a].Cells[0].Value;
            dr["Address"] = dataGridView3.Rows[a].Cells[5].Value;
            dr["Phone"] = dataGridView3.Rows[a].Cells[4].Value;
            courier.Rows.Add(dr);
            dataGridView4.DataSource = courier;
            label14.Text = "Подтверждено Администратором";
        }
    }
}
