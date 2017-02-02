using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class input : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler {

   // public GameObject icon;
	// Use this for initialization
    private Image controller;
    private Vector3 inputVector;
	void Start () {
        controller = GetComponent<Image>();
       // controller.rectTransform.anchoredPosition = new Vector2(-Screen.width/2,Screen.height/2);
    }

    public virtual void OnPointerDown(PointerEventData ped){
       // controller.rectTransform.anchoredPosition = new Vector2(ped.position.x,ped.position.y);
        Debug.Log(ped.position.x + " " + ped.position.y);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
    public virtual void OnDrag(PointerEventData ped)
    {

    }
    //public void createIcon(Vector2 touchPos)
    //{
    //  //SetActive(true);
    //    //icon.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
    //}

    //public void destroyIcon()
    //{
    //    icon.SetActive(false);
    //}
    void Update()
    {
//        Debug.Log(Input.GetTouch(0).position.x + " " + Input.GetTouch(0).position.y);

    }
}
