using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource defaultSound;
    [SerializeField] private AudioSource bossSound;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;
    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootClip);
    }
    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadClip);
    }
    public void PlayEnergySound()
    {
        audioSource.PlayOneShot(energyClip);
    }
    public void BackGroundSound()
    {
        bossSound.Stop();
        defaultSound.Play();
        
    }
    public void BossSound()
    {
        defaultSound.Stop();
        bossSound.Play();
        
    }
    public void StopAllSound()
    {
        bossSound.Stop();
        defaultSound.Stop();
        audioSource.Stop();
    }
}
