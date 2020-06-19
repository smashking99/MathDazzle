using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public bool currentOption; 
    public float selectionDuration = 1.0f;

    public GameObject playButtonPrefab;
    public GameObject levelsButtonPrefab;
    public GameObject quitButtonPrefab;
    public GameObject soundButtonPrefab;

    public RectTransform playButtonLocation;    
    public RectTransform levelsButtonLocation;
    public RectTransform quitButtonLocation;
    public RectTransform soundButtonLocation;

    public GameObject playSelectionHighlight;
    public GameObject levelsSelectionHightlight;
    public GameObject quitSelectionHightlight; 
    public GameObject soundSelecationHighlight;

    private int currentSelectedOption = 0;

    private float selectionTimer = 0.0f;

    public AudioSource gameSound;


    void Start()
    {
        Instantiate(playButtonPrefab, playButtonLocation.position, Quaternion.identity, playButtonLocation);
        Instantiate(levelsButtonPrefab, levelsButtonLocation.position, Quaternion.identity, levelsButtonLocation);
        Instantiate(quitButtonPrefab, quitButtonLocation.position, Quaternion.identity, quitButtonLocation);

        currentSelectedOption = 0;
        selectionTimer = selectionDuration;

        gameSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        selectionTimer -= Time.deltaTime;
        if (selectionTimer <= 0.0f) {
            currentSelectedOption = (currentSelectedOption + 1) % 2;
            selectionTimer = selectionDuration;
        }

        if (currentSelectedOption == 0) {
            playSelectionHighlight.SetActive(true);
            levelsSelectionHightlight.SetActive(false);
        }
        else {
            playSelectionHighlight.SetActive(false);
            levelsSelectionHightlight.SetActive(true);
        }

        if(currentSelectedOption == 0){
            soundSelecationHighlight.SetActive(true);
            quitSelectionHightlight.SetActive(false);
        }
        else {
            soundSelecationHighlight.SetActive(false);
            quitSelectionHightlight.SetActive(true);          
        }


        

        // implement key press
        if(Input.GetKeyDown(KeyCode.RightArrow)){  
            
            /*switch(currentSelectedOption){
                case 2: 
                SceneManager.LoadScene("CardGame");
                break;

                case 1:
                //SceneManager.LoadScene("CardGame");
                Debug.Log("Levels");
                break;

                default:
                SceneManager.LoadScene("CardGame");
                break;
            }*/
            if(currentSelectedOption == 0){
                //load play scene
                SceneManager.LoadScene("CardGame 3");

            }
            else {
                //load levels scene
                SceneManager.LoadScene("LevelScene");
            }
            /*else{
                //load quit scene
                SceneManager.LoadScene("CardGame");
            }*/
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(currentSelectedOption == 0){
                gameSound.mute = !gameSound.mute;
            }
            else {
                Application.Quit();
                Debug.Log("Quit");
            }
        }
    }   
}
