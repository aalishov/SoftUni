using SharedTrip.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        public void CreateUser(RegisterUserVM registerUserVM);
    }
}
