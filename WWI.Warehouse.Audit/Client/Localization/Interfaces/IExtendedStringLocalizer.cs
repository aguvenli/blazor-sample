using Microsoft.Extensions.Localization;
using System.Globalization;

namespace WWI.Warehouse.Audit.Client.Localization.Interfaces
{
    public interface IExtendedStringLocalizer : IStringLocalizer
    {
        Task LoadCatalogs(HttpClient client, List<string> languageList);
    }
}
