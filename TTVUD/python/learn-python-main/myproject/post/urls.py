# để dẫn dắt user đến cái views app
from django.urls import path #thêm thư viện django.urls import path , tạo các đường dẫn path
from . import views # gọi file view cùng cấp file này

app_name = 'post' #tên app
urlpatterns = [ # lưu các đường dẫn patterns
    #Nếu ko có gì thì nó vào name trang chủ 
    path('',views.post, name='post'),# khi vào đây nó vào đường dẫn trắng trước, tại đường dẫn trắng hiểu rằng nó sẽ gọi file views.index
    path('<int:id>/',views.postDetail, name='postDetail'),
]
