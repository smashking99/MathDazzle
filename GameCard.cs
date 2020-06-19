using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public Text cardText;
    public int cardValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCardValue(int value) {
        cardValue = value;
        cardText.text = value.ToString();
    }

    public void StartAnimation() {
            
            Animator anim = GetComponent<Animator>();
            anim.SetBool("isClicked", true);
        
    }
}
