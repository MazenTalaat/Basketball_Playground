using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreArea : MonoBehaviour
{
    public GameObject effectObject;
    private AudioSource winAudio;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        effectObject.SetActive(false);
        winAudio = effectObject.GetComponent<AudioSource>();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
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
            scoreText.text = "Score: " + score.ToString();
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
