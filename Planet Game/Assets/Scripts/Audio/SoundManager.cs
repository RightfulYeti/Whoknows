using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
#pragma warning disable 0649

[System.Serializable]
public class RollOff
{
    public AudioRolloffMode RollOffMode;
    public float MinCeaseDistance = 0.0f;
    public float MaxDistance = 0.0f;
}

[System.Serializable]
public class GeneralAudio
{
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1;
    [Range(0f, 0.5f)]
    public float VolumeRandomness = 0.1f;
    [Range(0f, 0.5f)]
    public float PitchRandomness = 0.1f;
    [Range(-1.0f, 1.0f)]
    public float StereoPan = 0;
    public bool Mute = false;
    public bool Loop = false;
    public AudioMixerGroup output;
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    private AudioSource source;
    public GeneralAudio GeneralAudioSettings;
    public RollOff RollOffSettings;

    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public AudioSource GetSource()
    {
        return source;
    }

    public void Play()
    {
        source.volume = GeneralAudioSettings.volume * (1 + Random.Range(-GeneralAudioSettings.VolumeRandomness / 2f, GeneralAudioSettings.VolumeRandomness / 2));
        source.pitch = GeneralAudioSettings.pitch * (1 + Random.Range(-GeneralAudioSettings.PitchRandomness / 2f, GeneralAudioSettings.PitchRandomness / 2)); ;
        source.panStereo = GeneralAudioSettings.StereoPan;
        source.mute = GeneralAudioSettings.Mute;
        source.loop = GeneralAudioSettings.Loop;
        source.rolloffMode = RollOffSettings.RollOffMode;
        source.minDistance = RollOffSettings.MinCeaseDistance;
        source.maxDistance = RollOffSettings.MaxDistance;
        source.outputAudioMixerGroup = GeneralAudioSettings.output;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField]
    Sound[] sounds;

    IEnumerator SFXCoroutineNeg(int soundindex, float changeamount)
    {
        //Debug.Log("Entered Neg Coroutine");
        float time = 0.0f;
        while (time < 500.0f && sounds[soundindex].GetSource().volume >= 0.03f)
        {
            time += Time.deltaTime;
            sounds[soundindex].GetSource().volume -= changeamount;
            yield return null;
        }
    }


    IEnumerator SFXCoroutinePos(int soundindex, float changeamount)
    {
        //Debug.Log("Entered Pos Coroutine");
        float time = 0.0f;
        while (time < 500.0f && sounds[soundindex].GetSource().volume <= 0.27f)
        {
            time += Time.deltaTime;
            sounds[soundindex].GetSource().volume += changeamount;
            yield return null;
        }
        
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one SoundManager in the scene");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound " + i + " " + sounds[i].name);
            go.transform.SetParent(this.transform);
            sounds[i].SetSource(go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager could not find the requested sound: " + _name);
    }

    public Sound GetSoundAtIndex(int index)
    {
        return sounds[index];
    }

    public Sound GetSoundWithName(string soundname)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == soundname)
            {
                //Debug.Log("entered");
                return sounds[i];
            }
        }
        return null;
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }

        Debug.LogWarning("AudioManager could not find the requested sound: " + _name);
    }

    public void DialogueEffect(string _music, bool _active)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _music)
            {
                if (_active)
                {
                    sounds[i].GeneralAudioSettings.output.audioMixer.SetFloat("LowpassEffect", 1.0f);
                    StartCoroutine(SFXCoroutineNeg(i, 0.002f));
                }

                else
                {
                    sounds[i].GeneralAudioSettings.output.audioMixer.SetFloat("LowpassEffect", -80.0f);
                    StartCoroutine(SFXCoroutinePos(i, 0.002f));
                }
            }
        }
    }
}

#pragma warning restore     0649