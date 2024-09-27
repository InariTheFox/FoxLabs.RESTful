using System.Collections.Concurrent;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class Model
    {
        private readonly ConcurrentDictionary<string, TypeMetadata> _types = new();

        public Model()
        {
            Builder = new(this);
        }

        public ModelBuilder Builder { get; }

        public virtual TypeMetadata? AddType(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var metadata = new TypeMetadata(name, this);

            return AddType(metadata);
        }

        public virtual TypeMetadata? AddType(Type type)
        {
            Check.NotNull(type, nameof(type));

            var metadata = new TypeMetadata(type, this);

            return AddType(metadata);
        }

        private TypeMetadata? AddType(TypeMetadata metadata)
        {
            var typeName = metadata.FullName;
            
            _types.TryAdd(typeName, metadata);
            
            return metadata;
        }
    }
}