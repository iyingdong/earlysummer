using EarlySummer.BusinessModules.DataAccess;
using EarlySummer.BusinessModules.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace EarlySummer.BusinessModules.WorkModules.Domains
{
    public class WorkService : IWorkService
    {
        EarlySummerContext db = new EarlySummerContext();
        /// <summary>
        /// 获取统计列表.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:28</para>
        /// </remarks>
        /// <remarks>
        /// <para>创建：yuyd</para>
        /// <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        public List<Work> GetList()
        {
            var result = db.WorkEntities.ToList();

            return result;
        }



        /// <summary>
        /// 根据ID获取统计实体.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:28</para>
        /// </remarks>
        /// <remarks>
        /// <para>创建：yuyd</para>
        /// <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        public Work GetModelById(Guid Id)
        {
            var model = db.WorkEntities.Where(o => o.WorkId == Id).FirstOrDefault();
            return model;
        }

        /// <summary>
        /// 添加/更新统计数据.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:28</para>
        /// </remarks>
        /// <remarks>
        /// <para>创建：yuyd</para>
        /// <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        public bool Update(Work model)
        {
            if (model.WorkId == Guid.Empty)
            {
                model.WorkId = Guid.NewGuid();
                model.CreationTime = DateTime.Now;
                db.WorkEntities.Add(model);
            }
            else
            {
                var entry = db.Entry(model);
                entry.State = EntityState.Modified;
            }
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据ID进行统计.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:28</para>
        /// </remarks>
        /// <remarks>
        /// <para>创建：yuyd</para>
        /// <para>日期：2017-5-27 14:27</para>
        /// </remarks>
        public string Count(Guid Id)
        {
            var message = "";

            var model = GetModelById(Id);
            if (model != null)
            {
                var content = model.Content;
                var br = new Regex(@"\r\n");
                //开始时间
                var start = new TimeSpan(9, 0, 0);
                //结束时间
                var stop = new TimeSpan(17, 30, 0);
                //累计时间
                int result = 0;
                if (content.Contains("|") && content.Contains(':'))
                {
                    var dayArr = br.Split(content);
                    if (dayArr.Length > 0)
                    {
                        Array.ForEach(dayArr, item => {
                            if (item.Contains("|"))
                            {
                                var datas = item.Split('|');
                                var _start = new TimeSpan();
                                var _stop = new TimeSpan();
                                TimeSpan.TryParse(datas[0], out _start);
                                TimeSpan.TryParse(datas[1], out _stop);
                                result += start.Subtract(_start).Minutes + _stop.Subtract(stop).Minutes;
                            }
                            else {
                                var _start = new TimeSpan();
                                TimeSpan.TryParse(item, out _start);
                                var minutes=start.Subtract(_start).Minutes-result;
                                var _stop = stop.Add(new TimeSpan(0, minutes, 0));
                                message = _stop.ToString();
                            }
                        });
                        if (string.IsNullOrEmpty(message))
                        {
                            message = result.ToString();
                        }
                    }
                }
            }

            return message;
        }
    }
}
