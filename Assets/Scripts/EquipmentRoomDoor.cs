using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentRoomDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextScene;
    public Item item;
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {//钥匙开门
            if (GameManager.instance.items.Contains(item))
            {
                GameManager.instance.RemoveItem(item);
                nextScene.gameObject.SetActive(true);
            }
           
           
        }
        
    }
}
