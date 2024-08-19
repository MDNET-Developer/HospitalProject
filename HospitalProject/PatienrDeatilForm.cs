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
        SqlConn bgl = new SqlConn();
        public PatienrDeatilForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand comand3 = new SqlCommand($"Select DoctorName,DoctorSurname from Tbl_Doctors where DoctorBranch=@p1", bgl.baglanti());
            comand3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = comand3.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0] + " " + dr[1]);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdatePatientİnfoForm updatePatient = new UpdatePatientİnfoForm();
            updatePatient.PatientFinCode = lblFin.Text;
            updatePatient.Show();
        }
        public string FinCode;
        public string NameSurname;
        private void PatienrDeatilForm_Load(object sender, EventArgs e)
        {
            SqlCommand comand3 = new SqlCommand("Select count(NotifcationId) from Tbl_Notifcation", bgl.baglanti());
            SqlDataReader reader = comand3.ExecuteReader();
            while (reader.Read())
            {
                lblNotifCount.Text = reader[0].ToString();
            }


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
            DataTable dt = new DataTable();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"Select *  from Tbl_Appointment where PatientFin = '{comboBox2.Text}'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
