create database BTL_QLCH_Sach
drop database BTL_QLCH_Sach

create table LoaiSach
(maloaisach int IDENTITY(1,1) PRIMARY KEY,
tenloaisach nvarchar(256));

insert into LoaiSach 
values
(N'Văn học'),
(N'Toán học'),
(N'Tâm lý-kỹ năng'),
(N'Truyện cười')

create table PhieuNhap
(maphieunhap int IDENTITY(1,1) PRIMARY KEY,
tennhacungcap nvarchar(256),
ngaylapphieu datetime,
tongtien float);

insert into PhieuNhap(tennhacungcap,ngaylapphieu)
values 
(N'Phúc Long', '2022/01/21'),
(N'Thành Đạt', '2022/05/30'),
(N'Hoa Mai', '2022/09/05'),
(N'Y Lan ','2022/07/4')

create table NhanVien
(manhanvien int IDENTITY(1,1) PRIMARY KEY,
tennhanvien nvarchar(50),
diachi nvarchar(256),
sdt char(10) unique)

insert into NhanVien
values
(N'Nguyễn Văn Nam', 'Hà Nội', '0918923753'),
(N'Phạm Thị An', 'Hà Nội', '0918923253'),
(N'Lê Thị Vân', 'Bắc Ninh', '0918932753'),
(N'Lê Thị Huyền Trang', 'Hải Phòng', '091893753')
select * from NhanVien
UPDATE NhanVien
SET  diachi= N'Hải Phòng'
WHERE manhanvien = 4
create table HoaDon
(mahoadon int IDENTITY(1,1) PRIMARY KEY,
ngaylaphoadon datetime,
tenkhachhang nvarchar(50),
sdtkhachhang nchar(11) unique,
manhanvien int ,
tongtien float,
foreign key (manhanvien) references nhanvien(manhanvien));

insert into HoaDon(ngaylaphoadon, tenkhachhang, sdtkhachhang, manhanvien)
values
('2022/12/23', N'Nguyễn Gia Bảo', '032165482', 1),
('2022/12/10', N'Phạm Thùy Linh', '03265487', 2),
('2022/10/12', N'Bùi Thu Thủy', '035687954', 4),
('2022/12/6', N'Mai Văn Hiếu', '064089478', 3),
('2022/12/23', N'Mai Thành Chung', '040847987', 1),
('2022/12/1', N'Phạm Toàn Thắng', '03654608', 4),
('2022/11/30', N'Văn Quang', '0231654688', 1)

create table KhoSach
(masach int IDENTITY(1,1) PRIMARY KEY,
tensach nvarchar(256),
tacgia nvarchar(256),
soluong int,
giaban float,
maloaisach int,
foreign key (maloaisach) references LoaiSach(maloaisach));

insert into KhoSach
values
(N'AQ chính truyện', N'Lỗ Tấn', 10, 90000,1),
(N'Giải Tích 1', N'Bùi Xuân', 13, 77000,2),
(N'Đọc Vị Bất kỳ ai', N'David J', 23, 80000,3),
(N'Tiểu Hòa Thượng', N'An Nam', 19, 48000,4),
(N'Đại Số Tuyến Tính', N'Bá Cao', 33, 70000,2),
(N'Tôm và Tít', N'Tố Hữu', 21, 32000,3),
(N'Chí Phèo', N'Nam Cao', 20, 56000,1)

create table ChiTietHoaDon
(mahoadon int,
masach int,
primary key( mahoadon, masach),
soluong int,
thanhtien float,
foreign key (mahoadon) references HoaDon(mahoadon),
foreign key (masach) references KhoSach(masach));

insert into ChiTietHoaDon(mahoadon, masach, soluong)
values
(1,1,3),
(1,3,1),
(2,2,1),
(2,4,2),
(3,5,1),
(4,7,3),
(5,3,4),
(6,1,1),
(7,5,2)
select * from hoadon;

