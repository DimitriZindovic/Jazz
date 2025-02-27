using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    private void Start()
    {
        // S'assurer que l'audio source est bien assignée
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Par défaut, couper la musique au départ
        audioSource.Stop();
    }

    // Méthode pour changer la musique en fonction de la pièce
    public void ChangeMusic(AudioClip newMusic)
    {
        // Si la musique est différente de celle qui est actuellement jouée, on la change
        if (audioSource.clip != newMusic)
        {
            audioSource.clip = newMusic;
            audioSource.Play();  // Joue la musique
        }
    }
}
