using Microsoft.EntityFrameworkCore.Query;
using MvcTemplate.Dtos;
using MvcTemplate.ModelUsers;
using MvcTemplate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository = new UserRepository();

        public void Add(UsersDto usersDto)
        {
            Users users = new Users();           
            users.Name = usersDto.Name;
            users.Password = usersDto.Password;
            users.Cnic = usersDto.Cnic;
            users.Address = usersDto.Address;
            users.Email = usersDto.Email;
          
            userRepository.Add(users);
        }

        public void Update(UsersDto usersdto)
        {
           Users users = userRepository.GetbyidRepo(usersdto.Id);
            if (users != null)
            {
                users.Name = usersdto.Name;
                users.Password = usersdto.Password;
                users.Cnic = usersdto.Cnic;
                users.Address = usersdto.Address;
                users.Email = usersdto.Email;

                userRepository.Update(users);
            }

        }

        public void Remove(UsersDto usersdto)
        {
            Users users = new Users();
            users.Id = usersdto.Id;
            userRepository.Remove(users);

        }
        public List<UsersDto> GetAll()
        {
            List<Users> users = userRepository.GetAllrepo();

            List<UsersDto> usersDtos = new List<UsersDto>();
            foreach (var user in users)
            {
                UsersDto usersDto = new UsersDto();
                usersDto.Id = user.Id;
                usersDto.Name = user.Name;
                usersDto.Password = user.Password;
                usersDto.Cnic = user.Cnic;
                usersDto.Address = user.Address;    
                usersDto.Email = user.Email;

                usersDtos.Add(usersDto);

            }
            return usersDtos;
        }

        public UsersDto GetbyID(int id)
        {
            Users users = userRepository.GetbyidRepo(id);
            if(users != null)
            {
                UsersDto usersDto = new UsersDto();
                usersDto.Id = users.Id;
                usersDto.Name = users.Name;
                usersDto.Password = users.Password;
                usersDto.Cnic = users.Cnic;
                usersDto.Address = users.Address;
                usersDto.Email = users.Email;

                return usersDto;
            }
            return null;
        }
    }
}