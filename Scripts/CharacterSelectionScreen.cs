using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScreen : MonoBehaviour
{
 
    public void PickFirst()
    {
        SceneManager.LoadScene(2);
    }

    public void PickSecond()
    {
        SceneManager.LoadScene(3);
    }
    public void PickThird()
    {
        SceneManager.LoadScene(4);
    }
    public void PickFourth()
    {
        SceneManager.LoadScene(5);
    }
}
