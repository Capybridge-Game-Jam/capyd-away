using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dramaticCameraMovements : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;

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

        SetDestination(new Vector3(1, -1.4f, -5), 6);
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(fadeUnfadeSetNewImage(image2));

        SetDestination(new Vector3(-1, -1, -5), 0);

        SetDestination(new Vector3(0.3f, -4f, -5), 6);
        yield return new WaitForSeconds(5);
        yield return StartCoroutine(fadeUnfadeSetNewImage(image3));

        SetDestination(new Vector3(1, -3.5f, -5), 3);
        yield return new WaitForSeconds(2);
        StartCoroutine(fadeUnfadeSetNewImage(image4));

        yield return new WaitForSeconds(2);
        SetDestination(new Vector3(-2, 1, -5), 0);

        SetDestination(new Vector3(2, -3, -5), 3);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(fadeUnfadeSetNewImage(image5));

        SetDestination(new Vector3(1, -1, -5), 6);
        yield return new WaitForSeconds(4);
        StartCoroutine(fadeUnfadeSetNewImage(image5));
        yield return new WaitForSeconds(1);
        // CHANGE SCENE HERE
        
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
        
        Debug.Log("e");
        imageObject.GetComponent<SpriteRenderer>().sprite = im;
        Debug.Log("f");

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
