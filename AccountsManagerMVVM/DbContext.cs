using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using AccountsManagerMVVM.Models;

namespace AccountsManagerMVVM;

using Dapper;
using Microsoft.Data.Sqlite;

public class DbContext
{
    private string ConnectionString { get; }
    private SqliteConnection _db;

    public DbContext(string connectionString)
    {
        ConnectionString = connectionString;
        _db = new SqliteConnection(ConnectionString);
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

    public bool AddUser(User user)
    {
        using (_db)
        {
            _db.Open();
            const string sql1 = """
                                INSERT INTO table_persons(last_name, first_name, patronymic)
                                VALUES (@LastName, @FirstName, @Patronymic);
                                """;
            var command1 = _db.Execute(sql1,new
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Patronymic = user.Patronymic
            });
            const string sqlGetId = "SELECT last_insert_rowid();";
            var personId = _db.QuerySingle<long>(sqlGetId);
            
            const string sql2 = """
                                INSERT INTO table_accounts(email, password,person_id)
                                VALUES (@Email, @Password, @PersonId);
                                """;
            var command2 = _db.Execute(sql2, new
            {
                Email = user.Email,
                Password = user.Password,
                PersonsId = personId
            });

            return command1 > 0 && command2 > 0;
        }
        
    }
}