namespace TrainCode.Domain.Entities
{
    using Domain.Enums;
    using Domain.BehaviorResults.Exercise;

    public class Exercise
    {
        public Exercise(
        Guid id,
        Guid coachId,
        DateTime dueDate,
        string description,
        ExerciseStatus status,
        Guid clientId,
        Client client
        )
        {
            Id = id;
            CoachId = coachId;
            DueDate = dueDate;
            Description = description;
            Status = status;
            ClientId = clientId;
            Client = client;
        }

        public Exercise(
        Guid id,
        Guid coachId,
        DateTime dueDate,
        string description,
        ExerciseStatus status,
        Guid clientId
        )
        {
            Id = id;
            CoachId = coachId;
            DueDate = dueDate;
            Description = description;
            Status = status;
            ClientId = clientId;
        }

        public Guid Id { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public ExerciseStatus Status { get; set; }

        public Guid ClientId { get; set; }

        public Guid CoachId { get; set; }

        public Coach Coach { get; set; }
        public Client Client { get; set; }

        public static Exercise Create(
            Guid id,
            Guid coachId,
            DateTime dueDate,
            string description,
            ExerciseStatus status,
            Guid clientId,
            Client? client 
        )
        {
            return new Exercise(id, coachId, dueDate, description, status, clientId, client);
        }

        public CheckExerciseExpirationResult CheckExerciseExpiration()
        {
            if (DueDate < DateTime.Now & Status != ExerciseStatus.Done)
            {
                bool updateStatus = Status == ExerciseStatus.Pending ? true : false;
                if (updateStatus)
                {
                    Status = ExerciseStatus.Missed;
                }
                return new CheckExerciseExpirationResult(false, updateStatus);
            }

            return new CheckExerciseExpirationResult(true, false);
        }

        public CompleteExerciseResult CompleteExercise()
        {
            var expCheck = CheckExerciseExpiration();
            if (expCheck.IsSuccess == false)
            {
                if (expCheck.IsUpdated)
                {
                    return new CompleteExerciseResult(false, true, "Exercise missed");
                }
                return new CompleteExerciseResult(false, false, "Exercise missed");
            }
            Status = ExerciseStatus.Done;
            return new CompleteExerciseResult(true, true);
        }
    }
}
