from django.db import models

# Create your models here.

class postForm(models.Model):
    title = models.CharField(max_length=250)
    body = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return f'{self.title} , {self.body} , {self.created_at}'
