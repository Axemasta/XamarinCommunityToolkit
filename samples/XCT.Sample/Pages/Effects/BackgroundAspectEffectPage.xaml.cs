using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Sample.Pages.Effects
{
	public partial class BackgroundAspectEffectPage : BasePage
	{
		public BackgroundAspectEffectPage(Aspect? aspect)
		{
			InitializeComponent();

			if (aspect.HasValue)
				SetAspect(aspect.Value);
			else
				SetDefault();
		}

		void SetDefault()
		{
			Title = "Default";
		}

		void SetAspect(Aspect aspect)
		{
			var backgroundAspect = new BackgroundAspectEffect()
			{
				Aspect = aspect
			};

			Effects.Add(backgroundAspect);

			Title = aspect.ToString();
		}
	}
}
