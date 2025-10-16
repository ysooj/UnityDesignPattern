using UnityEngine;

public class Golem : Creature
{
    [SerializeField] Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public override void Behaviour()
    {
        float offset = Mathf.PingPong(Time.time * speed, 5f);
        transform.position = startPosition + new Vector3(0, 0, offset - 2.5f);
    }
}