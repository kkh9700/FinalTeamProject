using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeOut : MonoBehaviour
{
    [SerializeField] Image blackImage;
    Color a;
    Tween fadeTween;
    private void Awake()
    {
        a = blackImage.color;
        
    }
    private void OnEnable()
    {
        fadeTween = blackImage.DOFade(0, 1f).SetDelay(0.2f);

        fadeTween.OnComplete(SetActice);
    }
    void SetActice()
    {
        blackImage.color = a;
        this.gameObject.SetActive(false);
    }
}
