using System.ComponentModel.DataAnnotations;

namespace Relationship_service.Models
{
    public class GameGroupModel
    {
        [Key]
        public int GameId { get; set; }
        [Key]
        public int GroupId { get; set; }
    }
}
