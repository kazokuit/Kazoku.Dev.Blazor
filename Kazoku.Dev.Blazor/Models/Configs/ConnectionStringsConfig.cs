namespace Kazoku.Dev.Blazor.Models.Configs
{
    /// <summary>
    /// Settings class to control database conncetion in the API
    /// </summary>
    public class ConnectionStringsConfig
    {
        /// <summary>
        /// Key to the connection strings in the settings file
        /// </summary>
        public const string Key = "ConnectionStrings";

        /// <summary>
        /// Api url
        /// </summary>
        public string Api { get; set; } = String.Empty;
    }
}
