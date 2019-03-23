using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    public float lives;
    public static GameManager Instance {
        get {
            if (instance = null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;


        }

    }

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
