namespace MusicMVC.Commons
{
    public static class Constants
    {
        public const int MAXLENGTH_ArtistName = 75;
        //public const int MAXLENGTH_MUSIC_NAME = 75;
        public readonly static string[] Invalid_Extenstion = { "bat", "com", "exe", "msi", "scr", "hta", "cpl", "cpp", "msc", "jar", "cmd" };
        public readonly static string[] Valid_Audio_Extenstion = { "mp3", "ogg" };

        public const string Music_Path = "~/music/";
        public const int TAKE = 5;

    }

}
