namespace NoticiaApi.Model
{
    public class Noticia
    {
        public Guid Id { get; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; }

        public Noticia(string titulo, string autor, string conteudo)
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
            Titulo = titulo;
            Autor = autor;
            Conteudo = conteudo;
        }
    }
}
