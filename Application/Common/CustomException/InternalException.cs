using Microsoft.Extensions.Logging;

namespace Application.Common.CustomException;

public class InternalException : Exception
{
   public int StatusCode { get; set; }
   readonly ILogger logger;

   readonly static string ExceptionMessage
        = Application.Common.Resource.Message.InternalError;

    public InternalException() : base(ExceptionMessage)
    {
        StatusCode = 500;
    }

    public InternalException(ILogger logger) : base(ExceptionMessage)
    {
        StatusCode = 500;
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        logger.LogError(ExceptionMessage);
    }

    public InternalException( string message, int StatusCode) : base(message)
    {

        this.StatusCode = StatusCode;
    }
    public InternalException(ILogger logger, string message, int StatusCode) : base(message)
    {
     
        this.StatusCode = StatusCode;
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        logger.LogError(message);
    }
    public InternalException(ILogger logger, Exception exception) : base(ExceptionMessage, exception)
    {
        StatusCode = 500;
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        logger.LogError(exception,exception.Message);
    }
}
