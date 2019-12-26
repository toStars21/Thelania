using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip Sound;

    private Button _button => GetComponent<Button>();
    private AudioSource _source => GetComponent<AudioSource>();
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        _source.clip = Sound;
        _source.playOnAwake = false;

        _button.onClick.AddListener(() => PlaySound());
    }


    void PlaySound()
    {
        _source.PlayOneShot(Sound);
    }
}
