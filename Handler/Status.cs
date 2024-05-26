using System.ComponentModel;
using AspBoot.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace AspBoot.Handler;

[SwaggerSchema(Title = "Статус", Description = "Информация об ошибке или другая причина отсутствия успешного ответа")]
public class Status<TEnum> where TEnum : Enum
{
    [SwaggerSchema(Title = "Вид статуса", Nullable = false)]
    public string Register { get; }

    [SwaggerSchema(Title = "Код статуса", Nullable = false)]
    public TEnum Code { get; }

    [SwaggerSchema(Title = "Описание статуса", Nullable = false)]
    public string Description { get; }

    public Status(TEnum code)
    {
        Register = typeof(TEnum).Name;
        Code = code;
        var attributes = EnumUtils.GetAttribute<TEnum, DescriptionAttribute>(code);
        Description = attributes is { Length: > 0 } ? attributes[0].Description : "";
    }
}
