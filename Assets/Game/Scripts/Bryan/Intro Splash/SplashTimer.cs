using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashTimer : MonoBehaviour 
{
    [SerializeField] float delay;
    [SerializeField] Image fadeImage;
    [SerializeField] Animator fadeImageAnim;

    void Start()
    {
        StartCoroutine(Delay(delay));
    }

    IEnumerator Delay(float del)
    {
        yield return new WaitForSeconds(del);
        fadeImageAnim.SetBool("play", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        fadeImageAnim.SetBool("play", false);
        SceneManager.LoadScene("Main Menu");
    }
}
