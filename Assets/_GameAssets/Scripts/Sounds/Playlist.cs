using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public AudioClip[] songs;
    
    private int idSong = -1;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (songs.Length<=1){
            Debug.LogError("Este Script sólo se puede utilizar para 2 o más canciones");
            return;
        }
        if (!audioSource.isPlaying){
            idSong++;
            if(idSong==songs.Length) idSong=0;
            audioSource.PlayOneShot(songs[idSong]);
        }
    }
}
