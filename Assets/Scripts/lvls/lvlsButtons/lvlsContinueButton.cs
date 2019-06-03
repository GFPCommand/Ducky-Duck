using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlsContinueButton : MonoBehaviour
{
    private int transition;

	public AudioClip click;

	private void OnMouseDown () {

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        transition = PlayerPrefs.GetInt("lvlsDiff");

    }

    private void OnMouseUp () {

        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        SceneManager.LoadScene(2);

        PlayerPrefs.SetInt("lvlsDiff", ++transition);
	}

	IEnumerator Click () {

		AudioSource.PlayClipAtPoint(click, transform.position);

		yield return new WaitForSeconds(0.3f);

	}
}
