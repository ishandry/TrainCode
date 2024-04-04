namespace TrainCode.App.DTOs
{
    using TrainCode.Domain.Enums;
    using TrainCode.Domain.Entities;

    public class CoachExerciseDto
    {
        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public ExerciseStatus Status { get; set; }

        public ClientInfoDto Client { get; set; }

        public CoachExerciseDto(Exercise exercise)
        {
            Id = exercise.Id;
            DueDate = exercise.DueDate;
            Description = exercise.Description;
            Status = exercise.Status;
            Client = new ClientInfoDto(exercise.Client);
        }
    }
}
