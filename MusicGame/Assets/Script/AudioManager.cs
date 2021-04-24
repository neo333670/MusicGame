using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Source;

    string path;
    string format;
    string songName_1;
    float[] samples;
    float threshold;
    int counter = 0;

    // Start is called before the first frame update
    public void Awake()
    {
        path = "Assets/Audio/";
        format = ".mp3";
        songName_1 = "bensound-dreams";
        samples = new float[64];
        threshold = 0.001f;

        var clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path + songName_1 + format);
        Source.clip = clip;
    }

    public void Play(float DeltaTime)
    {
        Debug.Log("Play music");
        Source.PlayDelayed(DeltaTime);

    }

    void Getdata() {
        Source.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        for (int i = 15; i < 64; i += 16) {
            if (samples[i] > threshold) {
                GameManeger.CreateButton((MusicButton)Random.Range(0, 4));
            }
        }
    }

    private void FixedUpdate()
    {
        if (counter < 25)
        {
            counter++;
            return;
        }
        else {
            counter = 0;
        }

        Getdata();
    }
}