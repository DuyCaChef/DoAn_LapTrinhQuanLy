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

---

---

---

# README - Giai đoạn 2 (Mở rộng trải nghiệm khách hàng)

## 10. Tổng quan giai đoạn 2

Giai đoạn 2 kế thừa toàn bộ nền tảng kỹ thuật đã xây dựng ở giai đoạn 1 và tập trung vào mục tiêu mở rộng theo hướng **khách hàng tự phục vụ** trên hệ thống quản lý phòng khám.

Trọng tâm của giai đoạn này là:

- Thiết kế giao diện riêng cho khách hàng (`FrmKhachHang`) với các nhu cầu nghiệp vụ cốt lõi.
- Hoàn thiện khung UX cho luồng đặt lịch, theo dõi lịch khám và cập nhật hồ sơ cá nhân.
- Kết nối tư duy thiết kế form với cấu trúc dữ liệu đã có từ giai đoạn 1 (Lịch khám, Phiếu khám, Khách hàng, Tài khoản).

Nói ngắn gọn, nếu giai đoạn 1 là phần móng hệ thống nội bộ, thì giai đoạn 2 là bước chuyển sang **lớp tương tác trực tiếp với người bệnh**.

---

## 11. Các form đã thiết kế trong giai đoạn 2

Trong phạm vi mã nguồn hiện tại của `GiaiDoan2`, phần mới nổi bật là form khách hàng và phần điều hướng liên quan tới vai trò khách hàng.

### 11.1. `FrmKhachHang` (form mới của giai đoạn 2)

Form này được thiết kế theo hướng module hóa với `TabControl`, gồm 3 tab nghiệp vụ:

1. **Tab Đặt lịch mới**

- Khu vực nhận diện người bệnh: mã bệnh nhân, tên bệnh nhân.
- Khu vực nhập thông tin đăng ký khám:
  - Chọn chuyên khoa (`cboChuyenKhoa`)
  - Chọn bác sĩ (không bắt buộc) (`cboChonBacSi`)
  - Chọn ngày khám (`dtpNgayKham`)
  - Mô tả triệu chứng (`txtMoTaTrieuChung`)
  - Nút xác nhận đặt lịch (`btnXacNhanDatLich`)
- Khu vực tra cứu lịch khám sắp tới bằng `DataGridView` (`dgvLichKham`) với các cột: Ngày khám, Bác sĩ, Trạng thái.

2. **Tab Lịch sử khám**

- Sử dụng `DataGridView` (`dgvLichSuKham`) để hiển thị lịch sử điều trị.
- Thiết kế cột dữ liệu theo hướng nghiệp vụ: Ngày khám, Bác sĩ phụ trách, Chuyên khoa, Kết luận/Chẩn đoán.

3. **Tab Hồ sơ cá nhân**

- Khối cập nhật thông tin cơ bản:
  - Họ tên, ngày sinh, số điện thoại, giới tính, địa chỉ.
  - Nút cập nhật thông tin (`btnCapNhat`).
- Khối đổi mật khẩu:
  - Mật khẩu cũ, mật khẩu mới, checkbox hiển thị mật khẩu, nút xác nhận đổi mật khẩu.

### 11.2. Điều hướng ở `FrmTrangChu` cho vai trò khách hàng

Ở giai đoạn 2, cấu trúc phân quyền trong `FrmTrangChu` đã tiếp tục thể hiện định hướng phục vụ khách hàng:

- Vai trò khách hàng được bật quyền truy cập mục thông tin/đặt lịch.
- Toolstrip có nút `Đặt lịch` và menu có mục `Thông tin khách hàng`.
- Đây là bước chuẩn bị để liên kết trực tiếp sang `FrmKhachHang` khi hoàn thiện logic sự kiện.

---

## 12. Các công việc đã thực hiện ở giai đoạn 2

### 12.1. Mở rộng phạm vi nghiệp vụ từ nội bộ sang khách hàng

- Giai đoạn 1 tập trung Admin/Nhân sự; giai đoạn 2 mở rộng trải nghiệm cho người bệnh.
- Bổ sung giao diện nghiệp vụ đủ lớn để chứa trọn các quy trình khách hàng hay dùng.

### 12.2. Chuẩn hóa bố cục giao diện theo nghiệp vụ thực tế

