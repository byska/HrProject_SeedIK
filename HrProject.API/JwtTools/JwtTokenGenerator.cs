using HrProject.DTOs;
using HrProject.Entities.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HrProject.API.JwtTools
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(UserSignInDTO userSignInDTO,IList<string> roleList)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HRProjectTeam123456789012345"));

            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            foreach (string role in roleList)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.Gender, userSignInDTO?.Gender.ToString()));
            claims.Add(new Claim("ID",userSignInDTO.ID.ToString()));
            claims.Add(new Claim("WorkingYear", userSignInDTO.WorkingYear.ToString()));
            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost",claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string tokenString = handler.WriteToken(token);

            return tokenString;
        }
    }
}
