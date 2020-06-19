using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CardAnim : MonoBehaviour
{
    public static bool var, access;
    public Button okButton; 
    // Start is called before the first frame update
    void Start()
    {
        var = false;
        Button btn = okButton.GetComponent<Button>();
        btn.onClick.AddListener(ButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        if(var == false)
        {
            AccessGranted();
        }
        //ButtonPress();
    }

    public void ButtonPress()
    {
        var = true;
        Debug.Log("Hello");
    }

    public void AccessGranted()
    {
        access = true;
    }
}
