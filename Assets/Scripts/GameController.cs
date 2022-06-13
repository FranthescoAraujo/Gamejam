using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<ObjectVO> objetos = new List<ObjectVO>();
    public List<GameObject> botoes;
    
    public ObjectVO voAtivo;
    public ObjectVO objetoVazio;

    public void inserirObjetoNaBolsa(ObjectVO objeto)
    {
        objetos.Add(objeto);
        ChamarAnimacao(objeto.animacao);
    }

    public void removerObjetoNaBolsa(InteracaoVO objeto)
    {
        if (voAtivo == null || voAtivo.id == null)
        {
            return;
        }
        if (voAtivo.id == objeto.objetoInteracao.id)
        {
            objetos.Remove(objeto.objetoInteracao);
            ChamarAnimacao(objeto.animacao);
        }
    }

    public void desabilitarBotao(GameObject botao)
    {
        if (voAtivo == null)
        {
            return;
        }
        if (voAtivo.id == botao.GetComponent<InteracaoVO>().objetoInteracao.id)
        {
            botao.SetActive(false);
        }
    }

    private void ChamarAnimacao(GameObject objeto)
    {
        objeto.GetComponent<Animator>().SetTrigger("Ativar");
    }

    public void setVoAtivo(ObjectVO objeto)
    {
        voAtivo = objeto;
    }

    public void AtualizarBotoes()
    {
        foreach (var botao in botoes)
        { 
            if (botoes.IndexOf(botao) >= objetos.Count)
            {
                botao.GetComponent<Image>().sprite = null;
                botao.GetComponent<ObjectVO>().setVO(null);
                continue;
            }
            botao.GetComponent<Image>().sprite = objetos[botoes.IndexOf(botao)].sprite;
            botao.GetComponent<ObjectVO>().setVO(objetos[botoes.IndexOf(botao)]);
        }
    }
}
