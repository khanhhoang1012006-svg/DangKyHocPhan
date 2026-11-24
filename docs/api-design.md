
# Thiết kế REST API

## 1. Danh sách học phần

GET /courses

Chức năng:
- Trả về danh sách lớp học phần.
- Hiển thị sức chứa và số chỗ còn lại.

HTTP 200: Thành công.

## 2. Chi tiết học phần

GET /courses/{id}

Chức năng:
- Tra cứu một lớp học phần theo ID.

HTTP 200: Thành công.
HTTP 404: Không tìm thấy.

## 3. Đăng ký học phần

POST /registrations

Request JSON:

```json
{
  "studentId": 1,
  "courseId": 2
}
```

Chức năng:
- Kiểm tra sinh viên.
- Kiểm tra đăng ký trùng.
- Gọi gRPC để giữ chỗ.
- Lưu đăng ký thành công.
- Phát sự kiện RegistrationCreated.

HTTP 201: Đăng ký thành công.
HTTP 400: Dữ liệu không hợp lệ.
HTTP 404: Sinh viên hoặc lớp không tồn tại.
HTTP 409: Đăng ký trùng hoặc lớp đã đầy.

## 4. Hủy đăng ký

DELETE /registrations/{id}

Chức năng:
- Kiểm tra đăng ký hiện tại.
- Cập nhật trạng thái thành Cancelled.
- Gọi gRPC trả chỗ.
- Phát sự kiện RegistrationCancelled.

HTTP 204: Hủy thành công.
HTTP 404: Không tìm thấy đăng ký.
HTTP 409: Không thể hủy ở trạng thái hiện tại.

## 5. Học phần đã đăng ký

GET /students/{studentId}/registrations

Chức năng:
- Tra cứu danh sách học phần mà sinh viên
  đang đăng ký.

HTTP 200: Thành công.

## 6. Giao tiếp gRPC dự kiến

Capacity Service cung cấp:
- CheckCapacity: Kiểm tra chỗ còn lại.
- ReserveSeat: Giữ một chỗ.
- ReleaseSeat: Trả một chỗ.

## 7. Sự kiện RabbitMQ

RegistrationCreated:
- eventId
- registrationId
- studentId
- courseId
- availableSeats
- occurredAt

RegistrationCancelled:
- eventId
- registrationId
- studentId
- courseId
- availableSeats
- occurredAt

Các sự kiện được gửi tới:
- Notification Service.
- Audit Worker.
