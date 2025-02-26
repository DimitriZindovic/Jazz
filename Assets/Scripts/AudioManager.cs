using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    public AudioObject[] conversation;
    public TextMeshProUGUI subtitleText;
    public Image bgc;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(PlayConversation());

        }
    }
    IEnumerator PlayConversation() {
        foreach (AudioObject audio in conversation)
        {
            source.PlayOneShot(audio.clip);
            subtitleText.text = audio.subtitle;
            yield return new WaitForSeconds(audio.clip.length);

        }
        subtitleText.text = "";
        bgc.gameObject.SetActive(false);
    }
}
