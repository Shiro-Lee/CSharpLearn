using System.Data;
using System.Data.SqlClient;

namespace SqlServerApp
{
    class Member
    {
        public string Name { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;
        public int Sex { get; set; } = 1;
        public int Age { get; set; } = 17;
        public double Height { get; set; } = double.NaN;
        public string School { get; set; } = string.Empty;
        public string Arcana { get; set; } = string.Empty;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = ".",
                InitialCatalog = "persona5",
                UserID = "sa",
                Password = "SAMsun123",
            };
            SqlConnection connection = new(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO ThePhantoms (Name, CodeName, Sex, Age, Height, School, Arcana) " +
                "VALUES (@Name, @CodeName, @Sex, @Age, @Height, @School, @Arcana)",
                connection);
            command.Parameters.AddWithValue("@Name", "Ren Amamiya");
            command.Parameters.AddWithValue("@CodeName", "Joker");
            command.Parameters.AddWithValue("@Sex", 1);
            command.Parameters.AddWithValue("@Age", 17);
            command.Parameters.AddWithValue("@Height", 175);
            command.Parameters.AddWithValue("@School", "Shujin Academy");
            command.Parameters.AddWithValue("@Arcana", "Fool");
            int rows = command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ThePhantoms";
            #region MySqlDataReader
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    Member member = new Member()
            //    {
            //        Name = reader.GetString("Name"),
            //        CodeName = reader.GetString("CodeName"),
            //        Sex = reader.GetInt32("Sex"),
            //        Age = reader.GetInt32("Age"),
            //        School = reader.GetString("School"),
            //        Arcana = reader.GetString("Arcana")
            //    };
            //    Console.WriteLine($"{member.Name} - {member.CodeName} - {member.Sex} - {member.Age} - {member.School} - {member.Arcana}");
            //}
            #endregion
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Console.WriteLine("Name\t\tCodeName\tSex\tAge");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", row["Name"], row["CodeName"], row["Sex"], row["Age"]);
            }
            connection.Close();
        }
    }
}
