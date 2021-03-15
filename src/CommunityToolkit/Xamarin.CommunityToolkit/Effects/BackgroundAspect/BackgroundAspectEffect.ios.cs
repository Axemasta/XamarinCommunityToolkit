using System;
using UIKit;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Effects = Xamarin.CommunityToolkit.iOS.Effects;

[assembly: ExportEffect(typeof(Effects.BackgroundAspectEffect), nameof(BackgroundAspectEffect))]

namespace Xamarin.CommunityToolkit.iOS.Effects
{
	public class BackgroundAspectEffect : PlatformEffect
    {
        CommunityToolkit.Effects.BackgroundAspectEffect FormsEffect
        {
            get
            {
                return Element.GetFormsEffect<CommunityToolkit.Effects.BackgroundAspectEffect>();
            }
        }

        UIImageView imageView;

        protected override void OnAttached()
        {
            if (!CanApplyEffect())
                return;

            var page = Element as ContentPage;

            var image = GetBackgroundImage(page);

            if (image == null)
                return;

            Container.BackgroundColor = page.BackgroundColor.ToUIColor();

            imageView = CreateImageView(image, FormsEffect.Aspect);

            Container.InsertSubview(imageView, 0);

            ApplyConstraints(imageView, Container);
        }

        protected override void OnDetached()
        {
            // TODO

            if (imageView == null)
                return;

            imageView.RemoveFromSuperview();
        }

        bool CanApplyEffect()
        {
            var page = Element as ContentPage;

            if (page == null)
                return false;

            // Check the page has a background image source
            if (page.BackgroundImageSource == null || page.BackgroundImageSource.IsEmpty)
                return false;

            // Need to access later
            if (Container == null)
                return false;

            return true;
        }

#pragma warning disable CS0618 //BackgroundImage is obsolete
        UIImage GetBackgroundImage(ContentPage page)
        {
            if (page == null)
                throw new ArgumentException("page must not be null", nameof(page));

            var size = Container.Frame.Size;

            if (size == null)
                return null;

            // use image loader source handler instead?
            // https://forums.xamarin.com/discussion/42363/custom-renderer-on-ios-imagesource-to-uiimage

            UIGraphics.BeginImageContext(size);
            var i = UIImage.FromBundle(page.BackgroundImage);

            return i;
        }
#pragma warning restore CS0618

        UIImageView CreateImageView(UIImage uIImage, Aspect aspect)
        {
            var imageView = new UIImageView();
            imageView.Image = uIImage;
            imageView.ContentMode = GetContentMode(aspect);
            imageView.TranslatesAutoresizingMaskIntoConstraints = false;

            return imageView;
        }

        void ApplyConstraints(UIView child, UIView parent)
        {
            var constraints = new NSLayoutConstraint[]
            {
                child.TopAnchor.ConstraintEqualTo(parent.TopAnchor),
                child.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor),
                child.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor),
                child.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor)
            };

            NSLayoutConstraint.ActivateConstraints(constraints);
        }

        UIViewContentMode GetContentMode(Aspect aspect)
        {
            switch (aspect)
            {
                default:
                case Aspect.Fill:
                    return UIViewContentMode.ScaleToFill;

                case Aspect.AspectFill:
                    return UIViewContentMode.ScaleAspectFill;

                case Aspect.AspectFit:
                    return UIViewContentMode.ScaleAspectFit;
            }
        }
    }
}
