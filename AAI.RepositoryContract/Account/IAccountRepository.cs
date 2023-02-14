using AAI.DataContract;
using AAI.DataContract.Models.Login;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace AAI.RepositoryContract.Account
{
    public interface IAccountRepository
    {
        /// <summary>
        ///<Description>Function to create user account in application</Description>
        /// </summary>
        Task<Guid> SignupAsync(CreateAccountModel model);

        /// <summary>
        ///<Description>Function to get users list</Description>
        /// </summary>
        Task<DataSet> UserListAsync(PageSortingModel model);

        /// <summary>
        ///<Description>Function to get users list</Description>
        /// </summary>
        Task<UserLoginDetailViewModel> UserDetailAsync(Guid userId);

        /// <summary>
        ///<Description>Function to activate user account</Description>
        /// </summary>
        Task<string> ActivateUserAsync(Guid userId);
    }
}
