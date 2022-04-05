using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager1 : MonoBehaviour
{
    [SerializeField] int round, countCandidateInteract, votesA, votesB, votesC;
    [SerializeField] List<string> datesText, comentarysCandidate;
    [SerializeField] GameObject[] News, Comments, Dates, CandidatesComments;
    [SerializeField] TMP_Text dateText, themeText, textBaloonComentary; 
    [SerializeField] AudioSource effect;
    [HideInInspector] public bool inputEnter;
    private GameObject comment;
    private Theme Theme;

    void Awake()
    {
        countCandidateInteract = 1;
        Comments = GameObject.FindGameObjectsWithTag("Comment");
        News = GameObject.FindGameObjectsWithTag("News");
        Dates = GameObject.FindGameObjectsWithTag("Dates");
        CandidatesComments = GameObject.FindGameObjectsWithTag("Candidate");
        foreach (var item in Dates)
        {
            datesText.Add(item.GetComponent<TMP_Text>().text);
        }
        foreach (var item in CandidatesComments)
        {
            comentarysCandidate.Add(item.GetComponent<TMP_Text>().text);
        }
    }
    void Start()
    {
        string theme = PlayerPrefs.GetString("Theme");
        if (PlayerPrefs.HasKey("Round"))
        {
            round = PlayerPrefs.GetInt("Round");
        }
        else
        {
            round = 0;
            PlayerPrefs.SetInt("Round", round);
        }
        votesA = PlayerPrefs.GetInt("VotesA");
        votesB = PlayerPrefs.GetInt("VotesB");
        votesC = PlayerPrefs.GetInt("VotesC");
                  
        dateText.text = datesText[round];
        Theme = FindObjectOfType<Theme>();
        int r = Random.Range(0, Theme.themes.Count);
        theme = Theme.themes[r];
        themeText.text = theme;
        PlayerPrefs.SetString("Theme", theme);
        Theme.themes.Remove(theme);

        switch (PlayerPrefs.GetString("Theme"))
        {
            case "Topic Debate: Covid-19 / Vaccine":
                textBaloonComentary.text = comentarysCandidate[1];
                break;
            case "Topic Debate: Education":
                textBaloonComentary.text = comentarysCandidate[2];
                break;
            case "Topic Debate: Pension":
                textBaloonComentary.text = comentarysCandidate[3];
                break;
            case "Topic Debate: Political Reform":
                textBaloonComentary.text = comentarysCandidate[4];
                break;
            case "Topic Debate: War / Ukraine-Russia":
                textBaloonComentary.text = comentarysCandidate[5];
                break;
        }
    }

    void Update()
    {
        Inputs();
        ControllerComentarys();
    }

    public void ContinueButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ControllerComentarys()
    {
        if(inputEnter){
            countCandidateInteract = countCandidateInteract < 3 ? countCandidateInteract += 1 : countCandidateInteract = countCandidateInteract;
            switch(countCandidateInteract)
            {
                case 1:
                    effect.Play();
                    switch (PlayerPrefs.GetString("Theme"))
                    {
                        case "Topic Debate: Covid-19 / Vaccine":
                            textBaloonComentary.text = comentarysCandidate[0];
                            break;
                        case "Topic Debate: Education":
                            textBaloonComentary.text = comentarysCandidate[1];
                            break;
                        case "Topic Debate: Pension":
                            textBaloonComentary.text = comentarysCandidate[2];
                            break;
                        case "Topic Debate: Political Reform":
                            textBaloonComentary.text = comentarysCandidate[3];
                            break;
                        case "Topic Debate: War / Ukraine-Russia":
                            textBaloonComentary.text = comentarysCandidate[4];
                            break;
                    }
                    break;
                case 2:
                    effect.Play();
                    switch (PlayerPrefs.GetString("Theme"))
                    {
                        case "Topic Debate: Covid-19 / Vaccine":
                            textBaloonComentary.text = comentarysCandidate[5];
                            break;
                        case "Topic Debate: Education":
                            textBaloonComentary.text = comentarysCandidate[6];
                            break;
                        case "Topic Debate: Pension":
                            textBaloonComentary.text = comentarysCandidate[7];
                            break;
                        case "Topic Debate: Political Reform":
                            textBaloonComentary.text = comentarysCandidate[8];
                            break;
                        case "Topic Debate: War / Ukraine-Russia":
                            textBaloonComentary.text = comentarysCandidate[9];
                            break;
                    }
                    break;
                case 3:
                    switch (PlayerPrefs.GetString("Theme"))
                    {
                        case "Topic Debate: Covid-19 / Vaccine":
                            textBaloonComentary.text = comentarysCandidate[10];
                            break;
                        case "Topic Debate: Education":
                            textBaloonComentary.text = comentarysCandidate[11];
                            break;
                        case "Topic Debate: Pension":
                            textBaloonComentary.text = comentarysCandidate[12];
                            break;
                        case "Topic Debate: Political Reform":
                            textBaloonComentary.text = comentarysCandidate[13];
                            break;    
                        case "Topic Debate: War / Ukraine-Russia":
                            textBaloonComentary.text = comentarysCandidate[14];
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

}
