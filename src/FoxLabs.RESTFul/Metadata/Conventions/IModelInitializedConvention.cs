using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public interface IModelInitializedConvention
    {
        void Apply(ModelBuilder builder);
    }
}