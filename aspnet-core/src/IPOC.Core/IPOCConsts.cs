using IPOC.Debugging;

namespace IPOC
{
    public class IPOCConsts
    {
        public const string LocalizationSourceName = "IPOC";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const string Sale = "SALE";

        public const string Payment = "PAYMENT";

        public const string Refund = "REFUND";

        public const string OpeningBalance = "OPENING";

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e0a141c6f83b4188ba12981f92e3e5c7";
    }
}
