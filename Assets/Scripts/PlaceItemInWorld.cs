using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemInWorld : MonoBehaviour
{
    public GameObject stopPlacingButton;

    private bool isPlacing = false;
    private GameObject prefab;
    private GameObject ghostPrefab;

    void Update()
    {
        if (isPlacing && ghostPrefab != null)
        {
            UpdateGhostPrefab();
        }
    }

    public void Begin(string itemName)
    {
        stopPlacingButton.SetActive(true);
        if (ghostPrefab != null)
        {
            Destroy(ghostPrefab);
        }
        this.isPlacing = true;
        this.prefab = Item.GetPrefab(itemName);
        this.ghostPrefab = Instantiate(prefab);
        Destroy(ghostPrefab.GetComponent<highlightScript>());
        UpdateGhostPrefab();
    }

    public void Finish()
    {
        stopPlacingButton.SetActive(false);
        isPlacing = false;

        Transform gpTransform = ghostPrefab.GetComponent<Transform>();
        GameObject worldObject = Instantiate(prefab, gpTransform.position, gpTransform.rotation);
        
        if (ghostPrefab != null)
        {
            Destroy(ghostPrefab);
        }
    }

    public void Stop()
    {
        stopPlacingButton.SetActive(false);
        if (ghostPrefab != null)
        {
            Destroy(ghostPrefab);
        }
        isPlacing = false;
    }

    private Vector3 MousePosInWorld()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        pos.z = 0;
        return pos;
    }

    // PRECONDITIONS: [isPlacing], [ghostPrefab != null]
    private bool GhostPrefabHasCollision()
    {
        foreach (Collider2D collider in gameObject.GetComponentsInChildren(typeof(Collider2D)))
        {
            Collider2D[] results = new Collider2D[1];
            collider.OverlapCollider(new ContactFilter2D().NoFilter(), results);
            if (results[0] != null)
            {
                return true;
            }
        }
        return false;
    }

    // PRECONDITIONS: [isPlacing], [ghostPrefab != null]
    private void UpdateGhostPrefab()
    {
        Transform gpTransform = ghostPrefab.GetComponent<Transform>();
        SpriteRenderer gpSpriteRenderer = ghostPrefab.GetComponent<SpriteRenderer>();

        gpTransform.position = MousePosInWorld();
        if (GhostPrefabHasCollision())
        {
            gpSpriteRenderer.color = new Color(1f, 0f, 0f, 0.5f);
        }
        else
        {
            gpSpriteRenderer.color = new Color(0f, 1f, 0f, 0.5f);
        }
    }
}
