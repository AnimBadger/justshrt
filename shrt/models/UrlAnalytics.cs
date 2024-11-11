namespace shrt.models;

public class UrlAnalytics
{
    public int AnalyticsId { get; set; }
    public int UrlId { get; set; }
    public DateTime LastAccess { get; set; }
    public string UserAgent { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
}
