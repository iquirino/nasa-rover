namespace NasaRover.Domain.Models
{
    public class RoverMoveResult
    {
        /// <summary>
        /// The rover with its properties.
        /// </summary>
        public RoverModel Rover { get; set; }
        /// <summary>
        /// The rover was able to move?
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// The message to be displayed.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Initializes RoverMoveResult
        /// </summary>
        public RoverMoveResult(RoverModel rover, bool isSuccess, string message)
        {
            Rover = rover;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}