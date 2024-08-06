using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDMVCApp.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName ("Appears in this movie")]
        public string AppearsIn { get; set; }
        [Required]
        public string WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = -1;
            Name = "nothing";
            Description = "nothing yet";
            AppearsIn = "non";
            WithThisActor = "withnonone";
        }

        public GadgetModel(int id, string name, string description, 
            string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }
    }
}