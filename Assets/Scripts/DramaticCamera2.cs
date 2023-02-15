using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DramaticCamera2 : MonoBehaviour {
    public Sprite image1;
    public Sprite image2;

    public GameObject imageObject;
    public GameObject fade;
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;
    void Start()
    {
        imageObject.GetComponent<SpriteRenderer>().sprite = image1;
        StartCoroutine(AnimationCoroutine());
    }
    IEnumerator AnimationCoroutine() {
        startPosition = target = transform.position;

        yield return new WaitForSeconds(5);
        yield return StartCoroutine(fadeUnfadeSetNewImage(image2));

        yield return new WaitForSeconds(10);
        StartCoroutine(fadeUnfadeSetNewImage(image2));
        yield return new WaitForSeconds(1);
        // CLOSE THE GAME PLEASE
        SceneManager.LoadScene (sceneName: "Menu");
        
    }
    void Update() 
    {
        t += Time.deltaTime/timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
    }
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination; 
    }

    public IEnumerator fadeUnfadeSetNewImage(Sprite im)
    {
        fade.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        // fade to black
        float fadeDuration = 0.0f;
        while (fadeDuration < 1.0f)
        {
            fadeDuration += Time.deltaTime / 1.0f;
            fade.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, fadeDuration);
            yield return null;
        }
        
        imageObject.GetComponent<SpriteRenderer>().sprite = im;

        fadeDuration = 0.0f;
        while (fadeDuration < 1.0f)
        {
            fadeDuration += Time.deltaTime / 1.0f;
            fade.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), fadeDuration);
            yield return null;
        }

        // force set to transparent
        fade.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
}
