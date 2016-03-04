using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inputGuiController : MonoBehaviour
{
    

    public GameObject prefab;
    public GameObject troutprefab;
    public GameObject minnowprefab;
    public GameObject lgmthbassprefab;
    public Dropdown mydropdown;
    public int dropvalue;
    public bool dropChanged;
    public GameObject focusedGuiElement;
   

    public void OnMouseDown()
    {
        if (mydropdown.value == 0) { prefab = troutprefab; }
        if (mydropdown.value == 1) { prefab = minnowprefab; }
        if (mydropdown.value == 2) { prefab = lgmthbassprefab; }
        focusedGuiElement = EventSystem.current.currentSelectedGameObject;

        if (focusedGuiElement == null )
        {
            
            Instantiate(prefab, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), new Quaternion(0, 0, 0, 0));
        }

    }

    // Use this for initialization
    void Start()
    {
        
        
    }

   

    // Update is called once per frame
    void Update()
    { 
        
        
        dropvalue = mydropdown.value;
       if (Input.GetMouseButtonDown(0) == true) { OnMouseDown(); }
        
    }
}
