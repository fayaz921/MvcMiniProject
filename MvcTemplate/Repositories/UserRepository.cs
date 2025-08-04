using MvcTemplate.Data;
using MvcTemplate.ModelUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Repositories
{
    public class UserRepository
    {
        private readonly MvcUserscontext mvcUserscontext = new MvcUserscontext();

        public void Add(Users users)
        {
            mvcUserscontext.Users.Add(users);
            mvcUserscontext.SaveChanges();
        }

        public void Update(Users users)
        {
            mvcUserscontext.Users.Update(users);
            mvcUserscontext.SaveChanges();
        }

        public void Remove(Users users)
        {
            mvcUserscontext.Users.Remove(users);
            mvcUserscontext.SaveChanges();
        }


        public List<Users> GetAllrepo()
        {
            return mvcUserscontext.Users.ToList();
        }

        public Users GetbyidRepo(int id)
        {
            return mvcUserscontext.Users.Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}