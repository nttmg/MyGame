using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    [SerializeField] GameObject preObj;
    public void DisableObject() {
        gameObject.SetActive(false);
        
        if(preObj != null) {
            preObj.SetActive(true);

        }
    }
}
