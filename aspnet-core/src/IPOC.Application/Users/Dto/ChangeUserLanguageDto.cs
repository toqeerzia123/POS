using System.ComponentModel.DataAnnotations;

namespace IPOC.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}