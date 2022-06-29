using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace KendoWindow_Ajax_Form.Models
{
    [Serializable]
    [XmlRoot("SR"), XmlType("SRViewModel")]
    public class SRViewModel
    {
        public int SRID
        {
            get;
            set;
        }

        public string CustomerID { get; set; }

        public string ContactName
        {
            get;
            set;
        }

        [Required]
        public DateTime SRDate
        {
            get;
            set;
        }

        public DateTime ShippedDate
        {
            get;
            set;
        }
    }
}
