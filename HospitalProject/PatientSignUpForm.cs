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
    public partial class PatientSignUpForm : Form
    {
        SqlConn sqlConn = new SqlConn();
        public PatientSignUpForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                    using (SqlCommand cmd = new SqlCommand("Insert into Tbl_Patient (PatientName,PatientSurname,PatiendFIN,PatientMail,PatientPhone,PatientGender,PatientPassword) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7)", sqlConn.baglanti()))
                    {
                        cmd.Parameters.AddWithValue("@P1", txtname.Text);
                        cmd.Parameters.AddWithValue("@P2", txtsurname.Text);
                        cmd.Parameters.AddWithValue("@P3", txtfincode.Text);
                        cmd.Parameters.AddWithValue("@P4", txtmail.Text);
                        cmd.Parameters.AddWithValue("@P5", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@P6", comboGender.Text);
                        cmd.Parameters.AddWithValue("@P7", txtpassword.Text);
                        cmd.ExecuteNonQuery();
                        sqlConn.baglanti().Close();
                        MessageBox.Show("Qeydiyyat uğurla tamamlandı", $"Təbriklər {txtname.Text} {txtsurname.Text}!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PatientLoginForm loginForm = new PatientLoginForm();
                        loginForm.Show();
                        this.Hide();
                    };
                
              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void PatientSignUpForm_Load(object sender, EventArgs e)
        {
        }
    }
}
