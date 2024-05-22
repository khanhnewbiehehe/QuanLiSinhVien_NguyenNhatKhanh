# WEBSITE QUẢN LÍ SINH VIÊN

## Giới thiệu
- Trang web cơ bản để quản lí thông tin sinh viên, giảng viên, lớp học phần, khoa.

## Chức năng
- Xem danh sách các đối tượng.
- Thêm, sửa, xóa các đối tượng.
- Tìm kiếm và lọc các đối tượng.
- Đăng nhập cho admin, giảng viên, sinh viên

## Yêu cầu hệ thống
- SQL Sever 2019
- Visual Studio 2022
- Git version 2.41.0.windows.2

## Hướng dẫn cài đặt
1. SQL Sever:
- Cài đặt SQL Sever 2019 hoặc mới hơn.
- Mở file QLSinhVien1.sql bằng MS Sql Sever Management Studio.
- Execute file để chạy và lưu cơ sở dữ liệu vào máy.
2. Git:
- Cài đặt git version 2.41.0 hoặc mới hơn.
- Tạo một thư mục chứa code chuẩn bị cho việc clone code về.
- Click on chuột phải vào thư mục vừa tạo và select Git Bash Here 
- Nhập: "git clone https://github.com/khanhnewbiehehe/QuanLiSinhVien_NguyenNhatKhanh.git" để tải toàn bộ dự án về máy.
3. Visual Studio:
- Cài đặt Visual Studio 2022 hoặc mới hơn.
- Mở thư mục chứa dự án đã clone code về.
- Cài đặt các NuGet package: Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools 
- Chỉnh sửa chuỗi kết nối trong QlsinhvienContext.cs cho phù hợp.
- Chạy chương trình.
