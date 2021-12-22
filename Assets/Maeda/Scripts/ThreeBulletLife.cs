using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeBulletLife : SceneChanger
{
    [SerializeField, Header("弾数のテキスト")] Text _textLife = default;
    [SerializeField, Header("Buletを入れるメンバ変数")] GameObject[] _bulletObj = new GameObject[] { };
    [SerializeField, Header("弾を生成するposition")] Transform instantiatePosition;
    GameObject newball = default;
    public bool _isNotPlayGame = default;
    int bullet = 0;
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
        if (Input.GetButtonDown("1"))
        {
            if (newball != _bulletObj[0])
                Present();
        }
        if (Input.GetButtonDown("2"))
        {
            if (newball != _bulletObj[1])
            {
                bullet = 1;
                Present();
            }
        }
        if (Input.GetButtonDown("3"))
        {
            if (newball != _bulletObj[2])
            {
                Present();
            }
        }
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
            if (life > 0 && bullet == 0)
            {
                if (_isNotPlayGame) return;
                newball = Instantiate(_bulletObj[0], instantiatePosition.position, Quaternion.identity);
                Debug.Log(_isNotPlayGame);
                //newball.name = PresentPrefab.name;
            }
            else if (life > 0 && bullet == 1)
            {
                if (_isNotPlayGame) return;
                newball = Instantiate(_bulletObj[1], instantiatePosition.position, Quaternion.identity);
                Debug.Log(_isNotPlayGame);
                //newball.name = PresentPrefab.name;
                bullet = 0;
            }
            else if (life > 0 && bullet == 2)
            {
                if (_isNotPlayGame) return;
                newball = Instantiate(_bulletObj[2], instantiatePosition.position, Quaternion.identity);
                Debug.Log(_isNotPlayGame);
                //newball.name = PresentPrefab.name;
                bullet = 0;
            }
            else
            {
                GameOver();
            }
        }
    }
}