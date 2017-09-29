using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//�������
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace EMS.BaseClass
{

    class BaseInfo
    {

        DataBase data = new DataBase();//����DataBase��Ķ���

        #region ���--������λ��Ϣ
        /// <summary>
        /// ���������λ
        /// </summary>
        /// <param name="client"></param>
        /// <returns>����������λid</returns>
        public int AddUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
										
			};
            return (data.RunProc("INSERT INTO tb_units (unitcode, fullname, tax, tel, linkman, address, accounts) VALUES (@unitcode,@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        #endregion 

        #region �޸�--������λ��Ϣ
        /// <summary>
        /// �޸�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_units set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts where unitcode=@unitcode", prams));
        }
        #endregion

        #region ɾ��--������λ��Ϣ
        /// <summary>
        /// ɾ��������λ
        /// </summary>
        /// <param name="client"></param>
        /// <returns>����������λid</returns>
        public int DeleteUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
			};
            return (data.RunProc("delete from tb_units where unitcode=@unitcode", prams));
        }
        #endregion 

        #region ��ѯ--������λ��Ϣ
        /// <summary>
        /// ����--��λ���--�õ�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByUnitCode(cUnitsInfo units,string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where unitcode like @unitcode", prams, tbName));
        }
        /// <summary>
        /// ����--��λ����--�õ�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByFullName(cUnitsInfo units, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--������λ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnits(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units ORDER BY unitcode", tbName));
        }
        #endregion


        #region ���--�����Ʒ��Ϣ
        /// <summary>
        /// ��ӿ����Ʒ������Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int AddStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  SqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  SqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  SqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("INSERT INTO tb_stock (tradecode, fullname, type, standard, unit, produce) VALUES (@tradecode,@fullname,@type,@standard,@unit,@produce)", prams));
        }
        #endregion

        #region �޸�--�����Ʒ��Ϣ
        /// <summary>
        /// �޸Ŀ����Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  SqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  SqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  SqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("update tb_stock set fullname=@fullname,type=@type,standard=@standard,unit=@unit,produce=@produce where tradecode=@tradecode", prams));
        }
        #endregion

        #region ɾ��--�����Ʒ��Ϣ
        /// <summary>
        /// ɾ�������Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int DeleteStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
			};
            return (data.RunProc("delete from tb_stock where tradecode=@tradecode", prams));
        }
        #endregion

        #region ��ѯ--������λ��Ϣ
        /// <summary>
        /// ����--��Ʒ����--�õ������Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <param name="tbName">ӳ��ԭ������</param>
        /// <returns></returns>
        public DataSet FindStockByProduce(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@produce",  SqlDbType.VarChar, 5, stock.Produce+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where produce like @produce", prams, tbName));
        }
        /// <summary>
        /// ����--��Ʒ����--�õ������Ʒ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindStockByFullName(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, stock.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--�����Ʒ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllStock(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock ORDER BY tradecode", tbName));
        }
        #endregion


        #region ���--��˾ְԱ��Ϣ
        /// <summary>
        /// ���--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int AddEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  SqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  SqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("INSERT INTO tb_Employee (employeecode, fullname, sex, dept, tel, memo) VALUES (@employeecode,@fullname,@sex,@dept,@tel,@memo)", prams));
        }
        #endregion

        #region �޸�--��˾ְԱ��Ϣ
        /// <summary>
        /// �޸�--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  SqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  SqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("update tb_Employee set fullname=@fullname,sex=@sex,dept=@dept,tel=@tel,memo=@memo where employeecode=@employeecode", prams));
        }
        #endregion

        #region ɾ��--��˾ְԱ��Ϣ
        /// <summary>
        /// ɾ��--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int DeleteEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
			};
            return (data.RunProc("delete from tb_employee where employeecode=@employeecode", prams));
        }
        #endregion

        #region ��ѯ--��˾ְԱ��Ϣ
        /// <summary>
        /// ����--ְԱ���ڲ���--�õ���˾ְԱ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByDept(cEmployeeInfo employee, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where dept like @dept", prams, tbName));
        }
        /// <summary>
        /// ����--ְԱ����--�õ���˾ְԱ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByFullName(cEmployeeInfo employee, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 20, employee.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--��˾ְԱ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllEmployee(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Employee ORDER BY employeecode", tbName));
        }
        #endregion


        #region ��Ʒ������---���ݹ���

        /// <summary>
        /// �õ�����tbName������Ϣ������Ҫ�������õ����ĵ��ݱ��Ȼ���Զ����
        /// </summary>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet GetAllBill(string tbName_trueName)
        { 
            return(data.RunProcReturn("select * from "+tbName_trueName+"",tbName_trueName));
        }
        /// <summary>
        /// ����������������˻���-����---���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableMainWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,billinfo.BillCode),
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, billinfo.Units),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10, billinfo.Handle),
                						data.MakeInParam("@summary",  SqlDbType.VarChar, 100, billinfo.Summary),
                						data.MakeInParam("@fullpayment",  SqlDbType.Float, 8, billinfo.FullPayment),
                                        data.MakeInParam("@payment",  SqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullpayment,payment) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }
        /// <summary>
        /// ��������˻��������۵�-����---���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableMainSellhouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,billinfo.BillCode),
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, billinfo.Units),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10, billinfo.Handle),
                						data.MakeInParam("@summary",  SqlDbType.VarChar, 100, billinfo.Summary),
                						data.MakeInParam("@fullpayment",  SqlDbType.Float, 8, billinfo.FullPayment),
                                        data.MakeInParam("@payment",  SqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullgathering,gathering) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }



        /// <summary>
        /// ����ϸ����������ݣ��������������˻��������۵��������˻���
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableDetailedWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billcode",  SqlDbType.VarChar, 20, billinfo.BillCode),
                						data.MakeInParam("@tradecode",  SqlDbType.VarChar, 20,billinfo.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20, billinfo.FullName),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 10, billinfo.TradeUnit),
                						data.MakeInParam("@qty",  SqlDbType.Float, 8, billinfo.Qty),
                						data.MakeInParam("@price",  SqlDbType.Float, 8, billinfo.Price),
                                        data.MakeInParam("@tsum",  SqlDbType.Float, 8, billinfo.TSum),
                                        data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
            };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billcode, tradecode, fullname, unit, qty, price,tsum,billdate) VALUES (@billcode,@tradecode,@fullname,@unit,@qty,@price,@tsum,@billdate)", prams));
        }
        /// <summary>
        /// �޸Ŀ�������ͼ�Ȩƽ���۸�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock_QtyAndAveragerprice(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  SqlDbType.Float, 30,stock.Price),
                						data.MakeInParam("@averageprice",  SqlDbType.Float, 10, stock.AveragePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,price=@averageprice,averageprice=@averageprice where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// �޸�������Ʒ�ͽ����˻���Ʒ--��Ŀ����Ʒ����
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateSaleStock_Qty(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
			};
            return (data.RunProc("update tb_stock set qty=@qty where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// �޸Ŀ�����������ۣ��ͽ����˻������һ�μ۸�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock_Qty(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  SqlDbType.Float, 30,stock.SalePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,saleprice=@price where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// ������Ʒ���TradeCode,��Ҫ�õ������ͼ�Ȩƽ���۸����ڶ�����¡�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <param name="tbName">ӳ�����������</param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",SqlDbType.VarChar, 30, stock.TradeCode),
			};
            return (data.RunProcReturn("select * from tb_stock where tradecode like @tradecode", prams, tbName));
        }
        #endregion

        #region ��Ʒ������---��������ϸ��
        /// <summary>
        /// �������---�����˱���ϸ��
        /// </summary>
        /// <param name="currentAccount"></param>
        /// <returns></returns>
        public int AddCurrentAccount(cCurrentAccount currentAccount)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, currentAccount.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,currentAccount.BillCode),
                						data.MakeInParam("@addgathering",  SqlDbType.Float, 8, currentAccount.AddGathering),
                						data.MakeInParam("@factaddfee",  SqlDbType.Float, 8,currentAccount.FactAddFee),
                						data.MakeInParam("@reducegathering",  SqlDbType.Float, 8,currentAccount.ReduceGathering),
                						data.MakeInParam("@factfee",  SqlDbType.Float, 8, currentAccount.FactReduceGathering),
                                        data.MakeInParam("@balance",  SqlDbType.Float, 8, currentAccount.Balance),
                                        data.MakeInParam("@units",  SqlDbType.VarChar, 20,currentAccount.Units),
			};
            return (data.RunProc("INSERT INTO tb_currentaccount (billdate, billcode, addgathering, factaddfee, reducegathering, factfee,balance,units) VALUES (@billdate,@billcode,@addgathering,@factaddfee,@reducegathering,@factfee,@balance,@units)", prams));
        }
        #endregion


        #region ��������--��������
        /// <summary>
        /// ��Ʒ��������--���������˻�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("SELECT a.tradecode, a.fullname, a.averageprice, b.qty, b.tsum FROM tb_stock a INNER JOIN (SELECT SUM(qty) AS qty, SUM(tsum) AS tsum, fullname FROM tb_rewarehouse_detailed GROUP BY fullname) b ON a.fullname = b.fullname WHERE (a.price > 0)", tbName));
        }

        /// <summary>
        /// ��Ʒ�������������˻���
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyAllStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("select tradecode,fullname,sum(qty) as qty,AVG(price) AS price,sum(tsum) as tsum from tb_warehouse_detailed group by tradecode,fullname", tbName));
        }
        #endregion

        #region  ��������--����ͳ��
        /// <summary>
        /// ������Ʒ������ϸͳ��
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, "%"+billinfo.Units+"%"),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������,SUM(b.tsum) AS ������� FROM tb_warehouse_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_warehouse_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @handle WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname",prams, tbName));
        }
        /// <summary>
        /// ������Ʒ����ͳ������
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as ��Ʒ���,fullname as ��Ʒ����,sum(qty) as ��������,sum(tsum)as ������� from tb_warehouse_detailed group by tradecode, fullname", tbName));
        }
        #endregion


        #region  ���۹���--����ͳ��
        /// <summary>
        /// ������Ʒ������ϸͳ��
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30,"%"+ billinfo.Units+"%"),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������,SUM(b.tsum) AS ���۽�� FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @units WHERE (a.billdate BETWEEN '" +starDateTime+ "' AND '" +endDateTime+ "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// ������Ʒ����ͳ������
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as ��Ʒ���,fullname as ��Ʒ����,sum(qty) as ��������,sum(tsum) as ���۽�� from tb_sell_detailed group by tradecode, fullname", tbName));
        }
        #endregion

        #region ���۹���--������״��
        /// <summary>
        /// ͳ����Ʒ����״��
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockStatusSum(string tbName)
        {
            return (data.RunProcReturn("select a.tradecode as ��Ʒ���,a.fullname as ��Ʒ����,a.qty as ��������,a.price AS ���۾���,a.tsum as ���۽��,b.qty2 as '�˻�����',b.tsum2 as '�˻����' from (SELECT tradecode,fullname,avg(price)as price,sum(qty) AS qty, sum(tsum) as tsum from tb_sell_detailed group by tradecode,fullname) a left join (SELECT tradecode,fullname,sum(qty) AS qty2, sum(tsum) as tsum2 from tb_resell_detailed group by tradecode,fullname) b on a.tradecode=b.tradecode ", tbName));
        }
        
        /// <summary>
        /// ��ϸ�˱�����������Ʒ���ۡ��͡���Ʒ�����˻���
        /// </summary>
        /// <param name="strTradeCode"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockDetailed(string strTradeCode,DateTime starDateTime,DateTime endDateTime,string tbName)
        {
            return (data.RunProcReturn("SELECT billdate as ��������, billcode as ���ݱ��, tradecode as ��Ʒ���, fullname as ��Ʒ����, price as ���ۼ۸�, qty as ��������, tsum as ���۽�� FROM "+tbName+" where tradecode = '" + strTradeCode + "' AND billdate BETWEEN '" +starDateTime+ "' AND '" +endDateTime+"'", tbName));
        }
        #endregion

        #region ���۹���--��Ʒ��������
        /// <summary>
        /// �������а���������������λ-�����б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetUnitsList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units", tbName));
        }
        /// <summary>
        /// �������а���������������-�����б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetHandleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_employee", tbName));
        }
        /// <summary>
        /// �����۽������
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetTSumDesc(string handle,string units,DateTime StarDateTime,DateTime EndDateTime,string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������, SUM(b.tsum) AS ���۽�� FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY ���۽�� DESC", tbName));
        }
        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetQtyDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������, SUM(b.tsum) AS ���۽�� FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY �������� DESC", tbName));
        }
        #endregion

        #region ���۹���--��Ʒ���۳ɱ���ϸ
        /// <summary>
        /// ���ݵ��ݱ��--�õ�������ϸ��������
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetDetailedkByBillCode(string billCode, string tbName)
        {
            return (data.RunProcReturn("SELECT tradecode,fullname,price,tsum,SUM(qty) AS qty FROM tb_sell_detailed WHERE (billcode = '" + billCode + "')group by tradecode,fullname,price,tsum",tbName));
        }
        /// <summary>
        /// ���ݵ��ݱ��--�õ�������ϸ��������
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock where tradecode ='" +tradeCode + "'", tbName));
        }
        /// <summary>
        /// �������ڣ�����ѯ��������������
        /// </summary>
        /// <param name="starDataTime"></param>
        /// <param name="endDataTime"></param>
        /// <returns></returns>
        public DataSet FindSellStock(DateTime starDataTime,DateTime endDataTime)
        {
            return (data.RunProcReturn("select * from tb_sell_main where (billdate BETWEEN '" +starDataTime+ " ' AND '" +endDataTime+ " ')", "tb_sell_main"));
        }
        #endregion


        #region ������--���״��
        /// <summary>
        /// ���������Ʒ--������������
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet setStockStatus(string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock order by qty",tbName));
        }
        /// <summary>
        /// ������Ʒ��ţ���ÿ����Ʒ��������Ϣ
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockLimitByTradeCode(string tradeCode,string tbName)
        {
            return(data.RunProcReturn("select * from tb_Stock where tradecode='"+tradeCode+"'",tbName));
        }
       /// <summary>
       /// �����Ʒ����������
       /// </summary>
       /// <param name="stock"></param>
       /// <returns></returns>
        public int UpdateStockLimit(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar,5,stock.TradeCode),
                						data.MakeInParam("@upperlimit",  SqlDbType.Float, 8, stock.UpperLimit),
                						data.MakeInParam("@lowerlimit",  SqlDbType.Float, 8, stock.LowerLimit),
            };
             return (data.RunProc("update tb_stock set upperlimit=@upperlimit,lowerlimit=@lowerlimit where tradecode=@tradecode", prams));
         }
        #endregion

        #region �����Ʒ�����ޱ���
         /// <summary>
        /// �����Ʒ���ޱ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetLowerLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as ��Ʒ���, fullname as ��Ʒ����, qty as �������,upperlimit as �������,lowerlimit as ������� from tb_stock WHERE (qty < lowerlimit) and lowerlimit > 0", "tb_stock"));
        }
        /// <summary>
        /// �����Ʒ���ޱ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetUpperLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as ��Ʒ���, fullname as ��Ʒ����, qty as �������,upperlimit as �������,lowerlimit as ������� FROM tb_stock WHERE (upperlimit < qty) and upperlimit>0","tb_stock"));
        }
        #endregion

        #region ����̵�
        public int CheckStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@check",  SqlDbType.Float, 8,stock.Check),
			};
            return (data.RunProc("update tb_stock set stockcheck=@check where tradecode=@tradecode", prams));
        }
        #endregion


        #region ����λ��Ϣ����--ϵͳ����
        /// <summary>
        /// ����λ��Ϣ����
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateSysUnits(cUnits units)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_unit set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts", prams));
        }
        public int InsertSysUnits(cUnits units)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("insert into tb_unit (fullname,tax,tel,linkman,address,accounts) values (@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        /// <summary>
        /// �õ�����λ��Ϣ����
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnit()
        {
            return (data.RunProcReturn("select * from tb_unit","tb_unit"));
        }
        #endregion

        #region  ���ݿⱸ����ָ�--ϵͳ����
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="bakUpName"></param>
        public void BackUp(string bakUpName)
        {
            data.RunProc("BACKUP DATABASE db_EMS TO DISK ='"+bakUpName+"'");
        }
        /// <summary>
        /// �ָ����ݿ�
        /// </summary>
        /// <param name="reStoreName"></param>
        public void ReStore(string reStoreName)
        {
            data.RunProc("backup log db_EMS to disk='" + reStoreName + "'use master RESTORE DATABASE db_EMS from disk='" + reStoreName + "'");
        }
        #endregion

        #region  ϵͳ��������--ϵͳ����
        /// <summary>
        /// ����ָ�������ݱ�������ݱ�������
        /// </summary>
        /// <param name="tbName_true"></param>
        public void ClearTable(string tbName_true)
        {
            data.RunProc("delete from " + tbName_true + "");
        }
        #endregion

        #region ϵͳ����Ա��Ȩ������--ϵͳ����
        /// <summary>
        /// ���ϵͳ����Ա
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void AddSysUser(string userName,string pwd)
        {
            data.RunProc("INSERT INTO tb_power (sysuser, password) VALUES ('" + userName + "', '" + pwd + "')");
        }
        /// <summary>
        /// ɾ��ϵͳ����Ա
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSysUser(int ID)
        {
            data.RunProc("delete from tb_power where id='"+ID+"'");
        }
        /// <summary>
        /// �������ϵͳ�û���Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUser()
        { 
            return(data.RunProcReturn("select * from tb_power","tb_Power"));
        }
        /// <summary>
        /// �����û�����---��ѯϵͳ�û�
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool FindUserName(string userName)
        {
            DataSet ds = null;
            ds = data.RunProcReturn("select * from tb_power where sysuser='" + userName + "'", "tb_power");
            if (ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// �޸�ϵͳ�û���Ϣ������Ӧ��Ȩ��
        /// </summary>
        /// <param name="popedom"></param>
        public void UpdateSysUser(cPopedom popedom)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@id",  SqlDbType.Int, 4, popedom.ID),
									    data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
                						data.MakeInParam("@stock",  SqlDbType.Bit, 1, popedom.Stock),
                						data.MakeInParam("@vendition",  SqlDbType.Bit, 1, popedom.Vendition),
                						data.MakeInParam("@storage",  SqlDbType.Bit, 1, popedom.Storage),
                						data.MakeInParam("@system",  SqlDbType.Bit, 1, popedom.SystemSet),
                                        data.MakeInParam("@base",  SqlDbType.Bit, 1, popedom.Base_Info),
			};
            int i = data.RunProc("update tb_power set sysuser=@sysuser,password=@password,stock=@stock,vendition=@vendition,storage=@storage,system=@system,base=@base where id=@id", prams);
        }
        #endregion

        #region ������λ����
        /// <summary>
        /// ������λ�б�--��ͳ��Ӧ�ն�-���Ӽ�����
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnitsList()
        {
            return (data.RunProcReturn("SELECT units as ������λ, SUM(addgathering) AS Ӧ������, SUM(reducegathering) AS Ӧ�ռ��� FROM tb_currentaccount GROUP BY units", "tb_currentaccount"));
        }
        /// <summary>
        ///��ѯ��ָ�������ڶ���--�Ƿ���ڣ�����ѯ���
        /// </summary>
        /// <param name="units"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet FindCurrentAccountDate(string units, DateTime starDateTime,DateTime endDateTime)
        {
            return (data.RunProcReturn("SELECT * FROM tb_currentaccount WHERE units='" + units + "' AND billdate BETWEEN '" +starDateTime+"'AND '" +endDateTime+ "'","tb_currentaccount"));
        }
        /// <summary>
        /// �������ˣ������ݵ��ݱ��--��ѯ��ϸ��������
        /// </summary>
        /// <param name="billcode"></param>
        /// <param name="tb_Detailed_true"></param>
        /// <returns></returns>
        public DataSet FindDetailde(string tb_Detailed_true, string billcode)
        {
            return (data.RunProcReturn("select * from "+tb_Detailed_true+" where (billcode='" + billcode + "')ORDER BY tsum","detailed"));
        }
        /// <summary>
        /// �������ˣ������ݵ��ݱ��--��ѯ����������
        /// </summary>
        /// <param name="tb_Main_true"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public DataSet FindMain(string tb_Main_true, string billcode)
        {
            return (data.RunProcReturn("select * from "+tb_Main_true+" where billcode='" + billcode + "'","main"));
        }
        #endregion

        #region �������߹���
        
        public void OpenInernet()
        { 

        }
        #endregion

        #region ϵͳ��¼
        /// <summary>
        /// ϵͳ��¼
        /// </summary>
        /// <param name="popedom"></param>
        /// <returns></returns>
        public DataSet Login(cPopedom popedom)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
			};
            return (data.RunProcReturn("SELECT * FROM tb_power WHERE (sysuser = @sysuser) AND (password = @password)",prams, "tb_power"));
        }
        #endregion
    }
    #region ����������λ--���ݽṹ
    public class cUnitsInfo
    {
        private string unitcode = "";
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";
        private float gathering = 0;
        private float payment = 0;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string UnitCode
        {
            get { return unitcode; }
            set { unitcode = value; }
        }
        /// <summary>
        /// ��λȫ��
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ��λ˰��
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string LinkMan
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// ��λ��ַ
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// �����м��˺�
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        /// <summary>
        /// �ۼ�Ӧ�տ�
        /// </summary>
        public float Gathering
        {
            get { return gathering; }
            set { gathering = value; }
        }
        /// <summary>
        /// �ۼ�Ӧ����
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }
    }

    #endregion

    #region ��������Ʒ--���ݽṹ
    public class cStockInfo
    {
        private string tradecode = "";
        private string fullname = "";
        private string tradetpye = "";
        private string standard = "";
        private string tradeunit = "";
        private string produce = "";
        private float qty = 0;
        private float price = 0;
        private float averageprice = 0;
        private float saleprice = 0;
        private float check = 0;
        private float upperlimit = 0;
        private float lowerlimit = 0;
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }
        /// <summary>
        /// ��λȫ��
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ��Ʒ�ͺ�
        /// </summary>
        public string TradeType
        {
            get { return tradetpye; }
            set { tradetpye = value; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string Standard
        {
            get { return standard; }
            set { standard = value; }
        }
        /// <summary>
        /// ��Ʒ��λ
        /// </summary>
        public string Unit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Produce
        {
            get { return produce; }
            set { produce = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// ����ʱ���һ�μ۸�
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// ��Ȩƽ���۸�
        /// </summary>
        public float AveragePrice
        {
            get { return averageprice; }
            set { averageprice = value; }
        }
        /// <summary>
        /// ����ʱ�����һ������
        /// </summary>
        public float SalePrice
        {
            get { return saleprice; }
            set { saleprice = value; }
        }
        /// <summary>
        /// �̵�����
        /// </summary>
        public float Check
        {
            get { return check; }
            set { check = value; }
        }
        /// <summary>
        /// ��汨������
        /// </summary>
        public float UpperLimit
        {
            get { return upperlimit; }
            set { upperlimit = value; }
        }
        /// <summary>
        /// ��汨������
        /// </summary>
        public float LowerLimit
        {
            get { return lowerlimit; }
            set { lowerlimit = value; }
        }
    }

    #endregion

    #region ���幫˾ְԱ--���ݽṹ
    public class cEmployeeInfo
    {
        private string employeecode = "";
        private string fullname = "";
        private string sex = "";
        private string dept = "";
        private string tel = "";
        private string memo = "";
        /// <summary>
        /// ְԱ���
        /// </summary>
        public string EmployeeCode
        {
            get { return employeecode; }
            set { employeecode = value; }
        }
        /// <summary>
        /// ְԱ����
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ְԱ�Ա�
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// ���ڲ���
        /// </summary>
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        /// <summary>
        /// ְԱ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
     }

    #endregion

    #region ������˵���--���ݽṹ
    public class cBillInfo
    {
        //����ṹ
        private DateTime billdate=DateTime.Now;
        private string billcode = "";
        private string units = "";
        private string handle = "";
        private string summary = "";
        private float fullpayment = 0;
        private float payment = 0;

        //��ϸ��ṹ
        private string tradecode = "";
        private string fullname = "";
        private string tradeunit = "";
        private float qty = 0;
        private float price = 0;
        private float tsum = 0;

        /// <summary>
        /// ¼������
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }
        /// <summary>
        /// ���ݱ��
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// ������λ
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Handle
        {
            get { return handle; }
            set { handle = value; }
        }
        /// <summary>
        /// ժҪ
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }
        /// <summary>
        /// Ӧ�����
        /// </summary>
        public float FullPayment
        {
            get { return fullpayment; }
            set { fullpayment = value; }
        }
        /// <summary>
        /// ʵ�����
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        //***************��ϸ��ṹ******************//
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ��Ʒ��λ
        /// </summary>
        public string TradeUnit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// �۸�
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// ���=����*�۸�
        /// </summary>
        public float TSum
        {
            get { return tsum; }
            set { tsum = value; }
        }
    }
     #endregion

    #region ���������˱���ϸ--���ݽṹ
    public class cCurrentAccount
    {
        private DateTime billdate = DateTime.Now;
        private string billcode = "";
        private float addgathering=0;             //Ӧ������
        private float factaddfee = 0;             //ʵ������
        private float reducegathering = 0;        //Ӧ�ռ���
        private float factreducegathering = 0;    //ʵ�ʼ���
        private float balance = 0;  //Ӧ�������� ���
        private string units = "";

        /// <summary>
        /// ¼������
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }/// <summary>
        /// ���ݱ��
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }/// <summary>
        /// Ӧ������
        /// </summary>
        public float AddGathering
        {
            get { return addgathering; }
            set { addgathering = value; }
        }/// <summary>
        /// ʵ������
        /// </summary>
        public float FactAddFee
        {
            get { return factaddfee; }
            set { factaddfee = value; }
        }/// <summary>
        /// Ӧ�ռ���
        /// </summary>
        public float ReduceGathering
        {
            get { return reducegathering; }
            set { reducegathering = value; }
        }/// <summary>
        /// ʵ�ʼ���
        /// </summary>
        public float FactReduceGathering
        {
            get { return factreducegathering; }
            set { factreducegathering = value; }
        }/// <summary>
        /// ���(Ӧ�ս��-ʵ�ʽ��)
        /// </summary>
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }/// <summary>
        /// ������λ
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
    }

    #endregion

    #region ���屾��λ��Ϣ����--���ݽṹ
    public class cUnits
    {
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";

        /// <summary>
        /// ��λȫ��
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ˰��
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// ��λ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string Linkman
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// ��ϵ��ַ
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// �����м��˺�
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
    }

    #endregion

    #region ������������ϸ���������ݽṹ
    public class cCurrentaccount
    {
        private DateTime billdate = DateTime.Now;
        private string billcode = "";
        private float addgathering = 0;
        private float factaddfee = 0;
        private float reducegathering = 0;
        private float factfee = 0;
        private float balance = 0;
        private string units = "";
        /// <summary>
        /// ¼������
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }
        /// <summary>
        /// ���ݱ��
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// Ӧ������
        /// </summary>
        public float AddGathering
        {
            get { return addgathering; }
            set { addgathering = value; }
        }
        /// <summary>
        /// ʵ������
        /// </summary>
        public float FactAddfee
        {
            get { return factaddfee; }
            set { factaddfee = value; }
        }
        /// <summary>
        /// Ӧ�ռ���
        /// </summary>
        public float ReduceGathering
        {
            get { return reducegathering; }
            set { reducegathering = value; }
        }
        /// <summary>
        /// ʵ�ʼ���
        /// </summary>
        public float FactFee
        {
            get { return factfee; }
            set { factfee = value; }
        }
        /// <summary>
        /// Ӧ�����
        /// </summary>
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        /// <summary>
        /// ������λ
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
    }
    #endregion

    #region ����Ȩ�ޣ������ݽṹ
    public class cPopedom
    {
        private int id = 0;
        private string sysuser = "";
        private string password = "";
        Boolean stock = false;
        Boolean vendition = false;
        Boolean storage = false;
        Boolean system=false;
        Boolean base_info=false;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string SysUser
        {
            get { return sysuser; }
            set { sysuser = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public Boolean Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public Boolean Vendition
        {
            get { return vendition; }
            set { vendition = value; }
        }
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public Boolean Storage
        {
            get { return storage; }
            set { storage = value; }
        }
        /// <summary>
        /// ϵͳ����Ȩ��
        /// </summary>
        public Boolean SystemSet
        {
            get { return system; }
            set { system = value; }
        }
        /// <summary>
        /// ������ϢȨ��
        /// </summary>
        public Boolean Base_Info
        {
            get { return base_info; }
            set { base_info = value; }
        }
    }
    #endregion
}