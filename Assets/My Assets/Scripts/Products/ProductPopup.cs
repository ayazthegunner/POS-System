using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductPopup : MonoBehaviour
{
    [SerializeField]
    private Image productImage;
    [SerializeField]
    private InputField productNameInputField;
    [SerializeField]
    private InputField productPriceInputField;

    private Product currentProduct;

    public GameObject deleteButton;

    public void PopulatePopup (Product newProd)
    {
        productNameInputField.text = "";
        productPriceInputField.text = "";

        if (newProd != null)
        {
            currentProduct = newProd;

            productImage = currentProduct.img;
            productNameInputField.text = currentProduct.name;
            productPriceInputField.text = currentProduct.price;

            deleteButton.SetActive(true);

            Debug.Log("product exists");
        }
        else
        {
            currentProduct = new Product();

            Debug.Log("product does not exist creating new cat");

            deleteButton.SetActive(false);
        }
    }

    public void SaveProduct ()
    {
        UpdateInfo();

        if (currentProduct.name == "")
        {
            Debug.LogError ("Category Name is empty");
        }
        else if (currentProduct.price == "")
        {
            Debug.Log ("Category Details are empty");
        }
        else
        {
            ReferencesManager._instance.productsManager.SaveProduct (currentProduct);
        }
    }

    public void DeleteProduct ()
    {
        if (currentProduct != null)
        {
            ReferencesManager._instance.productsManager.DeleteProduct (currentProduct);
        }
    }
    public void UpdateInfo ()
    {
        currentProduct.name = productNameInputField.text;
        currentProduct.price = productPriceInputField.text;

        if (currentProduct.img != null)
            currentProduct.img = productImage;

    }
}
