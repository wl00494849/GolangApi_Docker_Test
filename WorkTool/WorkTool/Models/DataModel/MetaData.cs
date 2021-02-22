using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WorkTool.Models.DataModel
{
    [ModelMetadataType(typeof(MetaDataWork))]
    public partial class Work {}
    public class MetaDataWork
    {
        [Key]
        [DisplayName("編號")]
        public string WorkID { get; set; }
        [DisplayName("工作名稱")]
        public string WorkName { get; set; }
        [DisplayName("工作內容")]
        public string WorkContents { get; set; }
        [DisplayName("工作狀態")]
        public string WorkStatus { get; set; }
        [DisplayName("緊急程度")]
        public string WorkUrgent { get; set; }
        [DisplayName("工作類別")]
        public string WorkType { get; set; }
        [DisplayName("預計消耗時間")]
        public string EConsumeTime { get; set; }
        [DisplayName("創建時間")]
        public DateTime? CreateTime { get; set; }
        [DisplayName("執行時間")]
        public DateTime? WorkDate { get; set; }
        [DisplayName("完成時間")]
        public DateTime? CompleteDate { get; set; }
    }
}
