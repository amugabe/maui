using System;
using System.Maui;
using System.Maui.CustomAttributes;
using System.Maui.Internals;

#if UITEST
using NUnit.Framework;
using System.Maui.Core.UITests;
using System.Threading.Tasks;
#endif

namespace System.Maui.Controls.Issues
{
	[Preserve (AllMembers=true)]
	[Issue (IssueTracker.Github, 1700, "Image fails loading from long URL", PlatformAffected.iOS | PlatformAffected.Android | PlatformAffected.WinPhone)]
	public class Issue1700 : TestContentPage
	{
		const string Success = "Success";

		protected override void Init() 
		{
			var stack = new StackLayout();
			var url = "https://github.com/xamarin/System.Maui/raw/master/System.Maui.ControlGallery.Android/Resources/drawable/Legumes.jpg?a=bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
			var url2 = "https://github.com/xamarin/System.Maui/raw/master/System.Maui.ControlGallery.Android/Resources/drawable/Vegetables.jpg?a=bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbasdasdasdasdasasdasdasdasdasd";
			var img = new Image{  
				Source = new UriImageSource { Uri =  new Uri(url) }
			} ;
			stack.Children.Add(img);
			var img2 = new Image{  
				Source = new UriImageSource { Uri =  new Uri(url2) }
			} ;
			stack.Children.Add(img2);

			var success = new Label { Text = Success };
			stack.Children.Add(success);

			Content = new ScrollView() { Content =  stack };
		}

#if UITEST
		[Test]
		[Category(UITestCategories.Image)]
		public void LongImageURLsShouldNotCrash()
		{
			// Give the images some time to load (or fail)
			Task.Delay(3000).Wait();
			
			// If we can see this label at all, it means we didn't crash and the test is successful
			RunningApp.WaitForElement(Success);
		}
#endif
	}
}


