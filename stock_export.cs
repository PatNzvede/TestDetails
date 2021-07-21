using System;
using System.Collections.Generic;
using System.Text;

namespace TestDetails
{
   public class stock_export
    {
        public string Product_group_description { get; set; }

        public string Stock_category_description { get; set; }
        public string Stock_code { get; set; }

        public string Stock_description { get; set; }

        public string Unit_of_measure { get; set; }

        public int Pack { get; set; }

        public string Bar_code { get; set; }

        public decimal Incl_unit_selling_price { get; set; }

        public int level { get; set; }
    }
}
