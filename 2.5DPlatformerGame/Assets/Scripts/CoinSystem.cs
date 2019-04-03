using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public float coins;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") {
            Destroy(other.gameObject);
            coins++;

        }
    }
}
