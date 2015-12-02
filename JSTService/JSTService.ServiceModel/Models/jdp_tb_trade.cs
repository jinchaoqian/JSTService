// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : ��Ǯ
// Created          : 2015-11-28 16:06:48
//
// Last Modified By : ��Ǯ
// Last Modified On : 2015-12-02 16:30:31
// ***********************************************************************
// <copyright file="jdp_tb_trade.cs" company="������������������޹�˾">
//     Copyright (c) . All rights reserved.
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��ʯ�������Ա�����
    /// </summary>
    /// <remarks>��ʯ��WebService</remarks>
    public partial class jdp_tb_trade 
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <value>�������</value>
        /// <remarks>��ʯ��WebService</remarks>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long tid { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        /// <value>����״̬</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(64)]
        public string status { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        /// <value>��������</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(64)]
        public string type { get; set; }

        /// <summary>
        /// �����ǳ�
        /// </summary>
        /// <value>�����ǳ�</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string seller_nick { get; set; }

        /// <summary>
        /// ����ǳ�
        /// </summary>
        /// <value>����ǳ�</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string buyer_nick { get; set; }

        /// <summary>
        /// �µ�ʱ��
        /// </summary>
        /// <value>�µ�ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? created { get; set; }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <value>�޸�ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? modified { get; set; }

        /// <summary>
        /// Gets or sets the jdp_hashcode.
        /// </summary>
        /// <value>The jdp_hashcode.</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(128)]
        public string jdp_hashcode { get; set; }

        /// <summary>
        /// ��ʯ����������
        /// </summary>
        /// <value>��ʯ����������</value>
        /// <remarks>��ʯ��WebService</remarks>
        [Column(TypeName = "text")]
        public string jdp_response { get; set; }

        /// <summary>
        /// ��ʯ������ʱ��
        /// </summary>
        /// <value>��ʯ������ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? jdp_created { get; set; }

        /// <summary>
        /// ��ʯ���޸�ʱ��
        /// </summary>
        /// <value>��ʯ���޸�ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? jdp_modified { get; set; }
    }
}
