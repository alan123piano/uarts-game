using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    // Start is called before the first frame update
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameTransition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("change");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelIndex);
    }
}
