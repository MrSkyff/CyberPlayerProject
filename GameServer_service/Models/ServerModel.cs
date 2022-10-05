namespace Server_service.Models
{
    public class ServerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public int GameId { get; set; }
        public int GroupId { get; set; }
    }
}
