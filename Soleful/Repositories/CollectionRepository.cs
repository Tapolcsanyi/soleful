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
    public class CollectionRepository : BaseRepository, ICollectionRepository
    {
        public CollectionRepository(IConfiguration configuration) : base(configuration) { }

        public List<Collection> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, Name, UserId
                    FROM Collection;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var collections = new List<Collection>();
                        while (reader.Read())
                        {
                            collections.Add(new Collection()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                            }); ;
                        }
                        return collections;
                    }
                }
            }
        }
        public List<Collection> GetCollectionByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT Id, Name, UserId
                    FROM Collection
                    WHERE UserId = {id};";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var collections = new List<Collection>();
                        while (reader.Read())
                        {
                            collections.Add(new Collection()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                            }); ;
                        }
                        return collections;
                    }
                }
            }
        }
        public void Add(Collection collection)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Collection (
                            UserId, Name )
                        OUTPUT INSERTED.ID
                        VALUES (
                            @UserId, @Name )";
                    cmd.Parameters.AddWithValue("@UserId", collection.UserId);
                    cmd.Parameters.AddWithValue("@Name", DbUtils.ValueOrDBNull(collection.Name));

                    collection.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public Collection GetCollectionById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"
                    SELECT Id, Name, UserId
                    FROM Collection
                    WHERE Id = {id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var collection = new Collection();
                        if (reader.Read())
                        {
                            collection = new Collection()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                            }; ;
                        }
                        return collection;
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
                    cmd.CommandText = @$"DELETE FROM Collection
                                         WHERE id = {id};";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Collection collection)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Collection
                                        SET Name = @name
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@name", collection.Name);
                    cmd.Parameters.AddWithValue("@id", collection.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private Collection NewCollectionFromReader(SqlDataReader reader)
        {
            Collection collection = new Collection()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                Name = DbUtils.GetString(reader, "Name"),
                UserId = DbUtils.GetInt(reader, "UserId"),
            };
            return collection;
        }

    }
}
