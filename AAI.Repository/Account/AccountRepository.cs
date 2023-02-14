using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace AAI.Repository.Account
{
    public class AccountRepository : BaseRepository
    {
        public AccountRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        ///<Description>Function used to create user account</Description>
        /// </summary>
        //public async Task<Guid> SignupAsync(CreateAccountModel model)
        //{
        //    string query = "CreateUserAccount";
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@companyName", model.CompanyName, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@room#", model.NumberofRooms, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@firstName", model.FirstName, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@lastName", model.LastName, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@email", model.Email, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@userName", model.UserName, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@password", model.Password, DbType.String, ParameterDirection.Input);

        //    return await GetFirstOrDefaultAsync<Guid>(query, parameter, CommandType.StoredProcedure, DataBaseNameEnum.DataBaseHotel);
        //}

        /// <summary>
        ///<Description>Function used to get user list</Description>
        /// </summary>
        //public async Task<DataSet> UserListAsync(PageSortingModel model)
        //{
        //    string query = "UserAccountList";
        //    Utility.Init_Hashtable();
        //    Utility.AddParameters("@search", SqlDbType.VarChar, model.Search);
        //    Utility.AddParameters("@pageNumber", SqlDbType.VarChar, model.PageNumber);
        //    Utility.AddParameters("@pageSize", SqlDbType.VarChar, model.PageSize);
        //    // parameter.Add("@sort", model.SortBy, DbType.String, ParameterDirection.Input);
        //    // parameter.Add("@sortOrder", model.SortOrder, DbType.String, ParameterDirection.Input);
        //    return (DataSet)ReturnObject(Utility.theParams, query, ObjectEnum.DataSet);
        //}

        /// <summary>
        ///<Description>Function used to get User Details</Description>
        /// </summary>
        //public async Task<UserLoginDetailViewModel> UserDetailAsync(Guid userId)
        //{
        //    string query = "UserDetail";
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@userId", userId, DbType.Guid, ParameterDirection.Input);

        //    return await GetFirstOrDefaultAsync<UserLoginDetailViewModel>(query, parameter, CommandType.StoredProcedure, DataBaseNameEnum.DataBaseHotel);
        //}

        /// <summary>
        ///<Description>Function used to activate user account</Description>
        /// </summary>
        //public async Task<string> ActivateUserAsync(Guid userId)
        //{
        //    string query = "ActivateUserAccount";
        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.Add("@userId", userId, DbType.Guid, ParameterDirection.Input);

        //    return await GetFirstOrDefaultAsync<string>(query, parameter, CommandType.StoredProcedure, DataBaseNameEnum.DataBaseHotel);
        //}
    }
}
