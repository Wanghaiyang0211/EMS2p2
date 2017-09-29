using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//�������
using System.Data.SqlClient;
using System.Data;

//������ƵĲ��ã���ð�exception message����ȥ
using System.Windows.Forms;

namespace EMS.BaseClass
{
    class DataBase:IDisposable
    {
        const bool DATA_BASE_OFF = false;

        private SqlConnection con;  //�������Ӷ���

        #region   �����ݿ�����
        /// <summary>
        /// �����ݿ�����.
        /// </summary>
        private void Open()
        {
            if (con == null)//�ж����Ӷ����Ƿ�Ϊ��
            {
                //�������ݿ����Ӷ��� sa nwpu2014...
                con = new SqlConnection("server=hxlvps.hellolzc.cn;uid=sa;pwd=nwpu2014...;database=db_EMS;Trusted_Connection=false;");
            }
            if (con.State == System.Data.ConnectionState.Closed)//�ж����ݿ������Ƿ�ر�
                con.Open();//�����ݿ�����
        }
        #endregion

        #region  �ر�����
        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if (con != null)//�ж����Ӷ����Ƿ�Ϊ��
                con.Close();//�ر����ݿ�����
        }
        #endregion

        #region �ͷ����ݿ�������Դ
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            if (con != null)//�ж����Ӷ����Ƿ�Ϊ��
            {
                con.Dispose();//�ͷ����ݿ�������Դ
                con = null;//�������ݿ�����Ϊ��
            }
        }
        #endregion
		
        #region   �������ı���ӵ�SqlCommand
        /// <summary>
        /// ����һ��SqlCommand�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams"�����ı��������</param>
        /// <returns>����SqlCommand����</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            this.Open();//�����ݿ�����
            SqlCommand cmd = new SqlCommand(procName, con);//����SqlCommand�������
            cmd.CommandType = CommandType.Text;//ָ��Ҫִ�е�����Ϊ�����ı�
            // ���ΰѲ������������ı�
            if (prams != null)//�ж�SQL�����Ƿ�Ϊ��
            {
                foreach (SqlParameter parameter in prams)//�������ݵ�ÿ��SQL����
                    cmd.Parameters.Add(parameter);//��SQL������ӵ�ִ�����������
            }
            //���뷵�ز���
            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,string.Empty, DataRowVersion.Default, null));
            return cmd;//����SqlCommand�������
        }
        #endregion

		/////////////////////////////////////////////////////////////////////////////////
		
        #region   �����������ת��ΪSqlParameter����
        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);//����SQL����
        }

        /// <summary>
        /// ��ʼ������ֵ
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;//����SQL��������
            if (Size > 0)//�жϲ����ֶ��Ƿ����0
                param = new SqlParameter(ParamName, DbType, Size);//����ָ�������ͺʹ�С����SQL����
            else
                param = new SqlParameter(ParamName, DbType);//����ָ�������ʹ���SQL����
            param.Direction = Direction;//����SQL����������
            if (!(Direction == ParameterDirection.Output && Value == null))//�ж��Ƿ�Ϊ�������
                param.Value = Value;//���ò�������ֵ
            return param;//����SQL����
        }
        #endregion
		
		/////////////////////////////////////////////////////////////////////////////////

        #region   ִ�в��������ı�(�����ݿ������ݷ���)
        /// <summary>
        /// ִ������
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);//����SqlCommand�������
            try
            {
                cmd.ExecuteNonQuery();//ִ��SQL����
            }
            catch (Exception ex0) 
            {
                //������ƵĲ��ã���ð�exception message����ȥ
                MessageBox.Show(ex0.Message);
                this.Close();//�ر����ݿ�����
                return -1;
            }
            this.Close();//�ر����ݿ�����
            return (int)cmd.Parameters["ReturnValue"].Value;//�õ�ִ�гɹ�����ֵ
        }
        /// <summary>
        /// ֱ��ִ��SQL���
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <returns></returns>
        public int  RunProc(string procName)
        {
            this.Open();//�����ݿ�����
            SqlCommand cmd = new SqlCommand(procName, con);//����SqlCommand�������
            try
            {
                cmd.ExecuteNonQuery();//ִ��SQL����
            }
            catch (Exception ex0) 
            {
                //������ƵĲ��ã���ð�exception message����ȥ
                MessageBox.Show(ex0.Message);
                this.Close();//�ر����ݿ�����
                return -1;
            }
            this.Close();//�ر����ݿ�����
            return 1;//����1����ʾִ�гɹ�
        }

        #endregion

		/////////////////////////////////////////////////////////////////////////////////
		
        #region �������ı���ӵ�SqlDataAdapter
        /// <summary>
        /// ����һ��SqlDataAdapter�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
        {
            this.Open();//�����ݿ�����
            SqlDataAdapter dap = new SqlDataAdapter(procName, con);//�����Ž�������
            dap.SelectCommand.CommandType = CommandType.Text;//ָ��Ҫִ�е�����Ϊ�����ı�
            if (prams != null)//�ж�SQL�����Ƿ�Ϊ��
            {
                foreach (SqlParameter parameter in prams)//�������ݵ�ÿ��SQL����
                    dap.SelectCommand.Parameters.Add(parameter);//��SQL������ӵ�ִ�����������
            }
            //���뷵�ز���
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,string.Empty, DataRowVersion.Default, null));
            return dap;//�����Ž�������
        }
        #endregion		
		
        #region   ִ�в��������ı�(�з���ֵ)
        /// <summary>
        /// ִ�в�ѯ�����ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, SqlParameter[] prams,string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);//�����Ž�������
            DataSet ds = new DataSet();//�������ݼ�����
            dap.Fill(ds, tbName);//������ݼ�
            this.Close();//�ر����ݿ�����
            return ds;//�������ݼ�
        }

        /// <summary>
        /// ִ�������ı������ҷ���DataSet���ݼ� //����1
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);//�����Ž�������
            DataSet ds = new DataSet();//�������ݼ�����
            dap.Fill(ds, tbName);//������ݼ�
            this.Close();//�ر����ݿ�����
            return ds;//�������ݼ�
        }

        #endregion

    }
}
