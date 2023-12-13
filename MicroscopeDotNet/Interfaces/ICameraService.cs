namespace MicroscopeDotNet.Interfaces
{
	public interface ICameraService
	{
		public Task<byte[]> CaptureVideoAsync();
	}
}