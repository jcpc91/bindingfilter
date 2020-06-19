//---------------------------------------------------------------------
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace BindingFilteringTest
{
    public class Product
    {
        private string categoryNameValue;
        private string productNameValue;
        private int stockNoValue;
        private DateTime addedDateValue;

        public Product(string categoryName, string name,
            int number, DateTime date)
        {
            Category = categoryName;
            ProductName = name;
            StockNo = number;
            AddedDate = date;
        }

        public string Category
        {
            get { return categoryNameValue; }
            set { categoryNameValue = value; }
        }
        public string ProductName
        {
            get { return productNameValue; }
            set { productNameValue = value; }
        }

        public int StockNo
        {
            get { return stockNoValue; }
            set { stockNoValue = value; }
        }

        public DateTime AddedDate
        {
            get { return addedDateValue; }
            set
            {
                addedDateValue = value;
            }
        }

        public override string ToString()
        {
            return Category + ", " + ProductName + "\n" +
                "StockNo:" + stockNoValue + "\n" +
                "Start date:" + addedDateValue;

        }

    }
}
