using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public GameObject scythePrefab;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void ScyhteSkill()
    {
        Instantiate(scythePrefab, player.gameObject.transform.position, Quaternion.identity);
    }
}
