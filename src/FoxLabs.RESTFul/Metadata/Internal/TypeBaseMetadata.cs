namespace FoxLabs.RESTFul.Metadata.Internal
{
    public abstract class TypeBaseMetadata
    {
        public TypeBaseMetadata(string name, Model model)
        {
            Model = model;
        }
        
        public TypeBaseMetadata(Type type, Model model)
        {
            Model = model;
        }
        
        public Type ClrType { get; }

        public Model Model { get; }
    }
}