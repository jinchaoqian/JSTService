// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : 金朝钱
// Created          : 2015-11-28 16:06:47
//
// Last Modified By : 金朝钱
// Last Modified On : 2015-11-28 16:06:58
// ***********************************************************************
// <copyright file="RDSContext.cs" company="杭州黯涉电子商务有限公司">
//     Copyright (c) 杭州黯涉电子商务有限公司. All rights reserved.
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
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Class RDSContext.
    /// </summary>
    /// <remarks>聚石塔WebService</remarks>
    public partial class RDSContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RDSContext"/> class.
        /// </summary>
        /// <remarks>聚石塔WebService</remarks>
        public RDSContext()
            : base("name=RDSContext")
        {
        }

        /// <summary>
        /// Gets or sets the jdp_fx_refund.
        /// </summary>
        /// <value>The jdp_fx_refund.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_fx_refund> jdp_fx_refund { get; set; }
        /// <summary>
        /// Gets or sets the jdp_fx_trade.
        /// </summary>
        /// <value>The jdp_fx_trade.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_fx_trade> jdp_fx_trade { get; set; }
        /// <summary>
        /// Gets or sets the jdp_jx_trade.
        /// </summary>
        /// <value>The jdp_jx_trade.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_jx_trade> jdp_jx_trade { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_item.
        /// </summary>
        /// <value>The jdp_tb_item.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_tb_item> jdp_tb_item { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_refund.
        /// </summary>
        /// <value>The jdp_tb_refund.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_tb_refund> jdp_tb_refund { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_trade.
        /// </summary>
        /// <value>The jdp_tb_trade.</value>
        /// <remarks>聚石塔WebService</remarks>
        public virtual DbSet<jdp_tb_trade> jdp_tb_trade { get; set; }

        /// <summary>
        /// 在完成对派生上下文的模型的初始化后，并在该模型已锁定并用于初始化上下文之前，将调用此方法。虽然此方法的默认实现不执行任何操作，但可在派生类中重写此方法，这样便能在锁定模型之前对其进行进一步的配置。
        /// </summary>
        /// <param name="modelBuilder">定义要创建的上下文的模型的生成器。</param>
        /// <remarks>聚石塔WebService</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<jdp_fx_refund>()
                .Property(e => e.supplier_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_refund>()
                .Property(e => e.distributor_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_refund>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_refund>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.tc_order_id)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.supplier_username)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.distributor_username)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_fx_trade>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_jx_trade>()
                .Property(e => e.order_status)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_jx_trade>()
                .Property(e => e.supplier_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_jx_trade>()
                .Property(e => e.applier_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_jx_trade>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_jx_trade>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.approve_status)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.has_showcase)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.cid)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.has_discount)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_item>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_refund>()
                .Property(e => e.seller_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_refund>()
                .Property(e => e.buyer_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_refund>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_refund>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_refund>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.seller_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.buyer_nick)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.jdp_hashcode)
                .IsUnicode(false);

            modelBuilder.Entity<jdp_tb_trade>()
                .Property(e => e.jdp_response)
                .IsUnicode(false);
        }
    }
}
