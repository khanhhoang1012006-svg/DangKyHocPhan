
# Phân tích yêu cầu hệ thống

## 1. Tên đề tài

Hệ thống đăng ký học phần thời gian thực.

## 2. Mục tiêu

Xây dựng hệ thống cho phép sinh viên đăng ký học phần,
đồng thời đảm bảo số lượng đăng ký không vượt quá
sức chứa của lớp.

## 3. Đối tượng sử dụng

- Sinh viên: Tra cứu, đăng ký và hủy học phần.
- Hệ thống: Kiểm tra sức chứa và xử lý đăng ký.

## 4. Yêu cầu chức năng

FR01: Xem danh sách lớp học phần.

FR02: Xem thông tin chi tiết và số chỗ còn lại.

FR03: Đăng ký một lớp học phần.

FR04: Hủy đăng ký học phần.

FR05: Ngăn đăng ký trùng.

FR06: Từ chối đăng ký khi lớp đã đầy.

FR07: Kiểm tra, giữ và trả chỗ thông qua gRPC.

FR08: Phát sự kiện đăng ký và hủy qua RabbitMQ.

FR09: Cập nhật số chỗ theo thời gian thực bằng SignalR.

FR10: Lưu lịch sử thay đổi bằng Audit Worker.

FR11: Xem danh sách học phần đã đăng ký của sinh viên.

## 5. REST API tối thiểu

GET /courses

GET /courses/{id}

POST /registrations

DELETE /registrations/{id}

GET /students/{studentId}/registrations

## 6. Yêu cầu phi chức năng

- Sử dụng C# và .NET 10.
- Xây dựng ASP.NET Core Minimal API.
- Các service chạy độc lập.
- Lưu trữ dữ liệu bằng cơ sở dữ liệu.
- Có Dockerfile cho từng service .NET.
- Có Docker Compose để chạy hệ thống.
- Có logging để theo dõi quá trình xử lý.
- Có khả năng phục hồi hợp lý khi service gặp sự cố.
- Quản lý mã nguồn bằng Git và GitHub.
