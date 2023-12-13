using MicroscopeDotNet.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MicroscopeDotNet.Hubs;

public class CameraHub(ICameraService cameraService) : Hub
{
	private readonly ICameraService _cameraService = cameraService;

	public async Task SendVideoStream()
	{
		var videoStream = await _cameraService.CaptureVideoAsync();
		await Clients.All.SendAsync("ReceiveVideoStream", videoStream);
	}
}