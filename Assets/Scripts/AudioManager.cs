using System.Collections;
using System.Collections.Generic; // Ajout pour utiliser Queue<>
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public TextMeshProUGUI subtitleText;
    public Image bgc;
    private AudioSource source;

    private bool isPlaying = false; // Vérifie si un dialogue est en cours
    private Queue<AudioObject[]> dialogueQueue = new Queue<AudioObject[]>(); // File d’attente des dialogues

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        subtitleText.text = "";
        bgc.gameObject.SetActive(false);
    }

    public void StartConversation(AudioObject[] conversation)
    {
        dialogueQueue.Enqueue(conversation); // Ajoute à la file d’attente

        if (!isPlaying) // Si aucun dialogue ne joue, on commence
        {
            StartCoroutine(PlayNextConversation());
        }
    }

    private IEnumerator PlayNextConversation()
    {
        while (dialogueQueue.Count > 0)
        {
            isPlaying = true; // Un dialogue est en cours
            AudioObject[] conversation = dialogueQueue.Dequeue(); // Récupère le premier de la file
            
            foreach (AudioObject audio in conversation)
            {
                bgc.gameObject.SetActive(true);
                subtitleText.text = audio.subtitle;
                source.PlayOneShot(audio.clip);
                yield return new WaitForSeconds(audio.clip.length);
            }

            subtitleText.text = "";
            bgc.gameObject.SetActive(false);
            isPlaying = false; // Fin du dialogue

            yield return new WaitForSeconds(0.5f); // Petite pause entre les dialogues
        }
    }
}
