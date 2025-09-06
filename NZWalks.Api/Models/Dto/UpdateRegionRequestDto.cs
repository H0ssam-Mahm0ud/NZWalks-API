using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.Dto
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Name has to be a maximum of 100 characters")]
        [MinLength(3, ErrorMessage = "Name has to be a Minimum of 100 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
