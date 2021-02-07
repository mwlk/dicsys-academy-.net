namespace Persistencia.Database.Models
{
    class VariedadPizza
    {
        //varios tamaños (8, 10 y 12 porciones).
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CantidadPorcion { get; set; }

        public Pizza Pizza { get; set; }
    }
}
