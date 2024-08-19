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
    public partial class SecreterLoginForm : Form
    {
        SqlConn bgl = new SqlConn();    
        public SecreterLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Select *  from Tbl_Secreter where SecreterFin='{txtFin.Text}' and SecreterPassword='{txtPass.Text}'",bgl.baglanti());
            SqlDataReader rdr = cmd.ExecuteReader();
            if( rdr.Read() )
            {
                SecreterDetailForm detail = new SecreterDetailForm();
                detail.SecreterFin = txtFin.Text;
                detail.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fin kod və ya şifrə yanlışdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SecreterLoginForm loginForm = new SecreterLoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void SecreterLoginForm_Load(object sender, EventArgs e)
        {
            txtFin.Text = "45RT7I";
            txtPass.Text = "123";
        }
    }
}
