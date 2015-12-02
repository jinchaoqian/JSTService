// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-29 17:15:54
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 16:36:38
// ***********************************************************************
// <copyright file="DefaltResponse.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 聚石塔WebService类对象
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel
{
    /// <summary>
    /// WebService返回对象
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class DefaultResponse
    {
        /// <summary>
        /// 查询结果总行数
        /// </summary>
        /// <value>查询结果总行数.</value>
        /// <remarks>聚石塔WebService</remarks>
        public int RecordCount { get; set; }

        /// <summary>
        /// 当前查询页大小
        /// </summary>
        /// <value>当前查询页大小</value>
        /// <remarks>聚石塔WebService</remarks>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询结果有多少页;RecordCount/PageSize
        /// </summary>
        /// <value>查询结果有多少页</value>
        /// <remarks>聚石塔WebService</remarks>
        public int PageCount { get; set; }

        /// <summary>
        /// 当前页内容
        /// </summary>
        /// <value>当前页内容</value>
        /// <remarks>聚石塔WebService</remarks>
        public object Result { get; set; }
    }
}
