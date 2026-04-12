### Giai đoạn 1: Nền tảng hệ thống

**Tổng quan & Mô tả:** Xây dựng khung WinForms, thiết kế mô hình dữ liệu lõi, phân quyền vai trò, quản lý migration.
**Tính năng chính:** Form điều hướng (`FrmTrangChu`), quản trị (`FrmAdmin`), mã hóa mật khẩu, CRUD tài khoản/nhân sự.
**Khó khăn & Kinh nghiệm:** Thiếu entity gây lỗi build, nên tách hàm phân quyền, ưu tiên ràng buộc DB, chuẩn hóa enum vai trò.

---

### Giai đoạn 2: Mở rộng trải nghiệm khách hàng

**Tổng quan & Mô tả:** Bổ sung giao diện khách hàng (`FrmKhachHang`), đặt lịch, xem lịch sử khám, cập nhật hồ sơ.
**Tính năng chính:** Tab đặt lịch, lịch sử, hồ sơ cá nhân, điều hướng phân quyền, đồng bộ control với entity.
**Khó khăn & Kinh nghiệm:** UI có trước logic, tên control chưa chuẩn, cần checklist build sạch, handler đủ, mapping entity-migration khớp.

---

### Giai đoạn 3: Tiếp nhận & đặt lịch tại quầy

**Tổng quan & Mô tả:** Triển khai form tiếp nhận (`FrmLichKham`), vận hành thực tế tại quầy lễ tân: tra cứu, lưu hồ sơ, đặt/cập nhật/hủy lịch khám.
**Tính năng chính:** Tự động điền thông tin bệnh nhân, đặt lịch, cập nhật, hủy lịch, lọc nhanh, validate số điện thoại/ngày khám, cảnh báo thay đổi chưa lưu.
**Khó khăn & Kinh nghiệm:** Cần kiểm tra trùng slot lịch, ưu tiên trạng thái "Đã hủy" thay vì xóa cứng, đồng bộ dữ liệu gốc, checklist build sạch, không còn class thiếu, event handler đủ.

---

### Giai đoạn 4: Khám bệnh cho Bác sĩ

**Tổng quan & Mô tả:** Bổ sung form khám bệnh (`FrmKhamBenh`), bác sĩ xử lý danh sách chờ, ghi nhận triệu chứng, chẩn đoán, chỉ định dịch vụ, kê đơn thuốc.
**Tính năng chính:** Danh sách chờ khám, phân quyền hiển thị, lưu bệnh án theo transaction, chỉ định dịch vụ, kê đơn thuốc, cảnh báo dữ liệu chưa lưu.
**Khó khăn & Kinh nghiệm:** Thiếu entity Thuốc/Dịch vụ gây lỗi build, kiểm tra trùng chỉ định/kê thuốc, đồng bộ trạng thái phiên khám, checklist transaction khi lưu nhiều bảng, chuẩn hóa test nghiệp vụ.

---

### Giai đoạn 5: Thu ngân & thanh toán

**Tổng quan & Mô tả:** Thiết kế form thu ngân (`FrmThuNgan`), chuẩn hóa luồng thanh toán sau khám.
**Tính năng chính:** Tìm kiếm phiếu khám, hiển thị chi tiết dịch vụ, tổng tiền, xác nhận thanh toán, in hóa đơn, điều hướng an toàn.
**Khó khăn & Kinh nghiệm:** Giao diện có nhưng thiếu logic code-behind, chuẩn hóa công thức tính tổng tiền, trạng thái thanh toán, checklist tách nghiệp vụ tài chính, ViewModel thanh toán thống nhất.

---

### Giai đoạn 6: Xác thực & đăng ký tài khoản

**Tổng quan & Mô tả:** Bổ sung đăng nhập (`FrmDangNhap`) và đăng ký tài khoản khách hàng (`FrmDangKi`), chuẩn hóa quy trình truy cập.
**Tính năng chính:** Đăng nhập, đăng ký, validate đầu vào, băm mật khẩu SHA-256, tạo đồng thời tài khoản và hồ sơ khách hàng.
**Khó khăn & Kinh nghiệm:** SHA-256 không salt, tài khoản admin hard-code, checklist transaction khi lưu nhiều bảng, build sạch, test chức năng cơ bản.

---

### Giai đoạn 7: Ổn định module Thuốc/Dịch vụ

**Tổng quan & Mô tả:** Bổ sung entity còn thiếu (`Thuoc`, `DichVu`, `ChiTietDonThuoc`, `ChiTietDichVu`), thêm form quản lý danh mục, gỡ lỗi build.
**Tính năng chính:** Form quản lý thuốc, dịch vụ (UI khung), đồng bộ DbContext, migration, build thành công.
**Khó khăn & Kinh nghiệm:** UI có trước, logic CRUD chưa có, validate dữ liệu, đồng bộ menu/toolbar, checklist CRUD end-to-end, validate đủ, test hồi quy.

---