create table ChiTietPhieuNhap
(maphieunhap int,
masach int,
primary key( maphieunhap, masach),
soluong int,
gianhap float,
thanhtien float,
foreign key (maphieunhap) references PhieuNhap(maphieunhap),
foreign key (masach) references KhoSach(masach));

insert into ChiTietPhieuNhap(maphieunhap, masach, soluong, gianhap)
values
(1,1,10,80000),
(1,7,12,50000),
(2,2,6,70000),
(2,5,16,60000),
(3,3,9,70000),
(3,6,11,25000),
(4,4,14,32000)
---===========================LỆNH CHẠY TRONG WINFORM=======================------------
--	KHO SÁCH
	--thêm sách
create proc proc_themsach
@tenSach nvarchar(256), @tacGia nvarchar(256), @soLuong int, @giaBan float, @maLoaiSach int
as
	begin
		insert into KhoSach(tensach, tacgia, soluong, giaban, maloaisach) values(@tenSach, @tacGia, @soLuong, @giaBan, @maLoaiSach);
	end

	--sửa sách
create proc proc_capnhatsach
@maSach int, @tenSach nvarchar(256), @tacGia varchar(256), @soLuong int, @giaBan float, @maLoaisach int
as
	begin
		update KhoSach
		set tensach = @tenSach, tacgia=@tacGia, soluong=@soLuong, giaban=@giaBan, maloaisach=@maLoaisach
		where masach = @maSach;
	end

--	LOẠI SÁCH
	--thêm loại sách
create proc proc_themloaisach
@tenLoaiSach nvarchar(256)
as
begin
	insert into LoaiSach(tenloaisach) values(@tenLoaiSach);
	end
	--sửa loại sách
create proc proc_capnhatloaisach
@maLoaiSach int, @tenLoaiSach nvarchar(256)
as
	begin
		update LoaiSach
		set tenloaisach = @tenLoaiSach
		where maloaisach = @maLoaiSach;
	end

--	HÓA ĐƠN
	--thêm hóa đơn
create proc proc_themhoadon
@tenKhachHang nvarchar(50), @sdtKhachHang nchar(11), @ngayLapHoaDon datetime
as
	begin
		insert into HoaDon(tenkhachhang, sdtkhachhang, ngaylaphoadon) values(@tenKhachHang, @sdtKhachHang, @ngayLapHoaDon);
	end
drop proc proc_capnhathoadon
	--sửa hóa đơn
create proc proc_capnhathoadon
@maHoaDon int, @tenKhachHang nvarchar(50), @sdtKhachHang nchar(11), @ngayLapHoaDon datetime
as
	begin
		update HoaDon
		set tenkhachhang = @tenKhachHang, sdtkhachhang = @sdtKhachHang, ngaylaphoadon = @ngayLapHoaDon
		where mahoadon = @maHoaDon;
	end

--	PHIẾU NHẬP
--thêm phiếu nhập
create proc proc_themphieunhap
@tenNhaCungCap nvarchar(256), @ngayLapPhieuNhap datetime
as
	begin
		insert into PhieuNhap(tennhacungcap, ngaylapphieu) values(@tenNhaCungCap, @ngayLapPhieuNhap);
	end
drop proc proc_capnhatchitietphieunhap

--sửa phiếu nhập
create proc proc_capnhatphieunhap
@maPhieuNhap int, @tenNhaCungCap nvarchar(256), @ngayLapPhieuNhap datetime
as
	begin
		update PhieuNhap
		set tennhacungcap = @tenNhaCungCap, ngaylapphieu = @ngayLapPhieuNhap
		where maphieunhap = @maPhieuNhap;
	end

