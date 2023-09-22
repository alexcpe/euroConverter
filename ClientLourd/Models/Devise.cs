using System.ComponentModel.DataAnnotations;

namespace ClientLourd.Models
{
    public class Devise
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string? nomDevise;
        [Required] 
        public string? NomDevise
        {
            get
            {
                return nomDevise;
            }
            set
            {
                nomDevise = value;
            }
        }

        private double taux;

        public Devise(int id, string? nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public double Taux
        {
            get
            {
                return taux;
            }
            set
            {
                taux = value;
            }
        }

    }
}