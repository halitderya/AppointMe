using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICPartners.DAL;
using ICPartners.Domains;
using ICPartners.Logic.Appointment;
using ICPartners.Logic.Customer;
using ICPartners.Logic.Resource;

namespace ICPartners.Logic.AppointmentFactory
{
    public class AppointmentFactory
    {
        Domains.Appointment appointment;
        UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext()); 
        public AppointmentFactory()
        {
            appointment = new Domains.Appointment();
        }

 

        public void CreateMultiAppointment(List<Job> _jobs)
        {

            throw new NotImplementedException();

        }

        public void CreateSingleAppointment()
        {
            //appointment.AppointmentID = 0;
            //appointment.AppointmentStatus = 0;
            ////appointment.Customer = unitOfWork.CustomerRepository.GetByID(CustomerSelector.CustomerToSelect);
            //appointment.CustomerRefId = CustomerSelector.CustomerToSelect;
            //Job job = unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate);
            //appointment.Job.Add(unitOfWork.jobRepository.GetByID(JobSelector.JobtoCreate));
            //appointment.StartDate = AppointmentSelector.SelectedNewAppointment.StartDate;
            //appointment.EndDate = AppointmentSelector.SelectedNewAppointment.StartDate + job.JobTimeSpan;
            //appointment.ResourceRefID = ResourceSelector.SelectedResource.ResourceID;

            //appointment.CreateDate = DateTime.Now;
            //unitOfWork.appointmentRepository.Add(appointment);
            //unitOfWork.Complete();

        }

        public void SaveAppointment()
        {

        }

      
    }
}
