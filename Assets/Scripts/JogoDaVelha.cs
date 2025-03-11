using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Para TextMeshPro


public class JogoDaVelha : MonoBehaviour
{
    public Button[] botoes; // Array com os 9 botões do tabuleiro
    private string jogadorAtual = "X"; // Define qual jogador inicia

    void Start()
    {
        // Adiciona eventos aos botões
        for (int i = 0; i < botoes.Length; i++)
        {
            int index = i;
            botoes[i].onClick.AddListener(() => Jogar(index));
        }
    }

    public void Jogar(int index)
    {
        if (botoes[index].GetComponentInChildren<TMP_Text>().text == "")
        {
            botoes[index].GetComponentInChildren<TMP_Text>().text = jogadorAtual;
            if (VerificarVitoria())
            {
                Debug.Log("Vitória do jogador " + jogadorAtual);
                ReiniciarJogo();
                return;
            }
            jogadorAtual = (jogadorAtual == "X") ? "O" : "X"; // Alterna jogadores
        }
    }

    bool VerificarVitoria()
    {
        int[,] combinacoesVitoria = {
            {0,1,2}, {3,4,5}, {6,7,8}, // Linhas
            {0,3,6}, {1,4,7}, {2,5,8}, // Colunas
            {0,4,8}, {2,4,6}  // Diagonais
        };

        for (int i = 0; i < combinacoesVitoria.GetLength(0); i++)
        {
            int a = combinacoesVitoria[i, 0];
            int b = combinacoesVitoria[i, 1];
            int c = combinacoesVitoria[i, 2];

            if (botoes[a].GetComponentInChildren<TMP_Text>().text != "" &&
                botoes[a].GetComponentInChildren<TMP_Text>().text == botoes[b].GetComponentInChildren<TMP_Text>().text &&
                botoes[a].GetComponentInChildren<TMP_Text>().text == botoes[c].GetComponentInChildren<TMP_Text>().text)
            {
                return true; // Vitória detectada
            }
        }
        return false;
    }

    void ReiniciarJogo()
    {
        foreach (Button botao in botoes)
        {
            botao.GetComponentInChildren<TMP_Text>().text = "";
        }
        jogadorAtual = "X"; // Reinicia com X
    }
}
