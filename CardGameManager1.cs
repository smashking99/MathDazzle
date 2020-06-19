using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardGameManager1 : MonoBehaviour
{
    public float selectionDuration = 1.0f;

    public GameObject cardPrefab1; 
    public GameObject cardPrefab;
    public GameObject soundButtonPrefab;
    public GameObject menuButtonPrefab;
    
    public RectTransform leftCardLocation;
    public RectTransform rightCardLocation;
    public RectTransform soundButtonLocation;
    public RectTransform menuButtonLocation;

    public GameObject leftSelectionHightlight;
    public GameObject rightSelectionHighlight;
    public GameObject soundSelecationHighlight;
    public GameObject menuSelectionHighlight;

    public Text cardCountText;
    public int cardCount = 0;

    private int numberOfCards = 20;

    private int currentSelectedCard = 0;
    private float selectionTimer = 0.0f;
    public AudioSource gameSound;

    //public GameObject menuButton;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfCards; i++) {
            GameCard leftCard = Instantiate(cardPrefab1, leftCardLocation.position, Quaternion.identity, leftCardLocation).GetComponent<GameCard>();
            leftCard.ChangeCardValue(Random.Range(-5,5));

            GameCard rightCard = Instantiate(cardPrefab, rightCardLocation.position, Quaternion.identity, rightCardLocation).GetComponent<GameCard>();
            rightCard.ChangeCardValue(Random.Range(-5,5));
        }

        cardCountText.text = cardCount.ToString();
        currentSelectedCard = 0;
        selectionTimer = selectionDuration;

        gameSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        selectionTimer -= Time.deltaTime;
        if (selectionTimer <= 0.0f) {
            currentSelectedCard = (currentSelectedCard + 1) % 2;
            selectionTimer = selectionDuration;
        }

        if (currentSelectedCard == 0) {
            leftSelectionHightlight.SetActive(true);
            rightSelectionHighlight.SetActive(false);
        }
        else {
            leftSelectionHightlight.SetActive(false);
            rightSelectionHighlight.SetActive(true);
        }

        if(currentSelectedCard == 0){
            soundSelecationHighlight.SetActive(true);
            menuSelectionHighlight.SetActive(false);
        }
        else {
            soundSelecationHighlight.SetActive(false);
            menuSelectionHighlight.SetActive(true);          
        }

        
        // implement key press
        if (Input.GetKeyDown(KeyCode.RightArrow)) {

                GameCard currentCard = null;
                if (currentSelectedCard == 0) {
                    currentCard = leftCardLocation.GetChild(leftCardLocation.childCount - 1).GetComponent<GameCard>();
                    
                    //level successfully completed on left card
                    if(leftCardLocation.childCount - 1 == 0 && cardCount > 1 && cardCount < 30)
                    {
                        //LevelSelector.levelPassed = true;
                        SceneManager.LoadScene("WinGame 1");
                        Debug.Log("Win");
                    }
                }
                else {
                    currentCard = rightCardLocation.GetChild(rightCardLocation.childCount - 1).GetComponent<GameCard>();

                    //level successfully completed on right card
                    if(rightCardLocation.childCount - 1 == 0 && cardCount > 1 && cardCount < 30)
                    {
                        //LevelSelector.levelPassed = true;
                        SceneManager.LoadScene("WinGame 1");
                        Debug.Log("Win");
                    }
                }

                cardCount += currentCard.cardValue;
                cardCountText.text = cardCount.ToString();

                //game over
                if(cardCount < 1 || cardCount > 30)
                {
                    //LevelSelector.levelPassed = false;
                    SceneManager.LoadScene("GameOver 1");
                    Debug.Log("Game Over");
                }
                
                currentCard.transform.SetParent(transform);
                currentCard.StartAnimation();
                Destroy(currentCard.gameObject, 1.0f); 
        }
        //MenuButton("LevelScene");

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(currentSelectedCard == 0){
                gameSound.mute = !gameSound.mute;

            }
            else {
                SceneManager.LoadScene("StartMenu");
            }
    }
    }
}

