using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float speed = 10f;

	public float jumpForce = 10f;

	public float groundCheckRadius = 0.2f;

	public Transform groundCheckPoint;

	public LayerMask groundLayer;

	private Rigidbody2D rigidbody2D;

	public int PlayerHealth = 100;

	public AudioClip jumpSound;

	public AudioSource audioSource;

	public Vector3 spawnPoint;

	private int jumpsLeft = 2;

	private float timeSinceLastJump;

	public float jumpCooldown = 0.5f;

	private void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		spawnPoint = base.transform.position;
	}

	private void Update()
	{
		float axis = Input.GetAxis("Horizontal");
		base.transform.position += new Vector3(axis * speed * Time.deltaTime, 0f, 0f);
		timeSinceLastJump += Time.deltaTime;
		if (Input.GetButtonDown("Jump") && IsGrounded() && jumpsLeft > 0 && timeSinceLastJump >= jumpCooldown)
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			audioSource.PlayOneShot(jumpSound);
			jumpsLeft--;
			timeSinceLastJump = 0f;
		}
	}

	private bool IsGrounded()
	{
		if ((bool)Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckRadius, groundLayer))
		{
			jumpsLeft = 2;
			return true;
		}
		return false;
	}

	public void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void TakeDamage(int damage)
	{
		PlayerHealth -= damage;
		if (PlayerHealth <= 0)
		{
			Die();
		}
	}
}
