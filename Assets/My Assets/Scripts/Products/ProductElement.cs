using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductElement : MonoBehaviour
{
     public Product productInfo;

    [SerializeField]    
    private Image prodImg;

    [SerializeField]
    private Text prodName;

    public void ShowCategoryInformation()
    {
        ReferencesManager._instance.productsManager.ShowProductInfo(productInfo);
    }

    public void PopulateData(Product newProd)
    {
        productInfo = newProd;

        if(newProd.img)
            prodImg = newProd.img;
            
        prodName.text = newProd.name;
    }
}
