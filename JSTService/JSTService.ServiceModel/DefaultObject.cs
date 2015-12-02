// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-29 17:10:20
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 15:11:10
// ***********************************************************************
// <copyright file="DefaultObject.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

/// <summary>
/// The ServiceModel namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel
{
    /// <summary>
    /// 请求对象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>聚石塔WebService</remarks>
    public class DefaultObject<T> : IReturn<T> 
    {
        /// <summary>
        /// 初始化请求对象 <see cref="DefaultObject{T}" /> class.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public DefaultObject()
        {
            PageSize = 500;
            PageNo = 1;
            StartDateTime = DateTime.Now.AddMonths(-1);
            EndDateTime  = DateTime.Now;
        }

        /// <summary>
        /// 授权码
        /// </summary>
        /// <value>授权码</value>
        /// <remarks>聚石塔WebService</remarks>
        public string AppKey { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        /// <value>签名</value>
        /// <remarks>聚石塔WebService</remarks>
        public string Sign { get; set; }

        /// <summary>
        /// 分页大小，最大500条记录
        /// </summary>
        /// <value>分页大小</value>
        /// <remarks>聚石塔WebService</remarks>
        public int PageSize { get; set; }

        /// <summary>
        /// 页码，默认1
        /// </summary>
        /// <value>页码</value>
        /// <remarks>聚石塔WebService</remarks>
        public int PageNo { get; set; }

        /// <summary>
        /// 请求时间戳，有效期5分钟
        /// </summary>
        /// <value>请求时间戳</value>
        /// <remarks>聚石塔WebService</remarks>
        public double TimeStamp { get; set; }

        /// <summary>
        /// 时间类型，0：聚石塔更新时间；1：淘宝订单时间
        /// </summary>
        /// <value>The type of the date.</value>
        /// <remarks>聚石塔WebService</remarks>
        public int DateType { get; set; }

        /// <summary>
        /// 开始查询时间，格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <value>开始查询时间.</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 截止查询时间，格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <value>截止查询时间</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime EndDateTime { get; set; }
    }
}
