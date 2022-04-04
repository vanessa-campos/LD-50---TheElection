using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int round, countCandidateInteract;
    [SerializeField] string[] comentarysCandidate1, comentarysCandidate2, comentarysCandidate3;
    [SerializeField] string[] Dates;
    [SerializeField] GameObject[] FinalStory, News, Comments;
    [SerializeField] public  TMP_Text dateText, themeText; 
    [SerializeField] GameObject panelComments, panelOptions, chooseComment, buttonSend;
    [SerializeField] Transform commentPos;
    [SerializeField] TMP_Text newsFeed, textBaloonComentary;
    [SerializeField] GameObject comment1, comment2, comment3;
    [SerializeField] Sprite[] candidatesImages;
    [SerializeField] Image winnerImage;
    [SerializeField] TMP_Text winnerName, winnerStory;
    [HideInInspector] public bool inputEnter;
    private GameObject comment;
    private int votesA, votesB, votesC;
    private Theme Theme;

    void Awake()
    {
        countCandidateInteract = 1;
        Comments = GameObject.FindGameObjectsWithTag("Comment");
        News = GameObject.FindGameObjectsWithTag("News");
    }
    void Start()
    {
        string theme = PlayerPrefs.GetString("Theme");

        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                if (PlayerPrefs.HasKey("Round"))
                {
                    round = PlayerPrefs.GetInt("Round");
                }
                else
                {
                    round = 0;
                    PlayerPrefs.SetInt("Round", round);
                }
                dateText.text = Dates[round];
                Theme = FindObjectOfType<Theme>();
                int r = Random.Range(0, Theme.themes.Count);
                theme = Theme.themes[r];
                themeText.text = theme;
                PlayerPrefs.SetString("Theme", theme);
                Theme.themes.Remove(theme);

                switch(countCandidateInteract)
                {
                    case 1:
                        switch (PlayerPrefs.GetString("Theme"))
                        {
                            case "Topic Debate: Covid-19 / Vaccine":
                                textBaloonComentary.text = comentarysCandidate1[1];
                                break;
                            case "Topic Debate: Education":
                                textBaloonComentary.text = comentarysCandidate1[2];
                                break;
                            case "Topic Debate: Pension":
                                textBaloonComentary.text = comentarysCandidate1[3];
                                break;
                            case "Topic Debate: Political Reform":
                                textBaloonComentary.text = comentarysCandidate1[4];
                                break;
                            case "Topic Debate: War / Ukraine-Russia":
                                textBaloonComentary.text = comentarysCandidate1[5];
                                break;
                        }
                        break;
                }
                break;
                
            case 2:
                round = PlayerPrefs.GetInt("Round");
                ChooseRandomNews();
                break;
            case 3:
                SetWinner();
                break;
        }


        
        
    }

    void Update()
    {
        Inputs();
        ControllerComentarys();
    }



    
    public void OpenPanelComments()
    {
        panelComments.SetActive(true);
        chooseComment.SetActive(true);
    }
    public void OpenPanelOptions(GameObject gameObject)
    {
        gameObject.SetActive(false);
        panelOptions.SetActive(true);
    }
    public void CloseButtonComment(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Destroy(comment);
        buttonSend.SetActive(false);
    }
    public void CloseButtonOptions(GameObject gameObject)
    {
        chooseComment.SetActive(true);
        Destroy(comment);
        gameObject.SetActive(false);
        buttonSend.SetActive(false);
    }
    public void CommentSelected(GameObject gameObject)
    {
        comment = Instantiate(gameObject, commentPos);
        panelOptions.SetActive(false);
        buttonSend.SetActive(true);
    }
    public void SendButton()
    {
        votesA = PlayerPrefs.GetInt("VotesA");
        votesB = PlayerPrefs.GetInt("VotesB");
        votesC = PlayerPrefs.GetInt("VotesC");
        switch (round)
        {
            case 0 & 1:
                votesA += comment.GetComponent<Comment>().VotesA;
                votesB += comment.GetComponent<Comment>().VotesB;
                votesC += comment.GetComponent<Comment>().VotesC;
                break;
            case 2 & 3:
                votesA += comment.GetComponent<Comment>().VotesA * 2;
                votesB += comment.GetComponent<Comment>().VotesB * 2;
                votesC += comment.GetComponent<Comment>().VotesC * 2;
                break;
            case 4:
                votesA += comment.GetComponent<Comment>().VotesA * 3;
                votesB += comment.GetComponent<Comment>().VotesB * 3;
                votesC += comment.GetComponent<Comment>().VotesC * 3;
                break;
        }
        PlayerPrefs.SetInt("VotesA", votesA);
        PlayerPrefs.SetInt("VotesB", votesB);
        PlayerPrefs.SetInt("VotesC", votesC);
        round = PlayerPrefs.GetInt("Round");
        round += 1;
        PlayerPrefs.SetInt("Round", round); 
        if(round == 5)
        {
            CompareVotes();            
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(2);
    }
    public void EndButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ControllerComentarys()
    {
        if(inputEnter){

            countCandidateInteract = countCandidateInteract < 3 ? countCandidateInteract += 1 : countCandidateInteract = countCandidateInteract;
            switch(countCandidateInteract)
            {
                case 1:
                        switch (PlayerPrefs.GetString("Theme"))
                        {
                            case "Topic Debate: Covid-19 / Vaccine":
                                textBaloonComentary.text = comentarysCandidate1[1];
                                break;
                            case "Topic Debate: Education":
                                textBaloonComentary.text = comentarysCandidate1[2];
                                break;
                            case "Topic Debate: Pension":
                                textBaloonComentary.text = comentarysCandidate1[3];
                                break;
                            case "Topic Debate: Political Reform":
                                textBaloonComentary.text = comentarysCandidate1[4];
                                break;
                            case "Topic Debate: War / Ukraine-Russia":
                                textBaloonComentary.text = comentarysCandidate1[5];
                                break;
                        }
                    break;

                case 2:
                    switch (PlayerPrefs.GetString("Theme"))
                        {
                            case "Topic Debate: Covid-19 / Vaccine":
                                textBaloonComentary.text = comentarysCandidate2[1];
                                break;
                            case "Topic Debate: Education":
                                textBaloonComentary.text = comentarysCandidate2[2];
                                break;
                            case "Topic Debate: Pension":
                                textBaloonComentary.text = comentarysCandidate2[3];
                                break;
                            case "Topic Debate: Political Reform":
                                textBaloonComentary.text = comentarysCandidate2[4];
                                break;
                            case "Topic Debate: War / Ukraine-Russia":
                                textBaloonComentary.text = comentarysCandidate2[5];
                                break;
                        }
                    break;

                case 3:
                    switch (PlayerPrefs.GetString("Theme"))
                        {
                            case "Topic Debate: Covid-19 / Vaccine":
                                textBaloonComentary.text = comentarysCandidate3[1];
                                break;
                            case "Topic Debate: Education":
                                textBaloonComentary.text = comentarysCandidate3[2];
                                break;
                            case "Topic Debate: Pension":
                                textBaloonComentary.text = comentarysCandidate3[3];
                                break;
                            case "Topic Debate: Political Reform":
                                textBaloonComentary.text = comentarysCandidate3[4];
                                break;
                            case "Topic Debate: War / Ukraine-Russia":
                                textBaloonComentary.text = comentarysCandidate3[5];
                                break;
                        }
                    break;
            }
        }
    }
    void Inputs()
    {
        inputEnter = Input.GetKeyDown(KeyCode.Return) ? inputEnter = true : inputEnter = false;
    }
    void ChooseRandomNews()
    {
        string theme = PlayerPrefs.GetString("Theme");
        switch (theme)
        {
            case "Topic Debate: Covid-19 / Vaccine":
                int r = Random.Range(0, 3);
                newsFeed.text = News[r].GetComponent<TMP_Text>().text;
                switch (r)
                {
                    case 0:
                        Comment(0);
                        break;
                    case 1:
                        Comment(3);
                        break;
                    case 2:
                        Comment(6);
                        break;
                }
                break;
            case "Topic Debate: Education":
                r = Random.Range(3, 6);
                newsFeed.text = News[r].GetComponent<TMP_Text>().text;
                switch (r)
                {
                    case 3:
                        Comment(9);
                        break;
                    case 4:
                        Comment(12);
                        break;
                    case 5:
                        Comment(15);
                        break;
                }
                break;
            case "Topic Debate: Pension":
                r = Random.Range(6, 9);
                newsFeed.text = News[r].GetComponent<TMP_Text>().text;
                switch (r)
                {
                    case 6:
                        Comment(18);
                        break;
                    case 7:
                        Comment(21);
                        break;
                    case 8:
                        Comment(24);
                        break;
                }
                break;
            case "Topic Debate: Political Reform":
                r = Random.Range(9, 12);
                newsFeed.text = News[r].GetComponent<TMP_Text>().text;
                switch (r)
                {
                    case 9:
                        Comment(27);
                        break;
                    case 10:
                        Comment(30);
                        break;
                    case 11:
                        Comment(33);
                        break;
                }
                break;
            case "Topic Debate: War / Ukraine-Russia":
                r = Random.Range(12, 15);
                newsFeed.text = News[r].GetComponent<TMP_Text>().text;
                switch (r)
                {
                    case 12:
                        Comment(36);
                        break;
                    case 13:
                        Comment(39);
                        break;
                    case 14:
                        Comment(42);
                        break;
                }
                break;
        }
    }
    void Comment(int x)
    {
        comment1.GetComponent<TMP_Text>().text = Comments[x].gameObject.GetComponent<TMP_Text>().text; 
        comment2.GetComponent<TMP_Text>().text = Comments[x+1].gameObject.GetComponent<TMP_Text>().text;
        comment3.GetComponent<TMP_Text>().text = Comments[x+2].gameObject.GetComponent<TMP_Text>().text;
        comment1.GetComponent<Comment>().VotesA = Comments[x].gameObject.GetComponent<Comment>().VotesA;
        comment1.GetComponent<Comment>().VotesB = Comments[x].gameObject.GetComponent<Comment>().VotesB;
        comment1.GetComponent<Comment>().VotesC = Comments[x].gameObject.GetComponent<Comment>().VotesC;
        comment2.GetComponent<Comment>().VotesA = Comments[x+1].gameObject.GetComponent<Comment>().VotesA;
        comment2.GetComponent<Comment>().VotesB = Comments[x+1].gameObject.GetComponent<Comment>().VotesB;
        comment2.GetComponent<Comment>().VotesC = Comments[x+1].gameObject.GetComponent<Comment>().VotesC;
        comment3.GetComponent<Comment>().VotesA = Comments[x+2].gameObject.GetComponent<Comment>().VotesA;
        comment3.GetComponent<Comment>().VotesB = Comments[x+2].gameObject.GetComponent<Comment>().VotesB;
        comment3.GetComponent<Comment>().VotesC = Comments[x+2].gameObject.GetComponent<Comment>().VotesC;

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
    void SetWinner()
    {
        switch (PlayerPrefs.GetInt("Winner"))
        {
            case 1:
                winnerImage.sprite = candidatesImages[0];
                winnerName.text = "Candidate A";
                winnerStory.text = FinalStory[0].GetComponent<TMP_Text>().text;
                break;
            case 2:
                winnerImage.sprite = candidatesImages[1];
                winnerName.text = "Candidate B";
                winnerStory.text = FinalStory[1].GetComponent<TMP_Text>().text;
                break;
            case 3:
                winnerImage.sprite = candidatesImages[2];
                winnerName.text = "Candidate C";
                winnerStory.text = FinalStory[2].GetComponent<TMP_Text>().text;
                break;
        }
    }
}
