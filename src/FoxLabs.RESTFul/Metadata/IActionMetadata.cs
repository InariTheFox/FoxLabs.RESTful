using FoxLabs.RESTFul.Adapter;

namespace FoxLabs.RESTFul.Metadata
{
    public interface IActionMetadata : IMemberMetadata
    {
        bool HasReturn { get; }

        bool IsStatic { get; }

        int ParameterCount { get; }

        IActionParameterMetadata[] Parameters { get; }

        IObjectAdapter Execute(IObjectAdapter target, IObjectAdapter[] parameters);
    }
}