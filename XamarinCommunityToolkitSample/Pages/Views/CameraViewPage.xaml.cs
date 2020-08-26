using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Xamarin.CommunityToolkit.Sample.Pages.Views
{
	public partial class CameraViewPage : BasePage
	{
		public CameraViewPage()
		{
			InitializeComponent();
			cameraView.MediaCaptured += (_, e) =>
			{
				switch (cameraView.CaptureOptions)
				{
					default:
					case CameraCaptureOptions.Default:
					case CameraCaptureOptions.Photo:
						testImage.IsVisible = true;
						testImage.Source = e.Image;
						buttonShot.Text = "Shot";
						break;
						// See how to add media element
					case CameraCaptureOptions.Video:
						testImage.IsVisible = false;
						//testMediaElement.IsVisible = true;
						//testMediaElement.Source = e.Video;
						buttonShot.Text = "Start record";
						break;
				}
			};
		}

		void shot_Clicked(object sender, EventArgs e)
		{
			cameraView.Shutter();
			buttonShot.Text = cameraView.CaptureOptions != CameraCaptureOptions.Video ? "Shot" : "Stop record";
		}

		void zoomSlider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			cameraView.Zoom = (float)e.NewValue;
		}

		void isPhoto_Toggled(object sender, ToggledEventArgs e)
		{
			cameraView.CaptureOptions = e.Value ? CameraCaptureOptions.Video : CameraCaptureOptions.Photo;

			buttonShot.Text = cameraView.CaptureOptions != CameraCaptureOptions.Video ? "Shot" : "Stop record";
		}

		void flash_Toggled(object sender, ToggledEventArgs e)
		{
			cameraView.FlashMode = e.Value ? CameraFlashMode.On : CameraFlashMode.Off;
		}

		void mirro_Toggled(object sender, ToggledEventArgs e)
		{
			cameraView.On<Android>().SetMirrorFrontPreview(e.Value);
		}
	}
}
