using System;

namespace InsuranceSales
{
    public static class AppSettings
    {
        public const bool UseMockAuthentication = true;

        public const bool UseMockDataService = true;

        public const bool UseMockServer = true;

        public static Uri BackendUrl => new Uri(UseMockServer ? "https://b5092384-2e15-47e1-b88e-e5eadb9ff896.mock.pstmn.io" : string.Empty);
    }
}
