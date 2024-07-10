using Microsoft.AspNetCore.Mvc;
using MusicMVC.Commons;
using MusicMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicMVC.ViewModels
{
    [Bind("Id, Name, Nickname, Gender, DateOfBirth")]
    public class ArtistViewModel
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = " Đừng bỏ trống")]
        [MaxLength(Constants.MAXLENGTH_ArtistName)]
        public string Name { get; set; }
        [MaxLength(25, ErrorMessage = "Chỉ được phép chứa 25 ký tự")]
        public string Nickname { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public int MusicCount { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Position { get; set; }
    }
}
