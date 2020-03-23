using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PcbHunt.Data.UnitOfWorks
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();

        /// <summary>
		/// 开启事务
		/// </summary>
		/// <param name="transactionMethod"></param>
		/// <param name="IsolationLevel"></param>
		IUnitOfWork BeginTransaction(Action transactionMethod, IsolationLevel IsolationLevel = IsolationLevel.Serializable);

    }
}
