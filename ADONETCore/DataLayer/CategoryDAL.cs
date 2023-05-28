using ADONETCore.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ADONETCore.DataLayer

{
    public class CategoryDAL
    {
        public string cnn = " ";
        public CategoryDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }


        public List<Categories> GetAllCategories()
        {
                   
        List<Categories> ListOfCategories = new List<Categories>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "GetAllCategories",
                    cn))
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfCategories.Add(new Categories()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            DisplayOrder = int.Parse(reader["DisplayOrder"].ToString()),
                        }); 
                    }
                   
                }
            }
            return ListOfCategories;

        }

        public List<Categories> GetCategoryById( int categoryId)
        {

            List<Categories> ListOfCategories = new List<Categories>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "GetCategoriesById",
                    cn))
                {
                    cmd.Parameters.Add("@CatId", SqlDbType.Int);
                    cmd.Parameters["@CatId"].Value = categoryId;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfCategories.Add(new Categories()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            DisplayOrder = int.Parse(reader["DisplayOrder"].ToString()),
                        });
                    }

                }
            }
            return ListOfCategories;

        }
    }
}
