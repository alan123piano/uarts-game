using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHoldable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (robotMoveScript.isMovingToPosition == true)
        {
            if(robotMoveScript.isGrabbing == false){
                robotMoveScript.chosenGameObject = gameObject;
                robotMoveScript.isSeekingPosition = false;
            }
            else{
                print("already grabbing somehting");
                robotMoveScript.isMovingToPosition = false;
            }
            

        }
    }
}
