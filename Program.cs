using DuAn1_Nhom4.GUI;

namespace DuAn1_Nhom4
{
    internal static class Program
    {
        public static string ChucVuDangNhap = "";
        public static string TenDangNhap = "";
        public static int MaNV = 0;

        // THÊM DÒNG NÀY ĐỂ KHỚP VỚI CODE TRONG FORM QUẢN LÝ
        public static int MaVaiTroDangNhap = 0;
        [STAThread]
        static void Main()
        {
            // 1. Cấu hình DPI trước khi khởi tạo bất kỳ UI nào
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // 2. Khởi tạo cấu hình mặc định của Application
            ApplicationConfiguration.Initialize();

            // 3. Chạy Form đăng nhập
            Application.Run(new FormDangNhap());
        }
    }
}