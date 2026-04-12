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
