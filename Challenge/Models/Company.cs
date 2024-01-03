namespace Challenge.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}