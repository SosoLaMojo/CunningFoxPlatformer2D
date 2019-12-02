using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    List<AudioSource> audioSources;

    [SerializeField] AudioMixer playerJumpMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = new List<AudioSource>();

        for (int i = 0; i < 5; i++)
        {
            GameObject instance = new GameObject();
            instance.transform.parent = transform;
            instance.name = "AudioSource" + i;

           // audioSources.Add(instance.AddComponent<AudioSource>());
            //audioSources[i].outputAudioMixerGroup = playerJumpMixer.outputAudioMixerGroup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
