using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_delegate
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> fun1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> fun2 = new Func<Product>(productFactory.MakeToyCar);

            Box box1 = wrapFactory.WrapProduct(fun1);
            Box box2 = wrapFactory.WrapProduct(fun2);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
            Console.ReadKey();
        }
    }
    class Product
    {
        public string Name { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            box.Product = product;
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            return product;
        }
    }
    
}

//public delegate double Calu(double x, double y);
//class Program
//{
//    static void Main(string[] args)
//    {
//        Calculator calculator = new Calculator();
//        Calu calutor = new Calu(calculator.Add);

//        double a = 100;
//        double b = 150;
//        double c = 0;

//        c = calutor.Invoke(a, b);

//        Console.WriteLine(c);
//        Console.ReadKey(); 
//    }


//}

//class Calculator
//{
//    public Calculator()
//    {

//    }
//    public double Add(double x, double y)
//    {
//        return x + y;
//    }
//}

