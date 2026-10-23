using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Classwork0309_FormPost.Models
{
    public class PeopleDbManager
    {
        private string _connectionString;

        public PeopleDbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM People";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }

        public void AddPerson(string firstName, string lastName, int age)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO People (firstName, lastName, age)
                                    VALUES (@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@age", age);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}