using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void Start()
    {
        // Example rotation parameters
        Vector3 targetRotation = new Vector3(0, 360, 0);
        float duration = 5.0f;
        iTween.RotateTo(gameObject, iTween.Hash(
            "rotation", targetRotation, 
            "time", duration, 
            "looptype", iTween.LoopType.loop, 
            "easetype", iTween.EaseType.linear
            ));
    }
}
