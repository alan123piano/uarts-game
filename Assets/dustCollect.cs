using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        PlayerVariables.addTaskProgress("clearAreaOfDust", 1);
    }
}
