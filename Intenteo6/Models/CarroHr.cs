namespace Intenteo6.Models
{
    public class CarroHr
    {
        
        public int IdCar { get; set; }

        public string Name { get; set; } = null!;

       
        public string Año { get; set; } = null!;

        public int Idmodelo { get; set; }

       
        public decimal Precio { get; set; }

       
        public int Marca { get; set; }
    }
}