- Dùng `SplitContainer` để tách vùng nhập liệu và vùng xem dữ liệu.
- Dùng `DataGridView` có cột rõ ràng để đồng bộ với dữ liệu thật từ DB sau này.
- Bố cục theo tác vụ giúp giảm thao tác chéo: đặt lịch, xem lịch sử, cập nhật hồ sơ.

### 12.3. Chuẩn bị dữ liệu đầu vào phục vụ tích hợp logic

- Các control nhập liệu được thiết kế bám sát dữ liệu trong Entity:
  - `LichKham.TrangThai`
  - `PhieuKham.TrieuChung`
  - `KhachHang` (thông tin nhân thân)
- Việc đặt tên control tương đối rõ mục đích, hỗ trợ phát triển code-behind nhanh ở giai đoạn tiếp theo.

### 12.4. Kế thừa hạ tầng kết nối dữ liệu

- Tiếp tục dùng mô hình C# WinForms + EF Core + SQL Server.
- App.config và DbContext giữ ổn định theo chiến lược của giai đoạn 1.
- Migrations trong giai đoạn 2 hiện vẫn theo bộ migration đã có trước đó (chưa thêm migration mới riêng cho giai đoạn 2).

---

## 13. Điểm khác biệt chính giữa giai đoạn 1 và giai đoạn 2

- Giai đoạn 1: xây nền kỹ thuật và quản trị hệ thống.
- Giai đoạn 2: mở rộng lớp giao diện phục vụ khách hàng cuối.

Khác biệt giá trị:

- Từ tư duy “quản trị nội bộ” sang “trải nghiệm người dùng nghiệp vụ”.
- Từ form quản trị dữ liệu sang form tác nghiệp đặt lịch và theo dõi khám bệnh.

---

## 14. Lỗi sai có thể gặp ở giai đoạn 2 (phân tích kỹ thuật)

### 14.1. Lỗi tích hợp: đã có giao diện nhưng chưa gắn sự kiện đầy đủ

- Một số nút/menu đã hiện trong UI nhưng chưa có handler điều hướng hoặc xử lý nghiệp vụ.
- Hậu quả: người dùng thao tác nhưng không có phản hồi, gây cảm giác hệ thống bị treo/chưa hoàn thiện.

### 14.2. Lỗi đặt tên control gây khó bảo trì

- Ví dụ biến textbox mật khẩu cũ đặt tên theo tiền tố `btn` dễ gây nhầm lẫn khi đọc code.
- Hậu quả: tăng rủi ro viết sai logic xử lý sự kiện hoặc binding.

### 14.3. Lỗi đồng bộ giữa model và UI grid

- `DataPropertyName` trong các cột DataGridView nếu không khớp đúng view model/query sẽ dẫn tới cột trắng dữ liệu.
- Cần quy ước tên thống nhất ngay từ đầu để tránh chỉnh sửa dây chuyền.

### 14.4. Lỗi build do entity thiếu file triển khai

- Dù có migration liên quan thuốc/dịch vụ, project hiện vẫn có thể lỗi compile khi thiếu class entity tương ứng (`Thuoc`, `DichVu`, `ChiTietDonThuoc`, `ChiTietDichVu`).
- Hậu quả: chặn test UI thực tế của giai đoạn 2.

### 14.5. Lỗi validate đầu vào ở form khách hàng

- Nếu chưa validate số điện thoại, ngày khám hợp lệ, hoặc triệu chứng quá dài, dữ liệu có thể không nhất quán và gây lỗi lưu DB.
- Đây là lỗi thường gặp khi chuyển từ thiết kế UI sang triển khai lưu dữ liệu thật.

### 14.6. Lỗi bảo mật khi đổi mật khẩu

- Dễ bỏ sót bước xác thực mật khẩu cũ hoặc chưa hash đúng chuẩn trước khi lưu.
- Rủi ro an toàn dữ liệu tài khoản tăng mạnh nếu triển khai vội.

---

## 15. Khó khăn thực tế và kinh nghiệm ở giai đoạn 2

### 15.1. Khó khăn khi chuyển từ “dựng khung” sang “điền logic thật”

- Thiết kế UI nhanh nhưng phần nghiệp vụ phía sau (đặt lịch, lọc lịch sử, cập nhật profile) cần nhiều xử lý đồng bộ DB.
- Kinh nghiệm: chốt hợp đồng dữ liệu (DTO/ViewModel) trước khi code xử lý sự kiện.

