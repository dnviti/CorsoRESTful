namespace API.Helpers.Utilities
{
    public class UrlHelper
    {
        public string BaseUrlGenerator(HttpContext httpContext)
        {
            return $"{(httpContext.Request.IsHttps ? "https:/" : "http:/")}/{httpContext.Request.Host}";
        }
    }
}
