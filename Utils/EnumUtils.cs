namespace AspBoot.Utils;

public static class EnumUtils
{
    public static TAttr[]? GetAttribute<TEnum, TAttr>(TEnum enm)
    {
        return enm
            ?.GetType()
            .GetField(enm.ToString() ?? String.Empty)
            ?.GetCustomAttributes(typeof(TAttr), false) as TAttr[];
    }
}
