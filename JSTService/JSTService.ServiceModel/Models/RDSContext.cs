// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : ��Ǯ
// Created          : 2015-11-28 16:06:47
//
// Last Modified By : ��Ǯ
// Last Modified On : 2015-11-28 16:06:58
// ***********************************************************************
// <copyright file="RDSContext.cs" company="������������������޹�˾">
//     Copyright (c) ������������������޹�˾. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Models namespace.
/// </summary>
/// <remarks>��ʯ��WebService</remarks>
namespace JSTService.ServiceModel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Class RDSContext.
    /// </summary>
    /// <remarks>��ʯ��WebService</remarks>
    public partial class RDSContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RDSContext"/> class.
        /// </summary>
        /// <remarks>��ʯ��WebService</remarks>
        public RDSContext()
            : base("name=RDSContext")
        {
        }

        /// <summary>
        /// Gets or sets the jdp_fx_refund.
        /// </summary>
        /// <value>The jdp_fx_refund.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_fx_refund> jdp_fx_refund { get; set; }
        /// <summary>
        /// Gets or sets the jdp_fx_trade.
        /// </summary>
        /// <value>The jdp_fx_trade.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_fx_trade> jdp_fx_trade { get; set; }
        /// <summary>
        /// Gets or sets the jdp_jx_trade.
        /// </summary>
        /// <value>The jdp_jx_trade.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_jx_trade> jdp_jx_trade { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_item.
        /// </summary>
        /// <value>The jdp_tb_item.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_tb_item> jdp_tb_item { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_refund.
        /// </summary>
        /// <value>The jdp_tb_refund.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_tb_refund> jdp_tb_refund { get; set; }
        /// <summary>
        /// Gets or sets the jdp_tb_trade.
        /// </summary>
        /// <value>The jdp_tb_trade.</value>
        /// <remarks>��ʯ��WebService</remarks>
        public virtual DbSet<jdp_tb_trade> jdp_tb_trade { get; set; }

        /// <summary>
        /// ����ɶ����������ĵ�ģ�͵ĳ�ʼ���󣬲��ڸ�ģ�������������ڳ�ʼ��������֮ǰ�������ô˷�������Ȼ�˷�����Ĭ��ʵ�ֲ�ִ���κβ���������������������д�˷�������������������ģ��֮ǰ������н�һ�������á�
        /// </summary>
        /// <param name="modelBuilder">����Ҫ�����������ĵ�ģ�͵���������</param>
        /// <remarks>��ʯ��WebService</remarks>
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