--CHI TIẾT HÓA ĐƠN
--thêm chi tiết hóa đơn
create proc proc_themchitiethoadon
@maHoaDon int, @maSach int, @soLuong int, @giaBan float
as
	begin
		insert into ChiTietHoaDon(mahoadon, masach, soluong, thanhtien ) values(@maHoaDon, @maSach, @soLuong, @thanhTien);
	end
		/*update KhoSach
		set soluong = soluong-@soLuong
		where  masach = @maSach;*/
	
	drop proc proc_themchitiethoadon
--load lại số lượng
create proc proc_loadslgsach
@maSach int, @soLuong int
as
	begin
		update KhoSach
		set soluong = soluong+@soLuong
		where  masach = @maSach;
	end

drop proc proc_xoachitiethoadon
--sửa chi tiết hóa đơn
///////
create proc proc_capnhatchitiethoadon
@maHoaDon int, @maSach int, @soLuong int
as
	begin

		declare @giaBan float
		declare @thanhTien float
		select @giaBan=giaban from KhoSach where masach=@maSach
		set @thanhTien=@soLuong*@giaBan

		update ChiTietHoaDon
		set soluong = @soLuong, thanhtien=@thanhTien
		where mahoadon = @maHoaDon and masach = @maSach;
	end
	drop proc proc_capnhatchitiethoadon
	select * from ChiTietHoaDon
	//////
	/*update KhoSach
		set soluong = soluong-@soLuong
		where  masach = @maSach;
	update KhoSach
		set soluong = soluong+@soLuong
		where  masach = @maSach;*/
	--slg 
create proc proc_xoachitiethoadon
@maHoaDon int, @maSach int, @soLuong int, @giaBan float
as
	begin
		delete from ChiTietHoaDon where mahoadon = @maHoaDon and masach = @maSach;
		
	end

--	CHI TIẾT PHIẾU NHẬP
--thêm chi tiết phiếu nhập
create proc proc_themchitietphieunhap
@maPhieuNhap int, @maSach int, @soLuong int, @giaNhap float
as
	begin
		insert into ChiTietPhieuNhap(maphieunhap, masach, soluong, gianhap ) values(@maPhieuNhap, @maSach, @soLuong, @giaNhap);
		update KhoSach
		set soluong = soluong+@soLuong
		where  masach = @maSach;
	end

	drop proc proc_themchitietphieunhap
--sửa chi tiết phiếu nhập
create proc proc_capnhatchitietphieunhap
@maPhieuNhap int, @maSach int, @soLuong int, @giaNhap float
as
	begin
		update ChiTietPhieuNhap
		set soluong = @soLuong, gianhap = @giaNhap
		where maphieunhap = @maPhieuNhap and masach = @maSach;
	end
--xóa chi tiết phiếu nhập
create proc proc_xoachitietphieunhap
@maPhieuNhap int, @maSach int, @soLuong int, @giaNhap float
as
	begin
		delete from ChiTietPhieuNhap where maphieunhap = @maPhieuNhap and masach = @maSach;
		--insert into ChiTietHoaDon(mahoadon, masach, soluong, giaban ) values(@maHoaDon, @maSach, @soLuong, @giaBan);
		update KhoSach
		set soluong = soluong-@soLuong
		where  masach = @maSach;
	end
	select * from ChiTietPhieuNhap
---///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
--============================================CON TRỎ-CURSOR===========================---
----in ra các hóa đơn đã mua quyển sách đại số tuyến tính
--: cập nhật dữ liệu cho trường tổng tiền
declare cur1 cursor dynamic scroll for
select mahoadon, sum(thanhtien) as thanhtien from chitiethoadon cthd group by mahoadon;
open cur1;
declare @mahd nvarchar(50), @thanhtien float ;
fetch first from cur1 into @mahd, @thanhtien;
while (@@FETCH_STATUS =0 ) 
begin 
update HoaDon
set Tongtien=@thanhtien where mahoadon=@mahd
fetch next from cur1 into @mahd, @thanhtien;
end
close cur1; deallocate cur1;
select * from KhoSach
select * from ChiTietHoaDon
select * from HoaDon

