using System.Drawing;

namespace Mac.PetShop2021comp1.EFCore.Entities
{
    public class PetColorEntity
    {
        public int PetId { get; set; }
        public PetEntity Pet { get; set; }
        
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; }

    }
}