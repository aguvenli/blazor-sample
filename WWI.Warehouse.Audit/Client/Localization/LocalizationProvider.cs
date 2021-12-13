using Karambolo.PO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System.Globalization;
using WWI.Warehouse.Audit.Client.Localization.Interfaces;

namespace WWI.Warehouse.Audit.Client.Localization
{
    public class LocalizationProvider : IExtendedStringLocalizer
    {
        private static readonly POParserSettings s_parserSettings = new POParserSettings
        {
            SkipComments = true,
            SkipInfoHeaders = true,
            StringDecodingOptions = new POStringDecodingOptions { KeepKeyStringsPlatformIndependent = true }
        };


        private IReadOnlyDictionary<string, POCatalog> _catalogs;

        public LocalizationProvider()
        {
        }


        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var key = new POKey(name);
                var translation = _catalogs[CultureInfo.CurrentCulture.Name].GetTranslation(key);
                return new LocalizedString(name, translation ?? name);
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                var key = new POKey(name);
                var tt = CultureInfo.CurrentCulture.Name;
                var translation = _catalogs[CultureInfo.CurrentCulture.Name].GetTranslation(key);
                return new LocalizedString(name, translation ?? name);
            }
        }

        public async Task LoadCatalogs(HttpClient client, List<string> languageList)
        {

            var dictionary = new Dictionary<string, POCatalog>();

            foreach (var language in languageList)
            {
                var fileContent = await client.GetStreamAsync($"translations/{language}.po");

                if (_catalogs == null || false == _catalogs.ContainsKey(language))
                {
                    var parseResult = new POParser(s_parserSettings).Parse(fileContent);
                    dictionary.Add(language, parseResult.Catalog);
                }
            }

            _catalogs = dictionary;
          
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

    }
}