---Tạo cursor để duyệt qua từng hàng kết quả của bảng nhân viên.
    DECLARE @manv int
  DECLARE @tennv nvarchar(200)
  DECLARE cur1 CURSOR DYNAMIC SCROLL
  FOR SELECT manhanvien, tennhanvien FROM Nhanvien
  OPEN cur1
  FETCH FIRST FROM cur1 INTO @manv, @tennv
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
 PRINT N'MÃ NH N VIÊN: ' + CAST(@manv as nvarchar)
 PRINT N'TÊN NH N VIÊN: ' + @tennv
 FETCH NEXT FROM cur1 INTO @manv, @tennv
 END
 close cur2; deallocate cur2

 --C U 1: In ra tên khách hàng mua hàng với mhd là 2 
declare cur_cau1 cursor dynamic scroll for
select tenkhachhang from HoaDon where mahoadon= 2
open cur_cau1
declare @x  nvarchar(50)
fetch first from cur_cau1 into @x
while (@@FETCH_STATUS = 0)
begin
print N'Khách hàng mua mã hóa đơn 2 có tên là: ' + @x
fetch next from cur_cau1 into @x;
end
close cur_cau1; deallocate cur_cau1

declare cur_c2 cursor dynamic scroll
for select mahoadon from  ChiTietHoaDon cthd, KhoSach ks where cthd.masach=ks.masach and tensach = N'Đại số tuyến tính'
open cur_c2;
declare @mhd int
fetch first from cur_c2 into @mhd;
while (@@FETCH_STATUS = 0)
begin
print N 'Đại số tuyến tính có mã hóa đơn là: ' + cast (@mhd as char(5))
fetch next from cur_c2 into @mhd;
end
close cur_c2; deallocate cur_c2

--============================================THỦ TỤC-PROC=========================---
----cập nhật trường thành tiền
create proc thanh_tien
as begin
Update ChiTietHoaDon
set ThanhTien=SoLuong* (Select giaban from KhoSach  where KhoSach.masach=ChiTietHoaDon.masach )
end;
exec thanh_tien
select * from ChiTietHoaDon

--2. Viết một thủ tục đặt tên là sp_ThuNhap để tính thu nhập của cửa hàng 
----trong một khoảng thời gian nào đó với ngày đầu và ngày cuối là tham số đầu vào của thủ tục. 
create proc sp_ThuNhap(@ngaydau date ,@ngaycuoi date ,@tongthunhap float output)
as 
	begin
		select @tongthunhap=Sum(TongTien) from HoaDon where ngaylaphoadon between @ngaydau and @ngaycuoi
	end
drop proc sp_ThuNhap
DECLARE @ttn float;

EXEC sp_ThuNhap
    @ngaydau = '2022-12-10',
    @ngaycuoi = '2022-12-23',
	@tongthunhap =@ttn output;
select @ttn as 'Tong thu nhap'

select * from HoaDon

 -- 05 Viết một thủ tục để thống kê và in ra màn hình số lượng hóa đơn theo ngày trong tuần.
 DROP proc IF EXISTS pr_01
 create proc pr_01 as
select
(case DATEPART(dw,ngaylaphoadon)
WHEN 1 THEN N'CHỦ NHẬT'
WHEN 2 THEN N'THỨ 2'
WHEN 3 THEN N'THỨ 3'
WHEN 4 THEN N'THỨ 4'
WHEN 5 THEN N'THỨ 5'
WHEN 6 THEN N'THỨ 6'
WHEN 7 THEN N'THỨ 7'
END) AS NGAYTRONGTUAN,
COUNT(*) AS SOLUONGDON
FROM HoaDon
GROUP BY DATEPART(DW, ngaylaphoadon)
go
EXEC pr_01
--06 Viết một thủ tục  đưa ra số lượng đã bán của tên sách, với tên sách là tham số đưa vào
Create procedure pr_02(@tensach nvarchar(50))
as
begin
declare @soluong int;
select @soluong = sum(ct.soluong)
from ChiTietHoaDon ct, KhoSach ks
WHERE  ks.tensach = @tensach
and ks.masach = ct.masach;
return @soluong;
end
--Gọi thực hiện thủ tục
DECLARE @soluong int;
EXEC @soluong = pr_02 N'AQ chính truyện';
select @soluong

