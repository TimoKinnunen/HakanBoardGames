using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HakanBoardGames.Shared.BoardGameModels
{
    public class BGPlayer
    {
        [Key]
        public Guid BGPlayerDBId { get; set; } = Guid.NewGuid();

        [Required]
        public int Min { get; set; }
        public int Max { get; set; }

        // navigation properties
        public Guid BoardGameDBId { get; set; }
        [JsonIgnore]
        public BGBoardGame? BoardGame { get; set; }
    }
}
