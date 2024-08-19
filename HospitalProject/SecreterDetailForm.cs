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
    public partial class SecreterDetailForm : Form
    {
        public SecreterDetailForm()
        {
            InitializeComponent();
        }
        SqlConn bgl =  new SqlConn();

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblFin_Click(object sender, EventArgs e)
        {

        }
        public string SecreterFin;
        private void SecreterDetailForm_Load(object sender, EventArgs e)
        {
            //ComboSahe
            SqlCommand saheCommad = new SqlCommand("Select BranchName from Tbl_Branchs", bgl.baglanti());
            SqlDataReader saheReader = saheCommad.ExecuteReader();
            while (saheReader.Read())
            {
                comboSahe.Items.Add(saheReader[0].ToString());
            }


            SqlCommand cmd = new SqlCommand($"Select SecreterName+' '+SecreterSurname,SecreterMail  from Tbl_Secreter where SecreterFin=@FinCode",bgl.baglanti());
            cmd.Parameters.AddWithValue("@Fincode", SecreterFin);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblNameSurname.Text = dr[0].ToString();
                lblMail.Text = dr[1].ToString();    
            }
            lblFin.Text = SecreterFin;


            //Branch in datagridview
            DataTable dt = new DataTable(); 
            SqlDataAdapter da =  new SqlDataAdapter("Select * from Tbl_Branchs",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            //Doctors in datagridview
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select *  from Tbl_Doctors", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource= dt1;

             
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Insert into Tbl_Notifcation (NotifcationText) values(@n1)", bgl.baglanti());
            sqlCommand.Parameters.AddWithValue("@n1", txtNotifcationText.Text);

            sqlCommand.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show($"Bildirişi əlavə olundu", "İnformasiya",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txtNotifcationText.Text = string.Empty;

        }

        private void comboSahe_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDoctor.Items.Clear();
            SqlCommand doctorCommad = new SqlCommand($"Select DoctorName + ' ' + DoctorSurname from Tbl_Doctors where DoctorBranch='{comboSahe.Text}'", bgl.baglanti());
            SqlDataReader doctorReader = doctorCommad.ExecuteReader();
            while (doctorReader.Read())
            {
                comboDoctor.Items.Add(doctorReader[0]);
            }
        }

        private void btnDoctorList_Click(object sender, EventArgs e)
        {
            AddDoctorPanel addDoctor  =  new AddDoctorPanel();
            addDoctor.Show();
        }
    }
} 
