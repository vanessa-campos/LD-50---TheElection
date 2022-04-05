using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager2 : MonoBehaviour
{
    [SerializeField] int round, votesA, votesB, votesC;
    [SerializeField] bool selected;
    [SerializeField] GameObject[] News, Comments;
    [SerializeField] GameObject panelComments, panelOptions, chooseComment, buttonSend;
    [SerializeField] Transform commentPos;
    [SerializeField] TMP_Text newsFeed;
    [SerializeField] GameObject comment1, comment2, comment3;
    [SerializeField] AudioSource effect;
    private GameObject comment;
    private Theme Theme;
    string theme;

    void Awake()
    {
        // Comments = GameObject.FindGameObjectsWithTag("Comment");
        // News = GameObject.FindGameObjectsWithTag("News");
        theme = PlayerPrefs.GetString("Theme");
        round = PlayerPrefs.GetInt("Round");
        votesA = PlayerPrefs.GetInt("VotesA");
        votesB = PlayerPrefs.GetInt("VotesB");
        votesC = PlayerPrefs.GetInt("VotesC");
    }
    void Start()
    {
        ChooseRandomNews();
    }

    public void OpenPanelComments()
    {
        effect.Play();
        panelComments.SetActive(true);
        chooseComment.SetActive(true);
    }
    public void OpenPanelOptions(GameObject gameObject)
    {
        effect.Play();
        gameObject.SetActive(false);
        panelOptions.SetActive(true);
    }
    public void CloseButtonComment(GameObject gameObject)
    {
        effect.Play();
        gameObject.SetActive(false);
        Destroy(comment);
        buttonSend.SetActive(false);
        if(selected){
            VotesRemove();
            selected = false;
        }
    }
    public void CloseButtonOptions(GameObject gameObject)
    {
        effect.Play();
        chooseComment.SetActive(true);
        Destroy(comment);
        gameObject.SetActive(false);
        buttonSend.SetActive(false);
    }
    public void CommentSelected(GameObject gameObject)
    {
        effect.Play();
        comment = Instantiate(gameObject, commentPos);
        panelOptions.SetActive(false);
        buttonSend.SetActive(true);
        VotesAdd();
        selected = true;
    }
    void VotesAdd()
    {        
        votesA = PlayerPrefs.GetInt("VotesA");
        votesB = PlayerPrefs.GetInt("VotesB");
        votesC = PlayerPrefs.GetInt("VotesC");        
        if(round == 5){
            votesA += comment.GetComponent<Comment>().VotesA * 3;
            votesB += comment.GetComponent<Comment>().VotesB * 3;
            votesC += comment.GetComponent<Comment>().VotesC * 3;
        }else{
            votesA += comment.GetComponent<Comment>().VotesA;
            votesB += comment.GetComponent<Comment>().VotesB;
            votesC += comment.GetComponent<Comment>().VotesC;
        }        
        PlayerPrefs.SetInt("VotesA", votesA);
        PlayerPrefs.SetInt("VotesB", votesB);
        PlayerPrefs.SetInt("VotesC", votesC);
    }
    void VotesRemove()
    {
        if(round == 5){
            votesA -= comment.GetComponent<Comment>().VotesA * 3;
            votesB -= comment.GetComponent<Comment>().VotesB * 3;
            votesC -= comment.GetComponent<Comment>().VotesC * 3;
        }else{
            votesA -= comment.GetComponent<Comment>().VotesA;
            votesB -= comment.GetComponent<Comment>().VotesB;
            votesC -= comment.GetComponent<Comment>().VotesC;
        } 
        PlayerPrefs.SetInt("VotesA", votesA);
        PlayerPrefs.SetInt("VotesB", votesB);
        PlayerPrefs.SetInt("VotesC", votesC);
    }
    
    public void SendButton()
    {        
        effect.Play();
        selected = false;
        round = PlayerPrefs.GetInt("Round");
        round += 1;
        PlayerPrefs.SetInt("Round", round); 
        if(round == 5)
        {          
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ContinueButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    void ChooseRandomNews()
    {
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
}
