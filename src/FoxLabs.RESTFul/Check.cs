namespace FoxLabs.RESTFul
{
    public class Check
    {
        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", parameterName);
            }

            return value;
        }
        
        public static T NotNull<T>(T value, string parameterName)
        {
            if (null == value)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}