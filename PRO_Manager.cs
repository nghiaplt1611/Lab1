using System;
using System.Collections.Generic;

namespace Lab1
{
    class PRO_Manager
    {

        // Tạo cái list kiểu PRODUCT để lưu các sản phẩm
        // Tạo constructor, get, set xem lại bên class PRODUCt
        private List<PRODUCT> listProduct = new List<PRODUCT>();

        public PRO_Manager() { }

        public PRO_Manager(List<PRODUCT> listProduct)
        {
            this.listProduct = listProduct;
        }

        internal List<PRODUCT> ListProduct { get => listProduct; set => listProduct = value; }

        // Thêm sản phẩm
        public void add()
        {
            int numOfProduct;

            // Chạy tiếp khi nhập đúng định dạng số và phải nhập số nguyên dương
            while (true)
            {
                Console.Write("+ Enter number of product: ");

                try
                {
                    numOfProduct = Convert.ToInt32(Console.ReadLine());
                    if (numOfProduct <= 0)
                        Console.WriteLine("The number of products must be a positive number");
                    else
                        break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Thêm từng sản phẩm vào list thông qua việc tạo object của product và gọi phương thức input
            for (int i = 0; i < numOfProduct; i++)
            {
                Console.WriteLine("- Product {0}", i + 1);
                PRODUCT product = new PRODUCT();
                product.input(ListProduct);
                listProduct.Add(product);
                Console.WriteLine();
            }
        }

        // Hiển thị list (Xem giải thích ở bên output của PRODUCT)
        public void show()
        {
            Console.WriteLine("=========================== List Product ===========================");
            Console.WriteLine("|{0, -10}\t|{1, -25}|{2, -10}\t|{3, -10}", "ID", "Name", "Price", "Quantity");
            foreach (PRODUCT p in ListProduct)
            {
                p.output();
            }
        }

        // Hiện menu
        public void menu()
        {
            bool exit = false;

            // Chương trình chỉ dừng khi người dùng chọn exit
            while (!exit)
            {
                Console.WriteLine("----------MENU----------\n" + "1. Input product.\n" + "2. Show list product.\n" + "0. Exit.\n");
                Console.Write("Please choose: ");
                int choice;

                // Kiểm tra lựa chọn của người dùng có đúng format số không rồi mới đi tiếp
                while (true)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Please choose: ");
                    }
                }
                switch (choice)
                {
                    case 1:
                        add();
                        break;
                    case 2:
                        show();
                        Console.WriteLine();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("This choice is not avalable");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
