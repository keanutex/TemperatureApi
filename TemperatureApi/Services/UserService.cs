using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TemperatureApi.Entities;
using TemperatureApi.Helpers;
using TemperatureApi.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TemperatureApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<User> GetAll(AuthenticateRequest model);
        User GetByUsername(string username);
        User registerUser(User user);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>();

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
       
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            _users = GetAll(model);
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public List<User> GetAll(AuthenticateRequest model)
        {
            string connectionString = _appSettings.ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //_users = db.Query<User>("Select * From Users").ToList();
                //TODO
                //SqlParameter @username = new SqlParameter("@username", SqlDbType.VarChar) { Value = model.Username };
                //SqlParameter @password = new SqlParameter("@password", SqlDbType.VarChar) { Value = model.Password };
                var query = $"SELECT username, password FROM Users WHERE username LIKE '{model.Username}' AND password LIKE '{model.Password}'";
                //var query = "SELECT username, password FROM Users WHERE username LIKE @username AND password LIKE @password";
                _users = db.Query<User>(query).ToList();
            }
            return _users;
        }

        public User GetByUsername(string username)
        {
            _users = getUsersFromDB();
            return _users.FirstOrDefault(x => x.Username.Equals(username));
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

        public User registerUser(User user) {

            //check user not already registered
            string connectionString = _appSettings.ConnectionString;

            _users = getUsersFromDB();
            foreach (User x in _users)
            {
                if ((x.Username).Equals(user.Username))
                    return null;
            }
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var query = $"INSERT INTO Users (FirstName, LastName, Username, Password) VALUES('{user.FirstName}','{user.LastName}', '{user.Username}', '{user.Password}')";
                var result = db.Execute(query);
            }
            return user;
        }
        public List<User> getUsersFromDB()
        {
            string connectionString = _appSettings.ConnectionString;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var query = "SELECT FirstName, LastName, Username, Password FROM Users";
                _users = db.Query<User>(query).ToList();
            }
            return _users;
        }
    }
}
