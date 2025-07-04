using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProductSalesReportApp.Models;

namespace ProductSalesReportApp.Services
{
    public class SalesService
    {
        private readonly string _connectionString;

        public SalesService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Sale> GetSales(DateTime startDate, DateTime endDate)
        {
            List<Sale> sales = new List<Sale>();
            string query = @"SELECT PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE 
                             FROM PRODUCTSALES
                             WHERE SALEDATE BETWEEN @startDate AND @endDate";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sales.Add(new Sale
                        {
                            ProductCode = reader.GetString(0),
                            ProductName = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            UnitPrice = reader.GetDecimal(3),
                            SaleDate = reader.GetDateTime(4)
                        });
                    }
                }
            }

            return sales;
        }
    }
}
