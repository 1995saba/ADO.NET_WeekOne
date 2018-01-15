using DataLayer.DTOs;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAOs
{
    public class RegionDAO : IDAO<RegionDTO>
    {
        private SqlConnection sqlConnection = null;
        public void Create(RegionDTO t)
        {
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseInsertQuery = @"INSERT INTO [NORTHWND].[dbo].[Region] " +
                                     "(RegionID, RegionDescription) " +
                                     "VALUES ({0}, '{1}')";
                    string realInsertQuery = String.Format(baseInsertQuery,
                        t.RegionId.ToString(),
                        t.RegionDescription);

                    sqlCommand.CommandText = realInsertQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    int result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine(result);
                }
                sqlConnection.Close();
            }
        }

        public void Delete<U>(ref U id)
        {
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseSelectQuery = @"DELETE FROM [NORTHWND].[dbo].[Region] " +
                                     "WHERE [RegionID] = {0}";
                    string realSelectQuery = String.Format(baseSelectQuery, id.ToString());

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;
                }
                sqlConnection.Close();
            }
        }

        public RegionDTO Read<U>(ref U id)
        {
            RegionDTO regionDTOToReturn = null;
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseSelectQuery = @"SELECT * FROM [NORTHWND].[dbo].[Region] " +
                                     "WHERE [RegionID] = {0}";
                    string realSelectQuery = String.Format(baseSelectQuery, id.ToString());

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        regionDTOToReturn = new RegionDTO()
                        {
                            RegionId = Int32.Parse(reader["RegionID"].ToString()),
                            RegionDescription = reader["RegionDescription"].ToString()
                        };
                    }
                }
                sqlConnection.Close();
            }
            return regionDTOToReturn;
        }

        public ICollection<RegionDTO> Read()
        {
            List<RegionDTO> regionDTOsToReturn = new List<RegionDTO>();
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string realSelectQuery = @"SELECT * FROM [NORTHWND].[dbo].[Region]";

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            regionDTOsToReturn.Add(new RegionDTO()
                            {
                                RegionId = Int32.Parse(reader["RegionID"].ToString()),
                                RegionDescription = reader["RegionDescription"].ToString()
                            });
                        }
                    }
                }
                sqlConnection.Close();
            }
            return regionDTOsToReturn;
        }

        public void Update(RegionDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
