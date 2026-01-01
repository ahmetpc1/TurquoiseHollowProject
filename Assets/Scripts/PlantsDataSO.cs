using UnityEngine;

[CreateAssetMenu(fileName = "PlantsDataSO", menuName = "Scriptable Objects/PlantsDataSO")]
public class PlantsDataSO : ScriptableObject
{
    public int[] plantPrice;
    public float[] plantTime;
    public int[] plantSellingPrice;

    public Sprite[] PlantProcessImages;
    

}
