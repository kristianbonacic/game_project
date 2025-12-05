using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public void LoadLevel()
	{
		SceneManager.LoadScene("Level1");
	}
}
