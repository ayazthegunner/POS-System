using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductsManager : MonoBehaviour
{
    public GameObject categoryButton;
    public Transform categoriesScrollViewContentsObj;
    public ProductElement productElementToInstantiate;
    public Transform productsGrid;
    public ProductPopup productPopup;
    public List<GameObject> instantiatedCategoryButtons;
    public List<ProductElement> generatedProductElements;
    int currentSelectedCategoryIndex;

    public GameObject addButton;

    private void OnEnable ()
    {
        UpdateCategoriesList ();
    }

    void UpdateCategoriesList ()
    {
        DestroyInstantiatedCategoryButtons();
        
        for (int i = 0; i < ReferencesManager._instance.categoriesManager.availableCategories.Count; i++)
        {
            GameObject tempObj = Instantiate (categoryButton, categoriesScrollViewContentsObj);
            tempObj.transform.GetChild (0).GetComponent<Text> ().text = ReferencesManager._instance.categoriesManager.availableCategories[i].name;
            instantiatedCategoryButtons.Add(tempObj);
        }
    }

    void DestroyInstantiatedCategoryButtons()
    {
        for (int i = 0; i < instantiatedCategoryButtons.Count; i++)
        {
            Destroy(instantiatedCategoryButtons[i]);
        }

        instantiatedCategoryButtons.Clear();
    }

    public void SelectCategory (string categoryName)
    {
        for (int i = 0; i < ReferencesManager._instance.categoriesManager.availableCategories.Count; i++)
        {
            if (ReferencesManager._instance.categoriesManager.availableCategories[i].name == categoryName)
            {
                currentSelectedCategoryIndex = i;
                RemoveAddGeneratedProducts();
                GenerateProducts ();
                addButton.SetActive (true);
                return;
            }
        }
    }

    void GenerateProducts ()
    {
        for (int i = 0; i < ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.Count; i++)
        {
            GameObject tempProd = Instantiate (productElementToInstantiate.gameObject, productsGrid);
            tempProd.GetComponent<ProductElement> ().PopulateData (ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products[i]);
            generatedProductElements.Add (tempProd.GetComponent<ProductElement> ());
        }
    }

    void RemoveAddGeneratedProducts()
    {
        for (int i = 0; i < generatedProductElements.Count; i++)
        {
            Destroy(generatedProductElements[i].gameObject);
        }

        generatedProductElements.Clear();
    }

    public void SaveProduct (Product newProd)
    {
        if (ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.Contains (newProd))
        {
            ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products[ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.IndexOf (newProd)] = newProd;

            for (int i = 0; i < generatedProductElements.Count; i++)
            {
                if (generatedProductElements[i].productInfo == newProd)
                {
                    generatedProductElements[i].PopulateData (newProd);
                    break;
                }
            }
        }
        else
        {
            AddIndividualProduct (newProd);
        }

        productPopup.gameObject.SetActive (false);
    }

    public void AddIndividualProduct (Product newProd)
    {
        GameObject tempProd = Instantiate (productElementToInstantiate.gameObject, productsGrid);
        tempProd.GetComponent<ProductElement> ().PopulateData (newProd);
        ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.Add (newProd);
        generatedProductElements.Add (tempProd.GetComponent<ProductElement> ());
    }

    public void DeleteProduct (Product newProd)
    {
        if (ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.Contains (newProd))
        {
            ReferencesManager._instance.categoriesManager.availableCategories[currentSelectedCategoryIndex].products.Remove (newProd);

            for (int i = 0; i < generatedProductElements.Count; i++)
            {
                if (generatedProductElements[i].productInfo == newProd)
                {
                    Destroy (generatedProductElements[i].gameObject);
                    generatedProductElements.RemoveAt (i);
                    break;
                }
            }

            productPopup.gameObject.SetActive (false);
        }

    }

    public void ShowProductInfo (Product newProd)
    {
        productPopup.PopulatePopup (newProd);
        productPopup.gameObject.SetActive (true);
    }

    public void ShowProductPopupAddButton ()
    {
        productPopup.PopulatePopup (null);
        productPopup.gameObject.SetActive (true);
    }
}