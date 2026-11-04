using UnityEngine;

public class SlotMachineAudio : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip leverPull;
    [SerializeField] private AudioClip reelSpin;
    [SerializeField] private AudioClip reelStop;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip jackpot;

    public void PlayButtonClick()
    {
        Play(buttonClick);
    }

    public void PlayLeverPull()
    {
        Play(leverPull);
    }

    public void PlayReelSpin()
    {
        Play(reelSpin);
    }

    public void PlayReelStop()
    {
        Play(reelStop);
    }

    public void PlayWin()
    {
        Play(win);
    }

    public void PlayJackpot()
    {
        Play(jackpot);
    }

    private void Play(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;

        audioSource.PlayOneShot(clip);
    }
}