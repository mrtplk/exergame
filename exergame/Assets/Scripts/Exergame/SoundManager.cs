using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public static class SoundManager
{
    private static string sfx_mixer_name = "sfx";
    private static string music_mixer_name = "music";

    public enum Sound
    {
        FootSteps,
        FireTouch,
        WaterdropTouch,
        StoneTouch,
        BackgroundMusicStart,
        BackgroundMusicGround,
        BackgrounMusicFront,
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.tag = "Sound";

        AudioMixer mixer = Resources.Load("exergameMixer") as AudioMixer;

        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups(sfx_mixer_name)[0];
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    public static void PlayBackgroundMusic(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Backround");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        AudioMixer mixer = Resources.Load("exergameMixer") as AudioMixer;
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups(music_mixer_name)[0];
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + "not found");
        return null;
    }
}

