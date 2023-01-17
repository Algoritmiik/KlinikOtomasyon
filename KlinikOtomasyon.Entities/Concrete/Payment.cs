using KlinikOtomasyon.Shared.Entities.Abstract;

namespace KlinikOtomasyon.Entities.Concrete
{
    public class Payment : EntityBase, IEntity
    {
        public int Price { get; set; }
        public string Currency { get; set; }
        public string WhatFor { get; set; }
        public bool IsCash { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }        
    }
}