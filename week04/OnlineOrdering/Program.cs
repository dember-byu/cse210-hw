using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string streetAddress, string city, string stateOrProvince, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        
        public bool IsUSA()
        {
            return _country.Trim().ToUpper() == "USA" || _country.Trim().ToUpper() == "UNITED STATES";
        }

        
        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    
    public class Customer
    {
        private string _name;
        private Address _address; 

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        
        public bool IsFromUSA()
        {
            return _address.IsUSA();
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }
    }

    
    public class Product
    {
        private string _name;
        private string _productId;
        private double _pricePerUnit;
        private int _quantity;

        public Product(string name, string productId, double pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        
        public double GetTotalProductCost()
        {
            return _pricePerUnit * _quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetProductId()
        {
            return _productId;
        }

        public double GetPricePerUnit()
        {
            return _pricePerUnit;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }

    
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        
        public double CalculateTotalCost()
        {
            double total = 0;
            
            foreach (Product product in _products)
            {
                total += product.GetTotalProductCost();
            }

            
            double shippingCost = _customer.IsFromUSA() ? 5.00 : 35.00;
            total += shippingCost;

            return total;
        }

        
        public string GetPackingLabel()
        {
            string label = "--- PACKING LABEL ---\n";
            foreach (Product product in _products)
            {
                label += $"- {product.GetName()} (ID: {product.GetProductId()}) x{product.GetQuantity()}\n";
            }
            return label;
        }

        
        public string GetShippingLabel()
        {
            string label = "--- SHIPPING LABEL ---\n";
            label += $"Customer: {_customer.GetName()}\n";
            label += _customer.GetAddress().GetFullAddress() + "\n";
            return label;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ONLINE ORDERING SYSTEM SHIPPMENTS\n");

            
            Address address1 = new Address("123 C# Programming Way", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Order order1 = new Order(customer1);

            
            order1.AddProduct(new Product("Mechanical Keyboard", "KB-990", 85.50, 1));
            order1.AddProduct(new Product("Ergonomic Wireless Mouse", "MS-432", 45.00, 1));
            order1.AddProduct(new Product("USB-C Braided Cable 6ft", "CB-102", 12.99, 2));

            
            Console.WriteLine("==================================================");
            Console.WriteLine("ORDER #1 (DOMESTIC)");
            Console.WriteLine("==================================================");
            Console.Write(order1.GetShippingLabel());
            Console.WriteLine();
            Console.Write(order1.GetPackingLabel());
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"TOTAL PRICE: ${order1.CalculateTotalCost():F2} (Includes $5.00 USA Shipping)");
            Console.WriteLine("==================================================\n\n");


            
            Address address2 = new Address("456 Avenue des Développeurs", "Paris", "Île-de-France", "France");
            Customer customer2 = new Customer("Marie Curie", address2);
            Order order2 = new Order(customer2);

            
            order2.AddProduct(new Product("UltraWide 34\" Productivity Monitor", "MN-771", 349.99, 1));
            order2.AddProduct(new Product("Noise Cancelling Headphones", "HP-550", 199.50, 1));

            
            Console.WriteLine("==================================================");
            Console.WriteLine("ORDER #2 (INTERNATIONAL)");
            Console.WriteLine("==================================================");
            Console.Write(order2.GetShippingLabel());
            Console.WriteLine();
            Console.Write(order2.GetPackingLabel());
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"TOTAL PRICE: ${order2.CalculateTotalCost():F2} (Includes $35.00 International Shipping)");
            Console.WriteLine("==================================================");
        }
    }
}
