using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public AudioSource hoverSound;
    public void OnMouseEnter()
    {
        hoverSound.Play();
    }
}
