namespace MessageBoard.Models
{
    public class Message
    {
        public string MessageText {get; set;}
        public string Group {get; set;}

        public string Author {get; set;}
        public int MessageId {get; set;}
    }

}