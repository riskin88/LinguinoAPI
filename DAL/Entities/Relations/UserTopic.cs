﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations
{
    [Table("UserTopic")]
    public class UserTopic : EntityBase
    {
        public string UserId { get; set; }
        public User User { get; set; } = null!;
        public long TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
        public long LessonsActive { get; set; } = 0;
        public bool IsEnabled { get; set; } = false;
    }
}