--C U 1: Tạo thủ tục để cho biết tên khách hàng của 1 hóa đơn bất kỳ(đúng)
create proc pr_1
@mhd char(5)
as begin
select tenkhachhang from HoaDon where mahoadon= @mhd
end;
exec pr_1'3'

--Câu 2 in ra các thông tin hóa đơn có tên khách hàng là 'Phạm Thùy Linh'
 create proc pr_c2
@tenkh nvarchar(50)
as begin
select * from HoaDon where tenkhachhang= @tenkh
end;
exec pr_c2 N 'Phạm Thùy Linh'

--============================================HÀM - FUNCTION------------------
----4. Hàm trả về bảng tính số lượng sách theo từng loại sách
CREATE FUNCTION SLSACHTHEOLOAI()
RETURNS @kq TABLE ( maloaisach nvarchar(50), SLSach int)
AS BEGIN
INSERT INTO @kq SELECT maloaisach, COUNT(masach) FROM KhoSach
GROUP BY maloaisach
RETURN END

SELECT  maloaisach, SLSach FROM dbo.SLSACHTHEOLOAI()

-- Viết 1 hàm f_SoMatHang trả về tổng số mặt hàng trong 1 hóa đơn 
create function f_SoMatHang (@mahd int)
returns int
as begin
declare @somh int;
select @somh = COUNT(masach) from ChiTietHoaDon where mahoadon=@mahd
group by mahoadon
return @somh
end
print ' Tong so mat hang trong hoa don: '+convert(char,dbo.f_SoMatHang('2'))


--01 in ra tên sách không có khách hàng nào mua
CREATE FUNCTION C1() RETURNS TABLE AS
RETURN(SELECT tensach FROM khosach WHERE masach not in (SELECT  masach FROM chitiethoadon))
select * from c1();
 --02 Viet hàm thống kê số lượng sách mỗi loại sách
Drop function fc_01
CREATE FUNCTION FC_01()
RETURNS @bang TABLE
(
   	MALOAISACH CHAR(10),
   	SOLUONG INT
)
AS BEGIN
   	INSERT INTO @bang
   	SELECT maloaisach, count(maloaisach)
   	FROM KhoSach
   	GROUP BY maloaisach
   	RETURN
END
SELECT * FROM FC_01()
 --03 viết hàm in ra thông tin các sách có trong một phiếu nhập bất kỳ. Với mã phiếu nhập là biến đầu vào.
drop function FC_02
CREATE FUNCTION FC_02(@maphieunhap int)
RETURNS @bang TABLE
(	MASACH INT,
   	TENSACH NVARCHAR(25),
   	TACGIA NVARCHAR(25),
   	SOLUONG INT,
   	GIABAN FLOAT,
   	MALOAISACH INT )
AS BEGIN
          	INSERT INTO @bang
          	SELECT ks.masach,tensach,tacgia,ks.soluong,giaban,maloaisach
    	FROM KhoSach ks
          	LEFT JOIN ChiTietPhieuNhap ct
          	ON ks.masach = ct.masach
          	WHERE maphieunhap = @maphieunhap
          	RETURN
END
SELECT * FROM FC_02(2)

--Câu 1: viết hàm trả về mã loại sách của tên sách Chí phèo(ĐÚNG)
create function func_1 ( @tens nvarchar(50)) returns int
as begin
return (select maloaisach from KhoSach  where tensach = @tens  )
end;
select dbo.func_1 (N'Chí phèo')

