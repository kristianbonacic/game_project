using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public Transform player;

	public float speed = 3f;

	public GameObject deathParticles;

	private void Update()
	{
		FollowPlayer();
	}

	private void FollowPlayer()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, player.position, speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			Object.Instantiate(deathParticles, collision.transform.position, Quaternion.identity);
			Player component = collision.gameObject.GetComponent<Player>();
			component.TakeDamage(100);
			if (component.PlayerHealth <= 0)
			{
				component.audioSource.Stop();
			}
		}
	}
}
