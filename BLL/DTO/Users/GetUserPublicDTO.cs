using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO.Users
{
    [AutoMap(typeof(User))]

    public class GetUserPublicDTO
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public long? Streak { get; set; }
        public int? Level { get; set; }
        public bool IsFollowed { get; set; } = false;
        [Ignore]
        public long Followers { get; set; } = 0;
        [Ignore]
        public long Following {  get; set; } = 0;
        [SourceMember(nameof(User.LearningStats))]
        public List<LearningStatDTO> LearningStats { get; set; }
    }
}
