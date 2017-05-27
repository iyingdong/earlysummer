using EarlySummer.BusinessModules.PetModules.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EarlySummer.BusinessModules.PetModules.Domains
{
    public class PetService : IPetService
    {
        /// <summary>
        /// 生成宠物列表.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <remarks>
        ///     <para>创建：yuyd</para>
        ///     <para>日期：2017-5-27 14:26</para>
        /// </remarks>
        public List<PetModel> GetPetList(string id)
        {
            var data = GetPetInfo(id);
            var petList = new List<PetModel>();

            var split = "%c";//分隔符

            if (data.Contains("%c"))
            {
                var petInfo = data.Split(new string[] { split }, StringSplitOptions.None)[1];
                if (petInfo.Contains("c"))
                {
                    var petsArr = petInfo.Split('c');
                    if (petsArr.Length > 0)
                    {
                        foreach (var pets in petsArr)
                        {
                            var petArr = pets.Split('|');
                            var pet = new PetModel()
                            {
                                PetName = petArr[0],
                                InTime = petArr[1],
                                CDTime = petArr[2],
                                LastTime = petArr[3],
                                InCD = petArr[4] == "0"
                            };
                            petList.Add(pet);
                        }
                    }
                }
            }

            return petList;
        }

        /// <summary>
        /// 获取宠物CD信息.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <remarks>
        /// <para>创建：yuyd</para>
        /// <para>日期：2017-05-18</para>
        /// </remarks>
        private string GetPetInfo(string id)
        {
            var result = "";

            string url = "http://yayaquanzhidao.com/PetServer.ashx";

            var request = (HttpWebRequest)HttpWebRequest.CreateHttp(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            var bytes = Encoding.UTF8.GetBytes(id);
            var writer = request.GetRequestStream();
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();


            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            result = reader.ReadToEnd();
            return result;
        }
    }
}
