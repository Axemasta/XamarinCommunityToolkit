
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Effects
{
	public class BackgroundAspectEffect : RoutingEffect
	{
		public Aspect Aspect { get; set; } = Aspect.Fill;

		public BackgroundAspectEffect()
			: base(EffectIds.BackgroundAspect)
		{
			#region Required work-around to prevent linker from removing the platform-specific implementation 
#if __IOS__
			if (System.DateTime.Now.Ticks < 0)
				_ = new Xamarin.CommunityToolkit.iOS.Effects.BackgroundAspectEffect();
// #elif __ANDROID__
// 			if (System.DateTime.Now.Ticks < 0)
// 				_ = new Xamarin.CommunityToolkit.Android.Effects.BackgroundAspectEffect();
#endif
			#endregion
		}
	}
}
