using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<ObjectVO> objetos = new List<ObjectVO>();
    public List<Image> botoes;

    public void inserirObjetoNaBolsa(ObjectVO objeto)
    {
        objetos.Add(objeto);
        ChamarAnimacao(objeto);
    }

    private void ChamarAnimacao(ObjectVO objeto)
    {
        objeto.animacao.GetComponent<Animator>().SetTrigger("Ativar");
    }

    public void AtualizarBotoes()
    {
        foreach (var botao in botoes)
        { 
            if (botoes.IndexOf(botao) >= objetos.Count)
            {
                return;
            }
            botao.GetComponent<Image>().sprite = objetos[botoes.IndexOf(botao)].sprite;
        }
    }
}
