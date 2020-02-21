using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPopup : MonoBehaviour
{
    [SerializeField]
    private Image categoryImage;
    [SerializeField]
    private InputField categoryNameInputField;
    [SerializeField]
    private InputField categoryDetailsInputField;

    private Category currentCategory;

    public GameObject deleteButton;

    public void PopulatePopup (Category newCat)
    {
        categoryNameInputField.text = "";
        categoryDetailsInputField.text = "";

        if (newCat != null)
        {
            currentCategory = newCat;

            categoryImage = currentCategory.img;
            categoryNameInputField.text = currentCategory.name;
            categoryDetailsInputField.text = currentCategory.details;

            deleteButton.SetActive(true);

            Debug.Log("category exists");
        }
        else
        {
            currentCategory = new Category();

            Debug.Log("category does not exist creating new cat");

            deleteButton.SetActive(false);
        }
    }

    public void SaveCategory ()
    {
        UpdateInfo();

        if (currentCategory.name == "")
        {
            Debug.LogError ("Category Name is empty");
        }
        else if (currentCategory.details == "")
        {
            Debug.Log ("Category Details are empty");
        }
        else
        {
            ReferencesManager._instance.categoriesManager.SaveCategory (currentCategory);
        }
    }

    public void DeleteCategory ()
    {
        if (currentCategory != null)
        {
            ReferencesManager._instance.categoriesManager.DeleteCategory (currentCategory);
        }
    }
    public void UpdateInfo ()
    {
        currentCategory.name = categoryNameInputField.text;
        currentCategory.details = categoryDetailsInputField.text;

        if (currentCategory.img != null)
            currentCategory.img = categoryImage;

    }
}