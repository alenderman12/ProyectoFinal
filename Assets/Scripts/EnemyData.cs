using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float speed;
    public float hitStrength;
    public float auditionRange;
    public float damage;
    public float maxHealth;
}
