using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;
using DAL.Repositories.Contracts;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(long id);
        long CreateUser(User user);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entityDto">entity details</param>
        /* Task Update(UserUpdateDto entityDto);

        /// <summary>
        /// Deletes entity with given Id
        /// </summary>
        /// <param name="entityId">Id of the entity to delete</param>
        void Delete(Guid entityId);

        /// <summary>
        /// Gets all DTOs (for given type) and given Filter
        /// </summary>
        /// <returns>all available dtos (for given type)</returns>
        Task<QueryResultDto<UserShowDto, UserFilterDto>> ListAllAsync(UserFilterDto filter);

        /// <summary>
        /// Gets DTO for user with given name
        /// </summary>
        /// <returns></returns>
        Task<UserShowDto> GetUserAccordingToNameAsync(string name);

        /// <summary>
        /// Authorizes user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserShowDto> AuthorizeUserAsync(UserLoginDto login);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Guid RegisterUser(UserCreateDto user); */
    }
}
