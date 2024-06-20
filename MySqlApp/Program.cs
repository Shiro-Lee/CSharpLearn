using MySql.Data.MySqlClient;
using System.Data;

namespace MySqlApp
{
    class Member
    {
        public string Name { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;
        public int Sex { get; set; } = 1;
        public int Age { get; set; } = 17;
        public double Height { get; set; } = double.NaN;
        public string School { get; set; } = string.Empty;
        public string Arcana {  get; set; } = string.Empty;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new()
            {
                UserID = "root",
                Password = "1234",
                Server = "localhost",
                Database = "persona5"
            };
            MySqlConnection connection = new(builder.ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO ThePhantoms (Name, CodeName, Sex, Age, School, Arcana) " +
                "VALUES (@Name, @CodeName, @Sex, @Age, @School, @Arcana)", 
                connection);
            command.Parameters.AddWithValue("@Name", "Ren Amamiya");
            command.Parameters.AddWithValue("@CodeName", "Joker");
            command.Parameters.AddWithValue("@Sex", 1);
            command.Parameters.AddWithValue("@Age", 17);
            command.Parameters.AddWithValue("@School", "Shujin Academy");
            command.Parameters.AddWithValue("@Arcana", "Fool");

			int rows = command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ThePhantoms";
            #region MySqlDataReader
            //MySqlDataReader reader = command.ExecuteReader();
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
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
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
