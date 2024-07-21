using System.ComponentModel.DataAnnotations.Schema;

namespace vechicalManagement.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime ServiceDate { get; set; }

        public List<WorkItem> WorkItems { get; set; }




    }
}
