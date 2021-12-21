using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool _setup = true;
    bool _entered = false;
    GameObject present = default;
    [SerializeField, Header("力の加える方向")] Vector2 shot = default;
    [SerializeField, Header("接触したとき反応するタグ")] string triggerTag = default;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (_entered)
        {
            Canon();
        }
        else if (time > 4)
        {
            _setup = true;
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerTag)
        {
            if (_setup)
            {
                present = collision.gameObject;
                collision.gameObject.SetActive(false);
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                collision.transform.position = gameObject.transform.position;
                _entered = true;
                _setup = false;
            }
        }
    }

    void Canon()
    {
        time += Time.deltaTime;
        if (time > 3 && time < 4)
        {
            present.SetActive(true);
            present.GetComponent<Rigidbody2D>().gravityScale = 1; 
            present.GetComponent<Rigidbody2D>().AddForce(shot * 10);
            _entered = false;
        }
    }

}
