using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager _instance;

    public CategoriesManager categoriesManager;

    private void Awake ()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy (gameObject);
    }
}