# README - Giai đoạn 1 (Nền tảng hệ thống)

## 1. Tổng quan giai đoạn 1

**Tên đồ án:** Quản lý phòng khám tư nhân  
**Nền tảng:** C# WinForms (.NET 8), SQL Server, ADO.NET provider (`System.Data.SqlClient`) kết hợp Entity Framework Core  
**Mục tiêu của giai đoạn 1:**

- Dựng bộ khung ứng dụng desktop quản lý phòng khám.
- Hoàn thiện mô hình dữ liệu lõi (tài khoản, nhân sự, khách hàng, lịch khám, phiếu khám, hóa đơn, nhật ký hệ thống).
- Thiết kế các form nền tảng để quản trị tài khoản và điều hướng theo vai trò.
- Tạo và quản lý migration để chuẩn hóa schema database theo hướng phát triển tăng dần.

Giai đoạn 1 đóng vai trò là **xương sống kỹ thuật** cho toàn bộ 10 giai đoạn: nếu nền tảng dữ liệu, phân quyền và điều hướng không chắc, các giai đoạn nghiệp vụ phía sau sẽ khó mở rộng và dễ phát sinh lỗi dây chuyền.

---

## 2. Các form đã thiết kế trong giai đoạn 1

Trong phạm vi mã nguồn hiện tại của `GiaiDoan1`, các form đã có file triển khai gồm:

### 2.1. `FrmTrangChu`

**Vai trò:** form trung tâm sau đăng nhập, điều phối menu/chức năng theo quyền user.

**Các điểm chính đã làm:**

- Nhận thông tin user đăng nhập (`TaiKhoan currentUser`) để hiển thị và phân quyền.
- Xử lý phân quyền theo vai trò: Admin, Bác sĩ, Nhân viên, Khách hàng.
- Điều khiển hiển thị menu và toolbar tương ứng với từng vai trò.
- Cơ chế đăng xuất an toàn: mở lại form đăng nhập và tránh thoát toàn bộ ứng dụng ngoài ý muốn.
- Tạo các điểm điều hướng đến các màn hình nghiệp vụ (khám bệnh, tiếp nhận, thuốc, dịch vụ) ở mức khung.

### 2.2. `FrmAdmin`

**Vai trò:** form quản trị hệ thống, tập trung vào quản lý user và hồ sơ nhân sự.

**Cấu trúc giao diện:** 3 tab chính

- Tab Quản lý tài khoản
- Tab Quản lý nhân sự
- Tab Nhật ký hệ thống (Log) - đã có UI khung

**Các điểm chính đã làm ở Tab Quản lý tài khoản:**

- CRUD tài khoản (thêm, sửa, khóa/mở khóa, xóa có kiểm soát).
- Tìm kiếm tài khoản theo từ khóa username.
- Mã hóa mật khẩu bằng SHA-256 trước khi lưu.
- Validate đầu vào cơ bản:
  - Username phải theo định dạng `@gmail.com`.
  - Không cho phép bỏ trống các trường bắt buộc.
- Cơ chế ưu tiên khóa tài khoản thay vì xóa cứng để giữ toàn vẹn lịch sử.

**Các điểm chính đã làm ở Tab Quản lý nhân sự:**

- Liên kết hồ sơ nhân sự với tài khoản hệ thống.
- Tách luồng cập nhật theo vai trò Bác sĩ/Nhân viên.
- Validate số điện thoại bằng regex (`9-10` chữ số).
- Đồng bộ dữ liệu lên DataGridView và cho phép click ngược để đổ dữ liệu lên form chỉnh sửa.

**Tab Nhật ký hệ thống (Log):**

- Đã dựng layout giao diện và control phục vụ lọc log/xuất báo cáo.
- Là nền sẵn để hoàn thiện logic truy vấn log ở các giai đoạn tiếp theo.

---

## 3. Công việc kỹ thuật đã thực hiện trong giai đoạn 1

### 3.1. Khởi tạo dự án và cấu hình môi trường

