using Azure;
using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Courses)
            .WithMany(c => c.Users)
            .UsingEntity<UserCourse>();
            builder.HasMany(u => u.Topics)
            .WithMany(t => t.Users)
            .UsingEntity<UserTopic>(
                l => l.HasOne<Topic>(e => e.Topic).WithMany(e => e.UserTopics), r => r.HasOne<User>(e => e.User).WithMany(e => e.UserTopics)
           );
        }
    }
}
