# để dẫn dắt user đến cái views app
from django.urls import path #thêm thư viện django.urls import path , tạo các đường dẫn path
from . import views # gọi file view cùng cấp file này

app_name = 'contact' #tên app
urlpatterns = [ # lưu các đường dẫn patterns
    #Nếu ko có gì thì nó vào name trang chủ 
    # dajng class baseview
    path('',views.contact.as_view(), name='contact'),# khi vào đây nó vào đường dẫn trắng trước, tại đường dẫn trắng hiểu rằng nó sẽ gọi file views.index
    # path('getContact/',views.get_contact, name = 'getContact'),
    # path('saveContact/',views.saveContact, name = 'saveContact'),
]
