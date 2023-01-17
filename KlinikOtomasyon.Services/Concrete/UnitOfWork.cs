using KlinikOtomasyon.Data.Concrete.EntityFramework.Contexts;
using KlinikOtomasyon.Entities.Concrete;
using KlinikOtomasyon.Services.Abstract;

namespace KlinikOtomasyon.Services.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        IGenericService<Clinic> _clinicManager;
        IGenericService<Department> _deparmentManager;
        IGenericService<Massage> _massageManager;
        IGenericService<Patient> _patientsManager;
        IGenericService<Payment> _paymentsManager;
        IGenericService<PerformedSurgery> _performedSurgeriesManager;
        IGenericService<Price> _pricesManager;
        IGenericService<Surgery> _surgeriesManager;
        public UnitOfWork(IGenericService<Clinic> clinicManager, IGenericService<Department> deparmentManager, IGenericService<Massage> massageManager, IGenericService<Patient> patientsManager, IGenericService<Payment> paymentsManager, IGenericService<PerformedSurgery> performedSurgeriesManager, IGenericService<Price> pricesManager, IGenericService<Surgery> surgeriesManager, KlinikOtomasyonContext context)
        {
            _clinicManager = clinicManager;
            _deparmentManager = deparmentManager;
            _massageManager = massageManager;
            _patientsManager = patientsManager;
            _paymentsManager = paymentsManager;
            _performedSurgeriesManager = performedSurgeriesManager;
            _pricesManager = pricesManager;
            _surgeriesManager = surgeriesManager;
        }

        public IGenericService<Clinic> Clinics => _clinicManager;
        public IGenericService<Department> Departments => _deparmentManager;
        public IGenericService<Massage> Massages => _massageManager;
        public IGenericService<Patient> Patients => _patientsManager;
        public IGenericService<Payment> Payments => _paymentsManager;
        public IGenericService<PerformedSurgery> PerformedSurgeries => _performedSurgeriesManager; 
        public IGenericService<Price> Prices => _pricesManager;
        public IGenericService<Surgery> Surgeries => _surgeriesManager;
    }
}