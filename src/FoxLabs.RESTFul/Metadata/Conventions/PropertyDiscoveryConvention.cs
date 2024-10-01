using System.Reflection;
using FoxLabs.RESTFul.Metadata.Builders;
using FoxLabs.RESTFul.Metadata.Internal;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public class PropertyDiscoveryConvention : ITypeAddedConvention
    {
        public void Apply(TypeBuilder builder)
        {
            var members = builder.Metadata.ClrType.GetMembers(BindingFlags.Public | 
                                                              BindingFlags.Instance |
                                                              BindingFlags.DeclaredOnly)
                                 .Where(m => m.MemberType == MemberTypes.Property || m.MemberType == MemberTypes.Field);

            foreach (var member in members)
            {
                builder.Metadata.AddProperty(member.Name, member.GetMemberType(), member);
            }
        }
    }
}