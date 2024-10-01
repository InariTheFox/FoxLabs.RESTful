using System.Reflection;

namespace FoxLabs.RESTFul
{
    public static class MemberInfoExtensions
    {
        public static Type GetMemberType(this MemberInfo memberInfo)
            => memberInfo switch
            {
                FieldInfo field => field.FieldType,
                PropertyInfo property => property.PropertyType,
                MethodInfo method => method.ReturnType,
                _ => null
            };
    }
}