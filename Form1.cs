using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomException
{
    public partial class frmAddProduct : Form
    {
        //initialize private variables
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        //declaring variable showProductList of BindSource
        BindingSource showProductList;


        //creating a custom exceptions named "NumberFormatException", "StringFormatException", and "CurrencyFormatException"
        class NumberFormatException : Exception
        {
            public NumberFormatException(string quantity) : base(quantity) { }
        }

        class StringFormatException: Exception
        {
            public StringFormatException(string name) :  base(name) { }
        } 
                  
        class CurrencyFormatException: Exception
        {
            public CurrencyFormatException(string price) : base(price) { }
        }

        public frmAddProduct()
        {
            InitializeComponent();
            //instantiate bindingsource
            showProductList = new BindingSource();
        }


        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            //creating string array named "ListOfProductCategory" 
            string[] ListOfProductCategory = new string[]
            {
                "Beverages", "Bread/Bakery", "Canned/Jarred Goods",
                "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other"
            };

            //creating a foreach statement
            foreach (string variableName in ListOfProductCategory) 
            { 
                cbCategory.Items.Add(variableName); 
            }
        }

        //number 8, to be continued
        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException(name);
                }
            }
            catch(StringFormatException stringformat)
            {
                MessageBox.Show("The product name is String format! " + stringformat.Message);
            }
            finally
            {
                Console.WriteLine("You can only input string type!");
            }
            return name;
        }


        public int Quantity(string quantity)
        {
            try
            {
                if (!Regex.IsMatch(quantity, @"^[0-9]"))
                {
                    throw new NumberFormatException(quantity);
                }
            }
            catch(NumberFormatException numberformat)
            {
                MessageBox.Show("Number input in Quantity! " + numberformat.Message);
            }
            finally
            {
                Console.WriteLine("Enter the correct value!");
            }
            return Convert.ToInt32(quantity);           
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException(price);
                }
            }
            catch(CurrencyFormatException currencyformat)
            {
                MessageBox.Show("Currency format input in price! " + currencyformat.Message);
            }
            finally
            {
                Console.WriteLine("Enter the correct value!");
            }                           
            return Convert.ToDouble(price);
        }


        private void btAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text; 
            _Quantity = Quantity(txtQuantity.Text); 
            _SellPrice = SellingPrice(txtSellPrice.Text); 
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            gridViewProductList.DataSource = showProductList;
        }
    }
}
