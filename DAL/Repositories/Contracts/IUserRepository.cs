using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DAL.Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmail(string email);
    }
}
