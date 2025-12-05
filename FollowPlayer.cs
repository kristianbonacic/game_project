using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform player;

	private void LateUpdate()
	{
		base.transform.position = new Vector3(player.position.x, player.position.y, base.transform.position.z);
	}
}
