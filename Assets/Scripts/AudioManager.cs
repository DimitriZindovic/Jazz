using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton
    public TextMeshProUGUI subtitleText;
    public Image bgc;
    private AudioSource source;

    private void Awake()
    {
        // S'assurer qu'il n'y a qu'un seul AudioManager
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

    public IEnumerator PlayConversation(AudioObject[] conversation)
    {
        foreach (AudioObject audio in conversation)
        {
            bgc.gameObject.SetActive(true);
            source.PlayOneShot(audio.clip);
            subtitleText.text = audio.subtitle;
            yield return new WaitForSeconds(audio.clip.length);
        }
        subtitleText.text = "";
        bgc.gameObject.SetActive(false);
    }
}
