using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public GameObject pickupEffect;
    private bool canPick = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") canPick = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPick = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPick==true)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameManager.instance.AddItem(itemData);
            }
        }
    }
}
