﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.Server
{
    public enum serverPackets
    {
        sWelcomeMessage=1,
    }
   

     class DataReceiver  // dovrebbe essere static ma mi serve che non lo sia
    {
       

        public static void HandleWelcomeMessage(byte[] data) // dovrebbe essere static ma così funzoina
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.writeBytes(data);
            int playerID = buffer.ReadInteger();
            string msg = buffer.ReadString();
            buffer.Dispose();

            if (NetworkManager.GetState() <= 0)  // casi normali 
            {
                switch (msg) // aggiungere un caso per scoprire il colore ?
                {
                    case "benvenuto nel server mettiti comodo": // mi sono connesso
                        {
                            Debug.Log(msg);
                            DataSender.SendHelloServer();
                            break;
                        }
                    /*   case "sei nella Wating room ora devi aspettare altri utenti":
                           {
                               Debug.Log(msg);                                           
                               break;
                           }
                   */
                    case "Come ti chiami ?":
                        {
                            Debug.Log("ecco come mi chiamo");
                            NetworkManager.SetState( -1); // impedisco l'uso del button nella waiting room
                            DataSender.SendName();
                            break;
                        }
                    case "ok":
                        {
                           NetworkManager.SetMessaggio("ok");
                            Debug.Log("nome salvato");
                            NetworkManager.SetState ( 0); // riattivo il bottone
                            break;
                        }
                /*    case "non si può giocare":
                        {
                            NetworkManager.messaggio = "no";
                            Debug.Log(msg);
                            break;
                        }
                    case "si puo giocare":
                        {
                            NetworkManager.messaggio = "si";
                            Debug.Log(msg);
                            break;
                        }
               */
                    case "startgame":
                        {
                            NetworkManager.SetMessaggio("start");
                            Debug.Log(msg);
                            break;
                        }
                    case "NewPlayer":
                        {
                            Debug.Log("newplayer");
                            NetworkManager.AddNPlayer(); // mi segno che è entrato un nuovo player
                            NetworkManager.SetMessaggio ("NewPlayer");
                            break;
                        }
                    case "PlayerQuit":
                        {
                            Debug.Log("playerquit");
                            NetworkManager.DimNPlayer(); // mi segno che è uscito un nuovo player
                            NetworkManager.SetMessaggio("PlayerQuit");
                            break;
                        }
                    case "Your Go":
                        {
                            NetworkManager.SetMessaggio("Myturn");
                            break;
                        }

                }
            }
            else if(NetworkManager.GetState()==1) // salvo il numero di player
            {
                NetworkManager.SetNPlayer (int.Parse(msg));
               // Debug.Log("msg");
                NetworkManager.SetState( 0);
              //  Debug.Log(NetworkManager.state);
            }
        }
    }
}
