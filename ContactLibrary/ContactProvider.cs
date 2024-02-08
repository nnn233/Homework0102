using Npgsql;
using System.Collections.Generic;

namespace ContactLibrary
{
    public class ContactProvider
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
            "Username=postgres;" +
            "Password=25481;" +
            "Database=Contacts";
        private readonly NpgsqlConnection connection;
        public ContactProvider()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }
        public List<Contact> GetContactsByInitialLetters(string letters)
        {
            string commandText = $"SELECT * FROM contact WHERE lower(name) LIKE '{letters.ToLower()}%'";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            var list = new List<Contact>();
            while (reader.Read())
            {
                var contact = new Contact()
                {
                    Id = (int)reader.GetValue(0),
                    Name = (string)reader.GetValue(1),
                    Number = (string)reader.GetValue(2)
                };
                list.Add(contact);
            }
            reader.Close();
            return list;
        }

        public void Add(string name, string number)
        {
            if (GetContactByName(name) != null)
                return;
            string commandText = "INSERT INTO contact (id, name, number) VALUES (@id, @name, @number)";
            var id = GetMaxId() + 1;

            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("number", number);
            cmd.ExecuteNonQuery();
        }

        public void Update(Contact contact)
        {
            var commandText = "UPDATE contact SET id = @id, name = @name, number = @number WHERE id = @id";

            var cmd = new NpgsqlCommand(commandText, connection);
            cmd.Parameters.AddWithValue("id", contact.Id);
            cmd.Parameters.AddWithValue("name", contact.Name);
            cmd.Parameters.AddWithValue("number", contact.Number);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string commandText = $"DELETE FROM contact WHERE id = {id}";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            cmd.ExecuteNonQuery();
        }

        public void Clear()
        {
            string commandText = $"DELETE FROM contact";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            cmd.ExecuteNonQuery();
        }

        public List<Contact> GetContacts()
        {
            string commandText = $"SELECT * FROM contact";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            var list = new List<Contact>();
            while (reader.Read())
            {
                var contact = new Contact()
                {
                    Id = (int)reader.GetValue(0),
                    Name = (string)reader.GetValue(1),
                    Number = (string)reader.GetValue(2)
                };
                list.Add(contact);
            }
            reader.Close();
            return list;
        }

        public Contact GetContactByName(string name)
        {
            string commandText = $"SELECT * FROM contact WHERE name= '{name}'";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            Contact result = null;
            while (reader.Read())
            {
                result = new Contact()
                {
                    Id = (int)reader.GetValue(0),
                    Name = (string)reader.GetValue(1),
                    Number = (string)reader.GetValue(2)

                };
            }
            reader.Close();
            return result;
        }


        private int GetMaxId()
        {
            string commandText = $"SELECT * FROM contact ORDER BY id";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var reader = cmd.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = (int)reader.GetValue(0);
            }
            reader.Close();
            return id;
        }
    }
}
