﻿namespace RESTAPI.Services.Exceptions
{
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException(string s)
            : base(s)
        {
        }
    }
}
