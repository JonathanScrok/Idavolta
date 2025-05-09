using System.Configuration;
using Newtonsoft.Json.Linq;

public class ConfigHelper
{
    private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "appsettings.json");

    public static List<string> ObterListaCaronas()
    {
        var json = File.ReadAllText(configPath);
        var obj = JObject.Parse(json);
        var caronasStr = obj["AppSettings"]?["ListaCaronas"]?.ToString() ?? "";
        return caronasStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();
    }

    public static void SalvarListaCaronas(List<string> caronas)
    {
        var json = File.ReadAllText(configPath);
        var obj = JObject.Parse(json);

        obj["AppSettings"]["ListaCaronas"] = string.Join(",", caronas);

        File.WriteAllText(configPath, obj.ToString());
    }
}
