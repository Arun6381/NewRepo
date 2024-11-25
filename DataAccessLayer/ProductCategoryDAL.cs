using System.Data;



namespace curdAppusingStoredProcurder.DataAccessLayer
{
    public class ProductCategoryDAL
    {
        //private readonly string _connectionString;
        internal string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        //public ProductCategoryDAL(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public int InsertProductCategory(string categoryName, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertProductCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.Parameters.AddWithValue("@Description", description);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
