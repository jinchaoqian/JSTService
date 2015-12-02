// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : Administrator
// Created          : 11-29-2015
//
// Last Modified By : Administrator
// Last Modified On : 2015-12-02 16:58:43
// ***********************************************************************
// <copyright file="DefaultValidator.cs" company="杭州黯涉电子商务有限公司">
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
using FluentValidation.Results;

/// <summary>
/// The ServiceModel namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceModel
{
    /// <summary>
    /// 数据请求验证基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>聚石塔WebService</remarks>
    public class DefaultValidator<T> : AbstractValidator<T> where T : DefaultObject <DefaultResponse>
    {

        /// <summary>
        /// 初始化数据请求验证基类 <see cref="DefaultValidator{T}" /> .
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public DefaultValidator()
        {
            //日期类型校验
            RuleFor(r => r.DateType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1)
                .WithMessage(string.Format("日期类型必须是{0}-{1}的值", 0, 1));
            //开始时间校验
            RuleFor(r => r.StartDateTime).NotNull().NotEqual(new DateTime(1, 1, 1))
                .WithMessage("开始时间不能为空");
            //截止时间校验
            RuleFor(r => r.EndDateTime).NotNull().NotEqual(new DateTime(1, 1, 1))
                .WithMessage("结束时间不能为空");
            //页大小校验1
            RuleFor(r => r.PageSize).GreaterThan(0).WithMessage("每页数量必须大于0");
            //页大小校验2
            RuleFor(r => r.PageSize).LessThanOrEqualTo(500).WithMessage("每页最大数量500");
            //页数校验
            RuleFor(r => r.PageNo).GreaterThan(0).WithMessage(string.Format("页数必须大于0", 0, 2));
            //时间戳校验
            RuleFor(r => r.TimeStamp).Must(TimeStampValied).WithMessage("会话超时,有效期5分钟");
            //Apkey校验
            RuleFor(r => r.AppKey).NotEmpty().Equal("JST").WithMessage("AppKey不能为空或者是错误");
            //签名校验
            RuleFor(r => r.Sign).NotEmpty().WithMessage("签名不能为空");
            //签名验证
            Custom((r, validationContext) =>
            {
                string AppSecret = "12345";
                string Sign = r.Sign;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("AppKey", r.AppKey);
                dic.Add("AppSecret", AppSecret);
                dic.Add("TimeStamp", r.TimeStamp.ToString());
                dic.Add("PageNo", r.PageNo.ToString());
                dic.Add("PageSize", r.PageSize.ToString());
                string Sign1 = Util.SignTopRequest(dic, AppSecret, true);
                return Sign1 == Sign ? null : new ValidationFailure("Sign", "签名验证失败", "Sign_Error");
            });

        }

        /// <summary>
        /// 时间戳验证方法
        /// </summary>
        /// <param name="timeStamp">请求时间戳</param>
        /// <returns>如果时间在五分钟之内<c>true</c>，否则 <c>false</c> .</returns>
        /// <remarks>聚石塔WebService</remarks>
        private bool TimeStampValied(double timeStamp)
        {
            DateTime dt = Util.ConvertIntDateTime(timeStamp);
            return dt >= DateTime.Now.AddMinutes(-5);
        }


    }
}
