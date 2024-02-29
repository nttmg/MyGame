using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private GameObject target;
    public static MouseCursor Instance {get; private set;}
    public bool isTriggerZone;
    

    private void Start() {
        Instance = this;
        target = GameObject.FindWithTag("Target");
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePositionScreen = Input.mousePosition;

        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, Camera.main.transform.position.z));

        transform.position = new Vector3(mousePositionWorld.x, mousePositionWorld.y, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Target"))
        {

            isTriggerZone = true;
            Debug.Log("t");

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            
            isTriggerZone = false;
            Debug.Log("F");

        }
    }













}
