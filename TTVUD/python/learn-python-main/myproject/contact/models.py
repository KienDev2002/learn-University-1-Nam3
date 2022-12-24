#modal: laf thanhf phaanf để tương tác với csdl, tạo bảng sửa cấu trúc và thuộc tính của bảng, thêm-sửa-xóa-lấy dữ liệu trong bảng,...
#template: là thông tin, dữ liệu hiển thị cho người dùng: giao  diện trang web
#view: thành phần điều khiển logic của chương trình là câu nối giữa model và template
#model là lớp trung gian để tương tác với csdl bên dưới
#csdl thường có bảng, cột ,...
from django.db import models

#đây là những trường thông tin người ta để lại
# Create your models here.
class contactForm(models.Model):
    username = models.CharField(max_length=25, null = False)
    email = models.EmailField(null=False)
    body = models.TextField(null=False)
    # password = models.CharField(max_length=10)
    # để hiển thị tên trong contact form có tên là username
    def __str__(self):
        return f'{self.username},{self.email}'
    