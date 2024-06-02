using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserWorker.Abstractions;
using UserWorker.Db;
using UserWorker.DbModels;
using UserWorker.DTO;

namespace Tests
{
    internal class MockUserWorkerTest : IUserRepository
    {
        private readonly IMapper _mapper;
        public int AddAdmin(UserViewModel userViewModel)
        {
            using (var context = new UserContext())
            {
                var entityUser = context.Users.Count();
                if (entityUser == 0)
                {
                    var entity = new User();
                    entity.Email = userViewModel.Email;
                    entity.RoleId = RoleId.Admin;

                    entity.Salt = new byte[16];
                    new Random().NextBytes(entity.Salt);

                    var data = Encoding.ASCII.GetBytes(userViewModel.Password).Concat(entity.Salt).ToArray();

                    SHA512 shaM = new SHA512Managed();

                    entity.Password = shaM.ComputeHash(data);

                    context.Users.Add(entity);
                    context.SaveChanges();
                    Task.Delay(2000);
                    return 0;
                }
                else
                {
                    throw new Exception("Admin уже есть, регистрируйте пользователя.");
                    return 2;
                }
                
            }
        }

        public int AddUser(UserViewModel userViewModel)
        {
            using (var context = new UserContext())
            {
                var entityAdmin = context.Users.Count(x => x.RoleId == RoleId.Admin);
                if (entityAdmin == 1)
                {
                    var entityUser = context.Users.FirstOrDefault(x => x.Email.ToLower().Equals(userViewModel.Email.ToLower()));
                    if (entityUser == null)
                    {
                        var entity = new User();
                        entity.Email = userViewModel.Email;
                        entity.RoleId = RoleId.User;
                        entity.Salt = new byte[16];
                        new Random().NextBytes(entity.Salt);
                        var data = Encoding.ASCII.GetBytes(userViewModel.Password).Concat(entity.Salt).ToArray();
                        SHA512 shaM = new SHA512Managed();
                        entity.Password = shaM.ComputeHash(data);

                        context.Users.Add(entity);
                        context.SaveChanges();
                        Task.Delay(2000);
                    }
                    else
                    {
                        throw new Exception("Такой пользователь уже есть.");
                    }
                }
                else
                {
                    throw new Exception("Сначала зарегистрируйте администратора.");
                }
                return 1;
            }
        }

        public int DeleteUser(string email)
        {
            using (var context = new UserContext())
            {
                var entityUser = context.Users.FirstOrDefault(x => x.Email == email);
                if (entityUser == null)
                {
                    throw new Exception("Такого пользователя нет.");
                }
                if (entityUser != null && entityUser.RoleId != RoleId.Admin)
                {
                    context.Users.Remove(entityUser);
                    context.SaveChanges();
                    Task.Delay(2000);
                }
                else if (entityUser.RoleId == RoleId.Admin)
                {
                    throw new Exception("Админа удалять нельзя.");
                }
                return 1;
            }
        }

        public Guid? GetUserID(string email)
        {
            using (var context = new UserContext())
            {
                var guid = context.Users.FirstOrDefault(x => x.Email == email).Id;
                return guid;
            }
        }

        public IEnumerable<UserViewModelWithoutPassword> GetUsers()
        {
            using (var context = new UserContext())
            {
                var users = context.Users.Select(_mapper.Map<UserViewModelWithoutPassword>).ToList();
                return users;
            }
        }

        public RoleId UserCheck(UserViewModel userViewModel)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Email == userViewModel.Email);
                if (user == null)
                {
                    return RoleId.Admin;
                }
                var data = Encoding.ASCII.GetBytes(userViewModel.Password).Concat(user.Salt).ToArray();
                SHA512 SHA512 = new SHA512Managed();
                var bpassword = SHA512.ComputeHash(data);

                if (user.Password.SequenceEqual(bpassword))
                {
                    return user.RoleId;
                }
                else
                {
                    throw new Exception("Неверный пароль. Попробуйте еще раз.");
                }
            }
        }
    }
}
