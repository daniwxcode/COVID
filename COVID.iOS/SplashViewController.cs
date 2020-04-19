using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Airbnb.Lottie;
using Foundation;
using UIKit;

namespace COVID.iOS
{
	public partial class SplashViewController : UIViewController
	{
		public SplashViewController() : base("SplashViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var animationView = LOTAnimationView.AnimationNamed("18066_covid_green");
			this.View.AddSubview(animationView);
			animationView.PlayWithCompletion((animationFinished) =>
			{
				UIApplication.SharedApplication.Delegate.FinishedLaunching(UIApplication.SharedApplication,
																		   new Foundation.NSDictionary());
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}