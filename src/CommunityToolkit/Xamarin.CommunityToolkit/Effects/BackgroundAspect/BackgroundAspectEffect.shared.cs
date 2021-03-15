using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Effects
{
	public class BackgroundAspectEffect : RoutingEffect
	{
		public Aspect Aspect { get; set; } = Aspect.Fill;

		public BackgroundAspectEffect()
			: base(EffectIds.BackgroundAspect)
		{
		}
	}
}