### 15.2. Khó khăn về trải nghiệm người dùng

- Với user là khách hàng, giao diện cần trực quan hơn giao diện admin.
- Kinh nghiệm: ưu tiên flow ngắn, thông báo lỗi dễ hiểu, và phản hồi rõ sau mỗi thao tác.

### 15.3. Khó khăn về kiểm thử luồng liên vai trò

- Dữ liệu khách hàng liên quan bác sĩ, lịch khám, phiếu khám nên cần test chéo nhiều role.
- Kinh nghiệm: tạo bộ dữ liệu mẫu chuẩn cho từng vai trò để test nhanh và ổn định.

### 15.4. Khó khăn về nhất quán giữa các giai đoạn

- Khi phát triển theo nhiều giai đoạn, rất dễ copy tiến độ không đồng đều giữa code, migration, form.
- Kinh nghiệm: mỗi giai đoạn nên có checklist đóng giai đoạn gồm:
  - Build sạch
  - Form chính có handler đủ
  - Mapping entity và migration khớp
  - README cập nhật đúng hiện trạng

---

## 16. Đánh giá kết quả giai đoạn 2

**Điểm đạt được:**

- Đã bổ sung thành công form khách hàng với phạm vi giao diện rộng và sát nghiệp vụ phòng khám.
- Đã định hình rõ 3 nhóm chức năng phía người bệnh: đặt lịch, xem lịch sử, quản lý hồ sơ cá nhân.
- Đã duy trì nhất quán nền tảng công nghệ từ giai đoạn 1, giúp giảm rủi ro phân mảnh kiến trúc.

---

## 17. Kết luận giai đoạn 2

Giai đoạn 2 là bước tiến quan trọng giúp đồ án vượt khỏi phạm vi quản trị nội bộ để tiếp cận đúng bối cảnh thực tế của phòng khám tư nhân: bệnh nhân cần tự theo dõi thông tin và tương tác dịch vụ. Việc thiết kế `FrmKhachHang` ở giai đoạn này là tiền đề trực tiếp cho các giai đoạn triển khai nghiệp vụ sâu hơn (tiếp nhận, khám, kê đơn, thanh toán và báo cáo tổng hợp).

---

---

---

# README - Giai đoạn 3 (Hoàn thiện luồng tiếp nhận và đặt lịch tại quầy)

## 18. Tổng quan giai đoạn 3

Giai đoạn 3 kế tiếp giai đoạn 2, tập trung chuyển từ mức "thiết kế giao diện" sang "vận hành nghiệp vụ thực tế tại quầy lễ tân". Điểm nổi bật của giai đoạn này là đã đưa vào triển khai form `FrmLichKham` với nhiều xử lý dữ liệu thật: tra cứu bệnh nhân, lưu hồ sơ nhanh, đặt lịch, cập nhật lịch, hủy lịch, và lọc danh sách lịch khám.

Nếu giai đoạn 2 nhấn mạnh trải nghiệm khách hàng ở mức khung, thì giai đoạn 3 nhấn mạnh **luồng thao tác nội bộ của nhân viên lễ tân** để phục vụ tiếp nhận khám bệnh hằng ngày.

---

## 19. Các form đã thiết kế/phát triển trong giai đoạn 3

### 19.1. `FrmLichKham` (form mới và là trọng tâm của giai đoạn 3)

Form này được tổ chức thành 2 nhóm nghiệp vụ chính và một lưới lịch khám tổng hợp:

1. **Nhóm Thông tin Bệnh nhân**

- Tra cứu nhanh theo số điện thoại (nhấn Enter để tự động lấy dữ liệu cũ).
- Tự động điền Họ tên, Địa chỉ, Ngày sinh, Giới tính nếu bệnh nhân đã tồn tại.
- Cho phép tạo mới hoặc cập nhật hồ sơ bệnh nhân tại quầy.

2. **Nhóm Thông tin Lịch khám**

- Chọn chuyên khoa, bác sĩ, ngày khám, giờ khám.
- Danh sách bác sĩ phụ thuộc chuyên khoa (cascading combobox).
- Thiết lập khung giờ khám định sẵn để chuẩn hóa lịch hẹn.

