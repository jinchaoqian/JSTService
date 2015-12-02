// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-29 16:06:43
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 15:53:08
// ***********************************************************************
// <copyright file="FXTrade.cs" company="杭州黯涉电子商务有限公司">
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
    /// 分销订单请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetFXTrade")]
    public class GetFXTrade : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化分销订单请求类 <see cref="GetFXTrade" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetFXTrade():base()
        {
        }

        /// <summary>
        /// 分销商单号
        /// </summary>
        /// <value>分销商单号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long TcOrderID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        /// <value>订单编号</value>
        /// <remarks>聚石塔WebService</remarks>
        public long FenxiaoID { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        /// <value>卖家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string SupplierName { get; set; }

        /// <summary>
        /// 分销商名称
        /// </summary>
        /// <value>分销商名称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string DistributorUserName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <value>订单状态</value>
        /// <remarks>聚石塔WebService</remarks>
        public int Status { get; set; }



    }



    /// <summary>
    /// 分销订单状态枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum FXTradeStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All =0,
        /// <summary>
        /// 分销商提交申请，待供应商审核
        /// </summary>
        WAIT_FOR_SUPPLIER_AUDIT1 = 1,
        /// <summary>
        /// 供应商驳回申请，待分销商确认
        /// </summary>
        SUPPLIER_REFUSE = 2,
        /// <summary>
        /// 供应商修改后，待分销商确认
        /// </summary>
        WAIT_FOR_APPLIER_AUDIT = 3,
        /// <summary>
        /// 分销商拒绝修改，待供应商再审核
        /// </summary>
        WAIT_FOR_SUPPLIER_AUDIT2 = 4,
        /// <summary>
        /// 审核通过下单成功，待分销商付款
        /// </summary>
        BOTH_AGREE_WAIT_PAY = 5,
        /// <summary>
        /// 付款成功，待供应商发货
        /// </summary>
        WAIT_FOR_SUPPLIER_DELIVER = 6,
        /// <summary>
        /// 供应商发货，待分销商收货
        /// </summary>
        WAIT_FOR_APPLIER_STORAGE = 7,
        /// <summary>
        /// 分销商收货，交易成功
        /// </summary>
        TRADE_FINISHED = 8,
        /// <summary>
        /// 经销采购单关闭
        /// </summary>
        TRADE_CLOSED = 9 

    }

    /// <summary>
    /// 分销订单请求验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class FXTradeValidator : DefaultValidator<GetFXTrade>
    {
        /// <summary>
        /// 初始化分销订单请求验证类 <see cref="FXTradeValidator" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public FXTradeValidator():base()
        {
            //验证订单状态
            RuleFor(r => r.Status).Must(BeAValidStatus).WithMessage("订单状态验证失败");
        }

        /// <summary>
        /// 校验订单状态
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidStatus(int Status)
        {
            if (!Enum.IsDefined(typeof(FXTradeStatus), Status))
            {
                return false;
            }
            return true;
        }
    }
}
