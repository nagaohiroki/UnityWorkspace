using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : NetworkBehaviour
{
	[SerializeField]
	PlayerInput mController;
	Vector3 mVec;
	[ServerRpc]
	void MoveServerRpc(Vector3 Val)
	{
		mVec = Val;
	}
	public override void OnNetworkSpawn()
	{
		var owner = IsOwner ? ":Owner" : "";
		var host = IsHost ? ":Host" : "";
		var newName = $"Player:{OwnerClientId}{owner}{host}";
		name = newName;
		if(IsOwner)
		{
			mController = FindObjectOfType<PlayerInput>();
		}
		Debug.Log($"login:{newName}");
	}
	void Move()
	{
		transform.position += mVec;
	}
	void Update()
	{
		if(IsOwner)
		{
			var v = mController.actions["Move"].ReadValue<Vector2>() * Time.deltaTime * 10.0f;
			MoveServerRpc(new Vector3(v.x, 0.0f, v.y));
		}
		if(IsServer)
		{
			Move();
		}
	}
}
