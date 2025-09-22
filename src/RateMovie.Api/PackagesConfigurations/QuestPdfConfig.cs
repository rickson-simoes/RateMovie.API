using QuestPDF.Infrastructure;
namespace RateMovie.Api.PackagesConfigurations
{
    public static class QuestPdfConfig
    {
        public static void QuestPdfSettings()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            QuestPDF.Settings.UseEnvironmentFonts = false;
        }
    }
}
