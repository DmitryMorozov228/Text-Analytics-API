using System;

namespace Microsoft.ProjectOxford.Text.Test
{
    public class AppSettings
    {
        private static AppSettings _instance;

        public static AppSettings Instance => _instance ?? (_instance = new AppSettings());

        public string ApiKey
        {
            get
            {
                var apiKey = Environment.GetEnvironmentVariable("COG_API_KEY_TEXTANALYTICS");

                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new Exception("Environment variable COG_API_KEY_TEXTANALYTICS not found.");
                }

                return apiKey;
            }
        }
    }
}
