// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 15:13:09
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 16:04:43
// ***********************************************************************
// <copyright file="TBTrade.cs" company="杭州黯涉电子商务有限公司">
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
    /// 淘宝订单请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetTBTrade")]
    public class GetTBTrade : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化淘宝订单请求类 <see cref="GetTBTrade" />.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetTBTrade():base()
        {
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        /// <value>订单类型</value>
        /// <remarks>聚石塔WebService</remarks>
        public int Type { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        /// <value>订单编号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long Tid { get; set; }

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
        /// 订单状态
        /// </summary>
        /// <value>订单状态</value>
        /// <remarks>聚石塔WebService</remarks>
        public int Status { get; set; }



    }

    /// <summary>
    /// 订单状态枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum TBTradeStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All =0,
        /// <summary>
        /// 没有创建支付宝交易
        /// </summary>
        TRADE_NO_CREATE_PAY = 1,
        /// <summary>
        /// 等待买家付款
        /// </summary>
        WAIT_BUYER_PAY = 2 ,
        /// <summary>
        /// 卖家部分发货
        /// </summary>
        SELLER_CONSIGNED_PART = 3,
        /// <summary>
        /// 等待卖家发货,即:买家已付款
        /// </summary>
        WAIT_SELLER_SEND_GOODS = 4,
        /// <summary>
        /// 等待买家确认收货,即:卖家已发货
        /// </summary>
        WAIT_BUYER_CONFIRM_GOODS = 5,
        /// <summary>
        /// 买家已签收,货到付款专用
        /// </summary>
        TRADE_BUYER_SIGNED = 6,
        /// <summary>
        /// 交易成功
        /// </summary>
        TRADE_FINISHED = 7,
        /// <summary>
        /// 付款以后用户退款成功，交易自动关闭
        /// </summary>
        TRADE_CLOSED = 8,
        /// <summary>
        /// 付款以前，卖家或买家主动关闭交易
        /// </summary>
        TRADE_CLOSED_BY_TAOBAO = 9,
        /// <summary>
        /// 国际信用卡支付付款确认中
        /// </summary>
        PAY_PENDING = 10,
        /// <summary>
        /// 0元购合约中
        /// </summary>
        WAIT_PRE_AUTH_CONFIRM = 11  

    }

    /// <summary>
    /// 订单类型枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum TBTradeType
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 一口价
        /// </summary>
        Fixed = 1,
        /// <summary>
        /// 拍卖
        /// </summary>
        Auction = 2,
        /// <summary>
        /// 一口价、拍卖
        /// </summary>
        Guarantee_trade = 3,
        /// <summary>
        /// 自动发货
        /// </summary>
        Auto_delivery = 4,
        /// <summary>
        /// 旺店入门版交易
        /// </summary>
        Independent_simple_trade = 5,
        /// <summary>
        /// 旺店标准版交易
        /// </summary>
        Iindependent_shop_trade = 6,
        /// <summary>
        /// 直冲
        /// </summary>
        Ec = 7,
        /// <summary>
        /// 货到付款
        /// </summary>
        Cod = 8,
        /// <summary>
        /// 分销
        /// </summary>
        Fenxiao = 9,
        /// <summary>
        /// 游戏装备
        /// </summary>
        Game_equipment = 10,
        /// <summary>
        /// ShopEX交易
        /// </summary>
        Shopex_trade = 11,
        /// <summary>
        /// 万网交易
        /// </summary>
        Netcn_trade = 12,
        /// <summary>
        /// 统一外部交易
        /// </summary>
        External_trade = 13,
        /// <summary>
        /// O2O交易
        /// </summary>
        O2o_offlinetrade = 14,
        /// <summary>
        /// 万人团
        /// </summary>
        Step = 15,
        /// <summary>
        /// 无付款订单
        /// </summary>
        Nopaid = 16,
        /// <summary>
        /// 预授权0元购机交易
        /// </summary>
        Pre_auth_type = 17    
    }

    /// <summary>
    /// 淘宝订单请求验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class TBTradeValidator : AbstractValidator<GetTBTrade>
    {
        /// <summary>
        /// 初始化淘宝订单请求验证类 <see cref="TBTradeValidator" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public TBTradeValidator()
        {
            //校验订单状态
            RuleFor(r => r.Status).Must(BeAValidTBTradeStatus).WithMessage("订单状态错误");
            //校验订单类型
            RuleFor(r => r.Type).Must(BeAValidTBTradeType).WithMessage("订单类型错误");
        }

        /// <summary>
        /// 校验订单类型
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidTBTradeType(int Type)
        {
            if (!Enum.IsDefined(typeof(TBTradeType), Type))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 校验订单状态
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidTBTradeStatus(int Status)
        {
            if (!Enum.IsDefined(typeof(TBTradeStatus), Status))
            {
                return false;
            }
            return true;
        }
    }
}
