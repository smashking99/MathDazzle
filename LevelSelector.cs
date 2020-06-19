using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public float selectionDuration = 1.0f;

    public GameObject level1Prefab;
    public GameObject level2Prefab;

    public RectTransform level1Location;
    public RectTransform level2Location;

    public GameObject level1Highlight;
    public GameObject level2Highlight;

    private int currentSelectedLevel = 0;
    private float selectionTimer = 0.0f;

    //public Button backButton;

    //public static bool levelPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(level1Prefab, level1Location.position, Quaternion.identity, level1Location);
        Instantiate(level2Prefab, level2Location.position, Quaternion.identity, level2Location);

        currentSelectedLevel = 0;
        selectionTimer = selectionDuration;
    }

    // Update is called once per frame
    void Update()
    {
        selectionTimer -= Time.deltaTime;
        if (selectionTimer <= 0.0f) {
            currentSelectedLevel = (currentSelectedLevel + 1) % 2;
            selectionTimer = selectionDuration;
        }

        if(currentSelectedLevel == 0){
            level1Highlight.SetActive(true);
            level2Highlight.SetActive(false);
        }

        else {
            level1Highlight.SetActive(false);
            level2Highlight.SetActive(true);
        }

        // implement key press
        if(Input.GetKeyDown(KeyCode.RightArrow)){

            if(currentSelectedLevel == 0){
                SceneManager.LoadScene("CardGame 3");
            }
            else {
                SceneManager.LoadScene("CardGame 1");
                //Debug.Log("Level locked");
                }
        }
    BackButtonOption("StartMenu");
    }

    public void BackButtonOption(string scene_name){
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
