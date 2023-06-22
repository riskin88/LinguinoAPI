using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext _dataContext) : base(_dataContext) { }

        public async Task<User> GetByEmail(string email)
        {
            return await dataContext.Set<User>().FirstOrDefaultAsync(x => x.Username == email);
        }
    }
}
