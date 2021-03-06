﻿using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User GetUserById(long id);
        bool DeleteUserById(long id);
        User GetByEmail(string email);
        User SaveUser(User mUser);
        UserResources GetResources();
        User Authenticate(string email, string password);
        User Credentials(string email);
    }
}
