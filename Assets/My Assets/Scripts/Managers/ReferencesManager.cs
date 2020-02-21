using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager _instance;

    public CategoriesManager categoriesManager;
    public ProductsManager productsManager;

    private void Awake ()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy (gameObject);
    }
}