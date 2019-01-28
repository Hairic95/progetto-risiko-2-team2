﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Server
{
    public enum ClientPackets
    {
        cHelloServer=1,
    }

    static class DataSender
    {
        public static void SendHelloServer()
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("ora sono connesso al server");
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void AskNPlayer()
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("quanti player sono connessi ?");
            NetworkManager.SetState(1);
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void StartMap(int a) // in via la pasrtenza del game e quale mappa
        {

            ByteBuffer buffer = new ByteBuffer();

            // System.Threading.Thread.Sleep(1000);          
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(a.ToString());
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void StarGame(int a) // in via la pasrtenza del game e quale mappa
        {
            NetworkManager.SetState(2);
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("start game");
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
            DataSender.StartMap(a);
        }
        public static void SendName()
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(NetworkManager.GetMessaggio()); // invio il nome
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void SendGoodBye() // quando si chiude l'applicazione
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("addio"); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }

        public static void SendPasso() // quando si passa il turno
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("Passo"); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        //attacco
        /***********************************************************************/
        public static void SendAttacco() // quando si attacca gli si passano i due stati coinvolti e il risultato
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("Attacco"); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
            SendStatoAttaccante(); // e gli passo lo stato
            SendStatoAttaccato(); //e gli passo lo stato
            SendRisultatoAttacco(); // unità perse dall'attacante
            SendRisultatoDifesa(); // unità perse dalla difesa
        }
        public static void SendStatoAttaccante() //
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(""); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void SendStatoAttaccato() // 
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(""); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void SendRisultatoAttacco() // 
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(""); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        public static void SendRisultatoDifesa() // 
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString(""); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
        }
        /*************************************************************************/
        // riuso i send sopra
        public static void SendSpostamento() // quando si sposta gli si passano 2 stati e il numero di armate
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackets.cHelloServer);
            buffer.WriteString("Spostamento"); // 
            ClientTcp.SendData(buffer.ToArray());
            buffer.Dispose();
            SendStatoAttaccante(); // e gli passo lo stato
            SendStatoAttaccato(); //e gli passo lo stato
            SendRisultatoAttacco(); // unità spostate            
        }
    }
}