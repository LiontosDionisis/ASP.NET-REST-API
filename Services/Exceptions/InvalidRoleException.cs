﻿namespace RESTAPI.Services.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException(string? s)
           : base(s)
        {
        }
    }
}
