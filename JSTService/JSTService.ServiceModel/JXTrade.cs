// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 15:13:09
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 15:53:09
// ***********************************************************************
// <copyright file="JXTrade.cs" company="杭州黯涉电子商务有限公司">
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
    /// 经销订单请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetJXTrade")]
    public class GetJXTrade : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化经销订单请求类 <see cref="GetJXTrade" />.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetJXTrade():base()
        {
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        /// <value>订单编号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long DealerOrderId { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        /// <value>The supplier nick.</value>
        /// <remarks>聚石塔WebService</remarks>
        public string SupplierNick { get; set; }

        /// <summary>
        /// 经销商名称
        /// </summary>
        /// <value>经销商名称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string ApplierNick { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <value>订单状态</value>
        /// <remarks>聚石塔WebService</remarks>
        public int OrderStatus { get; set; }

    }

    /// <summary>
    /// 经销订单状态枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum JXTradeStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All =0,
        /// <summary>
        /// 等待付款
        /// </summary>
        WAIT_BUYER_PAY = 1,
        /// <summary>
        /// 已付款，待发货
        /// </summary>
        WAIT_SELLER_SEND_GOODS = 2,
        /// <summary>
        /// 已付款，已发货
        /// </summary>
        WAIT_BUYER_CONFIRM_GOODS = 3,
        /// <summary>
        /// 交易成功
        /// </summary>
        TRADE_FINISHED = 4,
        /// <summary>
        /// 交易关闭
        /// </summary>
        TRADE_CLOSED = 5,
        /// <summary>
        /// (已付款（已分账），已发货。只对代销分账支持)
        /// </summary>
        WAIT_BUYER_CONFIRM_GOODS_ACOUNTED = 6,
        /// <summary>
        /// 已分账发货成功
        /// </summary>
        PAY_ACOUNTED_GOODS_CONFIRM = 7,
        /// <summary>
        /// 已付款，确认收货
        /// </summary>
        PAY_WAIT_ACOUNT_GOODS_CONFIRM = 8, 

    }

    /// <summary>
    /// 经销订单请求验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class JXTradeValidator : DefaultValidator<GetJXTrade>
    {
        /// <summary>
        /// 经销订单请求验证类 <see cref="JXTradeValidator" />.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public JXTradeValidator():base()
        {
            //校验订单状态
            RuleFor(r => r.OrderStatus ).Must(BeAValidStatus).WithMessage("订单状态验证失败");
        }

        /// <summary>
        /// 校验订单状态
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidStatus(int Status)
        {
            if (!Enum.IsDefined(typeof(JXTradeStatus), Status))
            {
                return false;
            }
            return true;
        }
    }
}
