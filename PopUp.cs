using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PopUp : MonoBehaviour
{
    public GameObject msgBox;
    public Text msgFieldLeft;
    public Text msgFieldRight; 

    
    private CardManager cardManager;

    void Start()
    {
        //cardManager = gameObject.GetComponent<CardManager>();
        msgFieldLeft.enabled = false;
        msgFieldRight.enabled = false;
    }

    void Update()
    {
        PopUpChecker();
        
    }
    public void DialogueBox()
    {        
        if(CardManager.msgClick == true)
        {
            if(!msgBox.activeInHierarchy)
            {
                msgBox.SetActive(true);
            }
        }

        /*if(msgBox.activeInHierarchy)
        {
            cardManager.CardMovement();
        }*/
    }

    public void PopUpChecker()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //msgField.text = GameObject.Find("/MsgRight").ToString();
            msgFieldRight.enabled = true;
            Debug.Log("RightClick");
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //msgField.text = GameObject.Find("/MsgLeft").ToString();
            msgFieldLeft.enabled = true;
            Debug.Log("LeftClick");
        }
        DialogueBox();
    }
}
