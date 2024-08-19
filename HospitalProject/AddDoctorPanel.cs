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
    public partial class AddDoctorPanel : Form
    {
        SqlConn bgl = new SqlConn();
        public AddDoctorPanel()
        {
            InitializeComponent();
        }

        private void AddDoctorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt =  new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("Select *  from Tbl_Doctor",bgl.baglanti());
            dr.Fill(dt);
            dataGridView1.DataSource= dt;
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
