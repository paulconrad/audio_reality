using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class pitchshifter : MonoBehaviour
{
    //ui parameters
    public GameObject playerCamera;
    public float pitchStartValue;
    public float pitchEndValue;
    public AudioClip successAudioClip;


    //other
    AudioSource audioSource;
    float playerDistance;
    float pitchBorder;
    float pitchTarget;
    bool success;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = pitchStartValue;
        if(playerCamera == null){
            //defaults to main camera. not sure why we would change this.. 
            playerCamera = Camera.main.gameObject;
        }
        pitchBorder = transform.GetChild(0).localScale.x / 2.0f;
        pitchTarget = transform.GetChild(1).localScale.x / 2.0f;
        success = false;

    }

    // Update is called once per frame
    void Update()
    {
        if ((playerCamera != null) && !success)
        {
            playerDistance = Vector3.Distance(gameObject.transform.position, playerCamera.transform.position);
            if (playerDistance < pitchBorder)
            {
                if (playerDistance > pitchTarget)
                {
                    audioSource.pitch = ((playerDistance - pitchTarget) / (pitchBorder - pitchTarget)) * (pitchStartValue - pitchEndValue) + pitchEndValue;
                }
                else
                {
                    audioSource.pitch = pitchEndValue;
                }
            }

            //Debug.Log(targetDistance);
        } 
        
    }
    void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<AudioSource>().PlayOneShot(successAudioClip);
        success = true;
        audioSource.pitch = 1.0f;
        
    }
    void OnTriggerStay(Collider other){
        
    }
    void OnTriggerExit(Collider other)
    {
        
    }
}
