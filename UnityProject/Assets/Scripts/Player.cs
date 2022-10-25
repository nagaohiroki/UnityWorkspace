using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : NetworkBehaviour
{
	[SerializeField]
	PlayerInput mInput;
	Vector3 mVec;
	[ServerRpc]
	void MoveServerRpc(Vector3 Val)
	{
		mVec = Val;
	}
	void Move()
	{
		transform.position += mVec;
	}
	void Update()
	{
		if (IsOwner)
		{
			var v = mInput.actions["Move"].ReadValue<Vector2>() * Time.deltaTime * 10.0f;
			MoveServerRpc(new Vector3(v.x, 0.0f, v.y));
		}
		if (IsServer)
		{
			Move();
		}
	}
}
