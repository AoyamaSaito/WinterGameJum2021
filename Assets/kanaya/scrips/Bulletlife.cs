using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulletlife : SceneChanger
{
    [SerializeField, Header("弾数のテキスト")] Text _textLife = default;
    [SerializeField, Header("Buletを入れるメンバ変数")] GameObject _bulletObj = default;
    [SerializeField, Header("弾を生成するposition")] Transform instantiatePosition;

    public int life;

    //public GameObject PresentPrefab;
    //public Transform parentTran;
    //public GameObject PresentImage;

    private bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        //life = 3;

        SetLifeUI(life);
        //GameObject Obj = (GameObject)Resources.Load("Present");
        //GameObject obj = Instantiate(PresentImage, Vector2.zero, Quaternion.identity);
        //obj.transform.SetParent(parentTran);
        //obj.transform.position = new Vector2(36.875f, 378.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetLifeUI(int life)
    {
        _textLife.text = " × " + life.ToString();
    }

    public void Present()
    {
        //GameObject BulletObj = GameObject.Find("Present");
        if (_bulletObj != null)
        {
            --life;
            SetLifeUI(life);
            if (life > 0)
            {
                GameObject newball = Instantiate(_bulletObj, instantiatePosition.position, Quaternion.identity);
                //newball.name = PresentPrefab.name;
            }
            else
            {
                OnClick();
            }
        }
    }
}
