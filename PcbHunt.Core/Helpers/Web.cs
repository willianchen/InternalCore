using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcbHunt.Core.Helpers
{
    /// <summary>
    /// Web操作
    /// </summary>
    public static partial class Web
    {
        #region 静态构造方法

        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static Web()
        {
            try
            {
                HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
                Environment = Ioc.Create<IHostingEnvironment>();
            }
            catch
            {
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        /// <summary>
        /// 当前Http请求
        /// </summary>
        public static HttpRequest Request => HttpContext?.Request;

        /// <summary>
        /// 当前Http响应
        /// </summary>
        public static HttpResponse Response => HttpContext?.Response;

        /// <summary>
        /// 宿主环境
        /// </summary>
        public static IHostingEnvironment Environment { get; set; }

        #endregion


        #region AccessToken(获取访问令牌)

        /// <summary>
        /// 获取访问令牌
        /// </summary>
        public static string AccessToken
        {
            get
            {
                var authorization = Request?.Headers["Authorization"].ToSafeString();
                if (string.IsNullOrWhiteSpace(authorization))
                    return null;
                var list = authorization.Split(' ');
                if (list.Length == 2)
                    return list[1];
                return null;
            }
        }

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => Request?.Headers["User-Agent"];

        #endregion

        #region RootPath(根路径)

        /// <summary>
        /// 根路径
        /// </summary>
        public static string RootPath => Environment?.ContentRootPath;

        #endregion 

        #region WebRootPath(Web根路径)

        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        public static string WebRootPath => Environment?.WebRootPath;

        #endregion 
    }
}
