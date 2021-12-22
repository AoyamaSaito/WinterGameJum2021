using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SledManager : MonoBehaviour
{
    //[SerializeField] UnityEvent StartSled = null;
    [SerializeField, Header("接触したとき反応するタグ")] string triggerTag = "Player";
    [SerializeField, Header("到着地点")] Vector2 arrival = default; //到着場所
    private bool _start = false;
    private float arrivaltime = 1f;
    private float distancetime = 0f;
    public float Speed = 0f;
    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (_start) 
        {
            Larp();
        }
    }

    void Arrival() 
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        this.transform.DetachChildren();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerTag)
        {
            _start = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.parent = this.transform.transform; //プレゼントを子オブジェクトに追加する
        }
    }

    void Larp() 
    {
        time = Time.time * Speed; //到着までの時間
        float positionDistance = Vector2.Distance(this.transform.position, arrival);
        transform.position = Vector2.Lerp(this.transform.position, arrival, time / positionDistance);
        distancetime = time / positionDistance;
        if (distancetime > arrivaltime) 
        {
            _start = false;
            Arrival();
        }
    }
}
