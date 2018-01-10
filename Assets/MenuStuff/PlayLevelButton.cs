using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLevelButton : MonoBehaviour {

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Debug.Log("Clicked");
        StartCoroutine(AsynchronousLoadScene());
    }

    IEnumerator AsynchronousLoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/TestLevel");
        Debug.Log("Beginning load");
        while(!asyncLoad.isDone)
        {
            Debug.Log("Loading...");
            yield return null;
        }
    }

}
