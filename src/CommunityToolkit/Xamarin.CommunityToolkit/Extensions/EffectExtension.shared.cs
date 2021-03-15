using System;
using System.Linq;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Extensions
{
    public static class EffectExtension
    {
        public static TEffect GetFormsEffect<TEffect>(this Element element) where TEffect : Effect
        {
            if (element == null)
                throw new ArgumentNullException("Forms element must not be null", nameof(element));

            var effect = element.Effects.FirstOrDefault(e => e is TEffect);

            return (TEffect)effect;
        }
    }
}
