using AAI.DataContract;
using AAI.DataContract.Models;
using AAI.DataContract.Models.Login;
using System.Threading.Tasks;
using System;

namespace AAI.ServiceContract.Account
{
    public interface IAccountService
    {
        ///<summary>
        ///<Description>Function to create account in application</Description>
        /// </summary>
        Task<APIResponse> SignUpAsync(CreateAccountModel model);

        ///<summary>
        ///<Description>Function to get user List</Description>
        /// </summary>
        Task<APIResponse> UserListAsync(PageSortingModel model);

        ///<summary>
        ///<Description>Function to get user Detail</Description>
        /// </summary>
        Task<APIResponse> UserDetailAsync(Guid userId);

        ///<summary>
        ///<Description>Function used to activate user account</Description>
        /// </summary>
        Task<APIResponse> ActivateUserAsync(Guid userId);
    }
}
