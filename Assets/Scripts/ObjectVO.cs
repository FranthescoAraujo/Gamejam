using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVO : MonoBehaviour
{
    public string id;
    public Sprite sprite;
    public GameObject animacao;

    public void setVO(ObjectVO vo)
    {
        if (vo == null)
        {
            id = null;
            sprite = null;
            animacao = null;
            return;
        }
        id = vo.id;
        sprite = vo.sprite;
        animacao = vo.animacao;
    }
}
