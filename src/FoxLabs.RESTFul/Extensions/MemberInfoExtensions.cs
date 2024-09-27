using System.Reflection;

namespace FoxLabs.RESTFul
{
    public static class MemberInfoExtensions
    {
        public static Type GetMemberType(this MemberInfo memberInfo)
            => (memberInfo as PropertyInfo)?.PropertyType ?? ((FieldInfo)memberInfo).FieldType;
    }
}