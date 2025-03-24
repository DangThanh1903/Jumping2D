using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceControler : MonoBehaviour
{
    public static ScenceControler instance;
    private float loadingScenceTime = 1f;
    [SerializeField] Animator transitionAnim;

    private List<int> completedLevels = new List<int>();

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    public void NextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (!completedLevels.Contains(currentSceneIndex)) {
            completedLevels.Add(currentSceneIndex);
        }

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (sceneCount == currentSceneIndex + 1) {
            SceneManager.LoadSceneAsync(0);
        }
        else {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel() {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(loadingScenceTime);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public bool IsLevelCompleted(int levelIndex) {
        return completedLevels.Contains(levelIndex);
    }
}
