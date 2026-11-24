
# Hệ thống đăng ký học phần thời gian thực

## 1. Giới thiệu

Đề tài 02 - Hệ thống đăng ký học phần thời gian thực.

Bài tập lớn môn Phát triển ứng dụng phân tán.

Hệ thống cho phép sinh viên:
- Tra cứu danh sách lớp học phần.
- Xem số chỗ còn lại của từng lớp.
- Đăng ký hoặc hủy đăng ký học phần.
- Xem các học phần đã đăng ký.
- Nhận thông báo cập nhật số chỗ theo thời gian thực.

## 2. Công nghệ dự kiến

- C# / .NET 10
- ASP.NET Core Minimal API
- PostgreSQL
- Entity Framework Core
- gRPC
- RabbitMQ
- SignalR
- HTML, CSS, JavaScript
- Docker Compose
- Git và GitHub

## 3. Các thành phần hệ thống

- Registration API: Xử lý đăng ký học phần.
- Course Capacity Service: Quản lý sức chứa lớp.
- Notification Service: Cập nhật thời gian thực.
- Audit Worker: Lưu lịch sử thay đổi.
- Student Web Client: Giao diện sinh viên.

## 4. Tiến độ

- Tuần 1: Khởi tạo và phân tích yêu cầu.
- Tuần 2: Thiết kế kiến trúc và cơ sở dữ liệu.
- Tuần 3: Xây dựng REST API tra cứu học phần.
- Tuần 4: Xây dựng chức năng đăng ký và hủy.
- Tuần 5: Tích hợp gRPC.
- Tuần 6: RabbitMQ và Audit Worker.
- Tuần 7: SignalR và giao diện web.
- Tuần 8: Docker Compose và kiểm thử.
- Tuần 9: Hoàn thiện, báo cáo và demo.

## 5. Trạng thái

Đang thực hiện - Tuần 1.
