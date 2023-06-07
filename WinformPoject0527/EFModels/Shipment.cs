namespace WinformPoject0527.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment
    {
        public int ShipmentID { get; set; }

        public int? OrderID { get; set; }

        public int? SellerID { get; set; }

        public DateTime? ShipmentDate { get; set; }

        [StringLength(50)]
        public string ShipmentStatus { get; set; }

        public DateTime? ShipDate { get; set; }

        [StringLength(50)]
        public string CompletionStatus { get; set; }

        public DateTime? ArrivalTimeDate { get; set; }

        [StringLength(50)]
        public string ReceiveStatus { get; set; }

        public DateTime? CompletionDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
