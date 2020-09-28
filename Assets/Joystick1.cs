using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick1 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image touch;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;
		public float joystickX;
		public float joystickY;

    void Start(){
        touch = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData ped){
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(touch.rectTransform, ped.position, ped.pressEventCamera, out pos)){
           pos.x = (pos.x / touch.rectTransform.sizeDelta.x);
           pos.y = (pos.y / touch.rectTransform.sizeDelta.y); 
		   float x =(touch.rectTransform.pivot.x==1f) ? pos.x * 2f : pos.x * 1f;
		   float y =(touch.rectTransform.pivot.y==1f) ? pos.y * 2f : pos.y * 1f;
		   inputVector = new Vector3(x, y, 0);

            //inputVector = new Vector2(pos.x * 2+0, pos.y * 2-0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x*(touch.rectTransform.sizeDelta.x/2f), inputVector.y*(touch.rectTransform.sizeDelta.y/2f));

        }

    }
    public void OnPointerDown(PointerEventData ped){
        OnDrag(ped);

    }
    public void OnPointerUp(PointerEventData ped){
inputVector = Vector2.zero;
joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
    public float Horizontal(){
        if(inputVector.x!=0) {
			
			
			
		  
		return inputVector.x;
		}
        else 
		
		
		return Input.GetAxis("Horizontal");
		
    }
    public float Vertical(){
        if(inputVector.y!=0) {
			
			
			
			return inputVector.y;
		}
        else return Input.GetAxis("Vertical");
    }
    
}
