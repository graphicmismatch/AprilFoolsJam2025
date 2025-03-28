using UnityEngine;
using UnityEngine.UI;

public class ClothingObject : MonoBehaviour
{

    public bool isDirty = true;
    public Clothes clothingInfo;
    public Image clothes;
    private Drag drag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clothes = GetComponent<Image>();
        drag = GetComponent<Drag>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVisibility(bool a)
    {
        clothes.color = new Color(clothes.color.r,clothes.color.g,clothes.color.b, ((a)?1:0));
    }
}
