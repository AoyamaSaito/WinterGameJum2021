using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool _setup = true;
    bool _entered = false;
    GameObject present = default;
    [SerializeField] Vector2 shot = default;
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
        //if (collision.tag == "")
        //{
            if (_setup)
            {
                present = collision.gameObject;
                collision.gameObject.SetActive(false);
                _entered = true;
                _setup = false;
            }
        //}
    }

    void Canon()
    {
        time += Time.deltaTime;
        if (time > 3 && time < 4)
        {
            GameObject newPresent = Instantiate(present, gameObject.transform.position, Quaternion.Inverse(this.transform.rotation));
            newPresent.SetActive(true);
            newPresent.GetComponent<Rigidbody2D>().AddForce(shot * 10);
            _entered = false;
        }
    }

}
