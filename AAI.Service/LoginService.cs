﻿using AAI.DataContract.Models.Entity;
using AAI.DataContract.Models.Entity.DB;
using AAI.DataContract.Models.Login;
using AAI.DataContract.Models.User;
using AAI.RepositoryContract.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI.Service
{
    public class LoginService : ILoginInterface
    {
        private readonly EntityDbContext _dbcontext;

        public LoginService(EntityDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }
        public async Task<DataContract.Models.Login.UserDetailViewModel> GetLoginDetailsAsync(string email,string password)
        {
            var userList = new DataContract.Models.Login.UserDetailViewModel();
            try
            {
                var data =  await _dbcontext.User1.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
                //var data =  await _dbcontext.User1.FirstOrDefaultAsync(a => a.Email == userName);
             
                //if (data. == null)
                //{
                //    userList.Id = data.Id;
                //    userList.Name = data.FirstName;
                //    userList.Email = data.Email;

                //}
            }
            catch (Exception ex)
            {

            }


            return userList;
        }
    }
}
