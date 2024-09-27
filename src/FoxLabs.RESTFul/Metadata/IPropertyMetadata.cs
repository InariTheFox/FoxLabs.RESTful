using FoxLabs.RESTFul.Adapter;

namespace FoxLabs.RESTFul.Metadata
{
    public interface IPropertyMetadata : IMemberMetadata
    {
        bool IsReadOnly { get; }

        IObjectAdapter GetObject(IObjectAdapter target);
    }
}