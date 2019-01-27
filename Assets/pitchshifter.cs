using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class pitchshifter : MonoBehaviour
{
    public GameObject playerCamera;
    public float targetDistance;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = 2.0f;
        if(playerCamera == null){
            //defaults to main camera. not sure why we would change this.. 
            playerCamera = Camera.main.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera != null)
        {
            targetDistance = Vector3.Distance(gameObject.transform.position, playerCamera.transform.position);
            if (targetDistance < 2.0f) {
                audioSource.pitch = targetDistance;
            }
            Debug.Log(targetDistance);
        }
        
    }
}
