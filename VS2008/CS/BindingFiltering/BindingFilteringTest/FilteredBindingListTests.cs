//---------------------------------------------------------------------
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BindingFilteringTest;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using BindingFiltering;

namespace BindingFilteringTest
{
    public class MyFilteredBindingList<T> : FilteredBindingList<T>
    {
    }

    [TestClass]
    public class MyFilteredBindingListTests
    {
        public MyFilteredBindingListTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestMethod]
        public void TestApplyFilterStringEquals()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            SingleFilterInfo info = myList.ParseFilter("Category = 'Gadgets'");
            myList.ApplyFilter(info);
            Assert.AreEqual(myList.Count, 2);
        }

        [TestMethod]
        public void TestConstructor()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2002, 5, 6)));
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void TestDetermineFilterOperator()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            Assert.AreEqual(FilterOperator.EqualTo, myList.DetermineFilterOperator("MyList='SomeStuff'"));
            Assert.AreEqual(FilterOperator.GreaterThan, myList.DetermineFilterOperator("MyList>'SomeStuff'"));
            Assert.AreEqual(FilterOperator.LessThan, myList.DetermineFilterOperator("MyList<'SomeStuff'"));
            Assert.AreEqual(FilterOperator.None, myList.DetermineFilterOperator("MyList<>'SomeStuff'"));
        }

        [TestMethod]
        public void TestFilteringWithAnd()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Candles", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category='Candles'";
            Assert.AreEqual(1, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);

        }
        [TestMethod]
        public void TestFilterAddNewItem()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Candles", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category='Candles'";
            myList.Add(new Product("Candles", "Bayberry", 54000, new DateTime(2005, 4, 6)));
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(5, myList.OriginalList.Count);

        }

        [TestMethod]
        public void TestFilterMultiColumn()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Candles", "Cherry", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category='Candles' AND ProductName = 'Cherry'";
            Assert.AreEqual(1, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);

        }
        [TestMethod]
        public void TestFilteringMultiColumnToSingleColumnDGVBehavior()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Candles", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category='Candles' AND ProductName = 'Jumper'";
            Assert.AreEqual(1, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);
            myList.Filter = "ProductName = 'Jumper'";
            myList.RemoveFilter();
            Assert.AreEqual(4, myList.Count);

        }
        [TestMethod]
        public void TestFilteringInt()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 54000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 53000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 46000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 36000, new DateTime(2002, 5, 6)));
            myList.Filter = "[StockNo]>'50000'";
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);

        }
        [TestMethod]
        public void TestFilterRegularExpressionApostrophe()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Aker's", "Jumper", 58000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "Category = 'Aker\'s'";
            Assert.AreEqual(1, myList.Count);
        }
        [TestMethod]
        public void TestFilterRegularExpressionLongDate()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Aker's", "Jumper", 58000, new DateTime(2002, 5, 6)));
            myList.Filter = "AddedDate = '5/6/2003 12:00:00 AM'";
            Assert.AreEqual(1, myList.Count);
        }
        [TestMethod]
        public void TestFilterDateTime()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "[AddedDate]<'5/6/2005'";
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);
        }
        [TestMethod]
        public void TestFilterNull()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = null;
            Assert.AreEqual(4, myList.Count);
        }
        [TestMethod]
        public void TestRegexBuilder()
        {

            Assert.AreEqual(@"\[?[\w\s]+\]?\s?[><=]\s?'?.+'?",
                MyFilteredBindingList<Employee>.BuildRegExForFilterFormat());
        }
        [TestMethod]
        public void TestFilterSetFilterAddItemResetFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Descending);
            myList.Filter = "[Category]< 'Games'";
            myList.Add(new Product("Johnson", "TickTock", 45000, new DateTime(2007, 9, 1)));
            myList.Filter = "[Category]< 'Games'";
            Assert.AreEqual(2, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(5, myList.Count);
            Assert.AreEqual("Johnson", myList[0].Category);
        }
        [TestMethod]
        public void TestFilterWithFonts()
        {
            MyFilteredBindingList<Font> myList = new MyFilteredBindingList<Font>();
            myList.Add(new Font("Arial", 20F));
            myList.Add(new Font("Courier", 18F));
            myList.Add(new Font("Verdana", 14F));
            myList.Add(new Font("Times New Roman", 13F));
            myList.Filter = "[Size]<'15'";
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);
        }

        [TestMethod]
        public void TestFilterMultiColumnFilterToSingleColumnFilterToNoFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "[Category] ='Games' AND [ProductName] ='TickTock'";
            Assert.AreEqual(1, myList.Count);
            myList.Filter = "[Category] ='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(4, myList.Count);
            Assert.AreEqual("TickTock", myList[0].ProductName);
            Assert.AreEqual("Gadgets", myList[0].Category);
        }
        [TestMethod]
        public void TestApplySortFilterMultiColumnFilterToSingleColumn()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("ProductName", ListSortDirection.Descending);
            myList.Filter = "[Category] ='Games' AND [ProductName] ='TickTock'";
            Assert.AreEqual(1, myList.Count);
            myList.Filter = "[ProductName] ='TickTock'";
            Assert.AreEqual(2, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(4, myList.Count);
            Assert.AreEqual("TickTock", myList[0].ProductName);
            Assert.AreEqual("Gadgets", myList[0].Category);
        }
        [TestMethod]
        public void TestFilterAddItemRemoveFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 54000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 46000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 36000, new DateTime(2002, 5, 6)));
            myList.Filter = "[StockNo]>'50000'";
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);
            myList.Add(new Product("Games", "John", 45000, new DateTime(2002, 4, 6)));
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(5, myList.OriginalList.Count);
        }

        [TestMethod]
        public void TestFilterWithApostrophe()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56200, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]= Games'";
            Assert.AreEqual(0, myList.Count);
        }

        [TestMethod]
        public void TestFilterRegularExpressionPass()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56200, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games'", "Jumper", 58000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]= 'Games'";
            myList.Filter = "StockNo < 50000";
            myList.Filter = "StockNo  < 50000";
            myList.Filter = "AddedDate = '5/01/2004'";
        }

        [TestMethod]
        public void TestFilterRemoveFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "[Category]='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(4, myList.Count);
        }

        [TestMethod]
        public void TestFilterStringLessThan()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category <'Gaf'";
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(4, myList.OriginalList.Count);
        }
       
       
        [TestMethod]
        public void TestFilterEmptyString()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "";
            Assert.AreEqual(4, myList.Count);
            
        }
 
        [TestMethod]
        public void TestParseFilterEmptyStringForValueEqual()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            SingleFilterInfo info = myList.ParseFilter("Category = ");
            Assert.AreEqual("Category", info.PropName);
            Assert.AreEqual(FilterOperator.EqualTo, info.OperatorValue);
            Assert.AreEqual(" ", info.CompareValue);
        }

        [TestMethod]
        public void TestParseFilterStringForValueEqualQuotes()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            SingleFilterInfo info = myList.ParseFilter("Category = 'Something'");
            Assert.AreEqual("Category", info.PropName);
            Assert.AreEqual(FilterOperator.EqualTo, info.OperatorValue);
            Assert.AreEqual("Something", info.CompareValue);
        }
 
        [TestMethod]
        public void TestParseFilterDateForValueGreaterThan()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            SingleFilterInfo info = myList.ParseFilter("AddedDate > 5/6/2002");
            Assert.AreEqual("AddedDate", info.PropName);
            Assert.AreEqual(FilterOperator.GreaterThan, info.OperatorValue);
            Assert.AreEqual(new DateTime(2002, 5, 6), info.CompareValue);
        }
        
        [TestMethod]
        public void TestParseFilterFloatForValueEqual()
        {
            MyFilteredBindingList<Font> myList = new MyFilteredBindingList<Font>();
            SingleFilterInfo info = myList.ParseFilter("Size = 3");
            Assert.AreEqual("Size", info.PropName);
            Assert.AreEqual(FilterOperator.EqualTo, info.OperatorValue);
            Assert.AreEqual(3.0F, info.CompareValue);
        }
        [TestMethod]
        public void TestParseFilterLongDateString()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            SingleFilterInfo info = myList.ParseFilter("AddedDate = 5/6/2002 12:00:00 AM");
            Assert.AreEqual("AddedDate", info.PropName);
            Assert.AreEqual(FilterOperator.EqualTo, info.OperatorValue);
            Assert.AreEqual(new DateTime(2002, 5, 6), info.CompareValue);
        }
        [TestMethod]
        public void TestParseFilterIntForValueLessThan()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            SingleFilterInfo info = myList.ParseFilter("StockNo < 3");
            Assert.AreEqual("StockNo", info.PropName);
            Assert.AreEqual(FilterOperator.LessThan, info.OperatorValue);
            Assert.AreEqual(3, info.CompareValue);
        }

        [TestMethod]
        public void TestStripOffQuotes()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            MyFilteredBindingList<Product>.StripOffQuotes("somefilter='someValue'");
            Assert.AreEqual("someValue",
                MyFilteredBindingList<Font>.StripOffQuotes("'someValue'"));
            Assert.AreEqual("some'Value",
                MyFilteredBindingList<Font>.StripOffQuotes("'some'Value'"));
            Assert.AreEqual("'someValue",
                MyFilteredBindingList<Font>.StripOffQuotes("'someValue"));
            Assert.AreEqual("someValue'",
                MyFilteredBindingList<Font>.StripOffQuotes("someValue'"));
        }
                
        [TestMethod]
        public void TestSortAndFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]='Games'";
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual("Jumper", myList[0].ProductName);
        }
        [TestMethod]
        public void TestSortAndFilterAddItemRemoveFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Descending);
            myList.Filter = "[Category]< 'Games'";
            myList.Add(new Product("Johnson", "TickTock", 45000, new DateTime(2007, 9, 1)));
            Assert.AreEqual(2, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(5, myList.Count);
            Assert.AreEqual("Johnson", myList[0].Category);
        }
        [TestMethod]
        public void TestSortAndFilterRemoveItem()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            Product TickTockGames = new Product("Games", "TickTock", 56100, new DateTime(2006, 5, 6));
            myList.Add(new Product("Gadgets", "TickTock", 56200, new DateTime(2003, 5, 6)));
            myList.Add(TickTockGames);
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]= 'Games'";
            myList.Remove(TickTockGames);
            Assert.AreEqual(1, myList.Count);
            myList.RemoveFilter();
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual("Gadgets", myList[0].Category);
        }
        [TestMethod]
        public void TestSortAndFilterAddNewItem()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Add(new Product("Candles", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.Filter = "Category='Candles'";
            myList.Add(new Product("Candles", "Zoe", 54000, new DateTime(2005, 4, 6)));
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual(5, myList.OriginalList.Count);

        }
        [TestMethod]
        public void TestSortAndFilterRemoveFilterRemoveSort()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            myList.RemoveFilter();
            myList.RemoveSort();
            Assert.AreEqual(4, myList.Count);
            Assert.AreEqual("TickTock", myList[0].ProductName );
            Assert.AreEqual("Gadgets", myList[0].Category);
        }
   
        [TestMethod]
        public void TestSortAndFilterTwoSortsRemoveFilterRemoveSort()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Games", "Bandwagon", 56100, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "TickTock", 56200, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Descending);
            myList.RemoveFilter();
            myList.RemoveSort();
            Assert.AreEqual(4, myList.Count);
            Assert.AreEqual("Bandwagon", myList[0].ProductName);
            Assert.AreEqual("Games", myList[0].Category);
            Assert.AreEqual("TickTock", myList[1].ProductName);
            Assert.AreEqual("Gadgets", myList[1].Category);
            Assert.AreEqual("Jumper", myList[2].ProductName);
            Assert.AreEqual("Gadgets", myList[2].Category);
        }

        [TestMethod]
        public void TestSortAndFilterRemoveFilter()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("Category", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            myList.RemoveFilter();
            Assert.AreEqual(4, myList.Count);
            Assert.AreEqual("Jumper", myList[0].ProductName);
        }

        [TestMethod]
        public void TestSortAndFilterRemoveSort()
        {
            MyFilteredBindingList<Product> myList = new MyFilteredBindingList<Product>();
            myList.Add(new Product("Gadgets", "TickTock", 56100, new DateTime(2003, 5, 6)));
            myList.Add(new Product("Games", "TickTock", 56200, new DateTime(2006, 5, 6)));
            myList.Add(new Product("Gadgets", "Jumper", 56000, new DateTime(2004, 5, 6)));
            myList.Add(new Product("Games", "Jumper", 56000, new DateTime(2002, 5, 6)));
            myList.ApplySort("ProductName", System.ComponentModel.ListSortDirection.Ascending);
            myList.Filter = "[Category]='Games'";
            Assert.AreEqual(2, myList.Count);
            myList.RemoveSort();
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual("TickTock", myList[0].ProductName);
        }
       
    }
}
