namespace TrainCode.App.DTOs
{
    using TrainCode.Domain.Entities;

    public class ClientInfoDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ClientInfoDto(Client client)
        {
            Id = client.Id;
            FirstName = client.FirstName;
            LastName = client.LastName;
        }
    }
}
