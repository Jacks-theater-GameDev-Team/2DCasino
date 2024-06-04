using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceneloader : MonoBehaviour
{
    private static SceneController instance;
    private Stack<string> sceneHistory = new Stack<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        // Add the current scene to the history stack before loading the new scene
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousScene()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene in history.");
        }
    }
}