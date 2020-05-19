using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBase.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name="Título Original")]
        public string TituloOriginal { get; set; }
        public int Ano { get; set; }
        [Display(Name = "Duração")]
        public int Duracao { get; set; }

    }
}
