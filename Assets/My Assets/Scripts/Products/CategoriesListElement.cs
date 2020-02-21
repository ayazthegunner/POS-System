using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesListElement : MonoBehaviour
{
    public void OnPressButton ()
    {
        ReferencesManager._instance.productsManager.SelectCategory(gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text);
    }
}