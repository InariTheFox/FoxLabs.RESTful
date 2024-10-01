using System.Reflection;
using FoxLabs.RESTFul.Metadata.Builders;

namespace FoxLabs.RESTFul.Metadata.Conventions
{
    public class ActionDiscoveryConvention : ITypeAddedConvention
    {
        public void Apply(TypeBuilder builder)
        {
            if (builder.Metadata.ClrType.Namespace.StartsWith("System"))
            {
                return;
            }
            
            var members = builder.Metadata.ClrType.GetMembers(BindingFlags.Public | 
                                                              BindingFlags.Instance |
                                                              BindingFlags.DeclaredOnly)
                                 .Where(m => m.MemberType == MemberTypes.Method)
                                 .Where(m => !((MethodInfo)m).IsSpecialName);

            foreach (var member in members)
            {
                builder.Metadata.AddAction(member.Name, member.GetMemberType(), member);
            }
        }
    }
}