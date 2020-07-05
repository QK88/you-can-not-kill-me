using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager :MonoBehaviour
{
    public static GameManager instance;
    public List<Item> items = new List<Item>();//the list of items
    public List<int> itemsNum = new List<int>();//the number of each item
    //public GameObject[] slots;

    public bool isPaused;//游戏的状态，true暂停，false游戏继续
    public bool isBag;//背包是否展开；
    public bool clickBag;//是否点击背包
    public bool clickMenu;//是否点击游戏暂停
    public bool isSucceed;//成功通关
    public bool isBoss;
    public bool isDeath;


    public int cycle=0;
    //public int panel;//当前处于的panelID
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {//如果运行的是医院或者器材室场景
            UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
            ui.DisplayItems();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2|| SceneManager.GetActiveScene().buildIndex == 3)
        {//如果运行的是医院或者器材室场景
            UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
            ui.DisplayItems();
        }
       
    }
   
    public void AddItem(Item _item)
    {
        // if did not have one exciting
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemsNum.Add(1);
        }
        else
        { //if not
            Debug.Log("you have aleardy have this one");
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == _item)
                {
                    itemsNum[i]++;
                }
            }
        }
        UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        ui.DisplayItems();//to show the change
    }

    public void RemoveItem(Item _item)
    {
        //if we have this item
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == _item)
                {
                    itemsNum[i]--;
                    if (itemsNum[i] == 0)
                    {
                        //the item has been thrown away
                        items.Remove(_item);
                        itemsNum.Remove(itemsNum[i]);
                    }
                }
            }
        }
        //if not
        else
        {
            Debug.LogError("you dont have this one");
        }
        UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        ui.DisplayItems();
    }
}
