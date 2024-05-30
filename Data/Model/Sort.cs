using System.Text.Json.Serialization;

namespace AspBoot.Data.Model;

public static class Sort
{
    public class Order
    {
        public required string Selector { get; init; }
        public Direction Direction { get; init; } = Direction.Asc;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Direction
    {
        Asc, Desc
    }
}
