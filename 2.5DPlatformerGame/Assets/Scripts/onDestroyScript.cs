using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onDestroyScript : MonoBehaviour
{
    public NewBehaviourScript nbs;
    // Start is called before the first frame update
    void Start()
    {
        nbs = FindObjectOfType<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDestroy()
    {
        if (nbs.lives == 0)
        {
            Destroy(nbs);
            SceneManager.LoadScene("GameOver");
        }
        else if (nbs.lives > 0) {
            nbs.lives--;

        }
    }
}
