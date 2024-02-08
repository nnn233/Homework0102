namespace ContactLibrary
{
    public class Contact
    {
        public Contact() { }
        public Contact(int id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is Contact)
            {
                var another = obj as Contact;
                if (Id == another.Id && Name == another.Name && Number == another.Number)
                    return true;
                else return false;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            int result = Id.GetHashCode();
            result = 31 * result + Name.GetHashCode();
            result = 31 * result + Number.GetHashCode();
            return result;
        }
    }
}
