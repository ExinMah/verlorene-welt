using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.OPENING_CUTSCENE, LoadSceneMode.Additive);
    }

    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    
    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.OPENING_CUTSCENE));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAMEPLAY, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    private float totalSceneProgress;
    IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100.0f;

                bar.current = Mathf.RoundToInt(totalSceneProgress);
                
                yield return null;
            }
            
            loadingScreen.gameObject.SetActive(false);
        }
        
    }
}
