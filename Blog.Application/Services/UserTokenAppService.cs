using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Common.JWT;
using Blog.Domain.Interfaces;
using Blog.Domain.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Services
{
    public class UserTokenAppService : IUserTokenAppService
    {
        private readonly IRepository<UserToken> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserTokenAppService(IRepository<UserToken> userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public UserToken GetTokenById(string id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// 保存用户的token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public void SaveUserToken(JwtTokenInfo token)
        {
            _userRepository.Add(_mapper.Map<UserToken>(token));
            _unitOfWork.Commit();

        }
    }
}
