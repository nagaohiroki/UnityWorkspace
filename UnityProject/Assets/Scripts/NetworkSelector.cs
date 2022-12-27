using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
public class NetworkSelector : MonoBehaviour
{
	[SerializeField]
	NetworkManager mManager;
	public void StartHost()
	{
		mManager.StartHost();
		Debug.Log("StartHost");
	}
	public void StartClient()
	{
		mManager.StartClient();
		Debug.Log("StartClient");
	}
	public void StartServer()
	{
		mManager.StartServer();
		Debug.Log("StartServer");
	}
	public void Logout()
	{
		mManager.Shutdown();
		Debug.Log("Logout");
	}
	void StartServerMode()
	{
		mManager.TryGetComponent<UnityTransport>(out var transport);
		transport.ConnectionData.Address = "0.0.0.0";
		transport.ConnectionData.Port = 7777;
		StartServer();
	}
	void Awake()
	{
#if UNITY_SERVER
		StartServerMode();
#endif
	}
}
