using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool currentOption; 
    public float selectionDuration = 1.0f;
    public GameObject playAgainPrefab;
    public GameObject menuPrefab;

    public RectTransform playAgainLocation;
    public RectTransform menuLocation;

    public GameObject playAgainHighlight;
    public GameObject menuHighlight;

    private int currentSelectedChoice = 0;

    private float selectionTimer = 0.0f;

    public AudioSource gameSound;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playAgainPrefab, playAgainLocation.position, Quaternion.identity, playAgainLocation);
        Instantiate(menuPrefab, menuLocation.position, Quaternion.identity, menuLocation);

        currentSelectedChoice = 0;
        selectionTimer = selectionDuration;

        gameSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        selectionTimer -= Time.deltaTime;
        if (selectionTimer <= 0.0f) {
            currentSelectedChoice = (currentSelectedChoice + 1) % 2;
            selectionTimer = selectionDuration;
        }

        if(currentSelectedChoice == 0){
            playAgainHighlight.SetActive(true);
            menuHighlight.SetActive(false);
        }

        else {
            playAgainHighlight.SetActive(false);
            menuHighlight.SetActive(true);   
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(currentSelectedChoice == 0){
                SceneManager.LoadScene("CardGame 1");
            }
            else {
                SceneManager.LoadScene("StartMenu");
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            gameSound.mute = !gameSound.mute;
        }
    }
}
