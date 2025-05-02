﻿using Microsoft.Extensions.Logging;

namespace Application.Common.CustomException;

public class InternalException : Exception
{
   public int StatusCode { get; set; }
  

   readonly static string ExceptionMessage
        = Application.Common.Resource.Message.InternalError;

    public InternalException() : base(ExceptionMessage)
    {
        StatusCode = 500;
    }


    public InternalException( string message, int StatusCode) : base(message)
    {

        this.StatusCode = StatusCode;
    }
  
    public InternalException(string message) : base(message)
    {

        this.StatusCode = StatusCode;
    }
  
}
