using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitClicked()
    {
        Application.Quit();
    }

    public void LoadLvl()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
