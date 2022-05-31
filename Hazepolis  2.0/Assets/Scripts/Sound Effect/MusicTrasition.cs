using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrasition : MonoBehaviour
{
    private static MusicTrasition instance;

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    } 
}
