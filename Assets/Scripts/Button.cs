using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioSource effect;

    public void PlayEffect()
    {
        effect.Play();
    }
}
