using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    PersistenceManager persistenceManager;

    private void Start()
    {
        persistenceManager = GameObject.Find("PersistenceManager").GetComponent<PersistenceManager>();
    }

    //starts the game, start button uses this method
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    //exits the application/game, exit button uses this method
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        persistenceManager.SaveScore();
#else
        Application.Quit();
        persistenceManager.SaveScore();
#endif
    }

    //returns to menu
    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
