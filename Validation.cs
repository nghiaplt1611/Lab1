using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{

    // Đây là lớp dùng để kiểm tra dữ liệu
    class Validation
    {
        // Kiểm tra định dạng ID của sản phẩm thông qua regular expression
        // @ là quy định chuỗi đặc biệt bên C# (không liên quan đến regex)
        // ^ là bắt đầu, $ là kết thúc của regex
        // SP là kí tự cần phải có
        // [0-9]{3} nghĩa là cho phép có kí tự (0-9) xuất hiện đúng 3 lần
        // Kiểm tra nếu id của người dùng nhập vào đúng với regex hay không
        public static bool checkIDNumber(string id)
        {
            Regex regex = new Regex(@"^SP[0-9]{3}$");
            if (regex.IsMatch(id))
                return true;
            return false;
        }

        // Kiểm tra id có bị trùng không thông qua id và list sản phẩm hiện có
        // Duyệt từ phần tử trong list
        // Lấy giá trị id sản phẩm ra so với id được truyền vào (id người dùng nhập)
        public static bool checkIDExisted(string id, List<PRODUCT> listProduct)
        {
            foreach (PRODUCT p in listProduct)
            {
                if (p.IdPro.Equals(id))
                    return false;
            }
            return true;
        }

        // Check giá sản phẩm theo yêu cần đề bài
        public static bool checkPrice(double price)
        {
            if (price <= 100)
                return false;
            return true;
        }

        // Check số lượng sản phẩm theo yêu cầu đề bài
        public static bool checkQuantity(double quantity)
        {
            if (!(quantity > 0 && quantity < 100))
                return false;
            return true;
        }

    }
}
