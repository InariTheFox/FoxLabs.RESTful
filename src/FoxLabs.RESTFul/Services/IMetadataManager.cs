using FoxLabs.RESTFul.Metadata;

namespace FoxLabs.RESTFul.Services
{
    public interface IMetadataManager
    {
        ITypeMetadata GetMetadata(Type type);

        ITypeMetadata GetMetadata(string name);
    }
}