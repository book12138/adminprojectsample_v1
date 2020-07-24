using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Jwt
{
    public static class JwtHelper
    {
        public static readonly string secretKey = "ahfuawivb754huab21n5n1";

        /// <summary>
        /// 根据用户信息，颁发Token
        /// </summary>
        public static string IssueJwt(TokenModelJwt tokenModel)
        {
            var dateTime = DateTime.UtcNow;

            var claims = new Claim[]
            {
                    //下边为Claim的默认配置
                    new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    //过期时间，可自定义，注意JWT有自己的缓冲过期时间
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddHours(2)).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Iss,"shapman"),
                    new Claim(JwtRegisteredClaimNames.Aud,"wr"),
                    //这个Role是官方UseAuthentication要要验证的Role，我们就不用手动设置Role这个属性了
           };


            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "shapman",
                claims: claims,
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析Token
        /// </summary>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role;
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                throw e;
            }
            var tm = new TokenModelJwt
            {
                Uid = long.TryParse(jwtToken.Id,out long temp) ? temp : 0,
            };
            return tm;
        }

        /// <summary>
        /// 从请求文中，获取token中，包含的信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static TokenModelJwt GetTokenModel(this HttpContext httpContext)
        {
            var temp = httpContext.Request;
            if (temp.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value))
            {
                string token = value.ToString().Split(' ')[1];
                var result = SerializeJwt(token);
                return result;
            }
            else
                return null;
        }
    }
}
