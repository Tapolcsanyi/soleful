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
    public class SneakerRepository : BaseRepository, ISneakerRepository
    {
        public SneakerRepository(IConfiguration configuration) : base(configuration) { }
        public List<Sneaker> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, Name, Brand, Gender, Colorway, ReleaseDate, RetailPrice, Shoe, Title, Year
                    FROM Sneaker;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneakers = new List<Sneaker>();
                        while (reader.Read())
                        {
                            sneakers.Add(new Sneaker()
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
                            }); ;
                        }
                        return sneakers;
                    }
                }
            }
        }
        public Sneaker GetSneakerById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT Id, Name, Brand, Gender, Colorway, ReleaseDate, RetailPrice, Shoe, Title, Year
                    FROM Sneaker
                    WhERE Id = {id};";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var sneaker = new Sneaker();
                        if (reader.Read())
                        {
                            sneaker = NewSneakerFromReader(reader);
                        }
                        return sneaker;
                    }
                }
            }
        }
        private Sneaker NewSneakerFromReader(SqlDataReader reader)
        {
            Sneaker sneaker = new Sneaker()
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
            };
            return sneaker;
        }
    }
}
