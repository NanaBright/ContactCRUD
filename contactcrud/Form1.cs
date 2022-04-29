using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contactcrud;
using MySql.Data.MySqlClient;



namespace contactcrud
{
    public partial class Form1 : Form
    {
        conn.CRUD crud = new conn.CRUD();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'contactdbDataSet.data' table. You can move, or remove it, as needed.

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    userid.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    u_firstname.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    u_surname.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    u_gender.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    u_phonenumber.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    u_email.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                }          
            }
            catch
            {
                MessageBox.Show("Dont Click the Header!");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            CREATE();
            READ();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DELETE();
            READ();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UPDATE();
            READ();
        }

        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;

        }

        public void CREATE()
        {
            crud.firstname = firstname.Text;
            crud.surname = surname.Text;
            crud.gender = gender.Text;
            crud.phonenumber = phonenumber.Text;
            crud.email = email.Text;
            crud.Create_data();
        }
        public void UPDATE()
        {
            crud.firstname = u_firstname.Text;
            crud.surname = u_surname.Text;
            crud.gender = u_gender.Text;
            crud.phonenumber = u_phonenumber.Text;
            crud.email = u_email.Text;
            crud.Update_data();

        }

        public void DELETE()
        {
            crud.userid = userid.Text;
            crud.Delete_data();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
