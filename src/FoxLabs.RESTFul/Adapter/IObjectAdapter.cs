using FoxLabs.RESTFul.Metadata;

namespace FoxLabs.RESTFul.Adapter
{
    public interface IObjectAdapter
    {
        object Object { get; }

        IOid Oid { get; }
        
        ITypeMetadata Type { get; }
    }
}