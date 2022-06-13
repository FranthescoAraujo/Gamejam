using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IDeselectHandler
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();    }
    public void OnDeselect(BaseEventData eventData)
    {
        Invoke("setarObjetoVazio", 0.5f);
    }

    public void setarObjetoVazio()
    {
        gameController.voAtivo = gameController.objetoVazio;
    }
}

