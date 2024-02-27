using Newtonsoft.Json;
namespace Student_Information_System.Helpers;
public class FileIO
{
#pragma warning disable
    public static async ValueTask<List<T>> ReadAsync<T>(string path)
    {
        var content = await File.ReadAllTextAsync(path);
        if (string.IsNullOrWhiteSpace(content))
            return [];

        return JsonConvert.DeserializeObject<List<T>>(content);
    }
    public static async ValueTask WriteAsync<T>(string path, List<T> values)
    {
        var json = JsonConvert.SerializeObject(values, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
    }
}
