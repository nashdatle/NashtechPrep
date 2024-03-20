using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NashtechPreparation
{
    public class WeatherForecast
    {
        [Required(ErrorMessage = "You should have this one", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [NotNull]
        public DateOnly Date { get; set; }

        [Required]
        [Range(-273, 1000)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [StringLength(255, MinimumLength = 3)]
        public string? Summary { get; set; }
    }
}
