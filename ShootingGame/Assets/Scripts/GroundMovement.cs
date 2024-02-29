using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] Tilemap tilemap1;
    [SerializeField] Tilemap tilemap2;
    [SerializeField] float speed;

    private float mapWidth;

    private Vector3 startPosition1;
    private Vector3 startPosition2;

    // Start is called before the first frame update
    void Start()
    {
        mapWidth = tilemap1.size.x * tilemap1.cellSize.x - .8f;
        startPosition1 = tilemap1.transform.position;
        startPosition2 = tilemap2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameActive) {
            GroundCtrl();
            
        }

    }

    void GroundCtrl() {
        tilemap1.transform.position += Vector3.left * speed * Time.deltaTime;
        tilemap2.transform.position += Vector3.left * speed * Time.deltaTime;

        if (tilemap1.transform.position.x < startPosition1.x - mapWidth)
        {
            tilemap1.transform.position = tilemap2.transform.position + Vector3.right * mapWidth;



        }

        if (tilemap2.transform.position.x < startPosition1.x - mapWidth)
        {
            tilemap2.transform.position = tilemap1.transform.position + Vector3.right * mapWidth;

        }
    }
}
