using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    public GameObject followGameObject;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        targetPosition.z = -1;
    }
}
