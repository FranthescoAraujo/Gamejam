using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public string senha;
    private string senhaDigitada;
    public Text texto;

    public void InserirDigito(BotaoVO botao)
    {
        senhaDigitada += botao.digito;
        AtualizarTexto();
    }

    public void Apagar()
    {
        senhaDigitada = "";
        AtualizarTexto();
    }

    public void Verificar()
    {
        if (senha.Equals(senhaDigitada))
        {
            this.gameObject.SetActive(false);
        }
        senhaDigitada = "";
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        texto.text = senhaDigitada;
    }
}
