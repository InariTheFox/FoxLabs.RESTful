using System.Collections;
using System.Reflection;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public class DefaultTypeAddedConvention : ITypeAddedConvention
    {
        public void Apply(TypeBuilder builder)
        {
            if (builder?.Metadata.ClrType != null)
            {
                builder.Metadata.IsVoid = builder.Metadata.ClrType == typeof(void);

                if (builder.Metadata.IsVoid)
                {
                    // Bail out early if we're void, as there's
                    // nothing more we can be.
                    return;
                }

                builder.Metadata.IsAbstract = builder.Metadata.ClrType.IsAbstract;
                builder.Metadata.IsInterface = builder.Metadata.ClrType.IsInterface;

                builder.Metadata.IsCollection = builder.Metadata.ClrType.IsAssignableTo(typeof(IEnumerable))
                                                || builder.Metadata.ClrType.IsArray;

                builder.Metadata.IsStatic = builder.Metadata.ClrType.IsAbstract
                                            && builder.Metadata.ClrType.IsSealed;
            }
        }
    }
}