using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfter : MonoBehaviour
{
    [SerializeField]
    private GameObject deadSmoke;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "DeathVFX")
        {
            Destroy(gameObject, 0.5f);
        }
        if (gameObject.tag == "VFX")
        {
            Destroy(gameObject, 0.3f);
        }
        if (gameObject.tag == "dead")
        {
            Instantiate(deadSmoke, transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
