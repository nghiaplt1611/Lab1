using System;
using System.Collections.Generic;

namespace Lab1
{
    class PRODUCT
    {

        // Thêm các thuộc tính của class vào theo yêu cầu đề bài
        // Cách thêm constructor: chuột phải, chọn quick actions... (đừng để con trỏ chuột ở hàm comment này, trỏ chỗ khác nhe)
        // Rồi chọn generate constructor (chọn các thuộc tính cần thiết) 

        private string idPro;
        private string namePro;
        private double price;
        private double quantity; // Chỗ này hơi hư cấu tại số lượng mà đề cho double thì thôi theo đề nha, chứ sai vl :))

        public PRODUCT() { }

        public PRODUCT(string idPro, string namePro, double price, double quantity)
        {
            this.IdPro = idPro;
            this.NamePro = namePro;
            this.Price = price;
            this.Quantity = quantity;
        }

        
        // Thêm get set của thuộc tính
        // Tô đen toàn bộ thuộc tính của class, chọn quick actions..., chọn encapsulate fields (and use properties)
        // Ý nghĩa các phương thức get set là như thế này
        // Ban đầu là mình có các thuộc tính mình khai báo, ví dụ như idPro
        // IdPro sẽ đóng vai trò như là 1 phương thức vừa có thể get vừa có thể set giá trị thông qua idPro
        // Nếu gọi nó thì nó sẽ đóng vai trò là get, nếu gán cho nó giá trị thì nó đóng vai trò là set
        // Giống java vậy, mình khai báo thuộc tính đầu sau đó sẽ có 2 hàm get và set để xử lí, thì bên c# chỉ chơi 1 hàm nhưng có thể đóng hai vai trò
        // Trong class này, mình sẽ lấy giá trị thông qua biến khải tạo là idPro để xử lí (nó sẽ tự động có được giá trị của IdPro)
        // Qua class khác, mình sẽ lấy giá trị thông qua product.IdPro (tương đương với product.getIdPro) á

        public string IdPro { get => idPro; set => idPro = value; }
        public string NamePro { get => namePro; set => namePro = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }


        // Hàm input, nhập vào sản phẩm 
        // Lí do truyền vào cái list chứa các product chính là nhờ cái list này mà mình có thể check các sản phẩm đã có
        // từ đó loại bỏ các mã sản phẩm nhập trùng
        // Hàm ...Trim() là hàm cắt các kí tự khoảng trắng trước và sau chuỗi gióng java nha
        public void input(List<PRODUCT> listProduct)
        {
            Console.Write("--Please enter id number: ");
            idPro = Console.ReadLine().Trim();

            // Thoả mãn 2 điều kiện mới có thể đi tiếp
            // 1. ID sản phẩm đúng định dạng
            // 2. ID sản phẩm không trùng
            while (true)
            {
                if (!Validation.checkIDNumber(idPro))
                {
                    Console.Write("--------Error! Please enter id number again (SPxxx): ");
                    idPro = Console.ReadLine().Trim();
                }
                else if (!Validation.checkIDExisted(idPro, listProduct))
                {
                    Console.Write("--------Error! This id has already existed! Please enter id number again (SPxxx): ");
                    idPro = Console.ReadLine().Trim();
                }
                else
                {
                    break;
                }

            }
            Console.Write("--Please enter name: ");
            namePro = Console.ReadLine().Trim();

            // Check chuỗi có bị rỗng không rồi mới tiếp tục
            while (String.IsNullOrEmpty(namePro))
            {
                Console.Write("--------Error! Please enter name again (Not Null): ");
                namePro = Console.ReadLine().Trim();
            }
            Console.Write("--Please enter price: ");

            // Check giá tiền có đúng định dạng không thông qua try catch hoặc có đúng với điều kiện không rồi mới tiếp tục
            while (true)
            {
                string errorMessage = "--------Error! Please enter price again (price > 100 USD): ";
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                    if (Validation.checkPrice(price))
                        break;
                    Console.Write(errorMessage);

                }
                catch (Exception)
                {
                    Console.Write(errorMessage);
                }
            }
            Console.Write("--Please enter quantity: ");

            // Giống với check giá tiền, check số lượng cũng thế
            while (true)
            {
                string errorMessage = "--------Error! Please enter quanity again (more than 0 and less than 100): ";
                try
                {
                    quantity = Convert.ToDouble(Console.ReadLine());
                    if (Validation.checkQuantity(quantity))
                        break;
                    Console.Write(errorMessage);

                }
                catch (Exception)
                {
                    Console.Write(errorMessage);
                }
            }
        }

        // Hàm in ra
        // Giải thích chỗ {1, -24}: 1 thì là số index phần tử truyền vào cái Console.WriteLine như bình thường
        // Còn -24 tức là sẽ canh trái qua phải trên console 24 ô trống, bắt đầu tính từ vị trí viết kí tự đầu tiên
        // Để nó có thể canh đều và không bị nhảy
        // Ví dụ:
        // Console.WriteLine("{0}{1}{2}", "a", "b", "c")  // Output: abc
        // Console.WriteLine("{0}{1, -5}{2}", "a", "b", "c")  // Output: ab    c
        // Tham khảo thêm: http://referencedesigner.com/tutorials/csharp/csharp_6.php?fbclid=IwAR3JF3-JvLfmkVKFHMrWWoSFjoLlb6NVc279SOM_ml2EEPLKs0Xxy1jqUVI#:~:text=WriteLine%20is%20used%20to%20output,%22%2C%20arg1%2C%20

        public void output()
        {
            Console.WriteLine("|{0, -10}\t| {1, -24}|{2, -10}\t|{3, -10}", IdPro, NamePro, Price, Quantity);
        }
    }
}
