using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public string sceneName;

    public float waitTime;
    public Animator musicAnim;

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene() {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
   }
}
