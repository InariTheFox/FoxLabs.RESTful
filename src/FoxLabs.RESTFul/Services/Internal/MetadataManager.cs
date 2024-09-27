using FoxLabs.RESTFul.Metadata;

namespace FoxLabs.RESTFul.Services.Internal
{
    internal class MetadataManager : IMetadataManager
    {
        private readonly IModel _model;

        public MetadataManager(IModel model)
        {
            _model = model;
        }

        public ITypeMetadata GetMetadata(Type type)
        {
            throw new NotImplementedException();
        }

        public ITypeMetadata GetMetadata(string name)
        {
            throw new NotImplementedException();
        }
    }
}