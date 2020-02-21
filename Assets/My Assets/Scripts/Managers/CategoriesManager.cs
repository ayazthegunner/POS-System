using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesManager : MonoBehaviour
{
    public List<Category> availableCategories = new List<Category> ();

    [SerializeField]
    private CategoryElement categoryElement;
    [SerializeField]
    private GameObject categoryGrid;
    [SerializeField]
    private CategoryPopup categoryPopup;

    private List<CategoryElement> categoryElementsGenerated = new List<CategoryElement> ();

    private void Start ()
    {
        PopulateCategories ();
    }

    void PopulateCategories ()
    {
        // DeleteAllCategoriesGeneratedElements();
        for (int i = 0; i < availableCategories.Count; i++)
        {
            CategoryElement newCategoryElement = Instantiate (categoryElement.gameObject, categoryGrid.transform).GetComponent<CategoryElement> ();
            newCategoryElement.PopulateData (availableCategories[i]);
        }
    }

    public void SaveCategory (Category newCat)
    {
        // if(availableCategories.Contains(newCat))
        // {
        //     Debug.Log("is in the list");
        // }

        bool categoryFound = false;
        for (int i = 0; i < availableCategories.Count; i++)
        {
            // if (availableCategories[i].name == newCat.name)
            // {
            if (availableCategories[i].isSelected)
            {
                Debug.Log ("Category available");
                availableCategories[i] = newCat;
                categoryFound = true;

                UpdateExistingCategoryElement (i, availableCategories[i]);
                categoryPopup.gameObject.SetActive (false);

                return;
            }
        }

        if (!categoryFound)
        {
            Debug.Log ("Category not available");
            AddIndividualCategory (newCat);

            categoryPopup.gameObject.SetActive (false);
        }
    }

    void AddIndividualCategory (Category newCat)
    {
        CategoryElement newCategoryElement = Instantiate (categoryElement.gameObject, categoryGrid.transform).GetComponent<CategoryElement> ();
        newCategoryElement.PopulateData (newCat);
        availableCategories.Add (newCat);
        categoryElementsGenerated.Add (newCategoryElement);
    }

    void UpdateExistingCategoryElement (int index, Category newCatData)
    {
        categoryElementsGenerated[index].PopulateData (newCatData);
    }

    public void DeleteCategory (Category categoryToDelete)
    {
        for (int i = 0; i < availableCategories.Count; i++)
        {
            // if (availableCategories[i].name == categoryToDelete.name)
            // {

            if (availableCategories[i].isSelected)
            {
                Debug.Log ("Category exists: Deleting");

                int tempIndex = availableCategories.IndexOf (categoryToDelete);
                Destroy (categoryElementsGenerated[tempIndex].gameObject);
                categoryElementsGenerated.RemoveAt (tempIndex);
                availableCategories.RemoveAt (tempIndex);
                categoryPopup.gameObject.SetActive (false);

                return;
            }
        }

        Debug.Log ("Category does not exist");
    }

    public void ShowCategoryInformation (Category newCat)
    {
        for (int i = 0; i < availableCategories.Count; i++)
        {
            if (availableCategories[i].name == newCat.name)
            {
                Debug.Log ("Available");
                availableCategories[i].isSelected = true;
            }
        }

        categoryPopup.PopulatePopup (newCat);
        categoryPopup.gameObject.SetActive (true);
    }

    public void ShowCategoryInformationFromAddButton ()
    {
        categoryPopup.PopulatePopup (null);
        categoryPopup.gameObject.SetActive (true);
    }

    public void ResetSelectedState ()
    {
        for (int i = 0; i < availableCategories.Count; i++)
        {
            if (availableCategories[i].isSelected)
            {
                availableCategories[i].isSelected = false;
                return;
            }
        }
    }
}