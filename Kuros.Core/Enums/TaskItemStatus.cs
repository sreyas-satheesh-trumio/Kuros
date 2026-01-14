using System.Text.Json.Serialization;

namespace Kuros.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskItemStatus
{
    BackLog,
    ToDo,
    InDevelopment,
    CodeReview,
    Done
}