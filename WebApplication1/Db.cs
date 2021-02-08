using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WebApplication1.Pages;

namespace WebApplication1
{
    public static class Db
    {
        // DBTest
        public static async Task<IEnumerable<Actor>> GetActors(string connectionString)
        {
            using var conn = GetOpenConnection(connectionString);

            var result = await conn.QueryAsync<Actor>(
                "SELECT actorid as ActorID, name as Name, sex as Sex " +
                "FROM Actors");

            return result;
        }

        // an empty result set testing nullable
        //public static async Task<IEnumerable<UserX>> GetNoUsers(string connectionString)
        //{
        //    using var conn = GetOpenConnection(connectionString);

        //    var result = await conn.QueryAsync<UserX>(
        //        "SELECT UserId, UserName " +
        //        "FROM aspnet_Users WHERE UserName='asdf'");

        //    return result;
        //}

        public static IDbConnection GetOpenConnection(string connectionString)
        {
            if (connectionString == null) throw new ArgumentException("connectionString can't be null");

            DbConnection cnn = new SqlConnection(connectionString);
            //if (MiniProfiler.Current != null)
            //{
            //    cnn = new ProfiledDbConnection(cnn, MiniProfiler.Current);
            //}
            //cnn.Open();
            return cnn;
        }

    }
}
