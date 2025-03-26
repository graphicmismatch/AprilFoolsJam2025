using UnityEngine;



public enum TimePeriod { 
    A_EGYPT, ROME, NINETEEN_HUNDREDS, PRESENT, FUTURE
}

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects/Clothes")]
public class Clothes : ScriptableObject
{
    public string itemName;
    public TimePeriod timePeriod;
    public Sprite sprite;

}
