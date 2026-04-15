namespace BO;

    [Serializable]
    //ישות כבר קיימת
    public class BlExistsException : Exception
    {
        public BlExistsException(string message) : base(message) { }
        public BlExistsException(string message, Exception innerException)
                  : base(message, innerException) { }

    }


    [Serializable]
    //ישות לא קיימת
    public class BlNotExistsException : Exception
    {
        public BlNotExistsException(string message) : base(message) { }
        public BlNotExistsException(string message, Exception innerException)
                 : base(message, innerException) { }

    }
    [Serializable]//קלט לא תקין
    public class BlNotValidInputException : Exception
    {
        public BlNotValidInputException(string? message) : base(message) { }
        public BlNotValidInputException(string message, Exception innerException)
                    : base(message, innerException) { }
    }

    [Serializable]
    public class BLOperationFailedException : Exception // פעולה נכשלה מסיבה פנימית
    {
        public BLOperationFailedException(string? message) : base(message) { }
        public BLOperationFailedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
//מחיקה אסורה
[Serializable]
public class BlDeletionForbiddenException : Exception
{
    public BlDeletionForbiddenException(string message) : base(message) { }
    public BlDeletionForbiddenException(string message, Exception innerException)
             : base(message, innerException) { }
}