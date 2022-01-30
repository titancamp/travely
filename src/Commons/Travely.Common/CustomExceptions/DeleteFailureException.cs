using System;

namespace Travely.Common.CustomExceptions
{
    public class DeleteFailureException : BusinessLayerException
    {
        public DeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}