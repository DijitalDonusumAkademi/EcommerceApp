﻿using System;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Models.Contracts;

namespace Ecommerce.Models.EntityModels
{
    public class Product : IDeleteable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz!")]
        public string Name { get; set; }
        [StringLength(11)]
        public string Code { get; set; }
        public double Price { get; set; }
        public string WarehouseLocation { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }


        public bool IsDeleted { get; set; }
        public int? DeleteById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}