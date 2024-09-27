using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTFul.Metadata.Builders
{
    public class TypeBuilder : TypeBaseBuilder
    {
        public TypeBuilder(ITypeMetadata metadata, ModelBuilder modelBuilder)
            : base(metadata, modelBuilder)
        {
        }

        public virtual ITypeMetadata Metadata
            => base.Metadata;
    }
}