- Tạo project WinForms trên `net8.0-windows`.
- Bật `UseWindowsForms` và `Nullable`.
- Cài package EF Core:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`

### 3.2. Thiết kế tầng dữ liệu bằng Entities (Code-First)

Đã xây dựng các entity lõi:

- `TaiKhoan`
- `BacSi`
- `NhanVien`
- `KhachHang`
- `LichKham`
- `PhieuKham`
- `HoaDon`
- `NhatKyHeThong`

**Đặc điểm thiết kế:**

- Dùng Data Annotations (`[Table]`, `[Key]`, `[Required]`, `[StringLength]`, `[ForeignKey]`) để ánh xạ table/column/ràng buộc.
- Định nghĩa quan hệ 1-1, 1-n thông qua navigation property.
- Thiết lập default value cho một số trường thời gian như `NgayTao`, `NgayLap`, `ThoiGian`.

### 3.3. Cấu hình `DbContext`

`PhongMachDbContext` đã:

- Khai báo đầy đủ `DbSet` cho các module lõi.
- Đọc chuỗi kết nối từ `App.config` thông qua `ConfigurationManager`.
- Sử dụng SQL Server provider:
  - `UseSqlServer(...)`
- Cấu hình chống cascade delete không mong muốn ở lịch khám:
  - `LichKham -> KhachHang` dùng `DeleteBehavior.Restrict`
  - `LichKham -> BacSi` dùng `DeleteBehavior.Restrict`

### 3.4. Kết nối database theo mô hình EF Core + ADO.NET

Chuỗi kết nối đặt trong `App.config`:

```xml
<add name="PhongMachDbContext"
		 connectionString="Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True;TrustServerCertificate=True"
		 providerName="System.Data.SqlClient" />
