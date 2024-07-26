using Microsoft.AspNetCore.Mvc;
using MusicMVC.Commons;
using MusicMVC.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MusicMVC.ViewModels
{
    [Bind("Id, Name, FileMusic, Lyrics, ReleaseYear, ArtistId, Price, PriceDiscounted")]
    // 2 nơi củng gọi 1 số phải làm 1 biến
    public class MusicViewModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public IFormFile? FileMusic { get; set; }
        public string MusicPath { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public double Price { get; set; }
        public double PriceDiscounted { get; set; }
        public int Position { get; set; }

        public static string GetMusicPath(Music music)
        {
             return music.MediumId.HasValue
                                ? (Constants.Music_Path + music.Medium.FileName + "." + music.Medium.Extension)
                                : "";
        }
    }
}
