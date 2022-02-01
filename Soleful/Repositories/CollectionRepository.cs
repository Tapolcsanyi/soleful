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

    }
}
