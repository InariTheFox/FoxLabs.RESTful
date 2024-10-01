using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public interface ITypeAddedConvention
    {
        void Apply(TypeBuilder builder);
    }
}