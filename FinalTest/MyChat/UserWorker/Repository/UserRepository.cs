using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using UserWorker.Abstractions;
using UserWorker.Db;
using UserWorker.DbModels;
using UserWorker.DTO;

namespace UserWorker.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;
        
        public UserRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            this._mapper = mapper;
            this._memoryCache = memoryCache;
        }
        //ok
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
                    _memoryCache.Remove("users");
                }
                else
                {
                    throw new Exception("Admin уже есть, регистрируйте пользователя.");
                }
                return 1;
            }
        }
        //ok
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
                        _memoryCache.Remove("users");
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
        //ok
        public IEnumerable<UserViewModelWithoutPassword> GetUsers()
        {
            using (var context = new UserContext())
            {
                if (_memoryCache.TryGetValue("users", out List<UserViewModelWithoutPassword> usersCache))
                {
                    return usersCache;
                }
                var users = context.Users.Select(_mapper.Map<UserViewModelWithoutPassword>).ToList();
                _memoryCache.Set("users", users, TimeSpan.FromMinutes(30));
                return users;
            }
        }

        public Guid? GetUserID(string email)
        {
            using (var context = new UserContext())
            {
                var entityUser = context.Users.FirstOrDefault(x => x.Email == email);
                if (entityUser != null)
                {
                    var userID = context.Users.FirstOrDefault(x => x.Email == email);
                    return userID.Id;
                }
                else
                {
                    throw new Exception("Такого пользователя нет.");
                }
            }
        }

        public int DeleteUser(string email)
        {
            using (var context = new UserContext())
            {
                var entityUser = context.Users.FirstOrDefault(x => x.Email == email);
                if(entityUser == null)
                {
                    throw new Exception("Такого пользователя нет.");
                }
                if (entityUser != null && entityUser.RoleId != RoleId.Admin)
                {
                    context.Users.Remove(entityUser);
                    context.SaveChanges();
                    _memoryCache.Remove("users");
                }
                else if (entityUser.RoleId == RoleId.Admin)
                {
                    throw new Exception("Админа удалять нельзя.");
                }
                return 1;
            }
        }

        public RoleId UserCheck(UserViewModel userViewModel)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Email == userViewModel.Email);
                if (user == null)
                {
                    throw new Exception("Такого пользователя нет.");
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
