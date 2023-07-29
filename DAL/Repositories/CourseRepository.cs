﻿using D.Exceptions.Auth;
using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly IRoleGuard _roleGuard;
        public CourseRepository(DataContext _dataContext, IRoleGuard roleGuard) : base(_dataContext) { 
            _roleGuard = roleGuard;
        }

        public async Task<IEnumerable<Course>> FindByFilter(CourseFilter filter)
        {
            if (filter.LanguageFrom != null && filter.LanguageTo != null)
                    return await FindByCondition(c => c.LanguageFrom == filter.LanguageFrom && c.LanguageTo == filter.LanguageTo);
            if (filter.LanguageFrom != null)
                    return await FindByCondition(c => c.LanguageFrom == filter.LanguageFrom);
            if (filter.LanguageTo != null)
                return await FindByCondition(c => c.LanguageTo == filter.LanguageTo);

            return await GetAll();            
            
        }

        public async Task<IEnumerable<Course>> GetOwn(string id)
        {
            if (id == _roleGuard.user.Id)
                return await FindByCondition(c => c.Users.Contains(_roleGuard.user));
            else throw new AccessDeniedException("Not authorized to view this data.");

        }
    }
}
