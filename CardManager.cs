using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CardManager : MonoBehaviour
{
    public Text cardText;

    public static int cardNumber;

    public Animator anim; 

    public Button okButton;

    public static bool msgClick = false; 

    public static int cardCheck;

    void Start()
    {
        cardNumber = Random.Range(-9,9);
        cardText.text = cardNumber.ToString(); 
        anim = GetComponent<Animator>();
        //okButton = GetComponent<Button>();
        //okButton.OnClick.AddListener(ButtonCheck);
    }

    void Update(){
        CardMovement();
    }

    public void CardMovement(){

    if(Input.GetKey(KeyCode.RightArrow))
    {
        if(gameObject.tag == "Right")
        {
            msgClick = true;
            if(CardAnim.access == true)
            {
                anim.SetBool("isClicked", true);
                Debug.Log("true");
            }
            //anim.SetBool("isClicked", true);
            //Debug.Log(cardNumber);
            //cardText.text = GameObject.Find("/PopUpBoxRight/Msg").ToString();
            //cardCheck = 1;
        }
    }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(gameObject.tag == "Left")
            {   
                msgClick = true;
                if(CardAnim.access == true)
                {
                    anim.SetBool("isClicked", true);
                }
                //anim.SetBool("isClicked", true);
                //Debug.Log(cardNumber); 
                //cardText.text = GameObject.Find("/PopUpBoxLeft/Msg").ToString();    
                //cardCheck = 0;
            }
        }
    }

    /*public void ButtonCheck()
    {
        if(cardCheck == 1)
        {
            anim.SetBool("isClicked", true);
        }

        if(cardCheck == 0)
        {
            anim.SetBool("isClicked", true);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MainCard"))
        {
            gameObject.SetActive(false);
        }
    }

    public void OnStartCardAnimation()
    {
        Debug.Log("Start Card Animation");
    }
}
