using UnityEngine;
using Unity.Netcode;
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
}
