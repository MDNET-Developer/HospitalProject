using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientLoginForm patientLoginForm = new PatientLoginForm();
            patientLoginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorLoginForm doctorLoginForm = new DoctorLoginForm();
            doctorLoginForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SecreterLoginForm secreter = new SecreterLoginForm(); 
            secreter.Show();
            this.Hide();
        }
    }
}
