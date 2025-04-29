using Microsoft.Extensions.Localization;
using Vandic.CrossCutting.Resources.Resources;

namespace Vandic.CrossCutting.Resources.LocationServices
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<Messages> _localizer;

        public LocalizationService(IStringLocalizer<Messages> localizer) // Alterado para 'internal'
        {
            _localizer = localizer;
        }

        public string GetString(string key)
        {
            return _localizer[key];
        }
    }
}
