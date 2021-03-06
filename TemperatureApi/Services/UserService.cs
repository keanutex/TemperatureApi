﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TemperatureApi.Models;
using TemperatureApi.Helpers;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TemperatureApi.Services
{
    public class UserService
    {
        private readonly AppSettings _appSettings;

        private static string connectionString;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            connectionString = _appSettings.ConnectionString;
        }
       
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var x = new { username = model.Username, password = hashPassword(model.Password) };
                var query = "SELECT FirstName, LastName, Username FROM Users WHERE Username LIKE @username AND Password LIKE @password";
                user =  db.Query<User>(query,x).FirstOrDefault();
            }

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public User GetByUsername(string username)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var x = new { name = username };
                var query = $"SELECT FirstName, LastName, Username FROM Users WHERE Username LIKE @name";
                return db.Query<User>(query, x).FirstOrDefault();
            } 
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", user.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public String registerUser(User user) {

            //check user not already registered
            if (GetByUsername(user.Username) != null)
                return "User already exists";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var x = new { firstname = user.FirstName, lastname = user.LastName, username = user.Username, password = hashPassword(user.Password) };
                var query = "INSERT INTO Users (FirstName, LastName, Username, Password) VALUES( @firstname, @lastname, @username, @password)";
                db.Execute(query, x);
            }
            return "User successfully registered";
        }

        private string hashPassword(String password)
        {
            byte[] salt = new byte[16] {198,211,143,7,130,128,198,53,104,130,191,46,105,139,126,191};

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
           
            return hashed;
        }
    }
}
