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
    public partial class PatientLoginForm : Form
    {
      
        public PatientLoginForm()
        {
            InitializeComponent();
        }

        private void PatientLoginForm_Load(object sender, EventArgs e)
        {
            txtFin.Text = "71SPY8D";
            txtPass.Text = "Murad2001";
            txtPass.PasswordChar = '*';
            
        }
      SqlConn bgl = new SqlConn();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PatientSignUpForm signUpForm = new PatientSignUpForm();
            signUpForm.Show();
            this.Hide();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
      
            SqlCommand command = new SqlCommand("Select * From Tbl_Patient Where PatiendFIN=@p1 and PatientPassword=@p2", bgl.baglanti());
            command.Parameters.AddWithValue("@p1", txtFin.Text);
            command.Parameters.AddWithValue("@p2", txtPass.Text);
            SqlDataReader reader = command.ExecuteReader();

         
            if(reader.Read())
            {
                PatienrDeatilForm form = new PatienrDeatilForm();
               
                form.FinCode=txtFin.Text.ToString();
                form.Show();
                this.Hide();   
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır.");
                PatientLoginForm form2 = new PatientLoginForm();
                form2.Show();
                this.Hide();
            }
            bgl.baglanti().Close();
        }
    }
}
