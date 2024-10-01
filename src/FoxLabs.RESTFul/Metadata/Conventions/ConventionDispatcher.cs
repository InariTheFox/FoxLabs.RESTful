using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public class ConventionDispatcher
    {
        private readonly ConventionSet _conventionSet;

        public ConventionDispatcher(ConventionSet conventionSet)
        {
            _conventionSet = conventionSet;
        }

        public ModelBuilder? OnModelInitialized(ModelBuilder builder)
        {
            foreach (var convention in _conventionSet.ModelInitializedConventions)
            {
                
            }
            
            return builder;
        }

        public TypeBuilder? OnTypeAdded(TypeBuilder builder)
        {
            foreach (var convention in _conventionSet.TypeAddedConventions)
            {
                convention.Apply(builder);
            }
            
            return builder;
        }
    }
}