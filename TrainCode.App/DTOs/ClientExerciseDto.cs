namespace TrainCode.App.DTOs
{
    using TrainCode.Domain.Enums;
    using TrainCode.Domain.Entities;

    public class ClientExerciseDto
    {
        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public ExerciseStatus Status { get; set; }

        public ClientExerciseDto(Exercise exercise)
        {
            Id = exercise.Id;
            DueDate = exercise.DueDate;
            Description = exercise.Description;
            Status = exercise.Status;
        }
    }
}