--câu 2: tính tổng số sách đã được nhập (ĐÚNG)
create function func_2()
returns int
as begin
 	declare @tong int
 	select @tong =(select COUNT(masach) from ChiTietPhieuNhap)
 	return @tong
end;
 
select dbo.func_2()

--câu 3. Hàm trả về bảng tính số lượng sách theo từng loại sách (ĐÚNG)
CREATE FUNCTION fun_kq()
RETURNS @kq TABLE ( maloaisach nvarchar(50), soluong int)
AS BEGIN
INSERT INTO @kq SELECT maloaisach, COUNT(maloaisach) FROM KhoSach
GROUP BY maloaisach
RETURN END
 
SELECT  maloaisach, soluong FROM dbo.fun_kq()



--============================================KHUNG NHÌN-VIEW---------------
----tạo view THONG TIN BAN HANG chứa manv, tennv, masach, tensach, mahd, tenkh, soluong---
create view thongtinbanhang 
as 
select hd.mahoadon, tenkhachhang, ks.masach, tensach, cthd.soluong, nv.manhanvien, tennhanvien
from NhanVien nv, KhoSach ks, HoaDon hd, ChiTietHoaDon cthd
	where nv.manhanvien=hd.manhanvien and hd.mahoadon=cthd.mahoadon and cthd.masach = ks.masach;
select *from thongtinbanhang

--07 Tạo view hiển thị thông tin cuốn sách chưa được mua lần nào.
CREATE VIEW view_01 AS
SELECT *
FROM KhoSach
WHERE masach not in (select masach from ChiTietHoaDon)
--Thực thi
SELECT * FROM view_01
 --08 Tạo view hiển thị thông tin của nhân viên và số hóa đơn tạo được trong năm 2022
CREATE VIEW view_02 AS
SELECT NV.manhanvien, NV.tennhanvien, COUNT(mahoadon) AS TongSoHoaDon
FROM NHANVIEN NV
LEFT JOIN HoaDon hd
ON NV.manhanvien= hd.manhanvien
WHERE YEAR(ngaylaphoadon) = 2022
GROUP BY NV.MANHANVIEN, NV.tennhanvien
--Thực thi
SELECT * FROM view_02

--Câu 1 tạo 1 view chứa thông tin tên tác giả, mã sách, mã loại sách 
create view v1
as
select masach , tensach, tacgia from KhoSach, LoaiSach
where tensach = N'Đọc vị bất kỳ ai';
select * from v1;


--============================================TRIGGER============================================---
--
----cập nhật số lượng sách trong kho sau khi quyển sách đó đc bán
create trigger trig_HoaDon on chitiethoadon
after insert 
as 
	begin
		update khosach
		set khosach.soluong = khosach.soluong - 
		(select inserted.soluong from inserted where masach = khosach.masach)
		from khosach join inserted on KhoSach.masach=inserted.masach
	end

insert into ChiTietHoaDon(mahoadon, masach, soluong)
values
(3,7,1)
select * from khosach
select * from chitiethoadon
----cập nhật số lượng sách trong khi sau khi khách hàng mua thêm quyển sách đó trong 1 hóa đơn 
CREATE TRIGGER trig_CapNhatHoaDon on chitiethoadon 
after update AS
BEGIN
   UPDATE KhoSach 
   SET khosach.soluong = khosach.soluong -
	   (SELECT inserted.soluong FROM inserted WHERE masach = KhoSach.masach) +
	   (SELECT deleted.soluong FROM deleted WHERE masach = KhoSach.masach)
   FROM KhoSach JOIN deleted ON KhoSach.masach=deleted.masach
end
----cập nhật sách trong kho sau khi khách hủy đơn k mua nữa
create trigger trig_HuyDon on chitiethoadon
for delete as
begin
	update KhoSach
	set khosach.soluong = KhoSach.soluong+
		(select deleted.soluong from deleted where masach = KhoSach.masach)
		from KhoSach
		join deleted on KhoSach.masach = deleted.masach
