using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Soleful.Models;
using Soleful.Utils;

namespace Soleful.Repositories
{
    public class UserSneakerRepository : BaseRepository, IUserSneakerRepository
    {
        public UserSneakerRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserSneaker> GetUserSneakerByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT us.Id, us.SneakerId, us.UserId, s.Id, s.Name, s.Brand, s.Gender, s.Colorway, s.ReleaseDate, s.RetailPrice, s.Shoe, s.Title, s.Year, u.Id,
                    u.FirstName, u.Lastname, u.DisplayName, u.Email, u.CreateDateTime, u.UserTypeId, ut.Id, ut.Name
                    FROM UserSneaker us
                    LEFT JOIN Sneaker s ON us.SneakerId = s.Id
                    LEFT JOIN [User] u ON us.UserId = u.Id
                    LEFT JOIN UserType ut ON u.UserTypeId = ut.Id
                    WHERE us.UserId = {id};";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneaker = new List<UserSneaker>();
                        while (reader.Read())
                        {
                            sneaker.Add(NewUserSneakerFromReader(reader));
                        }
                        return sneaker;
                    }
                }
            }
        }
        public List<UserSneaker> GetAllUserSneaker()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT us.Id, us.SneakerId, us.UserId, s.Id, s.Name, s.Brand, s.Gender, s.Colorway, s.ReleaseDate, s.RetailPrice, s.Shoe, s.Title, s.Year, u.Id,
                    u.FirstName, u.Lastname, u.DisplayName, u.Email, u.CreateDateTime, u.UserTypeId, ut.Id, ut.Name
                    FROM UserSneaker us
                    LEFT JOIN Sneaker s ON us.SneakerId = s.Id
                    LEFT JOIN [User] u ON us.UserId = u.Id
                    LEFT JOIN UserType ut ON u.UserTypeId = ut.Id;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneaker = new List<UserSneaker>();
                        while (reader.Read())
                        {
                            sneaker.Add(NewUserSneakerFromReader(reader));
                        }
                        return sneaker;
                    }
                }
            }
        }
        public void Add(UserSneaker sneaker)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserSneaker (UserId, SneakerId)
                                        OUTPUT INSERTED.ID
                                                     VALUES (@UserId, @SneakerId)";
                    cmd.Parameters.AddWithValue("@UserId", sneaker.UserId);
                    cmd.Parameters.AddWithValue("@SneakerId", sneaker.SneakerId);

                    sneaker.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        private UserSneaker NewUserSneakerFromReader(SqlDataReader reader)
        {
            UserSneaker sneaker = new UserSneaker()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                UserId = DbUtils.GetInt(reader, "UserId"),
                SneakerId = DbUtils.GetInt(reader, "SneakerId"),
                sneaker = new Sneaker
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                    Brand = DbUtils.GetString(reader, "Brand"),
                    Gender = DbUtils.GetString(reader, "Gender"),
                    Colorway = DbUtils.GetString(reader, "Colorway"),
                    ReleaseDate = DbUtils.GetDateTime(reader, "ReleaseDate"),
                    RetailPrice = DbUtils.GetInt(reader, "RetailPrice"),
                    Shoe = DbUtils.GetString(reader, "Shoe"),
                    Title = DbUtils.GetString(reader, "Title"),
                    Year = DbUtils.GetInt(reader, "Year")
                },
                user = new User
                {
                    Id = DbUtils.GetInt(reader, "UserId"),
                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                    FirstName = DbUtils.GetString(reader, "FirstName"),
                    LastName = DbUtils.GetString(reader, "LastName"),
                    Email = DbUtils.GetString(reader, "Email"),
                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                    UserType = new UserType()
                    {
                        Name = DbUtils.GetString(reader, "Name"),
                        Id = DbUtils.GetInt(reader, "UserTypeId")
                    }
                }
            };
            return sneaker;
        }
    }
}
