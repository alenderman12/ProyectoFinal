using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
public class Enemy : ScriptableObject
{
    public float speed;
    public float auditionRange;
    public int damage;
    public float maxHealth;
}