```

Ý nghĩa:

- Ứng dụng dùng EF Core để thao tác dữ liệu mức đối tượng (entity).
- Tầng kết nối vật lý xuống SQL Server sử dụng provider ADO.NET (`System.Data.SqlClient`).
- Cách tiếp cận này giúp vừa thuận tiện phát triển nhanh (ORM), vừa bám chuẩn kết nối doanh nghiệp của SQL Server trên Windows.

---

## 4. Lịch sử migration trong giai đoạn 1

Các migration đã có theo thứ tự:

### 4.1. `20260130045100_KhoiTaoCSDL`

- Tạo bộ bảng ban đầu: `TAIKHOAN`, `BACSI`, `KHACHHANG`, `NHANVIEN`, `NHATKYHETHONG`, `LICHKHAM`, `PHIEUKHAM`, `HOADON`.
- Tạo khóa chính, khóa ngoại, index và một số unique index quan trọng.
- Định hình mô hình dữ liệu lõi ngay từ đầu.

### 4.2. `20260321145913_ThemTrangThaiChoLichKham`

- Bổ sung cột `TrangThai` cho bảng `LICHKHAM`.
- Mục tiêu: hỗ trợ vòng đời lịch khám (chờ khám, đã khám, hủy, v.v.).

### 4.3. `20260322161807_ThemCotTrieuChung`

- Bổ sung cột `TrieuChung` cho bảng `PHIEUKHAM`.
- Mục tiêu: lưu triệu chứng ban đầu trước khi kết luận chẩn đoán.

### 4.4. `20260324071814_ThemThuocVaDichVu`

- Mở rộng module điều trị và thu phí:
  - Tạo bảng `THUOC`, `DICHVU`.
  - Tạo bảng chi tiết liên kết theo phiếu khám: `CHITIET_DONTHUOC`, `CHITIET_DICHVU`.

---

## 5. Quy trình migration nên áp dụng (chuẩn cho các giai đoạn sau)

Khi thay đổi entity, cần đi theo quy trình chặt chẽ:

1. Cập nhật entity + `DbContext`.
2. Tạo migration mới:
   - `Add-Migration TenMigration` (Package Manager Console)
   - hoặc `dotnet ef migrations add TenMigration`
3. Kiểm tra file migration và snapshot.
4. Cập nhật DB:
   - `Update-Database`
   - hoặc `dotnet ef database update`
5. Chạy lại các luồng chức năng liên quan để kiểm thử hồi quy.

---

## 6. Lỗi sai có thể gặp ở giai đoạn 1 (phân tích thực tế)

Phần này tổng hợp cả lỗi thường gặp trong dự án WinForms + EF Core và các rủi ro có thể phát sinh từ chính hiện trạng mã nguồn giai đoạn 1.

### 6.1. Lỗi thiếu class nhưng đã khai báo trong `DbContext`

- Có thể xảy ra khi đã thêm migration cho entity mới nhưng chưa commit file entity tương ứng.
- Hậu quả: project không build được (`CS0246`), chặn toàn bộ tiến trình phát triển.

### 6.2. Lỗi tham chiếu form điều hướng nhưng form chưa có file triển khai

- Form trung tâm (`FrmTrangChu`) có thể gọi tới các màn hình nghiệp vụ khác trước khi các màn hình đó hoàn thiện.
- Hậu quả: lỗi compile hoặc runtime nếu không kiểm soát theo từng giai đoạn.

### 6.3. Rủi ro bảo mật khi hash mật khẩu chưa có salt

- SHA-256 thuần giúp che mật khẩu nhưng chưa đủ mạnh khi đối mặt tấn công dictionary/rainbow table.
- Hướng cải tiến ở giai đoạn sau: dùng PBKDF2/BCrypt/Argon2 có salt riêng cho từng tài khoản.

### 6.4. Lỗi dữ liệu do thiếu unique index ở tầng DB

- Nếu chỉ kiểm tra trùng username ở tầng code mà DB chưa có unique constraint, có thể trùng dữ liệu khi ghi đồng thời.

### 6.5. Lỗi xóa dữ liệu gây vi phạm khóa ngoại

- Khi xóa cứng tài khoản đã phát sinh nghiệp vụ, rất dễ dính `DbUpdateException`.
- Cách làm đúng đã được áp dụng một phần: ưu tiên khóa mềm (soft lock) thay vì xóa cứng.

### 6.6. Lỗi nghiệp vụ do chuẩn hóa vai trò chưa nhất quán

- Nếu lưu vai trò bằng text tự do (`Admin`, `ADMIN`, `Bác sĩ`, `BAC SI`...), logic `Contains` dễ lệch.
- Kinh nghiệm: chuẩn hóa enum/code role từ sớm.

### 6.7. Lỗi quy trình migration trong làm việc nhóm

- Dễ gặp tình trạng xung đột snapshot hoặc thứ tự migration không đồng bộ giữa các máy.
- Kinh nghiệm: thống nhất quy tắc đặt tên migration + luôn review file migration trước khi merge.

---

## 7. Khó khăn thực tế và kinh nghiệm rút ra

### 7.1. Khó khăn về thiết kế dữ liệu ban đầu

- Giai đoạn đầu thường chưa nhìn hết toàn bộ nghiệp vụ, nên entity thay đổi liên tục.
- Kinh nghiệm: ưu tiên thiết kế các thực thể lõi và mối quan hệ chính trước, phần mở rộng tách migration sau.

### 7.2. Khó khăn về đồng bộ UI và nghiệp vụ

- WinForms cho phép dựng UI nhanh nhưng dễ phát sinh tình trạng "UI có trước, logic theo sau".
- Kinh nghiệm: mỗi tab/chức năng cần checklist rõ ràng: validate, truy vấn, xử lý lỗi, refresh dữ liệu.

### 7.3. Khó khăn về phân quyền

- Khi số vai trò tăng, việc bật/tắt control thủ công dễ sót.
- Kinh nghiệm: tách hàm phân quyền trung tâm, tránh duplicate logic ở nhiều form.

### 7.4. Khó khăn về toàn vẹn dữ liệu

- Các thao tác xóa/chỉnh sửa nếu không bám ràng buộc DB sẽ gây lỗi dây chuyền.
- Kinh nghiệm: ưu tiên ràng buộc ở DB + xử lý thông báo lỗi thân thiện ở UI.

---

## 8. Đánh giá kết quả giai đoạn 1

**Đã hoàn thành tốt:**

- Khung dự án WinForms + EF Core hoạt động theo hướng Code-First.
- Có form nền tảng cho điều hướng và quản trị hệ thống.
- Có lịch sử migration thể hiện tư duy phát triển theo từng bước.
- Đã chú trọng kiểm tra dữ liệu đầu vào và xử lý tình huống khóa ngoại khi thao tác tài khoản.

**Cần hoàn thiện tiếp ở giai đoạn kế tiếp:**

- Đồng bộ đầy đủ class entity và form được tham chiếu để build ổn định 100%.
- Hoàn chỉnh logic tab log hệ thống và xuất báo cáo.
- Nâng cấp bảo mật mật khẩu từ hash thuần sang thuật toán có salt/work factor.
- Chuẩn hóa role code và bổ sung unique constraint tại DB cho các trường định danh quan trọng.

---

## 9. Kết luận

Giai đoạn 1 đã đặt nền móng quan trọng cho đồ án Quản lý phòng khám tư nhân: từ kiến trúc ứng dụng WinForms, mô hình dữ liệu, cơ chế phân quyền, đến quy trình migration database. Với nền tảng này, các giai đoạn tiếp theo có thể tập trung mở rộng nghiệp vụ chuyên sâu (tiếp nhận, khám bệnh, kê thuốc, thanh toán, báo cáo) trên một cấu trúc đã được tổ chức bài bản.
