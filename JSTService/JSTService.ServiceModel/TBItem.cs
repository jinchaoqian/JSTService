// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 15:13:09
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 16:27:08
// ***********************************************************************
// <copyright file="TBItem.cs" company="杭州黯涉电子商务有限公司">
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
using ServiceStack.FluentValidation.Attributes;

/// <summary>
/// The ServiceModel namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel
{
    //[Validator(typeof(TBItemValidator))]
    /// <summary>
    /// 淘宝产品请求类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    [Route("/GetTBItem")]
    public class GetTBItem : DefaultObject<DefaultResponse>
    {
        /// <summary>
        /// 初始化淘宝产品请求类 <see cref="GetTBItem" />.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public GetTBItem():base()
        {
        }

        /// <summary>
        /// 买家昵称
        /// </summary>
        /// <value>买家昵称</value>
        /// <remarks>聚石塔WebService</remarks>
        public string Nicks { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        /// <value>产品ID</value>
        /// <remarks>聚石塔WebService</remarks>
        public string NumIID { get; set; }

        /// <summary>
        /// 产品状态
        /// </summary>
        /// <value>产品状态.</value>
        /// <remarks>聚石塔WebService</remarks>
        public int Status { get; set; }



    }

    /// <summary>
    /// 产品状态枚举
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public enum TBItemStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = 0,
        /// <summary>
        /// 在售
        /// </summary>
        OnSale =1 ,
        /// <summary>
        /// 下架
        /// </summary>
        InStock =2  
    }


    /// <summary>
    /// Class TBItemResponse.
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class TBItemResponse:DefaultResponse 
    {
        /// <summary>
        /// Gets or sets the jdp_delete.
        /// </summary>
        /// <value>The jdp_delete.</value>
        /// <remarks>聚石塔WebService</remarks>
        public int jdp_delete { get; set; }

        /// <summary>
        /// Gets or sets the jdp_response.
        /// </summary>
        /// <value>The jdp_response.</value>
        /// <remarks>聚石塔WebService</remarks>
        public string jdp_response { get; set; }
    }

    /// <summary>
    /// 淘宝产品请求验证类
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class TBItemValidator : DefaultValidator<GetTBItem>
    {
        /// <summary>
        /// 初始化淘宝产品请求验证类 <see cref="TBItemValidator" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public TBItemValidator():base()
        {
            //校验产品状态
             RuleFor(r => r.Status).Must(BeAValidStatus).WithMessage("产品状态验证失败");
        }

        /// <summary>
        /// 校验产品状态
        /// </summary>
        /// <param name="Status">产品状态</param>
        /// <returns>如果订单状态是枚举中的一种<c>true</c>,否则 <c>false</c></returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool BeAValidStatus(int Status)
        {
            if (!Enum.IsDefined(typeof(TBItemStatus), Status))
            {
                return false;
            }
            return true;
        }
    }

}
