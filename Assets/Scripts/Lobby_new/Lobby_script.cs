﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby_script : MonoBehaviour
{
    private InputField input;
    private NetworkManager net;
    private Player_script player;
  

    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        input.ActivateInputField();
        net = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        player = GameObject.Find("Player").GetComponent<Player_script>();
    }
    public void GetNome(string nome)
    {

        player.IstanziaPlayer(nome); // salvo  il nome del player
        Debug.Log("nome cambiato "+player.Getname());
    }
    public void OnMouseDown()
    {
        if(!string.IsNullOrEmpty(player.Getname())) // chiamo la network manager
        {
            net.initiate();
            // Debug.Log("il mio nome è "+nomeUtente);
            SceneManager.LoadScene("Waiting_Room");
            NetworkManager.setMessage ( player.Getname()); // mando il nome utente

        }
        else
        {
            Debug.Log("non hai inserito il nome");
        }

    }



}
