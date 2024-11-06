using ECommercePlatform.Business.Data_Protection;
using ECommercePlatform.Business.Operations.User.Dtos;
using ECommercePlatform.Business.Types;
using ECommercePlatform.Data.Entities;
using ECommercePlatform.Data.Enums;
using ECommercePlatform.Data.Repositories;
using ECommercePlatform.Data.UnitOfWork;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.User
{
    public class UserManager : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IDataProtection _dataProtector;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepo, IDataProtection dataProtector)
        {
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
            _dataProtector = dataProtector;
        }

        public async Task<ServiceMessage> AddUser(AddUserDto userDto)
        {
            var hasMail = _userRepo.GetAll(x => x.Email.ToLower() == userDto.Email.ToLower());
            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Girdiğiniz email adresi sistemde mevcuttur."
                };

            }

            var user = new UserEntity
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = _dataProtector.Protect(userDto.Password),
                BirthDate = userDto.BirthDate,
                UserType=UserType.Customer
            };

            _userRepo.Add(user);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Hata",ex);
            }

            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto userDto)
        {
            var userEntity=_userRepo.Get(x=>x.Email.ToLower()==userDto.Email.ToLower());
            if(userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }

            var unprotectedPassword=_dataProtector.UnProtect(userEntity.Password);

            if (unprotectedPassword == userDto.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Email = userEntity.Email,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        UserType=userEntity.UserType,
                    }
                };
            }

            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }





        }
    }
}
