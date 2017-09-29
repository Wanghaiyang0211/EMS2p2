using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS
{
    public partial class frmLogin : Form
    {
        EMS.BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cPopedom popedom = new EMS.BaseClass.cPopedom();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("�û����Ʋ���Ϊ�գ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataSet ds = null;
            popedom.SysUser = txtUserName.Text;
            popedom.Password = txtUserPwd.Text;
            try
            {
                ds = baseinfo.Login(popedom);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmMain frm_main = new frmMain();
                frm_main.Show();
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["stock"])) frm_main.toolStripMenuItem1.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["vendition"])) frm_main.toolStripMenuItem7.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["storage"])) frm_main.toolStripMenuItem15.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["system"])) frm_main.toolStripMenuItem24.Enabled = true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["base"])) frm_main.toolStripMenuItem20.Enabled = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("�û����ƻ����벻��ȷ��","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //�ж��Ƿ���Enter��
                txtUserPwd.Focus();//����꽹���ƶ��������롱�ı���
        }

        private void txtUserPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//�ж��Ƿ���Enter��
                btnLogin.Focus();//����꽹���ƶ�������¼����ť
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}