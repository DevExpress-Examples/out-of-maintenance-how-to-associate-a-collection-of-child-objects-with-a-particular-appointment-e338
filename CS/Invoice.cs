using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerAppointmentChildObjects {
    public class Invoice {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        private string description;

        public string Description {
            get { return description; }
            set { description = value; }
        }
        private decimal price;

        public decimal Price {
            get { return price; }
            set { price = value; }
        }

        public Invoice(int id, string description, decimal price) {
            this.Id = id;
            this.Description = description;
            this.Price = price;
        }

        // Serialization constructor
        public Invoice()
            : this(0, string.Empty, 0m) {

        }
    }
}
