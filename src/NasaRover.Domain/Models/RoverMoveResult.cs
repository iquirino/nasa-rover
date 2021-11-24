namespace NasaRover.Domain.Models
{
    public class RoverMoveResult
    {
        public RoverModel Rover { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public RoverMoveResult(RoverModel rover, bool isSuccess, string message)
        {
            Rover = rover;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}