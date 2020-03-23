using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PcbHunt.Data.UnitOfWorks
{
    /// <summary>
    /// 注册单元管理器
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// 提交
        /// </summary>
        void Commit();
       
        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        void Register(IUnitOfWork unitOfWork);
    }
}