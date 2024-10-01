using System.Reflection;
using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTFul.Metadata.Builders
{
    public abstract class TypeBaseBuilder
    {
        public TypeBaseBuilder(TypeMetadata metadata, ModelBuilder modelBuilder)
        {
            Metadata = metadata;
        }

        protected TypeMetadata Metadata { get; }

        public PropertyBuilder Property(Type? propertyType, string propertyName)
            => Property(propertyType, propertyName, memberInfo: null);

        protected PropertyBuilder Property(
            Type? propertyType,
            string propertyName,
            MemberInfo? memberInfo)
        {
            var metadata = Metadata as TypeMetadata;
            var existingProperty = metadata.GetProperty(propertyName);

            if (existingProperty != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                memberInfo ??= metadata.ClrType.GetMember(propertyName)
                                       .FirstOrDefault();

                if (propertyType == null)
                {
                    if (memberInfo == null)
                    {
                        throw new InvalidOperationException(
                            $"The property '{propertyName}' cannot be added to the type '{Metadata.FullName}' because because no property type was specified and is not corresponding CLR property or field.");
                    }

                    propertyType = memberInfo.GetMemberType();
                }
            }

            PropertyBuilder builder = metadata.AddProperty(propertyName, propertyType, memberInfo)!.Builder;

            return builder ?? metadata.GetProperty(propertyName)
                                     ?.Builder;
        }
    }
}