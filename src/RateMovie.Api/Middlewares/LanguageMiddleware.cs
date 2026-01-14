using System.Globalization;

namespace RateMovie.Api.Middlewares
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var cultureInfoLanguage = new CultureInfo("en");
            var headerLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();            

            if (!string.IsNullOrWhiteSpace(headerLanguage) &&
                SupportedLanguages().Contains(headerLanguage, StringComparer.OrdinalIgnoreCase))
            {
                cultureInfoLanguage = new CultureInfo(headerLanguage);
            }
            
            CultureInfo.CurrentCulture = cultureInfoLanguage;            
            CultureInfo.CurrentUICulture = cultureInfoLanguage;

            await _next(context);
        }

        /// <summary>
        /// Determines the language based on the available resource file languages.
        /// </summary>
        /// <returns>List of language culture codes supported by this application.</returns>
        private List<string> SupportedLanguages()
        {            
            return new List<string>
            {
                "pt-BR"
            };
        }
    }
}
