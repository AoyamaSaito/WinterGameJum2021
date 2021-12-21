using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : SceneChanger
{
    public void Fill()
    {
        FadeValue(1f);
    }

    void FadeValue(float Value)
    {
        Camera.main.DOColor(Color.black, 1.5f)
        .SetEase(Ease.InSine)
        .OnComplete(() => base.OnClick());
    }
}
