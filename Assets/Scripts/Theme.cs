using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Theme : MonoBehaviour
{
    public List<string> themes;
    
    // new List<string> { "Topic Debate: Covid-19 / Vaccine" , "Topic Debate: Education" , "Topic Debate: Pension" ,
                            // "Topic Debate: Political Reform", "Topic Debate: War / Ukraine-Russia"};
    int r;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            DontDestroyOnLoad(gameObject);
            Theme[] objects = FindObjectsOfType<Theme>();
            if(objects.Length > 1){
                Destroy(objects[0].gameObject);     
            }
        }
        
    }

    
    
}
