// ***********************************************************************
// Assembly         : JSTService.ServiceInterface
// Author           : 金朝钱
// Created          : 2015-11-28 15:13:08
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-12-02 16:38:57
// ***********************************************************************
// <copyright file="MyServices.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using JSTService.ServiceModel;
using JSTService.ServiceModel.Models;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation.Results;
using ServiceStack.Redis;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;
using JimLog;
using log4net;
using System.Reflection;
using Newtonsoft.Json;

/// <summary>
/// The ServiceInterface namespace.
/// </summary>
/// <remarks>聚石塔WebService</remarks>
namespace JSTService.ServiceInterface
{
    /// <summary>
    /// 聚石塔WebService
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public class JSTServices : Service
    {

        /// <summary>
        /// 日志对象
        /// </summary>
        private ILog logger = LoggerHelper.GetLogger(MethodBase.GetCurrentMethod().DeclaringType, "JST_SDK");

        /// <summary>
        /// 获取分销退货数据
        /// </summary>
        /// <param name="request">分销退货请求</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetFXRefund  request)
        {
            //记录请求
            logger.Debug(JsonConvert.SerializeObject(request));
            //验证请求数据
            FXRefundValidator validator = new FXRefundValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }
            //业务数据查询
            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_fx_refund> q = db.jdp_fx_refund;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified >= request.StartDateTime && u.jdp_modified <= request.EndDateTime).OrderBy(m => m.jdp_modified);
                }
                else
                {
                    q = q.Where(u => u.modified  >= request.StartDateTime && u.modified <= request.EndDateTime).OrderBy(m => m.modified);
                }
                //订单状态
                if (request.RefundStatus  != 0)
                {
                    q = q.Where(u => u.refund_status  == request.RefundStatus );
                }

                if (!string.IsNullOrEmpty(request.SupplierNick))
                {
                    q = q.Where(u => u.supplier_nick == request.SupplierNick);
                }
                if (!string.IsNullOrEmpty(request.DistributorNick ))
                {
                    q = q.Where(u => u.distributor_nick  == request.DistributorNick);
                }
                //组装返回对象
                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select( u => u.jdp_response ).ToList();
                //记录返回对象
                logger.Debug(JsonConvert.SerializeObject(results));
                return response;
            }
        }

        /// <summary>
        /// Anies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetJXTrade request)
        {
            logger.Debug(JsonConvert.SerializeObject(request));
            JXTradeValidator validator = new JXTradeValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }

            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_jx_trade> q = db.jdp_jx_trade;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified >= request.StartDateTime && u.jdp_modified <= request.EndDateTime).OrderBy(m => m.jdp_modified);
                }
                else
                {
                    q = q.Where(u => u.modified_time >= request.StartDateTime && u.modified_time <= request.EndDateTime).OrderBy(m => m.modified_time);
                }
                //订单状态
                if (request.OrderStatus  != 0)
                {
                    q = q.Where(u => u.order_status == ((JXTradeStatus )request.OrderStatus).ToString());
                }

                if (request.DealerOrderId  != 0)
                {
                    q = q.Where(u => u.dealer_order_id  == request.DealerOrderId );
                }

                if (!string.IsNullOrEmpty(request.SupplierNick ))
                {
                    q = q.Where(u => u.supplier_nick  == request.SupplierNick);
                }
                if (!string.IsNullOrEmpty(request.ApplierNick ))
                {
                    q = q.Where(u => u.applier_nick == request.ApplierNick);
                }

                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select(u => u.jdp_response).ToList();
                logger.Debug(JsonConvert.SerializeObject(results)); 
                return response;
            }
        }


        /// <summary>
        /// Anies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetFXTrade  request)
        {
            logger.Debug(JsonConvert.SerializeObject(request));
            FXTradeValidator validator = new FXTradeValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }

            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_fx_trade> q = db.jdp_fx_trade;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified >= request.StartDateTime && u.jdp_modified <= request.EndDateTime).OrderBy(m => m.jdp_modified);
                }
                else
                {
                    q = q.Where(u => u.modified >= request.StartDateTime && u.modified <= request.EndDateTime).OrderBy(m => m.modified);
                }
                //订单状态
                if (request.Status != 0)
                {
                    q = q.Where(u => u.status == ((FXTradeStatus)request.Status).ToString());
                }

                if (request.FenxiaoID  != 0)
                {
                    q = q.Where(u => u.fenxiao_id  == request.FenxiaoID );
                }

                if (!string.IsNullOrEmpty(request.SupplierName ))
                {
                    q = q.Where(u => u.supplier_username  == request.SupplierName );
                }
                if (!string.IsNullOrEmpty(request.DistributorUserName ))
                {
                    q = q.Where(u => u.distributor_username  == request.DistributorUserName );
                }

                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select(u => u.jdp_response).ToList();
                logger.Debug(JsonConvert.SerializeObject(results));
                return response;
            }
        }

        /// <summary>
        /// Anies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetTBRefund request)
        {
            logger.Debug(JsonConvert.SerializeObject(request));
            TBRefundValidator validator = new TBRefundValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }

            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_tb_refund> q = db.jdp_tb_refund;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy(m => m.jdp_modified);
                }
                else
                {
                    q = q.Where(u => u.modified >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy(m => m.modified);
                }

                //订单状态
                if (request.Status != 0)
                {
                    q = q.Where(u => u.status == ((TBRefundStatus)request.Status ).ToString());
                }
                //订单编号
                if (request.Tid != 0)
                {
                    q = q.Where(u => u.tid == request.Tid);
                }

                //退款单号
                if (request.RefundID  != 0)
                {
                    q = q.Where(u => u.refund_id  == request.RefundID);
                }

                //子订单编号
                if (request.Oid  != 0)
                {
                    q = q.Where(u => u.oid  == request.Oid );
                }

                //店铺
                if (!string.IsNullOrEmpty(request.SellerNick))
                {
                    q = q.Where(u => u.seller_nick == request.SellerNick);
                }
                //买家昵称
                if (!string.IsNullOrEmpty(request.BuyerNick))
                {
                    q = q.Where(u => u.buyer_nick == request.BuyerNick);
                }

                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select(u => u.jdp_response).ToList();
                logger.Debug(JsonConvert.SerializeObject(results));
                return response;
            }
        }

        /// <summary>
        /// Anies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetTBTrade request)
        {
            logger.Debug(JsonConvert.SerializeObject(request));
            TBTradeValidator validator = new TBTradeValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }

            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_tb_trade> q = db.jdp_tb_trade;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy(m => m.jdp_modified);
                }
                else
                {
                    q = q.Where(u => u.modified >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy(m => m.modified);
                }

                //订单类型
                if (request.Type != 0 )
                {
                     q = q.Where(u => u.type == ((TBTradeType )request.Type).ToString());
                    
                }
                //订单状态
                if (request.Status != 0)
                {
                   q = q.Where(u => u.status  == ((TBTradeStatus )request.Status ).ToString());
                }

                if (request.Tid != 0 )
                {
                    q = q.Where(u => u.tid == request.Tid);
                }

                if (!string.IsNullOrEmpty(request.SellerNick ))
                {
                    q = q.Where(u => u.seller_nick == request.SellerNick);
                }
                if (!string.IsNullOrEmpty(request.BuyerNick))
                {
                    q = q.Where(u => u.buyer_nick == request.BuyerNick);
                }


                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select(u => u.jdp_response).ToList();
                logger.Debug(JsonConvert.SerializeObject(results));
                return response;
            }
        }

        /// <summary>
        /// Anies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>聚石塔WebService</remarks>
        public object Any(GetTBItem request)
        {
            logger.Debug(JsonConvert.SerializeObject(request));
            TBItemValidator validator = new TBItemValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                logger.Error(JsonConvert.SerializeObject(results));
                return results;
            }

            using (RDSContext db = new RDSContext())
            {
                IQueryable<jdp_tb_item> q = db.jdp_tb_item;

                //0:淘宝推送时间;1:订单修改时间；默认0
                if (request.DateType == 0)
                {
                    q = q.Where(u => u.jdp_modified  >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy( m => m.jdp_modified);
                }else
                {
                    q = q.Where(u => u.modified >= request.StartDateTime && u.created <= request.EndDateTime).OrderBy(m => m.modified);
                }

                //店铺支持多选,格式shop1,shop2,shop3
                if (!string.IsNullOrEmpty(request.Nicks ))
                {
                    q = q.Where(u => request.Nicks.Contains(u.nick));
                }
                //1：在售;2:下架;0：全部；默认0
                if (request.Status != 0)
                {
                    q = q.Where(u => u.approve_status == ((TBItemStatus)request.Status).ToString());
                }
                DefaultResponse response = new DefaultResponse();
                response.PageSize = request.PageSize;
                response.RecordCount = q.Count();
                response.PageCount = (int)Math.Ceiling(response.RecordCount * 1.00 / response.PageSize);
                response.Result = q.Skip(request.PageNo * request.PageSize).Take(request.PageSize).Select(u => new { u.jdp_response,u.jdp_delete  }).ToList();
                logger.Debug(JsonConvert.SerializeObject(results));
                return response;
            }
        }
    }
}