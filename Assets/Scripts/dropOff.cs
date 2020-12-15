using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class dropOff : MonoBehaviour
{
    public AudioClip collectSound;
    
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<isHoldable>() == true && robotMoveScript.isGrabbing == false){
            PlayerVariables.sendMessage("System", "Item detected.");
            AudioSource.PlayClipAtPoint(collectSound, Vector3.zero);
            collision.gameObject.SetActive(false);
            PlayerVariables.addToInventory(collision.gameObject.GetComponent<itemIdentifier>().name);
        }
    }
}
