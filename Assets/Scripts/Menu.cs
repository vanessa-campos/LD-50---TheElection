using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
    
    public void QuitClicked()
    {
        Application.Quit();
    }

    public void LoadLvl()
    {
        SceneManager.LoadScene(1);
    }
}
