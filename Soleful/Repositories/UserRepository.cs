using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Soleful.Models;
using Soleful.Utils;

namespace Soleful.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT up.Id AS UserId, up.DisplayName, up.FirstName, up.LastName,
		                up.Email AS UserEmail, up.CreateDateTime AS UserCreateDateTime, 
		                up.UserTypeId, ut.[Name]

                    FROM [User] up
                     LEFT JOIN UserType ut
                        ON up.UserTypeId = ut.Id
                        ORDER BY DisplayName ASC";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var users = new List<User>();
                        while (reader.Read())
                        {
                            users.Add(new User()
                            {
                                Id = DbUtils.GetInt(reader, "UserId"),
                                DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                FirstName = DbUtils.GetString(reader, "FirstName"),
                                LastName = DbUtils.GetString(reader, "LastName"),
                                Email = DbUtils.GetString(reader, "UserEmail"),
                                CreateDateTime = DbUtils.GetDateTime(reader, "UserCreateDateTime"),
                                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                UserType = new UserType()
                                {
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Id = DbUtils.GetInt(reader, "UserTypeId")
                                }
                            });
                        }
                        return users;
                    }
                }
            }
        }

        public User GetUserById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"
                    SELECT u.Id AS UserId, u.DisplayName, u.FirstName, u.LastName,
		                u.Email AS UserEmail, u.CreateDateTime AS UserCreateDateTime, 
		                u.UserTypeId, ut.[Name]

                           From [User] u
                           LEFT JOIN UserType ut
                           ON u.UserTypeId = ut.Id
                            WHERE u.Id = {id}";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var users = new User();
                        if (reader.Read())
                        {
                            users = NewUserFromReader(reader);
                        }
                        return users;
                    }
                }
            }
        }

        private User NewUserFromReader(SqlDataReader reader)
        {
            User users = new User()
            {
                Id = DbUtils.GetInt(reader, "UserId"),
                DisplayName = DbUtils.GetString(reader, "DisplayName"),
                FirstName = DbUtils.GetString(reader, "FirstName"),
                LastName = DbUtils.GetString(reader, "LastName"),
                Email = DbUtils.GetString(reader, "UserEmail"),
                CreateDateTime = DbUtils.GetDateTime(reader, "UserCreateDateTime"),
                UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                UserType = new UserType()
                {
                    Name = DbUtils.GetString(reader, "Name"),
                    Id = DbUtils.GetInt(reader, "UserTypeId")
                }
            };
            return users;
        }



        public User GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, Up.FirebaseUserId, up.FirstName, up.LastName, up.DisplayName, 
                               up.Email, up.CreateDateTime, up.UserTypeId,
                               ut.Name AS UserTypeName
                          FROM [User] up
                               LEFT JOIN UserType ut on up.UserTypeId = ut.Id
                         WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            }
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [User] (FirebaseUserId, FirstName, LastName, DisplayName, 
                                                                 Email, CreateDateTime, UserTypeId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @FirstName, @LastName, @DisplayName, 
                                                @Email, @CreateDateTime, @UserTypeId)";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@DisplayName", user.DisplayName);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@CreateDateTime", user.CreateDateTime);
                    DbUtils.AddParameter(cmd, "@UserTypeId", user.UserTypeId);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }



        /*
        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            return _context.UserProfile
                       .Include(up => up.UserType) 
                       .FirstOrDefault(up => up.FirebaseUserId == firebaseUserId);
        }

        public void Add(UserProfile userProfile)
        {
            _context.Add(userProfile);
            _context.SaveChanges();
        }
        */
    }
}
