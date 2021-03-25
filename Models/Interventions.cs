using System;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Interventions
    {
       public long Id { get; set; }
       public int? Author { get; set; }
       public int? CustomerId { get; set; }
       public int? BuildingId { get; set; }
       public int? BatteryId { get; set; }
       public int? ColumnId { get; set; }
       public int? ElevatorId { get; set; }
       public int? EmployeeId { get; set; }
       public DateTime? StartOfIntervention { get; set; }
       public DateTime? EndOfIntervention { get; set; }
       public string Result { get; set; }
       public string Report { get; set; }
       public string Status { get; set; }
    }
}