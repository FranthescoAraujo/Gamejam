using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<ObjectVO> objetos = new List<ObjectVO>();
    public List<GameObject> botoes;
    public List<GameObject> ambientes;
    
    public ObjectVO voAtivo;
    public ObjectVO objetoVazio;

    public int ambienteAtivo = 0;

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
                botao.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                botao.GetComponent<ObjectVO>().setVO(null);
                continue;
            }
            botao.GetComponent<Image>().sprite = objetos[botoes.IndexOf(botao)].sprite;
            botao.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            botao.GetComponent<ObjectVO>().setVO(objetos[botoes.IndexOf(botao)]);
        }
    }

    public void MoverParaEsquerda()
    {
        ambienteAtivo--;
        if (ambienteAtivo < 0)
        {
            ambienteAtivo = 3;
        }

        foreach (var ambiente in ambientes)
        {
            if (ambientes.IndexOf(ambiente) == ambienteAtivo)
            {
                ambiente.SetActive(true);
                continue;
            }
            ambiente.SetActive(false);
        }
    }

    public void MoverParaDireita()
    {
        ambienteAtivo++;
        if (ambienteAtivo > 3)
        {
            ambienteAtivo = 0;
        }

        foreach (var ambiente in ambientes)
        {
            if (ambientes.IndexOf(ambiente) == ambienteAtivo)
            {
                ambiente.SetActive(true);
                continue;
            }
            ambiente.SetActive(false);
        }
    }

    public void Back(GameObject ambienteAtual)
    {
        ambientes[ambienteAtivo].SetActive(true);
        ambienteAtual.SetActive(false);
    }

    public void Inspecionar(GameObject ambienteInspecionar)
    {
        ambientes[ambienteAtivo].SetActive(false);
        ambienteInspecionar.SetActive(true);
    }

    public void playSound(AudioSource som)
    {
        som.Play();
    }

}
