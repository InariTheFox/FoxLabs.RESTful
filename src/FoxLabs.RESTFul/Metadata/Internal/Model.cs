using System.Collections.Concurrent;
using FoxLabs.RESTFul.Metadata.Builders;
using FoxLabs.RESTFul.Metadata.Conventions;

namespace FoxLabs.RESTFul.Metadata.Internal
{
    public class Model
    {
        private readonly ConcurrentDictionary<Type, string> _clrTypeNameMap = new();
        private readonly ConcurrentDictionary<string, TypeMetadata> _types = new();
        
        private readonly ConventionDispatcher _conventionDispatcher;

        public Model()
        {
            Builder = new(this);
            _conventionDispatcher = new(new ConventionSet());

            _conventionDispatcher.OnModelInitialized(Builder);
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

            if (_types.ContainsKey(typeName))
            {
                throw new InvalidOperationException($"Type '{typeName}' already added.");
            }
            
            _types.TryAdd(typeName, metadata);

            return _conventionDispatcher.OnTypeAdded(metadata.Builder)
                                       ?.Metadata;
        }

        public TypeMetadata? FindType(string name)
            => !string.IsNullOrEmpty(name) && _types.TryGetValue(name, out var metadata) 
                   ? metadata 
                   : null;

        public TypeMetadata? FindType(Type type)
            => FindType(GetFullName(type));
        
        public string GetFullName(Type type)
            => _clrTypeNameMap.GetOrAdd(type, t => t.FullName);
    }
}