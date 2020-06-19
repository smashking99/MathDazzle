using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCard : CardManager
{
    public GameObject maincardText;
    public static float maincardNumber;

    private float sum; 

    // Start is called before the first frame update
    void Start()
    {
        maincardNumber = Random.Range(1,30);
        maincardText.GetComponent<Text>().text = "" + maincardNumber;
        sum += maincardNumber;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Left")){
            sum += CardManager.cardNumber;
            maincardText.GetComponent<Text>().text = "" + sum;
            Debug.Log(sum);
        }

        if(other.CompareTag("Right"))
        {
            sum += CardManager.cardNumber;
            maincardText.GetComponent<Text>().text = "" + sum;
            Debug.Log(sum);
        }
    }
}
