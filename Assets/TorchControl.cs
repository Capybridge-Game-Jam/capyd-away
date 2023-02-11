using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{

    public GameObject capybara;
    public Animator capybaraAnimator;
    public GameObject stickFront;
    public GameObject stickBack;
    public GameObject flame;
    public Vector3 stickOffset = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool lookingRight = capybara.GetComponent<SpriteRenderer>().flipX;
        for (int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).GetComponent<SpriteRenderer>().flipX = !lookingRight;
        }
        if (lookingRight) {
            stickFront.transform.localPosition = new Vector3(1.625f, -0.13f, 0) + stickOffset;
            stickBack.transform.localPosition = new Vector3(2f, 0.12f, 0) + stickOffset;
            flame.transform.localPosition = new Vector3(2.25f, 1.37f, 0) + stickOffset;
        } else {
            stickFront.transform.localPosition = new Vector3(-1.625f, -0.13f, 0) + stickOffset;
            stickBack.transform.localPosition = new Vector3(-2f, 0.12f, 0) + stickOffset;
            flame.transform.localPosition = new Vector3(-2.25f, 1.37f, 0) + stickOffset;
        }
    }

    void LateUpdate() {
        AnimatorStateInfo capybaraAnimatorStateInfo = capybaraAnimator.GetCurrentAnimatorStateInfo(0);
        // switch (capybaraAnimatorStateInfo. )
        float animationLength = capybaraAnimatorStateInfo.length;
        float playedForTime = capybaraAnimatorStateInfo.normalizedTime % 1;
        int shortNameHash = capybaraAnimatorStateInfo.shortNameHash;
        Debug.Log(shortNameHash);
        Debug.Log(playedForTime);

        switch (shortNameHash) {
            case -1680735116: // still
                if (playedForTime >= animationLength/3) {
                    stickOffset = new Vector3(0, 0.2f, 0);
                    if (playedForTime <= animationLength*2.5/3) {
                        if (lookingRight) {
                            stickOffset = new Vector3(0.2f, 0.2f, 0);
                        } else {
                            stickOffset = new Vector3(-0.2f, 0.2f, 0);
                        }
                    }
                } else {
                    stickOffset = Vector3.zero;
                }
                break;
            case -717303239:  // run
                //
                break;

            default:
                break;
        }
    }
}
