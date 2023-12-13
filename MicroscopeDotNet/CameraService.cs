using MMALSharp;
using MMALSharp.Common.Utility;
using MMALSharp.Handlers;
using MicroscopeDotNet.Interfaces;

// Add any other missing using directives here
namespace MicroscopeDotNet
{
	public class CameraService : ICameraService
	{
		private readonly MMALCamera _camera;

		public CameraService()
		{
			_camera = MMALCamera.Instance;
		}

		public async Task<byte[]> CaptureVideoAsync()
		{
			MMALCameraConfig.VideoResolution = new Resolution(1920, 1080);

            using var vidCaptureHandler = new VideoStreamCaptureHandler("/home/pi/videos/", "h264");
            await _camera.TakeVideo(vidCaptureHandler, CancellationToken.None);
            var memoryStream = new MemoryStream();
            await vidCaptureHandler.CurrentStream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
	}
}