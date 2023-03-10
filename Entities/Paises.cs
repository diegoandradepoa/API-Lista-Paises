namespace ListaDePaises.API.Entities
{
    public class Paises
    {
        public Paises(string nome, string continente)
        {
            Nome = nome;
            Continente = continente;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Continente { get; set; }  

        public void Update(string  nome, string continente)
        {
            Nome = nome;
            Continente = continente;
        }
    }
}
