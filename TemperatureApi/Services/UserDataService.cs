using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Helpers;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TemperatureApi.Models;

namespace TemperatureApi.Services
{
    public class UserDataService
    {
        private readonly AppSettings _appSettings;

        private static string connectionString;

        public UserDataService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            connectionString = _appSettings.ConnectionString;
        }

        public int CheckIfConditionExists(String cond)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var x = new { condition = cond };
                var query = "SELECT condition_id FROM Conditions WHERE condition = @condition";

                var rd = db.ExecuteReader(query, x);

                if (!rd.Read())
                {
                    return -1;
                }
                else
                {
                    return rd.GetInt32(0);
                }
            }

        }

        public int SubmitUserData(UserSubModel userdata)
        {
            int cond_id = CheckIfConditionExists(userdata.condition);

            if(cond_id == -1)
            {
                return -1;
            }
            else
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var x = new {city=userdata.city, temp=userdata.temp, cond=cond_id };
                    var query = "INSERT INTO UserData ( city, temp, condition_id) VALUES ( @city, @temp, @cond)";
                    db.Execute(query, x);
                }
                return 1;
            }
        }

        public List<UserSubReturnModel> GetUserData()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var query = "SELECT TOP 10 * FROM UserData a INNER JOIN Conditions b on a.condition_id = b.condition_id";
                return db.Query<UserSubReturnModel>(query).ToList();
            }
        }
    }
}
