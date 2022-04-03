using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Candidate : MonoBehaviour
{
    [SerializeField] private string candidate;
    [SerializeField] private Slider statusBar;
    [SerializeField] private TMP_Text statusText;

    private int statusValue;
        
    public int StatusValue { get { return statusValue; } set { statusValue = value; statusText.text = StatusValue + "%"; statusBar.value = StatusValue * .01f; } }

    void Start()
    {
        if (PlayerPrefs.HasKey("Votes" + candidate))
        {
            StatusValue = PlayerPrefs.GetInt("Votes" + candidate);
        }
        else
        {
            StatusValue = 33;
            PlayerPrefs.SetInt("Votes" + candidate, StatusValue);
        }
    }

    private void Update()
    {

    }
         
}
