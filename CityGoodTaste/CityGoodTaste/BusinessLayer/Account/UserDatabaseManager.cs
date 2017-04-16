using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGoodTaste.Models;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;

namespace CityGoodTaste.BusinessLayer
{
    public class UserDatabaseManager : IUserDatabase
    {
        #region Log in
        private bool IsUserExist(GoodTasteContext context, 
            string email, string password)
        {
            var usersQuery = context.Users;
            foreach (var user in usersQuery)
            {
                if (user.Email == email &&
                    user.PasswordHash == password)
                    return true;
            }
            return false;
        }

        public ApplicationUser LogIn(string email, string password)
        {
            try
            {
                string message;
                using (GoodTasteContext context = new GoodTasteContext())
                {
                    if (!IsUserExist(context, email, password))
                    {
                        message = "Your email or password isn't correct!";
                        throw new Exception(message);
                    }
                    else
                    {
                        var user = context.Users.Where(u => u.Email == email)
                            .SingleOrDefault();
                        return user;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion       

        #region Sign up
        private bool IsInputDataCorrect(ApplicationUser currentUser)
        {
            return true;
        }

        private bool IsUserExist(GoodTasteContext context, ApplicationUser currentUser)
        {
            var usersQuery = context.Users;
            foreach (var user in usersQuery)
            {
                if (user.Email == currentUser.Email)
                    return true;
            }
            return false;
        }

        public void SignUp(ApplicationUser user)
        {
            try
            {
                string message;
                using (GoodTasteContext context = new GoodTasteContext())
                {
                    if (IsUserExist(context, user))
                    {
                        message = "Such user is already exist!";
                        throw new Exception(message);
                    }
                    if (!IsInputDataCorrect(user))
                    {
                        message = "User data isn't correct!";
                        throw new Exception(message);
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Get user data
        public ApplicationUser GetUserById(string id)
        {
            try
            {
                using (GoodTasteContext context = new GoodTasteContext())
                {
                    ApplicationUser user = context.Users.Where(d => d.Id == id).SingleOrDefault();
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}