namespace TrainCode.Domain.Entities
{
    public class Coach
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Client> Clients { get; set; }
    }
}
