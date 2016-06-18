using System;
using System.Configuration;
using System.Linq;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class TokenService:ITokenService
   {
       private readonly UnitOfWork _unitOfWork;

       public TokenService()
       {
           _unitOfWork = new UnitOfWork();
       }
        public TokenEntity GenerateToken(int userId)
       {
           string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
           DateTime expiredOn = DateTime.Now.AddSeconds(
               Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
           var tokendomain = new Token
           {
               userId = userId,
               authToken = token,
               issuedOn = issuedOn,
               expiresOn = expiredOn
           };
            _unitOfWork.TokenRepository.Insert(tokendomain);
            _unitOfWork.Save();

           var tokenModel = new TokenEntity()
           {
               UserId = userId,
               IssuedOn = issuedOn,
               ExpiresOn = expiredOn,
               AuthToken = token
           };
           return tokenModel;
           
       }

        /// <summary>
       /// Method to validate token against expiry and existence in database.
       /// </summary>
       /// <param name="tokenId"></param>
       /// <returns></returns>
       public bool ValidateToken(string tokenId)
       {
           var token = _unitOfWork.TokenRepository.Get(t => t.authToken == tokenId && t.expiresOn > DateTime.Now);
           if (token != null && !(DateTime.Now > token.expiresOn))
           {
               token.expiresOn = token.expiresOn.AddSeconds(
                   Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
               _unitOfWork.TokenRepository.Update(token);
               _unitOfWork.Save();
               return true;
           }
           return false;
       }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
       {
           _unitOfWork.TokenRepository.Delete(x=>x.authToken == tokenId);
            _unitOfWork.Save();

            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.authToken == tokenId).Any();
            if (isNotDeleted)
            {
                return false;
            }
            return true;
       }
        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
           _unitOfWork.TokenRepository.Delete(x => x.userId == userId);
        _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.userId == userId).Any();
            return !isNotDeleted;
        }
    }
}
