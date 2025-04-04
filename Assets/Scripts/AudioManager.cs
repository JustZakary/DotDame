using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource bowSound;
    public AudioSource robotHurtSound;
    public AudioSource explosionSound;
    public AudioSource grabItemSound;
    public AudioSource completeLevelSound;
    public AudioSource fuseSound;

    public void playSound(string name)
    {
        switch (name)
        {
            case "bow":
                bowSound.Play();
                break;
            case "robotHurt":
                robotHurtSound.Play();
                break;
            case "explosion":
                explosionSound.Play();
                break;
            case "grabItem":
                grabItemSound.Play();
                break;
            case "completeLevel":
                completeLevelSound.Play();
                break;
            case "fuse":
                fuseSound.Play();
                break;
            default:
                Debug.LogWarning("AudioManager: Sound not found: " + name);
                break;
        }
    }
}
