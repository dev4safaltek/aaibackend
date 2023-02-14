using AAI.DataContract.Models;
using AAI.DataContract.Models.Login;
using AAI.Service.Login;
using System.Threading.Tasks;

namespace AAI.ServiceContract.Login
{
    public interface ILoginService
    {
        /// <summary>
        ///<Description>Function to get login Details</Description>
        /// </summary>
        Task<APIResponse> LoginAsync(string userName, string password);
        ///<summary>
        ///<Description>Function to log in the application</Description>
        /// </summary>
    //    Task<APIResponse> LoginAsync(string username, string password);

        ///<summary>
        ///<Description>Function to open reset the password window.</Description>
        /// </summary>
    //    Task<APIResponse> ResetPasswordAsync(string username);

        /// <summary>
        ///<Description>Function to log the Entry in database while the user logged Out.</Description>
        /// </summary>
     //   Task<bool> LogOutAsync(int? userId);

        /// <summary>
        ///<Description>Function used to generate Token</Description>
        /// </summary>
      //  UserDetailModel GenerateToken(UserDetailModel model);
    }
}
