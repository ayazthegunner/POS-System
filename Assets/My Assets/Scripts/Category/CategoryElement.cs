using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryElement : MonoBehaviour
{
    public Category categoryInfo;

    [SerializeField]    
    private Image catImg;

    [SerializeField]
    private Text catName;

    public void ShowCategoryInformation()
    {
        ReferencesManager._instance.categoriesManager.ShowCategoryInformation(categoryInfo);
    }

    public void PopulateData(Category newCat)
    {
        categoryInfo = newCat;

        if(newCat.img)
            catImg = newCat.img;
            
        catName.text = newCat.name;
    }
}
