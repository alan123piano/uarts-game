using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public GameObject followGameObject;
    private Vector3 targetPosition;
    private int[,] camBounds = { { -3, 35 }, { -5, 25 } }; // low x, high x, low y, high y

    private void Start()
    {
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 4 * Time.deltaTime);
        if (shovelRobotMove.moveActive)
        {
            targetPosition = new Vector3(followGameObject.transform.position.x, followGameObject.transform.position.y, -1);
        }
        else
        {
            //targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPosition.x += Input.GetAxisRaw("Horizontal") * 12 * Time.deltaTime;
            //targetPosition.y += Input.GetAxisRaw("Vertical") * 12 * Time.deltaTime;
            targetPosition += new Vector3(Input.GetAxisRaw("Horizontal") * 12 * Time.deltaTime, Input.GetAxisRaw("Vertical") * 12 * Time.deltaTime, -1).normalized;
        }
        if (targetPosition.x < camBounds[0,0]) { targetPosition.x = camBounds[0,0]; }
        if (targetPosition.x > camBounds[0,1]) { targetPosition.x = camBounds[0,1]; }
        if (targetPosition.y < camBounds[1, 0]) { targetPosition.y = camBounds[1,0]; }
        if (targetPosition.y > camBounds[1, 1]) { targetPosition.y = camBounds[1, 1]; }
        targetPosition.z = -1;

    }
}