end

delete ChiTietHoaDon where mahoadon = 3 and masach=7
select * from KhoSach
select * from ChiTietHoaDon

CREATE TRIGGER trigger_01
ON PhieuNhap
FOR INSERT, UPDATE
AS BEGIN
   	DECLARE @ngaypn DATE
   	SET @ngaypn = (select ngaylapphieu from inserted)
   	IF (@ngaypn > GETDATE())
          	BEGIN ROLLBACK TRAN
                 	print N'Ngày lập phiếu không được lớn hơn ngày hiện tại'
                 	END
END

--
UPDATE PhieuNhap
set ngaylapphieu = '01/01/2022'
where maphieunhap = 1
 
--04 Tạo trigger để tránh xoá 2 bản ghi trong bảng Nhanvien đồng thời./////
DROP TRIGGER trigger_02
 CREATE TRIGGER trigger_02
    ON NhanVien
    FOR Delete
    AS
    IF((Select count(*) From deleted)>=2)
    BEGIN
    PRINT 'Ban khong duoc xoa cung luc 2 ban ghi'
    ROLLBACK TRAN
    END
--bước 1: thuc hien xoa rang buoc FK__HoaDon__manhanvi__2C3393D0
alter table HoaDon
drop constraint FK__HoaDon__manhanvi__2C3393D0
--bước 2: thuc thi
DELETE FROM NhanVien
WHERE tennhanvien  like N'Lê%'
select *from DBo.NhanVien

--câu 1: viết 1 trigger để khi thêm 1 tên sách mới vào kho sách thì trigger sẽ in ra thông báo thêm thành công
create trigger trig_them on khosach for insert
as
print N'Bạn đã thêm thành công';
insert into khosach (tensach) values (N'Hệ quản trị cơ sở dữ liệu');

--Câu 2 viết 1 trigger để k cho phép cập nhật cột giá nhập của Chi tiết hóa đơn 
create trigger trig_capnhat on chitietphieunhap for update as
if update (gianhap) begin rollback tran
 	print N'Không được phép cập nhật'
 	end
else
 	print N'OK'
--=================Giao dịch==============-------
---Mức độ cô lập áp dụng: read committed
----t1: cập nhật vào kho sách số lượng sách của 1 quyển sách sau đó set
------cài đặt thời gian chạy giao dịch là 10s
begin tran
update KhoSach
set soluong=32 where masach=1
waitfor delay '00:00:10'
rollback tran
----t2: đọc bản ghi
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ COMMITTED
SELECT * FROM KhoSach
COMMIT TRAN
-------------------------------------------
-- Cửa hàng vừa nhập thêm 10 quyển cho lô sách mới. Hãy viết một Transaction thực hiện việc cập nhật thông tin
--T1
Begin Tran
If exists (select * from KhoSach where masach = 2)
   	update KhoSach Set soluong = soluong+ 10
   	where masach = 2
   	waitfor delay'00:00:05'
   	commit tran
--T2
begin tran
set tran isolation level read committed
select * from khosach
commit tran
-- Quyển sách với mã 2 vừa được bán ra với số lượng là 2. Hãy viết một Transaction thực hiện việc cập nhật thông tin liên quan
declare @mas int = 2,
          	@sl int = 2,
          	@mahoadon int = 5
Begin Tran
-- Chèn vào 1 dòng vào bảng ChiTietHoaDon
Insert into ChiTietHoaDon(mahoadon, masach, soluong)
values (@mahoadon,@mas, @sl)
-- Update số lượng sách trong Khosach
update KhoSach
set soluong = soluong - @sl
where masach = @mas
waitfor delay'00:00:05'
Commit tran
--T2
begin tran
set tran isolation level read committed
select * from khosach
commit tran
