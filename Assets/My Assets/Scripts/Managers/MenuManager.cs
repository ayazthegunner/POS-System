using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum MenuStates
    {
        Login ,
        MainMenu,
        AddProduct,
        Inventory,
        MakeBill
    }

    public MenuStates defaultState;
    public MenuStates currentState;
    public MenuStates prevState;

    public GameObject[] allPanels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeState(MenuStates newState)
    {
        prevState = currentState;
        currentState = newState;

        allPanels[(int)prevState].SetActive(false);
        allPanels[(int)currentState].SetActive(true);
    }
}
