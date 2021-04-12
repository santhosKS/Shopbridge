using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class ItemsModels
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Depcode { get; set; }
        public string InternalCode { get; set; }
        public string HSNCode { get; set; }
        public string AccountsHead { get; set; }
        public string OEM1 { get; set; }//Original equipment manufacturer
        public string OEM2 { get; set; }
        public string BinNumber { get; set; }
        public string StoreRoomNumber { get; set; }
        public string UOM { get; set; }
        public int MinimumQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal itemprice { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Totalvalueofitem { get; set; }
        public DateTime Date { get; set; }
    }
}
