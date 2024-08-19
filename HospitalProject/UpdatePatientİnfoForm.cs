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
    public partial class UpdatePatientİnfoForm : Form
    {
        SqlConn bgl = new SqlConn();
        public UpdatePatientİnfoForm()
        {
            InitializeComponent();
        }

        public string PatientFinCode;
        private void UpdatePatientİnfoForm_Load(object sender, EventArgs e)
        {
           
            
            SqlCommand sqlCommand = new SqlCommand($"Select * from Tbl_Patient where PatiendFIN = '{PatientFinCode}'", bgl.baglanti());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                txtname.Text = reader[1].ToString();
                txtsurname.Text = reader[2].ToString();
                txtFin.Text = reader[3].ToString();
                txtmail.Text = reader[4].ToString();
                txtMobile.Text = reader[5].ToString();
                comboGender.Text = reader[6].ToString();
                txtpassword.Text = reader[7].ToString();
            }

            MessageBox.Show($"Hörmətli {txtname.Text} {txtsurname.Text}, məlumatlarda düzəliş edən zaman diqqətli olun" ,"Xəbərdarlıq" ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            SqlCommand cmd = new SqlCommand($"UPDATE  Tbl_Patient set PatientName='{txtname.Text}', PatientSurname='{txtsurname.Text}',PatiendFIN='{txtFin.Text}',PatientMail='{txtmail.Text}',PatientPhone='{txtMobile.Text}',PatientGender='{comboGender.Text}',PatientPassword='{txtpassword.Text}'where PatiendFIN='{PatientFinCode}'",bgl.baglanti());
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show($"Hörmətli {txtname.Text} {txtsurname.Text}, məlumatlarınız uğurla yeniləndi", "İnformasiya", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            PatienrDeatilForm deatilForm = new PatienrDeatilForm();
            deatilForm.FinCode = txtFin.Text;
            deatilForm.Show();
            this.Close();
        }
    }
}
