using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTFul.Metadata.Builders
{
    public class TypeBuilder : TypeBaseBuilder
    {
        public TypeBuilder(TypeMetadata metadata, ModelBuilder modelBuilder)
            : base(metadata, modelBuilder)
        {
        }

        public virtual TypeMetadata Metadata
            => base.Metadata;
    }
}