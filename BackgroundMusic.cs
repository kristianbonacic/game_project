using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	public AudioClip musicClip;

	public AudioSource musicSource;

	private void Start()
	{
		musicSource.clip = musicClip;
		musicSource.loop = true;
		musicSource.Play();
	}
}
