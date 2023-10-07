using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    [AutoMap(typeof(LessonFeedback), ReverseMap = true)]
    public class LessonFeedbackDTO
    {
        public string? Text { get; set; }
        public FeedbackState? State { get; set; }
    }
}
