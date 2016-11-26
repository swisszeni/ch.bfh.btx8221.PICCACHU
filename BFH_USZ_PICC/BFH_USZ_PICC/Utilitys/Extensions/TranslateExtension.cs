using BFH_USZ_PICC.Interfaces;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BFH_USZ_PICC.Utilitys.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension<string>
    {
        readonly CultureInfo ci;
        const string ResourceId = "BFH_USZ_PICC.Resx.AppResources";

        public TranslateExtension()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
        }

        public string Text { get; set; }

        string IMarkupExtension<string>.ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
                // HACK: returns the key, which gets displayed to the user
                translation = Text;
#endif
            }
            return translation;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            var test = serviceProvider;
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
