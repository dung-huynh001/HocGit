using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace sqlconnect
{
    class Program
    {
        static void Main(string[] args)
        {
           string sqlconnectStr = @"Data Source=DESKTOP-CUA-TAO\SQLEXPRESS;Initial Catalog=xtlab;User ID=SA;Password=vuka427";
            DbConnection connection = new SqlConnection(sqlconnectStr);
            
            Console.WriteLine(connection.State);
            connection.Open();                      // Mở kết nối - hoặc  connection.OpenAsync(); nếu dùng async

            Console.WriteLine(connection.State);

              // Dùng SqlCommand thi hành SQL  - sẽ  tìm hiểu sau
                using (DbCommand command = connection.CreateCommand())
                {
                // Câu truy vấn SQL
                command.CommandText = "select top(5) * from Sanpham";
                var reader = command.ExecuteReader();
                // Đọc kết quả truy vấn
                Console.WriteLine("\r\nCÁC SẢN PHẨM:");
                Console.WriteLine($"{"SanphamID ",10} {"TenSanpham "}");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["SanphamID"],10} {reader["TenSanpham"]}");
                }
                }   


            connection.Close();                     // Đóng kết nối
            Console.WriteLine(connection.State);

            
        }
    }
}
