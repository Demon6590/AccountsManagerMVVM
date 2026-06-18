using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using AccountsManagerMVVM.Models;

namespace AccountsManagerMVVM;

using Dapper;
using Npgsql;

public class DbContext
{
    private string ConnectionString { get; }
    private NpgsqlConnection _db;

    public DbContext(string connectionString)
    {
        ConnectionString = connectionString;
        _db = new NpgsqlConnection(ConnectionString);
    }

    public IEnumerable<User> GetAllUsers()
    {
        using (_db)
        {
            _db.Open();
            const string sql =
                "SELECT person_id, last_name, first_name,patronymic, email,password  FROM view_persons_and_accounts";
            return _db.Query<User>(sql);
        }
    }

    public bool AddUser(UserInsert user)
    {
        using (_db)
        {
            _db.Open();
            const string sql1 = """
                                INSERT INTO table_persons(last_name, first_name, patronymic)
                                VALUES (@LastName, @FirstName, @Patronymic)
                                RETURNING id;
                                """;
            var personId  = _db.QuerySingle(sql1,new
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Patronymic = user.Patronymic
            });
            
            const string sql2 = """
                                INSERT INTO table_accounts(email, password,person_id)
                                VALUES (@Email, @Password, @PersonId);
                                """;
            var command2 = _db.Execute(sql2, new
            {
                Email = user.Email,
                Password = user.Password,
                PersonId = personId
            });

            return personId  > 0 && command2 > 0;
        }
        
    }

    public bool UpdateUser(User user)
    {
        using (_db)
        {
            _db.Open();
            const string sql1 = """
                                UPDATE table_persons 
                                SET last_name = @LastName, 
                                    first_name = @FirstName, 
                                    patronymic = @Patronymic
                                WHERE id = @PersonId;
                                """;
            var rowsPerson = _db.Execute(sql1, new
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Patronymic = user.Patronymic,
                PersonId = user.PersonId
            });
            const string sql2 = """
                                UPDATE table_accounts 
                                SET email = @Email, 
                                    password = @Password
                                WHERE person_id = @PersonId;
                                """;

            var rowsAccount = _db.Execute(sql2, new
            {
                Email = user.Email,
                Password = user.Password,
                PersonId = user.PersonId
            });
            return rowsPerson > 0 && rowsAccount > 0;
        }

    }

}