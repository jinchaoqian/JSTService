// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 15:13:09
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 15:56:10
// ***********************************************************************
// <copyright file="TBRefund.cs" company="杭州黯涉电子商务有限公司">
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
    /// 淘宝退货请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetTBRefund")]
    public class GetTBRefund : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化淘宝退货请求类 <see cref="GetTBRefund" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetTBRefund():base()
        {
        }

        /// <summary>
        /// 退款单号
        /// </summary>
        /// <value>退款单号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long RefundID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        /// <value>订单编号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long Tid { get; set; }

        /// <summary>
        /// 订单明细单号
        /// </summary>
        /// <value>订单明细单号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long Oid { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        /// <value>卖家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string SellerNick { get; set; }

        /// <summary>
        /// 买家ID
        /// </summary>
        /// <value>买家ID</value>
        /// <remarks>聚石塔WebService</remarks>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        /// <value>退款状态</value>
        /// <remarks>聚石塔WebService</remarks>
        public int Status { get; set; }



    }


    /// <summary>
    /// 退款状态枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum TBRefundStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All =0,
        /// <summary>
        /// 买家已经申请退款，等待卖家同意
        /// </summary>
        WAIT_SELLER_AGREE = 1,
        /// <summary>
        /// 卖家已经同意退款，等待买家退货
        /// </summary>
        WAIT_BUYER_RETURN_GOODS = 2,
        /// <summary>
        /// 买家已经退货，等待卖家确认收货
        /// </summary>
        WAIT_SELLER_CONFIRM_GOODS = 3,
        /// <summary>
        /// 卖家拒绝退款
        /// </summary>
        SELLER_REFUSE_BUYER = 4,
        /// <summary>
        /// 退款关闭
        /// </summary>
        CLOSED = 5,
        /// <summary>
        /// 退款成功
        /// </summary>
        SUCCESS = 6,
        /// <summary>
        /// 未知
        /// </summary>
        WAIT_BUYER_CONFIRM_REDO_SEND_GOODS = 7  

    }


    /// <summary>
    /// 淘宝退货请求验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class TBRefundValidator : DefaultValidator<GetTBRefund>
    {
        /// <summary>
        /// 初始化淘宝退货请求验证类 <see cref="TBRefundValidator" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public TBRefundValidator():base()
        {
            //校验退货状态
            RuleFor(r => r.Status).Must(BeAValidStatus).WithMessage("退货状态验证失败");
        }

        /// <summary>
        /// 校验退货状态
        /// </summary>
        /// <param name="Status">退货状态</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidStatus(int Status)
        {
            if (!Enum.IsDefined(typeof(TBRefundStatus), Status))
            {
                return false;
            }
            return true;
        }
    }
}
