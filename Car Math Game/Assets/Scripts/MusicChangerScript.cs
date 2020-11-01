using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangerScript : MonoBehaviour
{

    [SerializeField] AudioSource[] songs;

    int numberOfSongs;
    int currentMusicIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        numberOfSongs = songs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusic()
    {
        songs[currentMusicIndex].Stop();
        currentMusicIndex = (currentMusicIndex + 1) % numberOfSongs;
        songs[currentMusicIndex].Play();
    }
}
