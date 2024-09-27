namespace FoxLabs.RESTFul.Metadata
{
    public interface IModel
    {
        ITypeMetadata? FindType(string name);
        
        ITypeMetadata? FindType(Type type);

        IEnumerable<ITypeMetadata> GetTypes();
    }
}