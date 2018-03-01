using System.ComponentModel.DataAnnotations;

namespace ABPTemplate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}