using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealthSystem : MonoBehaviour
{

    [SerializeField]
    private float currentHealth = 10; // Vida atual do GameObject

    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Damage(float dmg)
    {
        currentHealth = currentHealth - dmg;

        if (currentHealth <= 0f)
        {
            audioSrc.Play();
            Destroy(this.gameObject, audioSrc.clip.length);
        }
    }
}
