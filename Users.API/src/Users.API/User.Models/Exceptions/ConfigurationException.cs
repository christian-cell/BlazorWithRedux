namespace User.Models.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string entity):base($"{entity} is not configured"){}    
    }
};