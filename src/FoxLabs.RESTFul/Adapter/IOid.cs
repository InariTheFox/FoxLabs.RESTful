using FoxLabs.RESTFul.Metadata;

namespace FoxLabs.RESTFul.Adapter
{
    public interface IOid
    {
        bool IsTransient { get; }

        ITypeMetadata Type { get; }
    }
}