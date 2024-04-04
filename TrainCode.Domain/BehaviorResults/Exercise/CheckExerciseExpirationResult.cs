namespace TrainCode.Domain.BehaviorResults.Exercise
{
    public class CheckExerciseExpirationResult
    {
        public bool IsSuccess { get; set; }

        public bool IsUpdated { get; set; }

        public CheckExerciseExpirationResult(bool isSuccess, bool isUpdated)
        {
            IsSuccess = isSuccess;
            IsUpdated = isUpdated;
        }
    }
}
