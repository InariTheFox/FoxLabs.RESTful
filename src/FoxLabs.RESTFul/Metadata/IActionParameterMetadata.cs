using FoxLabs.RESTFul.Adapter;

namespace FoxLabs.RESTFul.Metadata
{
    public interface IActionParameterMetadata
    {
        int Index { get; }

        bool IsRequired { get; }

        string Name { get; }

        IObjectAdapter GetDefault(IObjectAdapter target);

        bool IsValid(IObjectAdapter target, IObjectAdapter proposedValue);
    }
}