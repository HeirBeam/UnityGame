using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;
    public static string isButtonInteractable;
    private void Awake() {
        rect = GetComponent<RectTransform>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Z))
            Interact();
        
    }



    private void ChangePosition(int _change) {
        
        currentPosition += _change;
        //Debug.Log("CURRENT POSITION IS =====" +currentPosition);

        if( currentPosition < 0) {
            currentPosition = options.Length -1;
        }
        else if (currentPosition > options.Length -1){
            currentPosition = 0;
        }
        //assign the y position of the current arrow
        isButtonInteractable =options[currentPosition].GetComponent<Button>().interactable.ToString();
        //Debug.Log("The current buttons interactability is " + isButtonInteractable);
        while(isButtonInteractable == "False"){
            currentPosition += _change;
            isButtonInteractable =options[currentPosition].GetComponent<Button>().interactable.ToString();
        }
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y,0 );
    }
    private void Interact() {
        string isButtonInteractable =options[currentPosition].GetComponent<Button>().interactable.ToString();
        //Debug.Log("the button interactable is = " +isButtonInteractable);
        if (isButtonInteractable == "True") { 
            options[currentPosition].GetComponent<Button>().onClick.Invoke();
        }
    }
}
