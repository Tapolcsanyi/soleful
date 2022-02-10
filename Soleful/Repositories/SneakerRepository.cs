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
                    SELECT Id, Name, Brand, Gender, Colorway, ReleaseDate, RetailPrice, Shoe, Title, Year, Image
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
                                Year = DbUtils.GetInt(reader, "Year"),
                                Image = DbUtils.GetString(reader, "Image")
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
                    SELECT Id, Name, Brand, Gender, Colorway, ReleaseDate, RetailPrice, Shoe, Title, Year, Image
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

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"DELETE FROM Sneaker
                                         WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Add(Sneaker sneaker)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Sneaker (
                            Brand, Name, Gender, Colorway, ReleaseDate, RetailPrice, Shoe, Title, Year, Image)
                        OUTPUT INSERTED.ID
                        VALUES (
                            @Brand, @Name, @Gender, @Colorway, @ReleaseDate, @RetailPrice, @Shoe, @Title, @Year, @Image )";
                    cmd.Parameters.AddWithValue("@Brand", sneaker.Brand);
                    cmd.Parameters.AddWithValue("@Name", DbUtils.ValueOrDBNull(sneaker.Name));
                    cmd.Parameters.AddWithValue("@Gender", sneaker.Gender);
                    cmd.Parameters.AddWithValue("@Colorway", sneaker.Colorway);
                    cmd.Parameters.AddWithValue("@ReleaseDate", sneaker.ReleaseDate);
                    cmd.Parameters.AddWithValue("@RetailPrice", sneaker.RetailPrice);
                    cmd.Parameters.AddWithValue("@Shoe", sneaker.Shoe);
                    cmd.Parameters.AddWithValue("@Title", sneaker.Title);
                    cmd.Parameters.AddWithValue("@Year", sneaker.Year);
                    cmd.Parameters.AddWithValue("@Image", sneaker.Image);

                    sneaker.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public void Update(Sneaker sneaker)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Sneaker
                                        SET Name = @Name, Brand = @Brand, 
                                        Gender = @Gender, Colorway = @Colorway, 
                                        ReleaseDate = @ReleaseDate, RetailPrice = @RetailPrice, 
                                        Shoe = @Shoe, Title = @Title, Year = @Year, Image = @Image
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@Brand", sneaker.Brand);
                    cmd.Parameters.AddWithValue("@Name", DbUtils.ValueOrDBNull(sneaker.Name));
                    cmd.Parameters.AddWithValue("@Gender", sneaker.Gender);
                    cmd.Parameters.AddWithValue("@Colorway", sneaker.Colorway);
                    cmd.Parameters.AddWithValue("@ReleaseDate", sneaker.ReleaseDate);
                    cmd.Parameters.AddWithValue("@RetailPrice", sneaker.RetailPrice);
                    cmd.Parameters.AddWithValue("@Shoe", sneaker.Shoe);
                    cmd.Parameters.AddWithValue("@Title", sneaker.Title);
                    cmd.Parameters.AddWithValue("@Year", sneaker.Year);
                    cmd.Parameters.AddWithValue("@Image", sneaker.Image);
                    cmd.Parameters.AddWithValue("@id", sneaker.Id);

                    cmd.ExecuteNonQuery();
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
                Year = DbUtils.GetInt(reader, "Year"),
                Image = DbUtils.GetString(reader, "Image")
            };
            return sneaker;
        }
    }
}
