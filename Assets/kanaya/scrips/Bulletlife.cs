using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletlife : MonoBehaviour
{
    public int life;
    private Text textLife;
    public GameObject PresentPrefab;
    public Transform parentTran;
    public GameObject PresentImage;

    private bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        //life = 3;
        textLife = GameObject.Find("LifeText").GetComponent<Text>();

        SetLifeUI(life);
        GameObject Obj = (GameObject)Resources.Load("Present");
        GameObject obj = Instantiate(PresentImage, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(parentTran);
        obj.transform.position = new Vector2(36.875f, 378.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetLifeUI(int life)
    {
        textLife.text = " × " + life.ToString();
    }


    public void Present()
    {
        GameObject BulletObj = GameObject.Find("Present");
        if (BulletObj == null)
        {
            --life;
            SetLifeUI(life);
            if (life > 0)
            {
                GameObject newball = Instantiate(PresentPrefab);
                newball.name = PresentPrefab.name;
            }
            else
            {
                life = 0;
            }
        }
    }
}
