using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.CommunityToolkit.Sample.Models;
using Xamarin.CommunityToolkit.Sample.Pages.Effects;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Sample.ViewModels.Effects
{
	public class BackgroundAspectGalleryViewModel : BaseGalleryViewModel
	{
		protected override IEnumerable<SectionModel> CreateItems() => new[]
		{
			new SectionModel(
				typeof(BackgroundAspectEffectPage),
				"Default",
				"Content Page with the default Forms BackgroundImageSource appearance",
				new object[] { null }),

			new SectionModel(
				typeof(BackgroundAspectEffectPage),
				nameof(Aspect.Fill),
				"Content Page with the BackgroundImageSource scaling set to Fill",
				new object[] { Aspect.Fill }),

			new SectionModel(
				typeof(BackgroundAspectEffectPage),
				nameof(Aspect.AspectFill),
				"Content Page with the BackgroundImageSource scaling set to AspectFill",
				new object[] { Aspect.AspectFill }),

			new SectionModel(
				typeof(BackgroundAspectEffectPage),
				nameof(Aspect.AspectFit),
				"Content Page with the BackgroundImageSource scaling set to AspectFit",
				new object[] { Aspect.AspectFit })
		};
	}
}
