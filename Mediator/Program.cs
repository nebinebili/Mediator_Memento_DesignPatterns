using System;
using System.Collections.Generic;

namespace Mediator
{
    public interface IChatroom
    {
        void Register(Participant participant);
        void Send(string from, string to, string message);
    }

    public class ChatRoom : IChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public void Send(string from, string to, string message)
        {
            Participant participant = participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    public class Participant
    {
        IChatroom chatroom;
        string name;

        public Participant(string name)
        {
            this.name = name;
        }
 
        public string Name
        {
            get { return name; }
        }

        public IChatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }
    
        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }
       
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",from, Name, message);
        }
    }

    public class Beatle : Participant
    {
     
        public Beatle(string name) : base(name)
        {

        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    public class NonBeatle : Participant
    {
        public NonBeatle(string name): base(name)
        {

        }
        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Chat otagi yaradrlir
            ChatRoom chatRoom = new ChatRoom();
            // userler qeydiyyatdan kecir
            Participant Kenan = new Beatle("Kenan");
            Participant Nebi = new Beatle("Nebi");
            Participant Emiraslan = new NonBeatle("Emiraslan");

            chatRoom.Register(Kenan);
            chatRoom.Register(Emiraslan);
            chatRoom.Register(Nebi);

            // Userlerin Sohbet
            Kenan.Send("Nebi", "Salam Nebi");
            Emiraslan.Send("Kenan", "Kenan necesen?");
            Nebi.Send("Emiraslan", "Neynirsen Emiraslan?");
         

        }
    }
}
