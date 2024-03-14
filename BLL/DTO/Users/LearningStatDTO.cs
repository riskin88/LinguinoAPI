using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
    [AutoMap(typeof(LearningStat))]
    public class LearningStatDTO
    {
        public DateTime? Date { get; set; }
        public long Points { get; set; }
    }
}
