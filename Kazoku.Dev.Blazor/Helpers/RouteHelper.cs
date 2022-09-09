using System.Data.Common;
using System.Reflection.Metadata;

namespace Kazoku.Dev.Blazor.Helpers
{
    public static class RouteHelper
    {
        /// <summary>
        /// Helps user build routes by putting paramaters in the right order
        /// </summary>
        /// <param name="route"></param>
        /// <param name="apiVersion"></param>
        /// <param name="parameter"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string BuildRoute(string route, string apiVersion, string? parameter = null, string? query = null)
        {
            route = RemoveLeadingAndTrailingSlash(route);
            apiVersion = $"api-version={apiVersion}";

            if (parameter is not null)
            {
                parameter = RemoveLeadingAndTrailingSlash(parameter);
            }

            string completeUri = $"{route}/{parameter}?{apiVersion}{query}";

            return completeUri;
        }
        public static string BuildRouteWithQuery(string route, string apiVersion, string query, string? parameter = null)
        {
            route = RemoveLeadingAndTrailingSlash(route);
            apiVersion = $"?api-version={apiVersion}";

            string completeUri = $"{route}/{parameter}{apiVersion}{query}";

            return completeUri;
        }

        public static string BuildRouteWithParameter(string route, string apiVersion, string parameter, string? query = null)
        {

            route = RemoveLeadingAndTrailingSlash(route);
            parameter = RemoveLeadingAndTrailingSlash(parameter);
            apiVersion = $"?api-version={apiVersion}";

            string completeUri = $"{route}/{parameter}{apiVersion}{query}";

            return completeUri;
        }

        private static string RemoveLeadingAndTrailingSlash(string data)
        {
            string result = data;
            char firstChar = data[0];
            char lastChar = data[^1];

            if (lastChar == '/')
            {
                result = data.Remove(data[^1]);
            }

            if (firstChar == '/')
            {
                result = data.Remove(1);
            }

            return result;
        }
    }
}
