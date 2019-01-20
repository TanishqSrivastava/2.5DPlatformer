using UnityEngine;
using UnityEngine.SceneManagement;


public class endgame : MonoBehaviour {

    bool gameHasEnded = false;

	public void EndGame () {

        if (gameHasEnded == false)
        {
            bool gameHasEnded = true;
            Debug.Log("GAME OVER");
            ;
        }
	}
    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
