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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BindingFiltering
{
    public class Form1 : Form
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(538, 220);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(145, 226);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(33, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 226);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Apply Filter";
            this.button1.UseVisualStyleBackColor = true;
            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Remove Filter";
            this.button2.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        private Button button1;
        private Button button2;
        public System.Windows.Forms.TextBox textBox1;
        private BindingSource bindingSource1;
        private IContainer components;
        FilteredBindingList<Employee> businessObjects;

        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            businessObjects = new FilteredBindingList<Employee>();
            businessObjects.Add(new Employee("Haas", "Jonathan", 35000, new DateTime(2005, 12, 12)));
            businessObjects.Add(new Employee("Adams", "Ellen", 55000, new DateTime(2004, 1, 11)));
            businessObjects.Add(new Employee("Hanif", "Kerim", 45000, new DateTime(2003, 12, 4)));
            businessObjects.Add(new Employee("Akers", "Kim", 35600, new DateTime(2002, 12, 12)));
            businessObjects.Add(new Employee("Harris", "Phyllis", 60000, new DateTime(2004, 10, 10)));
            businessObjects.Add(new Employee("Andersen", "Elizabeth", 65000, new DateTime(2006, 4, 4)));
            businessObjects.Add(new Employee("Alberts", "Amy", 35000, new DateTime(2007, 2, 1)));
            businessObjects.Add(new Employee("Hamlin", "Jay", 38000, new DateTime(2004, 8, 8)));
            businessObjects.Add(new Employee("Hee", "Gordon", 50000, new DateTime(2004, 10, 12)));
            businessObjects.Add(new Employee("Penor", "Lori", 40000, new DateTime(2006, 12, 20)));
            businessObjects.Add(new Employee("Pfeiffer", "Michael", 49000, new DateTime(2002, 1, 29)));
            businessObjects.Add(new Employee("Perry", "Brian", 54000, new DateTime(2005, 9, 25)));
            businessObjects.Add(new Employee("Pan", "Mingda", 56000, new DateTime(2004, 10, 17)));
            businessObjects.Add(new Employee("Philips", "Carol", 65000, new DateTime(2005, 8, 14)));
            businessObjects.Add(new Employee("Pica", "Guido", 52000, new DateTime(2006, 6, 23)));
            businessObjects.Add(new Employee("Jean", "Virginie", 38000, new DateTime(2002, 5, 2)));
            businessObjects.Add(new Employee("Reiter", "Tsvi", 39000, new DateTime(2003, 4, 12)));

            bindingSource1.DataSource = businessObjects;
            dataGridView1.DataSource = bindingSource1;
            PropertyDescriptorCollection objectProps = 
                TypeDescriptor.GetProperties(businessObjects[0]);
            BindingSource bindingSource2 = new BindingSource();
            foreach (PropertyDescriptor prop in objectProps)
            {
                if (prop.PropertyType.GetInterface("IComparable", true) != null)
                    bindingSource2.Add(prop.Name);
            }
            comboBox1.DataSource = bindingSource2;
            comboBox2.Items.AddRange(new string[] { "<", "=", ">" });
            comboBox2.SelectedIndex = 0;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.Filter = GetFilterString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + " Try another filter expression.");
            }
        }

        public string GetFilterString()
        {
            StringBuilder query = new StringBuilder();
            if (comboBox1.SelectedItem != null)
                query.Append((string)comboBox1.SelectedItem);
            else
                query.Append(comboBox1.Text);
            if (comboBox2.SelectedItem != null)
                query.Append((string)comboBox2.SelectedItem);
            else
                query.Append(comboBox2.Text);
            query.Append("'" + textBox1.Text + "'");
            return query.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveFilter();
        }
    }
}