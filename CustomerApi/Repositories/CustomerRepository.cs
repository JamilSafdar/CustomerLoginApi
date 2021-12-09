using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CustomerApi.Repositories
{
    public class CustomerRepository
    {
        public void Create(string forename, string surname, string title, string email)
        {
            using (var connection =
                new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=Customers;User Id=jamilTest;Password=test123;"))
            {
                connection.Open();
//                var sqlStatement = @"
//INSERT INTO [dbo].[Users]
//           ([Forename]
//           ,[Surname]
//           ,[Title]
//           ,[Email])
//     VALUES
//           (@Forename
//           ,@Surname
//           ,@Title
//           ,@Email)";
                var sqlStatement = @$"
                    INSERT INTO [dbo].[Users]
                               ([Forename]
                               ,[Surname]
                               ,[Title]
                               ,[Age])
                         VALUES
                               ('{forename}'
                               ,'{surname}'
                               ,'{title}'
                               ,{email})";
                connection.Execute(sqlStatement);
            }
        }

        public CustomerDetails Get(int id)
        {
            using (var connection =
                new SqlConnection(
                    "Server=(LocalDb)\\MSSQLLocalDB;Database=Customers;User Id=jamilTest;Password=test123;"))
            {
                connection.Open();

                var sqlStatement = @$"
                SELECT [Id]
                      ,[Forename]
                      ,[Surname]
                      ,[Title]
                      ,[Email]
                  FROM [Customers].[dbo].[Users]

                  where id = {id}";

                var details = connection.Query<CustomerDetails>(sqlStatement);
                return details.FirstOrDefault();
            }
        }
    }
}
