using HospitalProject.Commands.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class PatienrDeatilForm : Form
    {
       
        public PatienrDeatilForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        public string FinCode;
        public string NameSurname;
        private void PatienrDeatilForm_Load(object sender, EventArgs e)
        {
            SqlConn bgl = new SqlConn();
            lblNameSurname.Text = NameSurname;
            lblFin.Text = FinCode;
            SqlCommand command = new SqlCommand("Select  PatientName,PatientSurname from Tbl_Patient where PatiendFIN = @p1", bgl.baglanti());
            command.Parameters.Add("@p1", lblFin.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                lblNameSurname.Text = dr[0] + " " + dr[1];  
            }
            bgl.baglanti().Close();

            //Active appoitnmet
            DataTable dt  = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"Select *  from Tbl_Appointment where PatientFin = '{FinCode}'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Saheler
            SqlCommand command2 = new SqlCommand("Select * from Tbl_Branchs", bgl.baglanti());
            SqlDataReader sqlDataReader = command2.ExecuteReader();
            comboBox1.Text = "--Seçin--";
            while (sqlDataReader.Read())
            {
                comboBox1.Items.Add(sqlDataReader[1]);
            }
            bgl.baglanti().Close();

        }
    }
}
