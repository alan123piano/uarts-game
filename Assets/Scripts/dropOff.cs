using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOff : MonoBehaviour
{
    public GameObject mainframe;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && robotMoveScript.isSeekingPosition == true && GetComponent<dropOff>() != null)
        {
            robotMoveScript.isSeekingPosition = false;
            robotMoveScript.wantedDropObject = gameObject;
            robotMoveScript.chosenGameObject = gameObject;
            //robotMoveScript.isMovingToPosition = true;
            //robotMoveScript.wantedPosition = new Vector2(transform.position.x, transform.position.y);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (robotMoveScript.isMovingToPosition == true && robotMoveScript.isGrabbing == true)
        {
            robotMoveScript.dropOff();
            PlayerVariables.addTaskProgress("solar1", 1);
        }
    }
}
