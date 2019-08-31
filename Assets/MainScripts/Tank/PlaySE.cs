using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour {
    [SerializeField] private AudioClip m_Clip;
    private AudioSource m_AudioSource;

    public void Start() {
        m_AudioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySoundEffect() {
        m_AudioSource.PlayOneShot(m_Clip);
    }
}
