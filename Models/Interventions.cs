using System;

// Intervention Table model
namespace Rocket_Elevators_Rest_API.Models
{
    public class Interventions
    {
       public long Id { get; set; }
       public int? author { get; set; }
       public int? customer_id { get; set; }
       public int? building_id { get; set; }
       public int? battery_id { get; set; }
       public int? column_id { get; set; }
       public int? elevator_id { get; set; }
       public int? employee_id { get; set; }
       public DateTime? start_of_intervention { get; set; }
       public DateTime? end_of_intervention { get; set; }
       public string result { get; set; }
       public string report { get; set; }
       public string status { get; set; }
    }
}