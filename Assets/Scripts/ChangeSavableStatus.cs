using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSavableStatus : MonoBehaviour
{
    [SerializeField] bool allowSaveing;
    private Pause pauseScript;

    private void Start() {
        pauseScript = FindObjectOfType<Pause>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
            pauseScript.ToggleCanSave(allowSaveing);
    }

}
