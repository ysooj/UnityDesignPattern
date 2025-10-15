using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected float speed;

    public void Update()
    {
        Behaviour();
    }

    public abstract void Behaviour();
}