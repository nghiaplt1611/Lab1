using System;
using System.Text;

namespace Lab1
{

    /*
     * Ý tưởng cách bố trí của tui sẽ như sau (dựa trên đề bài nhe)
     * 1. Tạo các class đối tượng theo yêu cầu 
     * gồm có các thuộc tính (private giống java), 2 loại constructor (có và không có tham số), get set các dữ liệu, và các phương thức cần thiết 
     * 2. Tạo các class quản lý đối tượng đã tạo
     * thường là các list của đối tượng đó
     * 3. Tạo 1 class dùng để check các kiểu dữ liệu hay format cần thiết (Validation)
     * 4. Class Program chứa hàm main sẽ bắt đầu khởi tạo và chạy toàn bộ
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Dòng này dùng nếu muốn ghi ra console tiếng việt nhe
            //Console.OutputEncoding = Encoding.UTF8;

            // Vì tất cả các phương thức cần xử lí đều thông qua class PRO_manager nên cần tạo đối tượng trước, và gọi hàm menu để bắt đầu
            PRO_Manager manager = new PRO_Manager();
            manager.menu();

        }
    }
}
