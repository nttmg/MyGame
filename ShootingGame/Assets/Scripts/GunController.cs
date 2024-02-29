using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform mousePosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mousePosition.position.x, transform.position.y, transform.position.z);
    }

    
}
