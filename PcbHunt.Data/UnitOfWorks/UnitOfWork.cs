using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PcbHunt.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbConnection Connection { get; }

        /// <summary>
        /// 工作单元事务
        /// </summary>
        public IDbTransaction Transaction { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connection"></param>
        public UnitOfWork(IDbConnection connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            if (Transaction != null)
                Transaction.Commit();
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();

            if (Connection != null)
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        /// <summary>
		/// 开始事务
		/// </summary>
		/// <param name="transactionMethod"></param>
		/// <param name="IsolationLevel"></param>
		/// <returns></returns>
        public IUnitOfWork BeginTransaction(Action transactionMethod, IsolationLevel IsolationLevel = IsolationLevel.Serializable)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            Transaction = Connection.BeginTransaction(IsolationLevel);
            try
            {
                transactionMethod.Invoke();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
            }
            return this;
        }
    }
}
