using System;
using System.Collections.Generic;
using System.Text;

namespace PcbHunt.Core.Validations
{
    /// <summary>
    /// 验证操作
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// 验证
        /// </summary>
        ValidationResultCollection Validate();
    }
}

