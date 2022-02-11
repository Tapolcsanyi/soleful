using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Models;
using Soleful.Utils;

namespace Soleful.Repositories
{
    public class ListSneakerRepository : BaseRepository, IListSneakerRepository
    {
        public ListSneakerRepository(IConfiguration configuration) : base(configuration) { }

        public List<ListSneaker> GetListSneakerByListId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT DISTINCT ls.Id, ls.SneakerId, ls.ListId, s.Id, s.Name, s.Brand, s.Gender, s.Colorway, s.ReleaseDate, s.RetailPrice, s.Shoe, s.Title, s.Year, s.Image, l.Id,
                    l.Id, l.Name, l.UserId
                    FROM ListSneaker ls
                    LEFT JOIN Sneaker s ON ls.SneakerId = s.Id
                    LEFT JOIN [Collection] l ON ls.ListId = l.Id
                    WHERE ls.ListId = {id};";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneaker = new List<ListSneaker>();
                        while (reader.Read())
                        {
                            sneaker.Add(NewListSneakerFromReader(reader));
                        }
                        return sneaker;
                    }
                }
            }
        }
        public List<ListSneaker> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT DISTINCT ls.Id, ls.SneakerId, ls.ListId, s.Id, s.Name, s.Brand, s.Gender, s.Colorway, s.ReleaseDate, s.RetailPrice, s.Shoe, s.Title, s.Year, s.Image, l.Id,
                    l.Id, l.Name, l.UserId
                    FROM ListSneaker ls
                    LEFT JOIN Sneaker s ON ls.SneakerId = s.Id
                    LEFT JOIN [Collection] l ON ls.ListId = l.Id";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneaker = new List<ListSneaker>();
                        while (reader.Read())
                        {
                            sneaker.Add(NewListSneakerFromReader(reader));
                        }
                        return sneaker;
                    }
                }
            }
        }
        public void Add(ListSneaker sneaker)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO ListSneaker (ListId, SneakerId)
                                        OUTPUT INSERTED.ID
                                                     VALUES (@ListId, @SneakerId)";
                    cmd.Parameters.AddWithValue("@ListId", sneaker.ListId);
                    cmd.Parameters.AddWithValue("@SneakerId", sneaker.SneakerId);

                    sneaker.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"DELETE FROM ListSneaker
                                         WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private ListSneaker NewListSneakerFromReader(SqlDataReader reader)
        {
            ListSneaker sneaker = new ListSneaker()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                ListId = DbUtils.GetInt(reader, "ListId"),
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
                    Image = DbUtils.GetString(reader, "Image"),
                    Year = DbUtils.GetInt(reader, "Year")
                },
                list = new Collection
                {
                    Id = DbUtils.GetInt(reader, "UserId"),
                    Name = DbUtils.GetString(reader, "Name"),
                    UserId = DbUtils.GetInt(reader, "UserId"),
                }
            };
            return sneaker;
        }
    }
}
