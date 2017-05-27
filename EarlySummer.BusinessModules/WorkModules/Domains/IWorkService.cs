using EarlySummer.BusinessModules.DataAccess.Entity;
using System;
using System.Collections.Generic;

namespace EarlySummer.BusinessModules.WorkModules.Domains
{
    public interface IWorkService
    {
        /// <summary>
        /// 获取统计列表.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        List<Work> GetList();

        /// <summary>
        /// 根据ID获取统计实体.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        Work GetModelById(Guid Id);

        /// <summary>
        /// 添加/更新统计数据.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        bool Update(Work model);

        /// <summary>
        /// 根据ID进行统计.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        string Count(Guid Id);
    }
}
