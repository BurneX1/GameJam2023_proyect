using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change(string sceneName)
    {
        StartCoroutine(TransitionLoadScene(sceneName));
    }

    IEnumerator TransitionLoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
