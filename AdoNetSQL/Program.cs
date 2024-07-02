using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

namespace AdoNetSQL;
internal class Program
{
    static void Main(string[] args)
    {
        //Insert();
        //Delete(8);
        //GetAllData();
        //Update();
        //GetData(7);

        //int studentId = 12;
        //Student student = GetData(studentId);
        //if (student != null)
        //{
        //    Console.WriteLine($"{student.Id} - {student.Name} - {student.Surname} - {student.Age} - {student.Grant} - {student.GroupId}");
        //}
        //else
        //{
        //    Console.WriteLine($"No student found with Id: {studentId}");
        //}

    }


    const string SQLConnection = "Server=ILAHA\\SQLEXPRESS01;Database=EducationDatabase;Trusted_Connection=True;TrustServerCertificate=True";
    public static SqlConnection sqlConnection = new SqlConnection(SQLConnection);

   
    public static void Insert() 
    {
        sqlConnection.Open();
        string cmd = "Insert Into Students Values ('Aghalar','Aghalarli',28,1000,3)";
        SqlCommand comand = new SqlCommand(cmd, sqlConnection);
        int check = comand.ExecuteNonQuery();
        if (check > 0)
        {
            Console.WriteLine("New student installed");
        }
        else 
        {
            Console.WriteLine("Error"); 
        }
        sqlConnection.Close();
    } 

    public static void Delete(int id) 
    {
        sqlConnection.Open();
        string cmd = "Delete from Students Where Id=@Id";
        SqlCommand comand = new SqlCommand(cmd, sqlConnection);
        comand.Parameters.AddWithValue("@Id", id);
        //comand.Parameters.AddWithValue("@Id", id);  Bu hissədə Chatgpt-dən komek aldim.
        int check = comand.ExecuteNonQuery();
        if (check > 0)
        {
            Console.WriteLine("The student deleted");
        }
        else
        {
            Console.WriteLine("Error");
        }
        sqlConnection.Close();
    }

    public static void Update() 
    {

        sqlConnection.Open();
        string cmd = "Update Students Set Name = 'Dayanat' Where Id=12";
        SqlCommand comand = new SqlCommand(cmd, sqlConnection);
        int check = comand.ExecuteNonQuery();
        if (check > 0)
        {
            Console.WriteLine("The student updated");
        }
        else
        {
            Console.WriteLine("Error");
        }
        sqlConnection.Close();

    }

  
    public static void GetAllData()
    {
        sqlConnection.Open();
        string cmd = "Select * From Students";
        SqlCommand comand = new SqlCommand(cmd, sqlConnection);
        SqlDataReader sqlDataReader = comand.ExecuteReader();
        if (sqlDataReader.HasRows) 
        {
            while (sqlDataReader.Read()) 
            {
                Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]} - {sqlDataReader[2]} -{sqlDataReader[3]} - {sqlDataReader[4]} - {sqlDataReader[5]}");            
            }
        }
        sqlConnection.Close();
    }
    //public static void GetData(int id)
    //{
    //    sqlConnection.Open();
    //    string cmd = "Select * From Students Where Id=@Id";
    //    SqlCommand comand = new SqlCommand(cmd, sqlConnection);
    //    comand.Parameters.AddWithValue("@Id", id);
    //    SqlDataReader sqlDataReader = comand.ExecuteReader();
    //    if (sqlDataReader.HasRows)
    //    {
    //        while (sqlDataReader.Read())
    //        {
    //            Console.WriteLine($"{sqlDataReader["Id"]} - {sqlDataReader["Name"]} - {sqlDataReader["Surname"]} - {sqlDataReader["Age"]} - {sqlDataReader["Grant"]} - {sqlDataReader["GroupId"]}");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("No student found with the given Id");
    //    }

    //    sqlConnection.Close();

    //}

    public static Student GetData(int id)
    {
        Student student = null;

        sqlConnection.Open();
        string cmd = "Select * From Students Where Id=@Id";
        SqlCommand command = new SqlCommand(cmd, sqlConnection);
        command.Parameters.AddWithValue("@Id", id);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                student = new Student
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Age = (int)reader["Age"],
                    Grant = (decimal)reader["Grant"],
                    GroupId = (int)reader["GroupId"]
                };
            }
        }

        sqlConnection.Close();

        return student;
    }



}
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public decimal Grant { get; set; }

    public int GroupId { get; set; }
}