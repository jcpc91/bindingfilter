--------------------------------------------------------------------- 

                           Readme for

                        Behind the Scenes:
        Implementing Filtering for Windows Forms Data Binding
                          Code Sample

                       by Cheryl Simmons

--------------------------------------------------------------------- 


Overview
========
This code sample demonstrates how to extend the generic BindingList
and implement the filtering functionality of the IBindingListView.
This code sample contains three projects:

BindingFiltering
The BindingFiltering project implements the filtering functionality.
This project also includes a form and a sample business object
(Employee) to test the filtering.

DataGridViewAutoFilter
The DataGridViewAutoFilter project implements the the DataGridView
auto filter feature that is similar to Excel. For more information,
see http://go.microsoft.com/fwlink/?LinkId=105803

DGAutoFilter
The DGAutoFilter project tests the filtering functionality and
the DataGridViewAutoFilter.


System Requirements
===================
Visual Studio 2005


Testing the BindingFiltering Project
====================================
1. Set the BindingFiltering project as the start up project
2. Press F5 to start debugging.
3. In the displayed form, specify a filter, such as "LastName > Ham",
   and then click Apply Filter.
   Notice that the results are filtered.
4. Click Remove Filter to remove the filter.


Testing the DGAutoFilter Project
================================
1. Set the DGAutoFilter project as the start up project.
2. Press F5 to start debugging.
3. At the top of the DataGridView, click the down arrow for a column,
   and select an option.
   Notice that the results are filtered.
4. Click the Show All link to remove the filter.


--------------------------------------------------------------------- 
Copyright (C) Microsoft Corporation. All rights reserved. 

THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY 
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
PARTICULAR PURPOSE. 

---------------------------------------------------------------------