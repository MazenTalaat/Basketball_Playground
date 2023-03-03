using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameObject effectObject;
    private AudioSource winAudio;
    private int score = 0;
    void Start()
    {
        effectObject.SetActive(false);
        winAudio = effectObject.GetComponent<AudioSource>();
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            //print("Goal!");
            effectObject.SetActive(true);
            effectObject.GetComponent<ParticleSystem>().Play();
            winAudio.Play();
            score++;
        }
    }

    void Update()
    {
        if (!effectObject.GetComponent<ParticleSystem>().isPlaying)
        {
            effectObject.SetActive(false);
            winAudio.Stop();
        }
    }
}
