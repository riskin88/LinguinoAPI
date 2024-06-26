﻿using DAL.Entities;
using DAL.Entities.Relations;
using DAL.Filters;

namespace DAL.Repositories.Contracts
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        public Task<IEnumerable<Topic>> GetOwn();
        public Task<bool> IsEnabled(long topicId);
        public Task<Topic?> GetWithCourse(long topicId);
        public Task<UserTopic> GetUserTopic(long topicId);
        public Task<IEnumerable<UserLesson>> GetUserLessons(long topicId);
        public Task<IEnumerable<UserTopic>> GetUserTopics(long topicId);
        Task AddToSelf(long topicId);

    }
}