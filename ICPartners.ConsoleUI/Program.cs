using ICPartners.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new ICPartnersContext());

            //unitOfWork.taskRepository.Add(new Domains.Task()
            //{

            //    TaskName = "Name",
            //    TaskDescription = "Description",
            //    TaskTimeSpan = new TimeSpan(30),
            //    TaskID=3,
            //    Jobs=null

            //});

            var res = unitOfWork.resourceRepository.GetByID(1);
            //unitOfWork.appointmentRepository.Add(new Domains.Appointment()
            //{
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.Now.Add(new TimeSpan(10)),
            //    Job=null,
            //    Customers=null,
            //    AppointmentStatus=1,
            //   Operator=null,
            //   Resources=res,
            //   CreateDate=DateTime.Now,


            //});

            unitOfWork.CustomerRepository.Add(new Domains.Customer()
            {
                CustomerName="Mahmut Müşteri",
                CustomerSurname="Soyad Müşteri",
                CustomerTitle="Mr.",
                CustomerAddress="Adress here",
                CustomerEmail="email@musteri.com",
                CustomerPhone="phone",
                CustomerCity="london",
                
                CustomerPostCode="N15",
                




            });

            unitOfWork.Complete();

          
        }
    }
}
