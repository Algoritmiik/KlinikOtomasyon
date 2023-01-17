using KlinikOtomasyon.Entities.Concrete;

namespace KlinikOtomasyon.Services.Abstract
{
    public interface IUnitOfWork
    {
        IGenericService<Clinic> Clinics { get; }
        IGenericService<Department> Departments { get; }
        IGenericService<Massage> Massages { get; }
        IGenericService<Patient> Patients { get; }
        IGenericService<Payment> Payments { get; }
        IGenericService<PerformedSurgery> PerformedSurgeries { get; }
        IGenericService<Price> Prices { get; }
        IGenericService<Surgery> Surgeries { get; }
    }
}