[System.Serializable]
public class Category
{
    public bool isSelected;
    public UnityEngine.UI.Image img;
    public string name;
    public string details;
    public System.Collections.Generic.List<Product> products = new System.Collections.Generic.List<Product>();
}

[System.Serializable]
public class Product
{
    public bool isSelected;
    public UnityEngine.UI.Image img;
    public string name;
    public string price;
}