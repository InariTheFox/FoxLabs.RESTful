namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public class ConventionSet
    {
        public List<IModelInitializedConvention> ModelInitializedConventions { get; } = [];

        public List<ITypeAddedConvention> TypeAddedConventions { get; } =
        [
            new DefaultTypeAddedConvention(),
            new PropertyDiscoveryConvention(),
            new ActionDiscoveryConvention()
        ];
    }
}