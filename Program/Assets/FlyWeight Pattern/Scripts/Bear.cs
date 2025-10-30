using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}