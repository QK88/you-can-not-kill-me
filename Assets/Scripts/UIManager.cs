using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image bagIcon;
    public GameObject bagMenu;
    public GameObject gameMenu;
    public Image gameIcon;
    public GameObject[] slots;



    private void Start()
    {
        bagMenu.gameObject.SetActive(false);
        gameMenu.gameObject.SetActive(false);
        gameIcon.gameObject.SetActive(true);
        bagIcon.gameObject.SetActive(true);
    }
    private void Update()
    {
        bagController();
        menuController();
    }
    private void bagController()
    {
        if (Input.GetKeyDown(KeyCode.B) || GameManager.instance.clickBag)
        {//code: B  or press the image[bagIcon]
            if (GameManager.instance.isBag)
            {
                if (GameManager.instance.clickBag) GameManager.instance.clickBag = false;
                //opened the bag, set false, close
                bagMenu.gameObject.SetActive(false);
                bagIcon.gameObject.SetActive(true);
                GameManager.instance.isBag = false;
            }
            else
            {
                if (GameManager.instance.clickBag) GameManager.instance.clickBag = false;
                //closed the bag, set true ,open
                bagMenu.gameObject.SetActive(true);
                bagIcon.gameObject.SetActive(false);
                GameManager.instance.isBag = true;
            }
        }
    }
    private void menuController()
    {//控制menu，esc调度菜单，点击跳转菜单，跳转后esc依然回到游戏


        if (Input.GetKeyDown(KeyCode.Escape) || GameManager.instance.clickMenu)
        {
            //if game paused,resume the game
            //if game resume, pause the game
            if (GameManager.instance.isPaused)
            {
                if (GameManager.instance.clickMenu) GameManager.instance.clickMenu = false;
                Resume();
            }
            else
            {
                if (GameManager.instance.clickMenu) GameManager.instance.clickMenu = false;
                Pause();
            }

        }
        //设置菜单

    }
    private void Resume()
    {
        gameMenu.gameObject.SetActive(false);
        gameIcon.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
        //ChoosePanel();
    }
    private void Pause()
    {
        gameIcon.gameObject.SetActive(false);
        gameMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
        //ChoosePanel();
    }


    // Start is called before the first frame update
   public void DisplayItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < GameManager.instance.items.Count)
            {
                //there is a item
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.instance.items[i].itemSprite;
                //update slot count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = GameManager.instance.itemsNum[i].ToString();
                //update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //there is not a item
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                //update slot count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
                //update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }

        }
        //根据是否有对话框设置属性

    }
}
