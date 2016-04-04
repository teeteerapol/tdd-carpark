using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Models
{
    public class Ticket
    {
        public DateTime DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public decimal ParkingFee
        {
            get
            {
                var fee = 0m;
                TimeSpan diff = this.DateOut.GetValueOrDefault() - this.DateIn;

                if ((diff.TotalMinutes > 15) && (diff.TotalHours <= 3.25))
                {
                    fee = 50;
                }
                else if (diff.TotalHours > 3.25)
                {
                    fee = 50;
                    Int32 hour = (diff.Hours - 3);
                    if ((diff.TotalHours - diff.Hours) > 0.25)
                        hour += 1;
                    fee += hour * 30;
                }
                
                return fee;
            }
        }
        public string PlateNo { get; set; }
    }
}
