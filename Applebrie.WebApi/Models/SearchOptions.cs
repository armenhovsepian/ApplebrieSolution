using System.ComponentModel.DataAnnotations;

namespace Applebrie.WebApi.Models
{
    public class SearchOptions
    {
        [Range(1, int.MaxValue)]
        public int? UserTypeId { get; set; }
    }
}
