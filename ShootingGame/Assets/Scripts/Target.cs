using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour
{

    public float speed;
    [SerializeField] float minYPos;
    [SerializeField] float maxYPos;
    public GameObject difficultObj;
    private float minXPos = -6f;
    private float maxXPos = 6f;


    [SerializeField] int pointValue = 1;
    






    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = RandomPosition();
        StartCoroutine(MoveTarget(startPosition));

    }



    IEnumerator MoveTarget(Vector3 startPosition)
    {
        Vector3 targetStartPosition = startPosition;
        // Vector3 targetEndPosition = targetStartPosition + Vector3.up * 5f;
        Vector3 targetEndPosition = new Vector3(targetStartPosition.x, maxYPos, targetStartPosition.z);


        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(targetStartPosition, targetEndPosition, elapsedTime);
            elapsedTime += Time.deltaTime * speed;
            yield return null;
        }

        yield return new WaitForSeconds(.7f);

        // targetStartPosition = transform.position;
        // targetEndPosition = new Vector3(transform.position.x, minYPos, transform.position.z);

        // elapsedTime = 0f;
        // while (elapsedTime < 1f)
        // {
        //     transform.position = Vector3.Lerp(targetStartPosition, targetEndPosition, elapsedTime);
        //     elapsedTime += Time.deltaTime * speed;
        //     yield return null;
        // }

        Destroy(gameObject);
    }



    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(minXPos, maxXPos), minYPos, transform.position.z);
    }





    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Mouse"))
    //     {

    //         isTriggerZone = true;

    //     }
    //     else
    //     {
    //         isTriggerZone = false;
    //     }
    // }



    private void Update()
    {

        UpdateScore();





    }


    public void UpdateScore() {

        if (Input.GetMouseButtonDown(0))
        {

            if (MouseCursor.Instance.isTriggerZone)
            {
                Destroy(gameObject);
                GameManager.Instance.UpdateScore(pointValue);
                Debug.Log(GameManager.Instance.score);
            }
            else
            {
                GameManager.Instance.UpdateScore(-5);
                Debug.Log(GameManager.Instance.score);
            }
        }
    }


    









}
