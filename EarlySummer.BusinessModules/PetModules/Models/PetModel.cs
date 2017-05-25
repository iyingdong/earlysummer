namespace EarlySummer.BusinessModules.PetModules.Models
{
    public class PetModel
    {
        /// <summary>
        /// 宠物名称
        /// </summary>
        public string PetName { get; set; }

        /// <summary>
        /// 几点进入CD
        /// </summary>
        public string InTime { get; set; }

        /// <summary>
        /// 还有多久进入CD/进入CD时长
        /// </summary>
        public string CDTime { get; set; }

        /// <summary>
        /// 上个CD时间
        /// </summary>
        public string LastTime { get; set; }

        /// <summary>
        /// 是否进入CD
        /// </summary>
        public bool InCD { get; set; }
    }
}