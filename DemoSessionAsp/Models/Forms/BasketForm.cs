using System.ComponentModel.DataAnnotations;

namespace DemoSessionAsp.Models.Forms
{
    public class BasketForm
    {
        [Required]
        public string? Value { get; set; }
    }
}
