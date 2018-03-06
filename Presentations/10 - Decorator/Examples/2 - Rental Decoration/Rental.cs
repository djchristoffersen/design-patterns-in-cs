using System;
using System.Collections.Generic;

namespace Wincubate.DecoratorExamples
{
    public class Rental : VehicleDecorator
    {
        public int Available { get; private set; }

        public IEnumerable<string> RentalHistory => _rentalHistory;
        private List<string> _rentalHistory;

        public override string ToString()
        {
            string s = base.ToString() +
                $"{Environment.NewLine}{Available} available for rent.";

            if( _rentalHistory.Count > 0 )
            {
                string r = string.Join(Environment.NewLine, _rentalHistory);

                s += $"{ Environment.NewLine}{r}";
            }

            return s;
        }

        public Rental( IVehicle decoratee, int available ) : base(decoratee)
        {
            Available = available;

            _rentalHistory = new List<string>();
        }

        public void Rent( string customer )
        {
            if( Available > 0 )
            {
                _rentalHistory.Add($"{DateTime.Now}: Rented by {customer}");
                Available--;
            }
        }

        public void Return()
        {
            _rentalHistory.Add($"{DateTime.Now}: Returned");
            Available++;
        }
    }
}