3. **DataGridView danh sách lịch khám**

- Hiển thị đầy đủ: mã lịch, bệnh nhân, SĐT, bác sĩ, ngày/giờ khám, trạng thái.
- Hỗ trợ click dòng để nạp lại dữ liệu lên form phục vụ sửa/hủy.
- Có lọc nhanh theo tên hoặc số điện thoại.

4. **Các thao tác nghiệp vụ đã có logic**

- Lưu bệnh nhân.
- Đặt lịch khám.
- Cập nhật lịch khám.
- Hủy lịch (xóa lịch).
- Làm mới form và kiểm soát đóng form khi còn dữ liệu chưa lưu.

### 19.2. Các form kế thừa từ giai đoạn trước

- `FrmAdmin`, `FrmTrangChu`, `FrmKhachHang` vẫn giữ vai trò nền.
- `FrmTrangChu` tiếp tục điều hướng mở `FrmLichKham` cho vai trò lễ tân/nhân viên.

---

## 20. Các công việc đã thực hiện trong giai đoạn 3

### 20.1. Hoàn thiện nghiệp vụ tiếp nhận bệnh nhân tại quầy

- Thiết kế và cài đặt luồng "nhập SĐT -> kiểm tra bệnh nhân cũ -> tự điền thông tin".
- Nếu chưa có bệnh nhân, cho phép nhập đầy đủ hồ sơ và lưu mới trực tiếp.
- Gắn kết dữ liệu bệnh nhân với tài khoản hệ thống để đảm bảo quản lý thống nhất.

### 20.2. Hoàn thiện nghiệp vụ đặt lịch khám

- Thiết lập combobox giờ khám theo khung thời gian cố định.
- Chuyển đổi dữ liệu giờ từ chuỗi hiển thị sang `TimeSpan` trước khi lưu.
- Thiết lập trạng thái mặc định cho lịch mới là "Chờ khám".
- Áp dụng kiểm tra dữ liệu bắt buộc trước khi lưu lịch.

### 20.3. Hoàn thiện nghiệp vụ cập nhật và hủy lịch

- Cho phép chọn lịch từ lưới để nạp ngược toàn bộ dữ liệu lên form.
- Cập nhật đồng thời thông tin bệnh nhân và lịch khám.
- Hủy lịch có xác nhận, tải lại dữ liệu sau thao tác để đồng bộ UI.

### 20.4. Cải thiện chất lượng thao tác giao diện

- Lọc nhanh lịch khám theo từ khóa realtime.
- Nút làm mới để reset trạng thái làm việc.
- Cảnh báo trước khi đóng form nếu người dùng đang nhập dở dữ liệu.

### 20.5. Nâng mức validate dữ liệu

- Kiểm tra định dạng số điện thoại (9-10 chữ số).
- Không cho phép ngày sinh ở tương lai.
- Không cho phép đặt/ngày khám lùi về quá khứ.
- Cảnh báo rõ ràng theo từng tình huống để giảm sai sót thao tác.

---

## 21. Giá trị nghiệp vụ đạt được ở giai đoạn 3

- Lễ tân có thể thao tác gần như trọn chu trình tiếp nhận trên một màn hình.
- Thời gian nhập liệu giảm nhờ tự động điền theo số điện thoại.
- Dữ liệu lịch khám được chuẩn hóa tốt hơn nhờ khung giờ cố định và trạng thái lịch.
- Hệ thống tiến gần hơn đến trạng thái sẵn sàng vận hành thực tế tại phòng khám.

---

## 22. Lỗi sai có thể gặp ở giai đoạn 3 (phân tích thực tế)

### 22.1. Lỗi bảo mật khi tạo tài khoản bệnh nhân tại quầy

- Mật khẩu mặc định bệnh nhân nếu lưu trực tiếp theo số điện thoại (chưa hash) có rủi ro cao.
- Kinh nghiệm: luôn hash mật khẩu trước khi lưu, kể cả tài khoản sinh tự động.

### 22.2. Lỗi thiết kế thao tác hủy lịch bằng xóa cứng

- Xóa hẳn lịch khám có thể làm mất vết nghiệp vụ và gây khó truy vết sau này.
- Kinh nghiệm: nên ưu tiên cơ chế trạng thái "Đã hủy" thay vì delete vật lý.

