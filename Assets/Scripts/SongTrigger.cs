using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public SongManager songManager;
    public AudioClip musicToPlay; // La musique à jouer quand on entre dans la zone de la pièce

    // Cette fonction sera appelée lorsqu'un objet entre dans la zone de trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si c'est le joueur (en supposant que le joueur a un tag "Player")
        if (other.CompareTag("Player"))
        {
            // Change la musique
            songManager.ChangeMusic(musicToPlay);
        }
    }
}
