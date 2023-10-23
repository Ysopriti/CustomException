using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{

    //creating a Product Class
    internal class ProductClass
    {
        //initialize a private variable
        private int _Quantity;
        private double _SellingPrice; 
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

        //overloaded method with its parameters
        public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate,
            double Price, int Quantity, string Description)
        { 
            //adding value to the declared variables
            this._Quantity = Quantity; 
            this._SellingPrice = Price; 
            this._ProductName = ProductName;
            this._Category = Category; 
            this._ManufacturingDate = MfgDate; 
            this._ExpirationDate = ExpDate; 
            this._Description = Description; 
        }

        //creating a method for getter and setter
        public string Product_Name
        { 
            get
            {   return this._ProductName;   }
            set    
            {   this._ProductName = value;  } 
        }

        public string Category
        {
            get
            {   return this._Category;      }
            set 
            {   this._Category = value;     }
        }

        public string Manufacturing_Date 
        { 
            get 
            {   return this._ManufacturingDate;   }
            set
            {   this._ManufacturingDate = value;  }
        }

        public string Expiration_Date 
        {
            get
            {   return this._ExpirationDate;      } 
            set 
            {   this._ExpirationDate = value;     } 
        }

        public string Description 
        { 
            get
            {    return this._Description;        }
            set 
            {    this._Description = value;       }
        }

        public int Quantity
        {
            get
            {     return this._Quantity;          }

            set
            {     this._Quantity = value;         }
        }

        public double Selling_Price
        { 
            get 
            {     return this._SellingPrice;      }
            set 
            {     this._SellingPrice = value;     } 
        }

    }
}
