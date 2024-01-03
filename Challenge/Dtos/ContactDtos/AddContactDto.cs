namespace Challenge.Dtos.ContactDtos
{
    public class AddContactDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public int CityId { get; set; }
        public int CompanyId { get; set; }
    }
}
