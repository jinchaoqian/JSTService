// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 16:06:48
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 16:30:31
// ***********************************************************************
// <copyright file="jdp_jx_trade.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Models namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 聚石塔推送经销订单
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public partial class jdp_jx_trade 
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        /// <value>订单编号</value>
        /// <remarks>聚石塔WebService</remarks>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long dealer_order_id { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <value>订单状态</value>
        /// <remarks>聚石塔WebService</remarks>
        [StringLength(64)]
        public string order_status { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        /// <value>卖家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        [StringLength(32)]
        public string supplier_nick { get; set; }

        /// <summary>
        /// 经销商名称
        /// </summary>
        /// <value>经销商名称</value>
        /// <remarks>聚石塔WebService</remarks>
        [StringLength(32)]
        public string applier_nick { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        /// <value>下单时间.</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime? applied_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        /// <value>修改时间</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime? modified_time { get; set; }

        /// <summary>
        /// Gets or sets the jdp_hashcode.
        /// </summary>
        /// <value>The jdp_hashcode.</value>
        /// <remarks>聚石塔WebService</remarks>
        [StringLength(128)]
        public string jdp_hashcode { get; set; }

        /// <summary>
        /// 聚石塔推送数据
        /// </summary>
        /// <value>聚石塔推送数据</value>
        /// <remarks>聚石塔WebService</remarks>
        [Column(TypeName = "text")]
        public string jdp_response { get; set; }

        /// <summary>
        /// 聚石塔修改时间
        /// </summary>
        /// <value>聚石塔修改时间</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime? jdp_modified { get; set; }

        /// <summary>
        /// 聚石塔创建时间
        /// </summary>
        /// <value>聚石塔创建时间</value>
        /// <remarks>聚石塔WebService</remarks>
        public DateTime? jdp_created { get; set; }
    }
}
