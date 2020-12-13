using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceItemInWorld : MonoBehaviour
{
    public GameObject stopPlacingButton;

    private string itemName;
    private bool isPlacing = false;
    private GameObject prefab;
    private GameObject ghostPrefab;

    void Update()
    {
        if (isPlacing && ghostPrefab != null)
        {
            UpdateGhostPrefab();
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Item removed = PlayerVariables.removeFromInventory(itemName);
                if (removed != null)
                {
                    Finish();
                }
                else
                {
                    Stop();
                }
            }
        }
    }

    public void Begin(string itemName)
    {
        this.itemName = itemName;
        stopPlacingButton.SetActive(true);
        if (ghostPrefab != null)
        {
            Destroy(ghostPrefab);
        }
        this.isPlacing = true;
        this.prefab = Item.GetPrefab(itemName);
        this.ghostPrefab = Instantiate(prefab);
        InitGhostPrefab();
        UpdateGhostPrefab();
    }

    public void Finish()
    {
        stopPlacingButton.SetActive(false);
        isPlacing = false;

        Transform gpTransform = ghostPrefab.GetComponent<Transform>();
        GameObject worldObject = Instantiate(prefab, gpTransform.position, gpTransform.rotation);
        worldObject.name = itemName;
        
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

    // PRECONDITIONS: [ghostPrefab != null]
    private void InitGhostPrefab()
    {
        highlightScript gphs = ghostPrefab.GetComponent<highlightScript>();
        if (gphs != null)
        {
            Destroy(gphs);
        }
        foreach (Collider2D collider in ghostPrefab.GetComponentsInChildren(typeof(Collider2D)))
        {
            collider.isTrigger = true;
        }
    }

    // PRECONDITIONS: [isPlacing], [ghostPrefab != null]
    private bool GhostPrefabHasCollision()
    {
        foreach (Collider2D collider in ghostPrefab.GetComponentsInChildren(typeof(Collider2D)))
        {
            Collider2D[] results = new Collider2D[1];
            ContactFilter2D cFilter = new ContactFilter2D();
            cFilter.minDepth = 0;
            int amount = collider.OverlapCollider(cFilter, results);
            if (amount > 0)
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
