using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    public void load()
        {
            ketnoi.openketnoi();
            //load listBox
            listban.DataSource = ketnoi.gettable("select *from ban");
            listban.DisplayMember = "tenban";
            listban.ValueMember = "maban";

            //Load DataGridView
            dataGridView1.DataSource = ketnoi.gettable("select *from hoadon");
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            ketnoi.dongketnoi();
        }

    private void listban_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ma = listban.SelectedValue.ToString();
        dataGridView1.DataSource = ketnoi.gettable("select * from hoadon where hoadon.maban='"+ma+"'");
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
            int t = dataGridView1.CurrentCell.RowIndex;
            txtmahd.Text = dataGridView1.Rows[t].Cells[0].Value.ToString();
            txttenhd.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
            txtngaylap.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
            txtthucdon.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
            txtmaban.Text = dataGridView1.Rows[t].Cells[4].Value.ToString();
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthoat.Enabled = true;
    }
        private int chon=0;

        private void btnsua_Click(object sender, EventArgs e)
        {
            chon = 2;
        
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
              DialogResult = MessageBox.Show(" Do you want to exit ?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            chon = 1;
          
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            tangma _tm = new tangma();
            txtmahd.Text = _tm.matutang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure want to delete ?", "Notice",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                ketnoi.openketnoi();
                ketnoi.executeQuery("delete from hoadon where mahd='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' ");
                load();
                ketnoi.dongketnoi();
            }
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            chon = 0;
        }
        //Save Button
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (chon == 1) // gọi Button Thêm
            {
                ketnoi.openketnoi();
                ketnoi.executeQuery("insert into hoadon values('" + txtmahd.Text + "','" + txttenhd.Text + "','" + DateTime.Parse(txtngaylap.Text) + "','" +txtthucdon.Text + "','" + txtmaban.Text + "')");
                load();
                btnluu.Enabled = true;
                btnhuy.Enabled = true;
            }
            else if (chon == 2)// gọi Button Sửa
            {
                ketnoi.openketnoi();
                ketnoi.executeQuery("update hoadon set mahd='" + txtmahd.Text + "',tenhd='" + txttenhd.Text + "',ngaylap='" + DateTime.Parse(txtngaylap.Text) + "',thucdon='" + txtthucdon.Text + "',maban='" + txtmaban.Text + "' where mahd='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                load();
                btnluu.Enabled = true;
                btnhuy.Enabled = true;
            }
            else
            {
                chon = 0;
            }
        }

    }

}
