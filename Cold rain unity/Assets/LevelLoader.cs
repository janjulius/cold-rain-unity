using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float transitionTime = 1f;
    public int sceneToLoad;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(LoadLevel(sceneToLoad));
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
