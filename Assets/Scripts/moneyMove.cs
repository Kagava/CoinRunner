using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(25 * Time.deltaTime, 25 * Time.deltaTime, 25 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            gaveOverScript.numberCoins += 1;
            Debug.Log("Coins " + gaveOverScript.numberCoins);
            Destroy(gameObject);
        }
    }
}
