
# Thiết kế cơ sở dữ liệu

Hệ quản trị: PostgreSQL

## 1. Bảng students

Lưu thông tin sinh viên.

| Cột | Kiểu | Ý nghĩa |
|---|---|---|
| id | INTEGER | Khóa chính |
| student_code | VARCHAR(20) | Mã sinh viên, duy nhất |
| full_name | VARCHAR(100) | Họ tên |
| email | VARCHAR(150) | Email |

## 2. Bảng courses

Lưu lớp học phần và sức chứa.

| Cột | Kiểu | Ý nghĩa |
|---|---|---|
| id | INTEGER | Khóa chính |
| code | VARCHAR(20) | Mã lớp, duy nhất |
| name | VARCHAR(150) | Tên học phần |
| capacity | INTEGER | Sức chứa tối đa |
| registered_count | INTEGER | Số chỗ đã giữ |

Số chỗ còn lại = capacity - registered_count.

## 3. Bảng registrations

Lưu thông tin đăng ký học phần.

| Cột | Kiểu | Ý nghĩa |
|---|---|---|
| id | INTEGER | Khóa chính |
| student_id | INTEGER | Khóa ngoại students |
| course_id | INTEGER | Khóa ngoại courses |
| status | VARCHAR(20) | Trạng thái |
| created_at | TIMESTAMPTZ | Thời gian đăng ký |

Trạng thái:
- Active: Đang đăng ký.
- Cancelled: Đã hủy.

## 4. Bảng audit_logs

Lưu lịch sử thay đổi.

| Cột | Kiểu | Ý nghĩa |
|---|---|---|
| id | INTEGER | Khóa chính |
| event_id | UUID | Mã sự kiện duy nhất |
| event_type | VARCHAR(50) | Loại sự kiện |
| registration_id | INTEGER | Mã đăng ký |
| created_at | TIMESTAMPTZ | Thời gian ghi |

## 5. Quan hệ

- students 1:N registrations.
- courses 1:N registrations.
- Mỗi sinh viên không được có hai đăng ký Active
  trên cùng một lớp học phần.
- registered_count phải nằm trong khoảng
  từ 0 đến capacity.

## 6. Quy tắc xử lý

- Khi đăng ký thành công, registered_count tăng 1.
- Khi hủy thành công, registered_count giảm 1.
- Khi lớp đầy, từ chối đăng ký mới.
- Thao tác giữ chỗ cần đảm bảo tính nguyên tử.
- API phải tránh xử lý đăng ký trùng khi gửi lại yêu cầu.
- Trạng thái đăng ký và sức chứa phải được đối soát
  khi xảy ra lỗi giữa các service.

## 7. Ghi chú triển khai

Tuần 2 chỉ thực hiện thiết kế.

Các bảng và ràng buộc sẽ được triển khai thực tế
bằng PostgreSQL và Entity Framework Core
trong các tuần lập trình tiếp theo.
```
