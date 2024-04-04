namespace TrainCode.App.DTOs
{
    public class NewExerciseDto
    {
        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public Guid ClientId { get; set; }

        public NewExerciseDto(DateTime due, string description, Guid clientId)
        {
            DueDate = due;
            Description = description;
            ClientId = clientId;
        }
    }
}
