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
    void Update()
    {
        
    }
    /**private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && robotMoveScript.isSeekingPosition == true && GetComponent<isHoldable>() != null)
        {
            robotMoveScript.isSeekingPosition = false;
            robotMoveScript.wantedCollectObject = gameObject;
            robotMoveScript.chosenGameObject = gameObject;
            //robotMoveScript.isMovingToPosition = true;
            //robotMoveScript.wantedPosition = new Vector2(transform.position.x, transform.position.y);
            
        }
    }**/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (robotMoveScript.isMovingToPosition == true)
        {
            robotMoveScript.chosenGameObject = gameObject;
            robotMoveScript.isSeekingPosition = false;
        }
    }
}
