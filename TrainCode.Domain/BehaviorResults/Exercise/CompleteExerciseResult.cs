namespace TrainCode.Domain.BehaviorResults.Exercise
{
    public class CompleteExerciseResult
    {
        public bool IsSuccess { get; set; }

        public bool IsUpdated { get; set; }

        public string? Message { get; set; }

        public CompleteExerciseResult(bool isSuccess, bool isUpdated, string message)
        {
            IsSuccess = isSuccess;
            IsUpdated = isUpdated;
            Message = message;
        }

        public CompleteExerciseResult(bool isSuccess, bool isUpdated)
        {
            IsSuccess = isSuccess;
            IsUpdated = isUpdated;
        }
    }
}
