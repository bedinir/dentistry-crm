using System;

namespace Entities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public static string GenerateMessage<T>(object id)
        {
            return $"The {typeof(T).Name} with id: {id} doesn't exist in the database.";
        }
    }
}
