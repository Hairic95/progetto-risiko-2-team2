﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    private string nome;
    private string color; // tipo "rosso","verde"....
    private Player_script istanza;
    private int turno = 0;

    private void Awake()
    {
        istanza = this;
      
    }
    public void IstanziaPlayer(string s)
    {
        nome = s;
        DontDestroyOnLoad(this);
    }
    public void Update()
    {
        if (NetworkManager.GetMessaggio() == "Myturn")
            turno = 1;
    }
    public void PassaTurno()
    {
       
        turno=NetworkManager.PassaTurno();
    }

    public void SetName(string a)
    {
        nome = a;
    }
    public string Getname()
    {
        return nome;
    }
    public void SetColor(string a)
    {
       color = a;
    }
    public string Getcolor()
    {
        return color;
    }
    public int GetTurno()
    {
        return turno;
    }
  
    public void Myturn()
    {
        turno = 1;
    }

}