### 22.3. Lỗi dữ liệu do thiếu kiểm tra trùng slot lịch

- Nếu chưa kiểm tra trùng bác sĩ + ngày + giờ, hệ thống có thể tạo 2 lịch trùng khung khám.
- Đây là lỗi thường gặp khi vừa hoàn thiện CRUD cơ bản.

### 22.4. Lỗi kiểm soát thay đổi chưa lưu chưa đầy đủ

- Dù có biến lưu trạng thái gốc để so sánh thay đổi, nếu không cập nhật các biến này đúng thời điểm sau khi chọn dòng/lưu dữ liệu, cảnh báo "chưa lưu" có thể sai thực tế.
- Kinh nghiệm: đồng bộ rõ vòng đời dữ liệu gốc ngay sau mỗi lần load dữ liệu chuẩn.

### 22.5. Lỗi thiếu event điều hướng giữa các form

- Một số mục menu/toolbar có thể đã hiển thị nhưng chưa gắn sự kiện mở form tương ứng.
- Hậu quả: UX không nhất quán giữa quyền và hành vi bấm nút.

### 22.6. Lỗi build vẫn tồn tại do thiếu entity mở rộng

- Dự án giai đoạn 3 hiện vẫn có nguy cơ không build thành công nếu thiếu class: `Thuoc`, `DichVu`, `ChiTietDonThuoc`, `ChiTietDichVu`.
- Đây là điểm nghẽn kỹ thuật cần xử lý dứt điểm trước khi mở rộng module khám/chỉ định sâu hơn.

---

## 23. Khó khăn và kinh nghiệm ở giai đoạn 3

### 23.1. Khó khăn khi đồng bộ 2 cụm dữ liệu cùng lúc

- Một thao tác sửa lịch có thể chạm cả bảng Khách hàng và Lịch khám.
- Kinh nghiệm: đóng gói theo transaction hoặc quy trình lưu nhất quán để tránh trạng thái nửa chừng.

### 23.2. Khó khăn về trải nghiệm nhập liệu nhanh tại quầy

- Người dùng nội bộ cần tốc độ cao và ít thao tác lặp.
- Kinh nghiệm: ưu tiên keyboard-first (Enter tra cứu), tự động nạp dữ liệu, và thông báo ngắn gọn dễ hiểu.

### 23.3. Khó khăn về quy tắc nghiệp vụ thời gian

- Quản lý ngày/giờ khám có nhiều edge case (quá khứ, cận giờ, đổi lịch).
- Kinh nghiệm: chuẩn hóa toàn bộ rule ngay ở tầng service hoặc trước khi save để giảm lỗi nghiệp vụ.

### 23.4. Khó khăn về tính mở rộng nhiều giai đoạn

- Khi phát triển tuần tự theo giai đoạn, việc "có migration nhưng thiếu class" hoặc "có UI nhưng chưa wiring" rất dễ tái diễn.
- Kinh nghiệm: mỗi lần kết thúc giai đoạn nên có checklist bắt buộc:
  - Build sạch
  - Không còn class tham chiếu thiếu
  - Form chính có event handler cho các nút quan trọng
  - README cập nhật đúng trạng thái thật

---

## 24. Đánh giá kết quả giai đoạn 3

**Đã hoàn thành tốt:**

- Hoàn thiện được form `FrmLichKham` với nhiều luồng nghiệp vụ thực chiến cho lễ tân.
- Đã có đầy đủ thao tác chính: thêm/sửa/hủy/lọc lịch khám, kết hợp quản lý thông tin bệnh nhân.
- Chất lượng validate và cảnh báo người dùng đã tiến bộ rõ so với các giai đoạn đầu.

---

## 25. Kết luận giai đoạn 3

Giai đoạn 3 đánh dấu bước trưởng thành quan trọng của đồ án: từ thiết kế màn hình sang triển khai luồng nghiệp vụ vận hành tại quầy tiếp nhận. Với `FrmLichKham`, hệ thống đã có nền tảng thao tác thực tế cho lễ tân, đồng thời bộc lộ rõ các điểm cần chuẩn hóa ở tầng dữ liệu và bảo mật để sẵn sàng bước sang các giai đoạn nghiệp vụ chuyên sâu tiếp theo.
