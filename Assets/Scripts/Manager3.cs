using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager3 : MonoBehaviour
{
    [SerializeField] int votesA, votesB, votesC;   
    [SerializeField] GameObject[] FinalStory;
    [SerializeField] Sprite[] candidatesImages;
    [SerializeField] Image winnerImage;
    [SerializeField] TMP_Text winnerName, winnerStory;
    [SerializeField] AudioSource effect;
    private Theme Theme;


    private void Awake()
    {        
        if(SceneManager.GetActiveScene().buildIndex == 4){
            FinalStory = GameObject.FindGameObjectsWithTag("Final");
        }        
        votesA = PlayerPrefs.GetInt("VotesA");
        votesB = PlayerPrefs.GetInt("VotesB");
        votesC = PlayerPrefs.GetInt("VotesC");
    }
    void Start()
    {
        CompareVotes();        
        Winner(); 
    }

    public void ContinueButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    void CompareVotes()
    {
        if (votesA > votesB & votesA > votesC)
        {
            PlayerPrefs.SetInt("Winner", 1);
        }
        else if (votesB > votesA & votesB > votesC)
        {
            PlayerPrefs.SetInt("Winner", 2);
        }
        else if (votesC > votesA & votesC > votesB)
        {
            PlayerPrefs.SetInt("Winner", 3);
        }
    }

    void Winner()
    {
        switch (PlayerPrefs.GetInt("Winner"))
        {
            case 1:
                winnerImage.sprite = candidatesImages[0];
                winnerName.text = "Candidate A";
                switch(SceneManager.GetActiveScene().buildIndex)
                {
                    case 3:
                        winnerStory.text = "The candidate was elected by " + votesA + "% of the votes.";
                    break;
                    case 4:
                        winnerStory.text = FinalStory[0].GetComponent<TMP_Text>().text;                     
                        break;
                }
                break;
            case 2:
                winnerImage.sprite = candidatesImages[1];
                winnerName.text = "Candidate B";
                switch(SceneManager.GetActiveScene().buildIndex)
                {
                    case 3:
                        winnerStory.text = "The candidate was elected by " + votesB + "% of the votes.";
                    break;
                    case 4:
                        winnerStory.text = FinalStory[1].GetComponent<TMP_Text>().text;                     
                        break;
                }
                break;
            case 3:
                winnerImage.sprite = candidatesImages[2];
                winnerName.text = "Candidate C";
                switch(SceneManager.GetActiveScene().buildIndex)
                {
                    case 3:
                        winnerStory.text = "The candidate was elected by " + votesC + "% of the votes.";
                    break;
                    case 4:
                        winnerStory.text = FinalStory[2].GetComponent<TMP_Text>().text;                     
                        break;
                }
                break;
        }
    }
}
