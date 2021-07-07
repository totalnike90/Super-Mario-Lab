using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameObject[] finishObjects;
    PlayerController playerController;
    void Awake()
    {
        
        Time.timeScale = 0;
        //Debug.Log("here");
    }

    public void StartButtonClicked()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name != "ScoreText")
            {
                Debug.Log("Child found. Name: " + eachChild.name);
                // disable thadadem
                eachChild.gameObject.SetActive(false);
                // playerController.score = 0;
                // playerController.scoreText.text = "Score: 0";
                Time.timeScale = 1;
            }
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("here4");
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        foreach(GameObject g in finishObjects){
			g.SetActive(false);
        }
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("here3");

       if (Time.timeScale == 0 && playerController.alive == false)
       {
            Debug.Log("here5");
            foreach(GameObject g in finishObjects){
                g.SetActive(true);
            }
       }
    }

}
