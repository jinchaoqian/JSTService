// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-29 16:25:35
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 15:53:08
// ***********************************************************************
// <copyright file="FXRefund.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JSTService.ServiceModel.Models;
using ServiceStack;

/// <summary>
/// The ServiceModel namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel
{
    /// <summary>
    /// 分销退货请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetFXRefund")]
    public class GetFXRefund : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化分销退货请求类 <see cref="GetFXRefund" />.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetFXRefund():base()
        {
        }

        /// <summary>
        /// 退货单号
        /// </summary>
        /// <value>退货单号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long SubOrderID { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        /// <value>退款状态</value>
        /// <remarks>聚石塔WebService</remarks>
        public int RefundStatus { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        /// <value>卖家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string SupplierNick { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        /// <value>买家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string DistributorNick { get; set; }
    }


    /// <summary>
    /// 分销退货参数验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class FXRefundValidator : DefaultValidator<GetFXRefund>
    {
        /// <summary>
        /// 初始化分销退货参数验证类 <see cref="FXRefundValidator" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public FXRefundValidator()
            : base()
        {
            //校验退款状态
            RuleFor(r => r.RefundStatus).InclusiveBetween(0,10)
                .WithMessage(string.Format("退款状态必须是{0}-{1}的值", 0, 10));
        }
    }
}
