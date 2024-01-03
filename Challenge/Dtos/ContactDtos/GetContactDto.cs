namespace Challenge.Dtos.ContactDtos
{
    public class GetContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public string CityName { get; set; }
        public string CompanyName { get; set; }
    }
}
