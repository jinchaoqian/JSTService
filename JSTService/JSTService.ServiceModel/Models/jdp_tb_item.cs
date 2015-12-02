// ***********************************************************************
// Assembly         : JSTService.ServiceModel
// Author           : ��Ǯ
// Created          : 2015-11-28 16:06:48
//
// Last Modified By : ��Ǯ
// Last Modified On : 2015-12-02 16:30:31
// ***********************************************************************
// <copyright file="jdp_tb_item.cs" company="������������������޹�˾">
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
    /// ��ʯ�������Ա���Ʒ
    /// </summary>
    /// <remarks>��ʯ��WebService</remarks>
    public partial class jdp_tb_item
    {
        /// <summary>
        /// ��ƷID
        /// </summary>
        /// <value>��ƷID</value>
        /// <remarks>��ʯ��WebService</remarks>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long num_iid { get; set; }

        /// <summary>
        /// �����ǳ�
        /// </summary>
        /// <value>�����ǳ�</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string nick { get; set; }

        /// <summary>
        /// ��Ʒ״̬
        /// </summary>
        /// <value>��Ʒ״̬</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string approve_status { get; set; }

        /// <summary>
        /// Gets or sets the has_showcase.
        /// </summary>
        /// <value>The has_showcase.</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string has_showcase { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <value>����ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? created { get; set; }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <value>�޸�ʱ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public DateTime? modified { get; set; }

        /// <summary>
        /// ��Ʒ��Ŀ
        /// </summary>
        /// <value>��Ʒ��Ŀ</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(256)]
        public string cid { get; set; }

        /// <summary>
        /// �Ƿ����ۿ�
        /// </summary>
        /// <value>�Ƿ����ۿ�</value>
        /// <remarks>��ʯ��WebService</remarks>
        [StringLength(32)]
        public string has_discount { get; set; }

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
        /// �Ƿ�ɾ��
        /// </summary>
        /// <value>�Ƿ�ɾ��</value>
        /// <remarks>��ʯ��WebService</remarks>
        public int? jdp_delete { get; set; }

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
